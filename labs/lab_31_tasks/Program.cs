using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace lab_31_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            // anonymous (lamdba) delegate 
            var task01 = new Task(() => { 
                Console.WriteLine("Running Task01");     
            });
            task01.Start();
            

            // delegate is PLACEHOLDER FOR ONE OR MORE METHODS
            // simplest DELEGATE is called ACTION  
            // ACTION      void DoThis(){}     // no parameters in, void output
            
            var taskOld = new Task(  DoThis   );
            taskOld.Start();

            var task02 = Task.Run(  ()=> {
                Console.WriteLine("Running Task02");
            });


            var taskArray = new Task[10];
            taskArray[0] = Task.Run(() => { Console.WriteLine("Task Array 00"); });
            taskArray[1] = Task.Run(() => { Console.WriteLine("Task Array 01"); });
            taskArray[2] = Task.Run(() => { Console.WriteLine("Task Array 02"); });

            var counter = 3;
            for (int i = 3; i < 10; i++)
            {
                taskArray[counter] = Task.Run(() => { Console.WriteLine($"Task Array {counter}");   });
                System.Threading.Thread.Sleep(10);
                counter++;
            }

            Task.WaitAll(taskArray);

            Console.ReadLine();

            // Parallel ForEach
            var myList = new List<string> { "a", "b", "c","d","e","f","g" };
            // take 150 ms ie 3 loops in SERIAL

            myList.ForEach((s) => { 
                Console.WriteLine($"Item is {s}");
                System.Threading.Thread.Sleep(50);
            });
            // Execute in PARALLEL 
            Parallel.ForEach(myList, (s) => { 
                Console.WriteLine($"Parallel item is {s}");
                System.Threading.Thread.Sleep(50);
            });
            // How much faster is Parallel query (20%  50%  100%  200%)
            // PLINQ Parallel LINQ
            var output =
                (from item in myList
                 select item).ToList();
            var outputASPARALLEL =
                (from item in myList
                 select item).AsParallel().ToList();

            // Getting data back from a task
            // var t = Task.Run( ()=>{}  );
            // var t = Task<T>.Run...    return data of Type T
            // access data  t.Result 
            var taskWithResult = Task<int>.Run(   ()=> {
                return 100;
            });
           // taskWithResult.Wait();
            Console.WriteLine($"Result of our task is  {taskWithResult.Result }");
           // Console.ReadLine();
        }

        static void DoThis() { Console.WriteLine("I am doing something"); }
    }
}
