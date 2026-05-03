using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    internal sealed class Singleton
    {
        /*
         * Updates to _instance will eventually "leak through", but you can't rely on "eventually" in multithreaded code where
         * timing and order matter. That’s why volatile exists: to make visibility immediate and predictable across threads.
         */
        private static volatile Singleton _instance;

        private static readonly object _instanceLock = new object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                            _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }
    }

    public sealed class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> _instance = new(() => new SingletonLazy());

        private SingletonLazy() { }

        public static SingletonLazy Instance => _instance.Value;
    }

    public sealed class SingletonAnother
    {
        private static readonly SingletonAnother _instance = new SingletonAnother();

        private SingletonAnother() { }

        public static SingletonAnother Instance => _instance;
    }
}
