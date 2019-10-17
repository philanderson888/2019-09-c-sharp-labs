using System;
using System.Collections.Generic;
using System.Collections;

namespace lab_21_collections
{
    class Program
    {
        static void Main(string[] args)
        {

            // dictionary of KEY-VALUE PAIRS
            // KEY IS INDEX 0,1,2,3
            // VALUE IS STRING SAVED 
            // pairs  0,"hi"     1,"there"
            var dictionary = new Dictionary<int, string>();
            dictionary.Add(0, "hi");
            dictionary.Add(1, "hi"); 
            dictionary.TryAdd(0, "hi");  // silently fail
            dictionary.TryAdd(2, "there");

            // GET VALUES
            foreach(KeyValuePair<int,string> item in dictionary)
            {
                Console.WriteLine($"{ item.Key,-10}{item.Value}");
            }


            // Queue : enqueue, dequeue, peek, contains

            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(100);
            queue.Enqueue(1000);
            foreach (var item in queue) { Console.WriteLine(item); }

            // Stack : push, pop, peek,contains
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(100);
            stack.Push(1000);
            foreach (var item in stack) { Console.WriteLine(item); }

            // List : add, Insert, RemoveAt


            // ArrayList : cast from object when get data out 
            var arraylist = new ArrayList();
            arraylist.Add(1);
            arraylist.Add("hi");
            foreach (var item in arraylist) { Console.WriteLine(item.ToString()); }

            // LinkedList


            // HashSet



        }
    }
}
