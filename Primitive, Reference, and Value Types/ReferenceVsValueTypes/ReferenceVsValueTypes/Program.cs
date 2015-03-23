using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceVsValueTypes
{
    /// <summary>
    /// this is a reference type it is always allocated from the managed heap,
    /// the C# new operator returns the memory address of the object. the memory address
    /// refers to the opbjects bits.
    /// </summary>
    class SomeRef 
    {
        public Int32 x;
    }

    /// <summary>
    /// this is a value type because it is a struct. these are more lightweight
    /// they can not be derived or used as a based class. The veriable representing
    /// the instance of the value type doesn't contain a pointer to an instance like
    /// a reference type just the fields of this instance its self. This is important
    /// you will see why this distinction is important below.
    /// </summary>
    struct SomeVal
    {
        public Int32 x;
    }

    class Program
    {
        static void Main(string[] args)
        {
            ValueReferenceDemo();

            Console.WriteLine("\nPress Any key to continue...");
            Console.ReadKey();
        }

        /// <summary>
        /// this shows the difference between how value types and reference types are allocated in memory.
        /// also, you will get to see the difference between how copies are handled of each. References
        /// are allocated in the heap while structs are allocated on the stack
        /// </summary>
        private static void ValueReferenceDemo()
        {
            SomeRef r1 = new SomeRef(); // allocated in heap
            SomeVal v1 = new SomeVal(); // allocated on stack

            r1.x = 5; // pointer dereference
            v1.x = 5; // changed on stack

            Console.WriteLine("Reference: r1.x = " + r1.x);
            Console.WriteLine("Value: v1.x = " + v1.x);

            // This is where things change pay attention to the differences in the
            // way these are handled
            SomeRef r2 = r1; // copies referent (pointer) only
            SomeVal v2 = v1; // allocate on stack and copies members

            r1.x = 8; // this changes r1.x and r2.x
            v1.x = 9; // this changes just v1.x

            Console.WriteLine("\nReference: r1.x = " + r1.x);
            Console.WriteLine("Reference: r2.x = " + r2.x);
            Console.WriteLine("Value: v1.x = " + v1.x);
            Console.WriteLine("Value: v2.x = " + v2.x);
        }
    }
}
