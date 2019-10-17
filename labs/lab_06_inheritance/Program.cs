using System;

namespace lab_06_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dog();
            d.Name = "Fido";
            var labrador01 = new Labrador();
            labrador01.Name = "MansBestFriend";
            labrador01.Age = 2; // child only
        }
    }

    class Dog {
        public string Name { get; set; }
    }

    class Labrador : Dog { 
        public int Age { get; set; }
    }
}
