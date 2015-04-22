using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalAndNamedParameters
{
    class Program
    {
        private static Int32 s_n = 0;
        
        /// <summary>
        /// If this method is missing a parameter when it is called the method will fill in the parameter
        /// with the default values supplied below, this also works for constructors. 
        /// 
        /// If parameters don't have default values they must come before variables with default values.
        ///
        /// </summary>
        /// <param name="x"></param>
        /// <param name="s"></param>
        /// <param name="dt"></param>
        /// <param name="guid"></param>
        private static void M(Int32 x = 9, String s = "A", DateTime dt = default(DateTime), Guid guid = new Guid())
        {
            Console.WriteLine("x = {0}\ns = {1}\ndt = {2}\nguid = {3}\n", x, s, dt, guid);
        }

        /// <summary>
        /// below is how to pass an argument by parameter name that requires ref/out, use syntax like below
        /// </summary>
        /// <param name="x"></param>
        private static void M(ref Int32 x)
        {
            // implementation goes here
        }

        static void Main(string[] args)
        {
            // same as M(9,"A",default(DateTime),new Guid());
            M();

            // same as M(8, "X", default(DateTime), new Guid());
            M(8, "X");

            // same as M(3, "A", DateTime.Now, Guid.NewGuid()); 
            M(dt: DateTime.Now, x: 3, guid: Guid.NewGuid());

            // same as M(0, "1", DateTime.Now, Guid.NewGuid());
            // this is executed from right to left the string is 
            // incremented then x is one more than that. even though
            // the x perameter is first
            M(s: s_n++.ToString(), x: s_n); 

            // method invocation with ref
            Int32 a = 5;
            M(x: ref a);

            Console.WriteLine("\n\npress any key to continue...");
            Console.ReadKey();
        }
    }
}
