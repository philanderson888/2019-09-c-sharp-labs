using System;
using System.Diagnostics;
using System.IO;

namespace lab_14_stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();

            var counter = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                counter++;
            }

            var b = 0b_1010_1010_1010;
            var hex = 0x_ff_ee_dd_cc_bb;

            s.Stop();

            Console.WriteLine(s.Elapsed + " seconds");
            Console.WriteLine(s.ElapsedMilliseconds + " ms");
            Console.WriteLine(s.ElapsedTicks + " ticks which are 10-7 seconds");


        }
    }
}
