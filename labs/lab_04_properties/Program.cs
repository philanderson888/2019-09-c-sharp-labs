using System;

namespace lab_04_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbit = new Rabbit();
            rabbit.Name = "Cute01";
            // rabbit._bloodType.. INVALID
            rabbit.Age = -10;
            Console.WriteLine(rabbit.Age);

            int x = default; // 0
        }
    }

    class Rabbit
    {
        private int _bloodType;            // FIELD
        private int _age;
        public string Name { get; set; }   // AUTO-IMPLEMENTED PROPERTY

        public int Age { 
            get {
                return this._age;
            } 
            set {
                if (value > 0)
                {
                    this._age = value; // value is c# code word
                }
            } 
        }
    }
}
