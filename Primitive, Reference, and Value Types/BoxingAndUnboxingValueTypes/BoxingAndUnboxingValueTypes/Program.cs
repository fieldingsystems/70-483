using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingAndUnboxingValueTypes
{
    // delcare a value type, 2D point
    struct Point
    {
        public Int32 x, y;
    }


    class Program
    {
        static void Main(string[] args)
        {
            CanYouGuess();

            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// can you guess what is what is what will happen if you try
        /// to get reference to a an instance of a value type like shown below
        /// </summary>
        private static void CanYouGuess()
        {
            ArrayList a = new ArrayList();
            Point p; // allocate a point, not in heap

            // with each iteration point is being initialized and then stored in the ArrayList
            // but when you look up ArrayList's Add method you see what its parameter is defiect as
            // and object like shown below:
            //
            // public virtual Int32 Add(Object value);
            //
            // means that for this to work the point value type must be converted to a true heap-managed
            // object, and a reference to this object must then be obtained. It is possible to convert
            // a value tyep to a reference type using a mechanism called boxing. (generics should be used
            // for this but for now its important to know the difference)
            for(Int32 i = 0; i < 10; i++)
            {
                p.x = i;
                p.y = i + 2;

                a.Add(p);
            }
        }
    }
}
