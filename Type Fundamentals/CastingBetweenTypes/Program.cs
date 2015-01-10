using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastingBetweenTypes
{
    // new type implicityly derived from System.Object
    internal class Employee 
    {
        // ... some implementation
    }

    class Program
    {
        static void Main(string[] args)
        {
            // first example of type casting
            FirstExample();
            Console.WriteLine("first example ran successfully, press any key to continue...");
            Console.ReadKey();


        }

        private static void FirstExample()
        {
            // cast not needed since new returns an employee object
            // and object is the base type of employee
            Object o = new Employee();

            // here a cast is required sinc employee is derived from object
            // other languages might not require this to compilet but C# does
            Employee e = (Employee)o;
        }
    }
}
