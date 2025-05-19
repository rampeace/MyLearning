using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.Collections
{
    public class Patient
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class Priority : IComparable<Priority>
    {
        public int Level { get; set; }

        public int Age { get; set; }

        public int ArrivalOrder {  get; set; }

        public int CompareTo(Priority? other)
        {
            if (other == null) return 1;

            //     Less than zero – This instance is less than value.
            //     Zero – This instance is equal to value.
            //     Greater than zero – This instance is greater than value.

            int comparision = this.Level.CompareTo(other.Level);
            if (comparision != 0)
            {
                return comparision;
            }

            comparision = -this.Age.CompareTo(other.Age);
            if (comparision != 0)
            {
                return comparision;
            }

            return this.ArrivalOrder.CompareTo(other.ArrivalOrder);
        }
    }

    internal class PatientQueue
    {
        PriorityQueue<Patient, Priority> _queue = new PriorityQueue<Patient, Priority>();

        public void Enqueue(Patient patient, Priority priority)
        {
            _queue.Enqueue(patient, priority);
        }

        public void Dequeue()
        {
            if (_queue.Count == 0) throw new InvalidOperationException("The queue is empty.");
            _queue.Dequeue();
        }

        public int Count() => _queue.Count;
    }
}
