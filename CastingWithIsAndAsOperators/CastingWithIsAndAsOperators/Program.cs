using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastingWithIsAndAsOperators
{
    class Employee
    {
        // ...some implementation
    }

    class Program
    {
        static void Main(string[] args)
        {
            Object o = new Object();
            Object o2 = new Object();

            // this is a demo on how to use the is operator
            // pass in an object
            IsOperatorDemo(o);

            // this is an example on how to use the is operator
            IsOperatorDemo2(o);

            // demo with the as operator
            AsOperatorDemo(o);

            // wait to end
            Console.WriteLine("\n\npress any key to continue...");
            Console.ReadKey();
        }

        // this is used to check if o is compatible with the Employee type and if it is, returens a non-null
        // reference to the same object, if itn't compatible as retunrs a null. This check is usally faster
        // than returning an objects type. If the as operator can't complete a cast it will never throw an
        // exception just make null reference. Thats why you must always check after using as for a null reference.
        private static void AsOperatorDemo(object o)
        {
            Employee e = o as Employee;
            if (e != null)
            {
                Console.WriteLine("\ne is an Employee");
            }
            else
            {
                Console.WriteLine("\ne is null");
            }
        }

        // if the object is null the is operator alway returns false because there is no object to check
        // its type, below is how you use this example with a null object. 
        private static void IsOperatorDemo2(Object o)
        {
            o = null;

            if (o is Employee)
            {
                Console.WriteLine("This will not get called");
            } 
            else
            {
                Console.WriteLine("\nObject o is null");
            }
        }

        // Another way to cast is to use the is operator, this checks
        // if the object is compatible with a given type. The result is a a boolean
        // (true or false). the is operator will never throw and exception, just
        // true or false this is demonstrated below
        private static void IsOperatorDemo(object o)
        {
            Boolean b1 = (o is Object); // b1 is true
            Boolean b2 = (o is Employee); // b2 is false

            Console.WriteLine("Boolean b1 = (o is Object);\nBoolean b2 = (o is Employee);"
                +"\nBoolean b1 = " + b1 + "\nBoolean b2 = " + b2);

        }
    }
}
