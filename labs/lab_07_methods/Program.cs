using System;

namespace lab_07_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            DoThisAswell();
            var m = new Mammal();       // m is an INSTANCE (REAL EXAMPLE) of class mammal
            m.GetOlder(); // INCREASE AGE TO 1

            // method INSIDE method
            void DoThis(){
                Console.WriteLine("I am doing something");
            }

            CountNumbers(5000);       // y only
            CountNumbers(5000, 300);  // y and x

            OutParameters(10, 10, out int a);
            Console.WriteLine($"out parameter was {a}");

            TupleMethod();         // Not gathering output; output is wasted

            var tupleOutput = TupleMethod();   // OUTPUT Sent to custom object
            Console.WriteLine($"{tupleOutput.x}, {tupleOutput.y},{tupleOutput.z}");

        }

        // ATTACH METHOD TO CLASS : ADD 'STATIC' KEYWORD
        static void DoThisAswell() {
            Console.WriteLine("I am doing something aswell");
        }


        static void CountNumbers(int y, int x = 100)
        {
            Console.WriteLine(x*y);
        }

        static void OutParameters(int x, int y, out int z)
        {
            z = x * y;   // WILL RETURN THIS AS z
        }

        static (int x, string y, bool z) TupleMethod()
        {
            return (10, "hi", false);
        }


    }


    class Mammal
    {
        public int Age { get; set; }
        // INSTANCE METHOD
        public void GetOlder() { Age++; }
    }
}
