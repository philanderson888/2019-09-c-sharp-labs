using System;
using System.Collections.Generic; // list

namespace lab_05_rabbits
{
    class Program
    {
        static List<Rabbit> rabbits = new List<Rabbit>();
        static void Main(string[] args)
        {

                       

            for(int i = 1; i<=20; i++)
            {
                var r = new Rabbit();
                r.Age = i;
                //if (i < 10)
                //{
                //    r.Name = $"Rabbit0{i}";
                //}
                //else
                //{
                //    r.Name = $"Rabbit{i}";
                //}

                r.Name = (i<10) ? $"Rabbit0{i}" : $"Rabbit{ i}";

                r.Name = String.Format("Rabbit{0:D2}", i);
                r.Name = $"Rabbit{i:D2}";
                rabbits.Add(r);
            }
            foreach(var rabbit in rabbits)
            { 
                Console.WriteLine($"Name is {rabbit.Name} and age is {rabbit.Age}");
            }
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
