using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangingBoxedValueTypeFields
{
    // interface for boxed value type
    internal interface IChangeBoxedPoint
    {
        void Change(Int32 x, Int32 y);
    }

    // create a value type of point
    internal struct Point : IChangeBoxedPoint
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

    // main class to execute all the code
    public sealed class Program
    {
        static void Main(string[] args)
        {
            // a failed attempt at changing the fields in a boxed value type
            BoxDemo1();

            // now boxed demo involving an interface to change the fields
            BoxDemo2();

            Console.WriteLine("\n\npress any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// this is just to show you how all this works in practice but in reality you should use value types
        /// as immutable, its is even recomended to mark them as read only. when you try to alter the fields in
        /// value types you can get unexpected behavior that is best to avoid all together.
        /// </summary>
        public static void BoxDemo2()
        {
            // create a new instance of p
            Point p = new Point(1, 1);

            // this is working as expected
            Console.WriteLine(p);

            // this works as expected
            p.Change(2, 2);
            Console.WriteLine(p);

            // this works as expected
            Object o = p;
            Console.WriteLine(p);

            // we know what happens here
            ((Point)o).Change(3, 3);
            Console.WriteLine(o);

            // boxes p, changes the boxed object and discards it. 2,2 will be displayed
            // the 4,4 is garbage collected before it gets displayed.
            ((IChangeBoxedPoint) p).Change(4, 4);
            Console.WriteLine(p);

            // no boxing is necessaryi because o is already a boxed point. then change is called, which does change
            // the poxed Point's m_x and m_y fields. The interface method change has allowed me to change the fields
            // in a boxed point object. This is not possible without an interface in c#
            ((IChangeBoxedPoint)o).Change(5, 5);
            Console.WriteLine(o);
        }

        private static void BoxDemo1()
        {
            // create a new instance of p
            Point p = new Point(1, 1);

            // this is working as expected
            Console.WriteLine(p);

            // this works as expected
            p.Change(2, 2);
            Console.WriteLine(p);

            // this works as expected
            Object o = p;
            Console.WriteLine(p);

            // UNEXPECTED: o doesn't know anything about the changes method so o must be casted to a point.
            // casting o to a point unboxes o and copies the fields in the boxed point to a temporary point on the thread's stack.
            // the m_x and m_y fields of this temporary point are changed to 3,3 but the point isn't affected by this call to change.
            // when you call the last write line 2,2 is displayed. in some languages you can change the fields in a boxed value type (c++,
            // for example) but C# does not. You can trick C# into letting you do this with an interface though.
            ((Point)o).Change(3, 3);
            Console.WriteLine(o + "\n");
        }
    }
}
