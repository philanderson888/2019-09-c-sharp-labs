using System;
using System.Collections.Generic;

namespace just_do_it_11_rabbit_explosion
{
    class Program
    {
        
        static void Main(string[] args)
        {
            just_do_it_11_rabbit_explosion_test.Rabbit_Exponential_Growth(100);
        }
    }


    public class just_do_it_11_rabbit_explosion_test
    {

        public static int Rabbit_Exponential_Growth(int populationLimit)
        {
            List<Rabbit> rabbits = new List<Rabbit>();

            var adultAge = 3;
            var yearCounter = 0;
            var rabbitCounter = 0;
            var initialRabbit = new Rabbit();
            initialRabbit.Name = "Rabbit0";
            rabbits.Add(initialRabbit);
            while (true)
            {
                for (int i = 0; i < rabbits.Count; i++)
                {
                    Console.WriteLine($"{rabbits[i].Name} has age {rabbits[i].Age}");
                    if (rabbits[i].Age >= adultAge)
                    {
                        var rabbit = new Rabbit();
                        rabbit.Name = $"Rabbit{rabbitCounter}";
                        rabbits.Add(rabbit);

                        rabbitCounter++;
                    }
                    rabbits[i].Age++;
                }



                if (rabbits.Count > populationLimit)
                {
                    break;
                }
                // increment counters
                yearCounter++;

            }

            Console.WriteLine($"Population limit exceeded at year {yearCounter} " +
                $"with population of  {rabbits.Count}");

            return yearCounter;
        }
    }


    class Rabbit
    {
        public int Age { get; set; }
        public string Name { get; set; }

    }
}
