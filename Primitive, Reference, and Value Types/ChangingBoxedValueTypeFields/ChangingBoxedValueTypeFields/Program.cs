using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangingBoxedValueTypeFields
{
    // create a value type of point
    internal struct Point 
    {
        private Int32 m_x, m_y;

        public Point(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }

        public void Change(Int32 x, Int32 y)
        {
            m_x = x;
            m_y = y;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", m_x.ToString(), m_y.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(1, 1);

            Console.WriteLine(p);

            p.Change(2, 2);
            Console.WriteLine(p);

            Object o = p;
            Console.WriteLine(p);

            ((Point)o).Change(3, 3);
            Console.WriteLine(o);

            Console.WriteLine("press any key to continue...");
            Console.ReadKey();
        }
    }
}
