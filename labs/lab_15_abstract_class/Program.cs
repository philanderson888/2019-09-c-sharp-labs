using System;

namespace lab_15_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // var h = new Holiday();
            var h = new HolidayWithTravel();

            string x = "Hello World";
            if (x.StartsWith("Hello"))
            {
                Console.WriteLine("world");
            }

           x = x.AmazingExtraStringMethod();
            Console.WriteLine(x);

            // used in Math class
            Console.WriteLine(Math.PI);
            Console.WriteLine(Math.Max(30,40));
        }
    }

    abstract public class Holiday
    {
        public abstract void Travel();

        public void Places() { Console.WriteLine("Visiting Vienna, Salzburg"); }

        public void Activities() { Console.WriteLine("Skiiing, Walking, Fishing"); }
    }

    public class HolidayWithTravel : Holiday
    {
        public override void Travel() { Console.WriteLine("By Train Eurostar Then Hire A Car"); }
    }

    sealed class Security { }

    // class CannotInherit : Security { }



    public static class AddingToStrings
    {
        public static string AmazingExtraStringMethod(this string s)
        {
            Console.WriteLine("Changing string");
            s = s + "--->add your comment ";
            return s;
        }
    }
}
