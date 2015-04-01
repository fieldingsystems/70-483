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
            // boxing demo of a point to an arraylist
            ArrayList a = new ArrayList();
            BoxingDemo1(a);

            // first demo of unboxing
            UnboxingDemo1(a);

            // this demo goes over some the exceptions that might need to be handled with boxing and unboxing
            UnboxingDemo2();

            // unboxing then field copy
            UnboxingDemo3();

            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// unboxing operations are usally follwed immediately by a field copy. this demo shows how 
        /// the unbox and copy operation work together.
        /// 
        /// to do the code just to change point x's field from 1 to 2, an unbox operation must be preformed.
        /// this is follwed by a field copy, followed by changing the field on the stack, followed by a boxing operation
        /// (which creates a whole new boxed instance in the managed heap). the impact that boxing and unboxing have in
        /// C# can be detrimintal to preformance.
        /// 
        /// another note is unboxed value types don't have a sync block index, this means you can't have
        /// multiple threads synchronize thier access tot he instance or with lock statements
        /// </summary>
        private static void UnboxingDemo3()
        {
            Point p;
            p.x = p.y = 1;
            Object o = p; // boxes p, o refers to the boxed instance.

            // now we unbox o and copy the fields from the boxed instance to stack variable
            p = (Point)o;

            // now we change point's x field to to 2
            p.x = 2; // this changes the state of the stack variable;
            o = p; // boxes p, o referes to a new boxed instance
        }

        /// <summary>
        /// there are two main points to remember when a boxed value type gets unboxed.
        /// 
        /// 1) if the variable containing the reverence to the boxed value type instance is null, a
        /// Null-ReferenceException is thrown
        /// 
        /// 2) if teh reverence doesn't refere to an object that is a boxed instance of the desired value
        /// type, an InvalidCastException is thrown. (the CLR also allows you to unbox a value type into a
        /// a nullable version of the same value type. well cover that in another example)
        /// 
        /// </summary>
        private static void UnboxingDemo2()
        {
            // this code doesn't work correctly run it once then comment out to
            // run the correct version
            Int32 x = 5;
            Object o = x; // box x, o refers to the boxed object
            Int16 y = (Int16)o; // throws and InvalidCastException

            // this is the correct way to do this you must unbox to the EXACT same type was boxed
            Int32 x1 = 5;
            Object o1 = x1; // box x, o refers to the boxed object
            Int16 y1 = (Int16)(Int32)o1; // this is the correct way to unbox this
        }

        /// <summary>
        /// now that you see how boxing works lets take a look at unboxing... lets say you want to grab the first element out
        /// of an ArrayList by using the following code. Here you are takinf the reference (or pointer) contained in
        /// element 0 of the ArrayList and trying to put it into a point value type instance, p. for this to work all
        /// the fields contained in the boxed Point ovject must be copied into the value type variable, p, which is 
        /// on the thread's stack. this is done in two steps. First the address of the Point fields in the boxed Point object is obtained,
        /// this is the unboxing. Then, the values of these fields are copied from the heap to the stack-based value type instance.
        /// 
        /// this means that unboxing isn't the exact opposite of boxing. the unboxing operationt is mush less costly that boxing. It just
        /// involves geting a pointer to the raw data and doesnt actually copy any bytes in memory.
        /// </summary>
        /// <param name="a"></param>
        private static void UnboxingDemo1(ArrayList a)
        {
            Point p = (Point)a[0];
            Console.WriteLine("unboxing complete");
        }

        /// <summary>
        /// can you guess what is what is what will happen if you try
        /// to get reference to a an instance of a value type like shown below
        /// </summary>
        private static void BoxingDemo1(ArrayList a)
        {
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
            Console.WriteLine("boxing complete");
        }
    }
}
