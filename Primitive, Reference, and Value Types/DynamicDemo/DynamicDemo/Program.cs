using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            // second demo showing how dynamic sytax can make life easier
            DynamicDemo2();

            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// the point of this is jsut to show how the two segments of code do the same thing but
        /// one is much easier to read and write than the other. The first uses reflection the
        /// second uses dynamic types
        /// </summary>
        private static void DynamicDemo2()
        {
            // firtst the long way without dynamic object
            Object target = "Alex Compton";
            Object arg = "Comp";

            // find a method on the target that matches the desired argument types
            Type[] argTypes = new Type[] { arg.GetType() };
            MethodInfo method = target.GetType().GetMethod("Contains", argTypes);

            // invoke the method on the target passing the desired arguments
            Object[] arguments = new Object[] { arg };
            Boolean result = Convert.ToBoolean(method.Invoke(target, arguments));
            Console.WriteLine("\n1st example: " + result);

            // I know the code above really was ugly the code below does the same thing with improved syntax
            dynamic dynamicTarget = "Alex Compton";
            dynamic dynamicArg = "Comp";
            Boolean result2 = dynamicTarget.Contains(dynamicArg);
            Console.WriteLine("2nd example: " + result2);
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
