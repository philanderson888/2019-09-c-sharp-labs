using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_17_rabbit_database_explosion
{
    class Program
    {
        static List<Rabbit> rabbits;

        static void Main(string[] args)
        {
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }

            PrintRabbits();
            //foreach(var rabbit in rabbits)
            //{
            //    Console.WriteLine($"{rabbit.RabbitId,-5}{rabbit.Name,-12}{rabbit.Age}");
            //}

            // new rabbit : WPF Textbox01.text ==> use for Age, Name (2 boxes)
            // buttonAdd : run this code


            var newRabbit = new Rabbit()
            {
                Age = 0,
                Name = $"Rabbit{rabbits.Count+2}"
            };

            using (var db = new RabbitDbEntities())
            {

                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }

            // pause to ensure database has finished writing
            System.Threading.Thread.Sleep(200);
            // read db from scratch
            Console.WriteLine("\n\nAfter adding a rabbit, re-read database");
            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                PrintRabbits();
            }



        }

        static void PrintRabbits()
        {
            // print rabbits
            rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitId,-5}" +
                $"{rabbit.Name,-12}{rabbit.Age}"));
        }
    }
}
