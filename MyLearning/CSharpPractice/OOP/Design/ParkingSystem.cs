using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpPractice.OOP.Design
{
    internal class ParkingSystem
    {
        private readonly Dictionary<string, VehicleType> _vehicleTypes = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, ParkingSpot> _spots = new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<Guid, ParkingTicket> _activeTickets = new();

        public void RegisterVehicleType(string vehicleType, (decimal length, decimal breadth) size)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(vehicleType);
            ValidateDimensions(size.length, size.breadth);

            _vehicleTypes[vehicleType] = new VehicleType(vehicleType, size.length, size.breadth);
        }

        public void RegisterParkingSpot(string spotId, (decimal length, decimal breadth) size)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(spotId);
            ValidateDimensions(size.length, size.breadth);

            _spots[spotId] = new ParkingSpot(spotId, size.length, size.breadth);
        }

        public ParkingTicket ParkNewVehicle(string vehicleType, string registrationNumber)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(vehicleType);
            ArgumentException.ThrowIfNullOrWhiteSpace(registrationNumber);

            if (!_vehicleTypes.TryGetValue(vehicleType, out var registeredVehicleType))
            {
                throw new InvalidOperationException($"Vehicle type '{vehicleType}' is not registered.");
            }

            var availableSpot = _spots.Values
                .Where(spot => !spot.IsOccupied && spot.CanFit(registeredVehicleType))
                .OrderBy(spot => spot.Area)
                .FirstOrDefault();

            if (availableSpot is null)
            {
                throw new InvalidOperationException($"No parking spot is available for vehicle type '{vehicleType}'.");
            }

            availableSpot.Park();

            var ticket = new ParkingTicket(
                Guid.NewGuid(),
                registrationNumber,
                registeredVehicleType.Name,
                availableSpot.SpotId,
                DateTime.UtcNow);

            _activeTickets[ticket.TicketId] = ticket;
            return ticket;
        }

        public ParkingReceipt UnparkVehicle(Guid ticketId, decimal hourlyRate)
        {
            if (!_activeTickets.TryGetValue(ticketId, out var ticket))
            {
                throw new InvalidOperationException($"Ticket '{ticketId}' was not found.");
            }

            if (!_spots.TryGetValue(ticket.SpotId, out var spot))
            {
                throw new InvalidOperationException($"Parking spot '{ticket.SpotId}' was not found.");
            }

            if (hourlyRate < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(hourlyRate), "Hourly rate cannot be negative.");
            }

            spot.Unpark();
            _activeTickets.Remove(ticketId);

            var exitTime = DateTime.UtcNow;
            var parkedHours = Math.Max(1m, (decimal)Math.Ceiling((exitTime - ticket.EntryTime).TotalHours));
            var amount = parkedHours * hourlyRate;

            return new ParkingReceipt(ticket.TicketId, ticket.RegistrationNumber, ticket.SpotId, ticket.EntryTime, exitTime, amount);
        }

        public IEnumerable<string> GetAvailableSpotIds()
        {
            return _spots.Values
                .Where(spot => !spot.IsOccupied)
                .OrderBy(spot => spot.SpotId)
                .Select(spot => spot.SpotId);
        }

        public int GetActiveVehicleCount()
        {
            return _activeTickets.Count;
        }

        private static void ValidateDimensions(decimal length, decimal breadth)
        {
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be positive.");
            }

            if (breadth <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(breadth), "Breadth must be positive.");
            }
        }

        internal sealed record VehicleType(string Name, decimal Length, decimal Breadth);

        internal sealed class ParkingSpot
        {
            public ParkingSpot(string spotId, decimal length, decimal breadth)
            {
                SpotId = spotId;
                Length = length;
                Breadth = breadth;
            }

            public string SpotId { get; }
            public decimal Length { get; }
            public decimal Breadth { get; }
            public decimal Area => Length * Breadth;
            public bool IsOccupied { get; private set; }

            public bool CanFit(VehicleType vehicleType)
            {
                return Length >= vehicleType.Length && Breadth >= vehicleType.Breadth;
            }

            public void Park()
            {
                if (IsOccupied)
                {
                    throw new InvalidOperationException($"Parking spot '{SpotId}' is already occupied.");
                }

                IsOccupied = true;
            }

            public void Unpark()
            {
                if (!IsOccupied)
                {
                    throw new InvalidOperationException($"Parking spot '{SpotId}' is already vacant.");
                }

                IsOccupied = false;
            }
        }

        internal sealed record ParkingTicket(
            Guid TicketId,
            string RegistrationNumber,
            string VehicleType,
            string SpotId,
            DateTime EntryTime);

        internal sealed record ParkingReceipt(
            Guid TicketId,
            string RegistrationNumber,
            string SpotId,
            DateTime EntryTime,
            DateTime ExitTime,
            decimal Amount);
    }
}
