using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.DesignPatterns
{
    internal sealed class Singleton
    {
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
}
