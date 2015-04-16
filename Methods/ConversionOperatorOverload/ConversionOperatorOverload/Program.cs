using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionOperatorOverload
{
    /// <summary>
    /// this class has overloaded the conversion methods for a rational number to various 
    /// other primative types the implementation is left out but this should be enough for
    /// you to figure out how this works. also in this case the implicit cast might 
    /// loose some presicion or magnitude, these should through an Overflow exception or
    /// invalidOperation exception
    /// </summary>
    class Rational
    {
        // construct rational from an Int32
        public Rational(Int32 num)
        {
            // implmentation goes here
        }

        // constructs a ration from a string
        public Rational(String numString)
        {
            // implementation goes here
        }

        // converts a rational to an Int32
        public Int32 ToInt32()
        {
            return new Int32();
        }

        // converts a rational to an String
        public override String ToString()
        {
            return "";
        }

        // implicitly constructs and returns a rational from an Int32
        public static implicit operator Rational(Int32 num)
        {
            return new Rational(num);
        }

        // implicitly constructs and returns a rational from an String
        public static implicit operator Rational(String num)
        {
            return new Rational(num);
        }

        // NOTE:
        // notice anything differnt from the next two methods
        // they differ only by thier return type... (Didn't think
        // you could do that.)

        // explicitly returns and Int32 from a rational
        public static explicit operator Int32(Rational r)
        {
            return r.ToInt32();
        }

        // explicitly returns and String from a rational
        public static explicit operator String(Rational r)
        {
            return r.ToString();
        }
    }

    /// <summary>
    /// the code above alows you write the following code. nothing
    /// intersting will happend but it compiles
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = 5; // implicit cast from int32 to rational
            Rational r2 = "2.343"; // implicit cast from a string to rational

            Int32 x = (Int32)r1; // explicit cast from rational to Int32
            String s = (String)r2; // explicit cast from rational to string

            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
    }
}
