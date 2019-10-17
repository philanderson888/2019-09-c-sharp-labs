using System;

namespace lab_12_test_me_out
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestMeSomething.RunThisTestNow(10));
        }
    }

    public class TestMeSomething { 
        public static int RunThisTestNow(int input)
        {
            return input * input;
        }
    }
}
