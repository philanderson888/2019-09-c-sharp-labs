using System;

namespace lab_37_overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            short s = 12345;
            int i = 1234567890;
            long l = 1234567890123456789;
            float f = 123456789012345678901234567890.0123456789012345678901234567890F;
            double d = 123456789012345678901234567890177777777777777777777777777777777.0123456789012345678901234567890;
            decimal dd = 12345678901234567890123456789.0123456789012345678901234567890M;
            Console.WriteLine(f);
            Console.WriteLine(d);
            Console.WriteLine(dd);

            // DEFAULT IS UNCHECKED BECAUSE CPU INTENSIVE
            unchecked
            {
                // integer maximums  MAX = 4.   0,1,2,3, -4,-3-2-1 0 1 2 3  -4
                Console.WriteLine(int.MaxValue);
                int bigInt = int.MaxValue;
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
                Console.WriteLine(bigInt);
                bigInt += 1;
            }

            DoThis();
        }
        static int counter = 0;
       static void DoThis() {
            counter++;
            Console.WriteLine(counter + "Doing This");
            DoThis();
        }
    }
}
