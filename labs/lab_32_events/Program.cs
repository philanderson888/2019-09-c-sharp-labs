using System;

namespace lab_32_events
{
    class Program
    {
        public delegate void MyDelegate();

        public static event MyDelegate MyEvent;
        static void Main(string[] args)
        {
            MyEvent += MethodA;   // pointer to a method, but don't call the method right now
                                  // callback
            MyEvent += MethodB;
            MyEvent += MethodC;
            MyEvent -= MethodA;
            MyEvent();
        }

        static void MethodA() { Console.WriteLine("Method A"); }
        static void MethodB() { Console.WriteLine("Method B"); }
        static void MethodC() { Console.WriteLine("Method C"); }
    }
}
