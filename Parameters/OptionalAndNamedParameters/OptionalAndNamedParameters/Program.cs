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
        
        private static void M(Int32 x = 9, String s = "A", DateTime dt = default(DateTime), Guid guid = new Guid())
        {
            Console.WriteLine("x = {0}\ns = {1}\ndt = {2}\nguid = {3}\n", x, s, dt, guid);
        }

        static void Main(string[] args)
        {

            M();
        }
    }
}
