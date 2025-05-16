using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractice.SOLID
{
    internal class DependencyInversionPrinciple
    {
        /*
         * The Dependency Inversion Principle (DIP) states that high-level modules should not depend 
         * on low-level modules. Instead, both should depend on abstractions. 
         * 
         * */

        // Problem
        public class SqlServerDatabase
        {
            public void SaveData() => Console.WriteLine("Save data");
        }

        // Problem: High level module (MyApplication) is dependent on Low level module (SqlServerDatabase)
        public class MyApplication
        {
            SqlServerDatabase db = new SqlServerDatabase();

            public void SaveData() => db.SaveData();
        }

        // Fix
        public interface IDatabase
        { 
            void SaveData();    
        }

        public class SQLServerDatabase2 : IDatabase
        {
            public void SaveData()
            {
                Console.WriteLine("Saved to sql server database");
            }
        }

        // Fix: High level module (MyApplication) is not dependent on Low level module (SqlServerDatabase)
        // but it's dependent on Abstraction(IDatabase)
        public class MyApplication2(IDatabase db)
        {
            IDatabase _db = db;

            public void SaveData()
            {
                _db.SaveData();
            }
        }
    }
}
