using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualMethdodsPropertiesAndEvents
{
    class Employee
    {
        // non virtual instance method that you can inherit
        public Int32 GetYearsEmployed()
        {
            return 5;
        }

        // virtual method that can be overwritten
        public virtual String GetProgressReport()
        {
            return "You have worked here for the last " + GetYearsEmployed() + " years, your due for a promotion.";
        }
    }

    // derive employee to a slacker employee
    class SlackerEmployee : Employee
    {
        // override the get progress report you can still use the the get years employeed method because you inherit it
        public override String GetProgressReport()
        {
            return "You have been employeed over " + GetYearsEmployed() + ", you should be better at your job";
        }
    }

    class Program
    {
        /// <summary>
        /// This is to show how to use vitual methods to change type behavior. The object e is an employee that
        /// is then turned to a slacker employee to change the behavior of virtual methods depending on what type
        /// e is when that method is called.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // create a new employee
            Employee e = new Employee();
            Console.WriteLine(e.GetProgressReport());

            // make the employee a slacker
            e = new SlackerEmployee();
            Console.WriteLine(e.GetProgressReport());

            // the code below should be commented out if you want this to run correctly, this is just to show the 
            // difference between C# and some other languages, this would run just fine and return 5 but for c# it 
            // throws a NullReferenceException
            e = null;
            Console.WriteLine(e.GetYearsEmployed());

            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
