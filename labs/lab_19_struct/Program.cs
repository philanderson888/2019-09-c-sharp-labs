using System;

namespace lab_19_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new MyStruct();
            var s2 = new MyStruct(10, 10, "hi");
            Console.WriteLine(s2.GetX());


        }
    }
    
    class MyClass { }

    struct MyStruct {
        private int X;
        public int Y;
        public string Z { get; set; }
        public MyStruct(int X, int Y, string Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
        public int GetX()
        {
            return this.X;
        }
    }
}
