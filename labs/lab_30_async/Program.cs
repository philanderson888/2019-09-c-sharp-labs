using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace lab_30_async
{
    class Program
    {
        static List<string> lines = new List<string>();
        static Stopwatch s = new Stopwatch();

        static void Main(string[] args)
        {

            s.Start();

            // File.Delete("data.txt");
            //// create dummy data
            //for (int i = 0; i < 100000; i++)
            //{
            //    File.AppendAllText("data.txt",$"\nAdding Line {i} at {DateTime.Now}");

            //}




            // DoThisLongThing();
            DoThisLongThingAsync();
            Console.WriteLine($"Main Thread has finished at time {s.ElapsedMilliseconds} milliseconds");
            Console.ReadLine();
            
        }

        static void DoThisLongThing()
        {
            Thread.Sleep(3000);
        }
        async static void DoThisLongThingAsync()
        {
            
            // STREAM IN LINES USING STREAMREADER (DON'T KNOW EXACTLY LENGTH OF DATA WE ARE PULLING IN)
            using (var reader = new StreamReader("data.txt"))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if(line==null)
                    {
                        break;
                    }
                    lines.Add(line);
                }
            };

            s.Stop();
            Console.WriteLine($"Finished reading {lines.Count} lines which took {s.ElapsedMilliseconds} milliseconds");
        }
    }
}
