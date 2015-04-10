using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticClasses
{
    /// <summary>
    /// 
    /// static classes exist simply as a way to group  a set of related memers together.
    /// such as the Math or Console class they have the following restrictions the compiler
    /// will make the class both abstract and sealed
    /// 
    /// * the class must be derived directly from System.Object, you can not instanciate a
    /// static class
    /// 
    /// * the class must not implement any interface, interface methods are callable only
    /// when using and instance of a class
    /// 
    /// * the class must define only static members
    /// 
    /// * the class cannot be used as a field, method arameter, or local variable because 
    /// all of these would indicate a variable that refers to an instance
    /// 
    /// </summary>
    public static class StaticClass
    {
        public static void Method()
        {
            Console.WriteLine("Static Method");
        }

        public static String staticProperty
        {
            get { return s_staticField; }
            set { s_staticField = value; }
        }

        private static string s_staticField;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("this was just to show how you can use a static class");
            Console.ReadKey();
        }
    }
}
