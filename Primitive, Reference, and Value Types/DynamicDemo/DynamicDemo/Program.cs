using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDemo
{
    class Program
    {
        /// <summary>
        /// dynamic objects can be very useful to get around the type-safety of C# when 
        /// you might get an object at run time and you don't know what it may be or 
        /// if its coming from another non-type-safe languages such as JavaScript or Ruby
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // first demo using dynamic objects
            DynamicDemo();

            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// the example below shows how when the for loop is executed that depending on the value
        /// type (which is not know until runtime the correct implementation will still be used.
        /// </summary>
        /// <param name="value">you dont know what this is at compile time only run time</param>
        private static void Print(Int32 value) { Console.WriteLine("Int32: " + value); }
        private static void Print(String value) { Console.WriteLine("String: " + value); }
        private static void DynamicDemo()
        {
            // note about dynamic vs. var, var can only be used for declaring a local variable
            // dynamic keyword can be used for local variables, fields, and arguments. You can't
            // cast and expression to var but you can cast an expression to dynamic. you must explicityly
            // initialize a variable declared useing var, you do not have to initialize a variable 
            // declared with dynamic.
            dynamic value;

            for(Int32 demo = 0; demo < 2; demo++)
            {
                value = (demo == 0) ? (dynamic) 5 : (dynamic) "A";
                value = value+value; // its important to realize this does both add and concat depending on type
                Print(value);
            }
        } 
    }
}
