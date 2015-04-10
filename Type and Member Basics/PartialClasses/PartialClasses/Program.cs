using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClasses
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            // call the partial class
            OutPut();

            Console.ReadKey();
        }
    }

    public partial class Program
    {
        public static void OutPut()
        {
            Console.WriteLine("I'm a partial Class");
        }
    }
}
