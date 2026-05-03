using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    using System;
    using System.Collections.Generic;

    namespace DesignPatterns.Builder
    {
        // =========================
        // 1. Product
        // =========================
        public class User
        {
            public string Name { get; }
            public string Email { get; }
            public string? Address { get; }
            public string? Phone { get; }

            public User(string name, string email, string? address, string? phone)
            {
                Name = name;
                Email = email;
                Address = address;
                Phone = phone;
            }

            public void Display()
            {
                Console.WriteLine("User Details:");
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Email: {Email}");
                Console.WriteLine($"Address: {Address}");
                Console.WriteLine($"Phone: {Phone}");
                Console.WriteLine("--------------------------");
            }
        }

        // =========================
        // 2. Builder
        // =========================
        public class UserBuilder
        {
            private string? _name;
            private string? _email;
            private string? _address;
            private string? _phone;

            public UserBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public UserBuilder WithEmail(string email)
            {
                _email = email;
                return this;
            }

            public UserBuilder WithAddress(string address)
            {
                _address = address;
                return this;
            }

            public UserBuilder WithPhone(string phone)
            {
                _phone = phone;
                return this;
            }

            public User Build()
            {
                // 🔥 Validation (important use of Builder)
                if (string.IsNullOrWhiteSpace(_name))
                    throw new InvalidOperationException("Name is required");

                if (string.IsNullOrWhiteSpace(_email))
                    throw new InvalidOperationException("Email is required");

                return new User(_name, _email, _address, _phone);
            }
        }

        // =========================
        // 3. Demo
        // =========================
        public static class UserBuilderTest
        {
            public static void Test()
            {
                var builder = new UserBuilder();

                // Step 1 (initial info)
                builder.WithName("Ram");

                // Step 2 (later info)
                builder.WithEmail("ram@email.com");

                // Step 3 (optional info comes even later)
                builder.WithAddress("Bangalore");

                // Build at the end
                var user = builder.Build();

                user.Display();

                // Another example (different order, partial fields)
                var user2 = new UserBuilder()
                    .WithEmail("test@email.com")
                    .WithName("Test User")
                    .Build();

                user2.Display();
            }
        }
    }

    // Example: 2
    // =========================
    // 1. Product
    // =========================
    public class HttpRequest
    {
        public string Url { get; }
        public string Method { get; }
        public Dictionary<string, string> Headers { get; }
        public string? Body { get; }

        public HttpRequest(string url, string method, Dictionary<string, string> headers, string? body)
        {
            Url = url;
            Method = method;
            Headers = headers;
            Body = body;
        }

        public void Print()
        {
            Console.WriteLine($"Method: {Method}");
            Console.WriteLine($"URL: {Url}");

            Console.WriteLine("Headers:");
            foreach (var h in Headers)
            {
                Console.WriteLine($"  {h.Key}: {h.Value}");
            }

            Console.WriteLine($"Body: {Body}");
            Console.WriteLine("--------------------------");
        }
    }

    // =========================
    // 2. Builder
    // =========================
    public class HttpRequestBuilder
    {
        private string? _url;
        private string _method = "GET"; // default
        private readonly Dictionary<string, string> _headers = new();
        private string? _body;

        public HttpRequestBuilder SetUrl(string url)
        {
            _url = url;
            return this;
        }

        public HttpRequestBuilder SetMethod(string method)
        {
            _method = method;
            return this;
        }

        public HttpRequestBuilder AddHeader(string key, string value)
        {
            _headers[key] = value;
            return this;
        }

        public HttpRequestBuilder SetBody(string body)
        {
            _body = body;
            return this;
        }

        public HttpRequest Build()
        {
            // Validation (important in Builder)
            if (string.IsNullOrWhiteSpace(_url))
                throw new InvalidOperationException("URL is required");

            return new HttpRequest(
                _url,
                _method,
                new Dictionary<string, string>(_headers), // defensive copy
                _body
            );
        }
    }

    // =========================
    // 3. Demo
    // =========================
    public static class HttpBuilderPatternTest
    {
        public static void Test()
        {
            var builder = new HttpRequestBuilder();

            // Step 1
            builder.SetUrl("https://api/orders");

            // Step 2 (later)
            builder.AddHeader("Authorization", "Bearer token123");

            // Step 3 (even later)
            builder.SetMethod("POST");

            // Step 4 (optional)
            builder.SetBody("{ \"orderId\": 123 }");

            // Final build
            var request = builder.Build();

            request.Print();

            // Fluent style (single chain)
            var request2 = new HttpRequestBuilder()
                .SetUrl("https://api/users")
                .SetMethod("GET")
                .AddHeader("Accept", "application/json")
                .Build();

            request2.Print();
        }
    }
}

