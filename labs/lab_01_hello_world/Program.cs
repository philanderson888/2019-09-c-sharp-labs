﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_01_hello_world
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            var r = new Random();
            var randomNumber = r.Next(100,999);
            Console.WriteLine(randomNumber);
        }
    }
}
