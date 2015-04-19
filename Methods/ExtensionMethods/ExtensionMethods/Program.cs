using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{

    /// <summary>
    /// this is and extension of the string builder class the stringbuilder doesn't have an
    /// IndexOf method so i wrote my own. it acts like part of the string builder class first the
    /// the complier will look to the stringbuilder class for the indexOf method and when it can't
    /// find it, it will use this method below. also this will show up when using intellisense and
    /// this will also affect all derived types. StringBuilder cant be inherited but this does
    /// open the door for some unexpected behavior so this feature should be used sparingly. Also
    /// if microsoft adds an indexOf feature to stringbuilder class then every instance will bind to
    /// the microsoft version and ignore the one i wrote so this can create a problem with versioning
    /// </summary>
    public static class StringBuilderExtension
    {
        public static Int32 IndexOf(this StringBuilder sb, Char value)
        {
            for (Int32 index = 0; index < sb.Length; index++)
                if (sb[index] == value) return index;

            return -1;
        }
    }

    /// <summary>
    /// another neat feature is you can call extention metnods for interface types
    /// the one below will print on a new line each item in a collection. intellisense
    /// will display this method in every collection that impelements IEnumerable
    /// </summary>
    public static class IEnumerableExtention
    {
        public static void ShowItems<T>(this IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Console.WriteLine(item);
        }
    }

    /// <summary>
    /// you can also device extension methods for delegate types
    /// </summary>
    public static class DelegateExtention
    {
        /// <summary>
        /// takes an action and takes the exception and swallows it and still compiles
        /// </summary>
        /// <typeparam name="TException"></typeparam>
        /// <param name="d"></param>
        /// <param name="o"></param>
        public static void InvokeAndCatch<TException>(this Action<Object> d, Object o)
            where TException : Exception
        {
            try { d(o); }
            catch (TException) 
            {
                Console.WriteLine("The code still compiles!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder("hello i'm a string builder.");
            Console.WriteLine(sb.IndexOf('i'));
            Console.WriteLine();

            // you can also use it like this
            Console.WriteLine(sb.Replace('a', 'c').IndexOf('t'));
            Console.WriteLine();

            // here is some examples with the interface extension method
            "Alex".ShowItems();
            Console.WriteLine();

            new[] { "one", "two", "three" }.ShowItems();
            Console.WriteLine();

            List<Int32> numberList = new List<Int32>() { 1, 2, 3 };
            numberList.ShowItems();
            Console.WriteLine();

            // this will throw a NullReferenceExcpetion then Swallow the NullReferenceException example
            Action<Object> action = o => Console.WriteLine(o.GetType());
            action.InvokeAndCatch<NullReferenceException>(null);

            // below is an example eating the ArgumentOutOfRangeException, i think 2 examples are enough
            Action<Object> action2 = o2 => Console.WriteLine(numberList[5]);
            action2.InvokeAndCatch<ArgumentOutOfRangeException>(null);

            // last example involving extention methods involve invoking delegates
            Action a = " Alex".ShowItems;
            a();            

            Console.WriteLine("\n\npress any key to continue...");
            Console.ReadKey();
        }


    }
}
