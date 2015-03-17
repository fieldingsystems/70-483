using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastingBetweenTypes
{
    // new type implicitly derived from System.Object
    internal class Employee 
    {
        // ... some implementation
    }

    // class derived from employee explicitly
    internal class Manager : Employee
    {
        // ... some implementation
    }

    class Program
    {
        static void Main(string[] args)
        {
            // first example of type casting
            FirstExample();
            Console.WriteLine("first example ran successfully, press any key to continue...");
            Console.ReadKey();

            // second example this will compile but 
            // at run time CLR check casting operations to ensure that cast
            // are always to the objects actual type or any of its base types
            // this should throw an InvalidCastException
            SecondExample();
            Console.WriteLine("you shouldn't see this");
            Console.ReadKey();
        }

        private static void SecondExample()
        {
            // construct a mander object and pass it to PromoteEmployee
            // A Manager IS-A Employee: Promote Employee runs OK
            Manager m = new Manager();
            PromoteEmployee(m);
            Console.WriteLine("manager Promoted, press any key to continue...");
            Console.ReadKey();

            // construct a datetime object and pass it to PromoteEmployee
            // a datetime is now derived rom employee. PromoteEmployee
            // throws a System.InvalidCastException excetion.
            DateTime newYears = new DateTime(2015, 1, 1);
            PromoteEmployee(newYears);
        }

        // at this point the compiler doesn't know exactly what type of object o refers
        // to. So the compiler allows the code to comiple. However, at run time, the CLR
        // knows wat type o refers to each time the cast is preformed and it checks
        // if the object is type Employee or a derived type.
        private static void PromoteEmployee(Object o)
        {
            Employee e = (Employee) o;
        }

        private static void FirstExample()
        {
            // cast not needed since new returns an employee object
            // and object is the base type of employee
            Object o = new Employee();

            // here a cast is required sinc employee is derived from object
            // other languages might not require this to compilet but C# does
            Employee e = (Employee)o;
        }
    }
}
