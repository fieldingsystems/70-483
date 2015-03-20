using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntExampleSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimativeDemo1();
            PrimativeDemo2();

            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }

        // this next example is a little ugly but its to show how the compiler has
        // intimite knowledge of the primitive types and applies its own special rules when compiling
        // the code. This example displayes the casting of primatives. if the cast is safe, meaning 
        // no chance of data loss then implicit cast are allowed. if it is unsafe then you must use
        // an explicit cast
        private static void PrimativeDemo2()
        {
            Int32 i = 5; // implicit cast from int32 to int32
            Int64 l = i; // implicit cast from int32 to int64
            Single s = i; // implicit cast from int32 to single
            Byte b = (Byte)i; // explicit cast from int32 to byte
            Int16 v = (Byte)s; // explicit cast from single to int16

            Console.WriteLine("Primative Demo 2");
            Console.WriteLine(i);
            Console.WriteLine(l);
            Console.WriteLine(s);
            Console.WriteLine(b);
            Console.WriteLine(v);
            Console.WriteLine();
        }

        // the following all create the same Intermediate Language which all create 
        // System.Int32. Any data type the compiler directly supports is called a primitive type.
        // primitive types map directly to the Framework Class Library (FCL). As an example
        // the following four lines of code all compile correctly and produce the same IL
        private static void PrimativeDemo1()
        {          
            int a = 0; // most convient syntax
            System.Int32 b = 0; // still kinda convient
            int c = new int(); // inconvient
            System.Int32 d = new System.Int32(); // not convient this would be a nightmare if you had to do this each time

            Console.WriteLine("Primative Demo 1");
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine();
        }
    }
}
