using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloads
{
    /// <summary>
    /// this is a silly example of operator overloading its not very useful but
    /// it displayes everything you need to know about how this is done
    /// </summary>
    public class Tilda 
    {
        public int t;

        public Tilda(int t)
        {
            this.t = t;
        }

        // this instance you declare that the tilda operator (~)
        // is the operator that you would like to overload
        // in this case we just make it add 10 what ever the current value is.
        public static Tilda operator~(Tilda tilda)
        {
            return new Tilda(tilda.t + 10);
        }

        // you need to override the tostring method to go from an 
        // oobject to just the int you actually wanted.
        public override string ToString()
        {
            return t.ToString();
        }
    }

    /// <summary>
    /// no one would ever want to actually overload the tilda operator make it add 10 instead
    /// but you should get the idea and im sure once you get these basics down you can make 
    /// much more useful versions of this code
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            Tilda tilda = new Tilda(5);
            Tilda tilda2 = ~tilda;
            Console.WriteLine(" tilda = " + tilda);
            Console.WriteLine(" ~tilda = tilda2 = " + tilda2);
            Console.WriteLine(" tilda = " + tilda);

            Console.WriteLine("\n\npress any key to continue...");
            Console.ReadKey();
        }
    }
}
