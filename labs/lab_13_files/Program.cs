using System;
using System.IO;
using System.Linq;

namespace lab_13_files
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("===Just a single line of text===\n\n");
            if (File.Exists("myFile.txt"))
            {
                var string1 = File.ReadAllText("myFile.txt");
                Console.WriteLine(string1);
            }

            File.WriteAllText("output.txt", "some data to be saved");

            Console.WriteLine("\n===Save multiple lines===\n");

            File.WriteAllText("multiplelines.txt", "some\ndata\non\ndifferent\nlines");
            Console.WriteLine(File.ReadAllText("multiplelines.txt"));

            File.WriteAllText("multiplelines.txt", "some" + Environment.NewLine +
                    "text" + Environment.NewLine + "here");
            Console.WriteLine(File.ReadAllText("multiplelines.txt"));

            Console.WriteLine("=== Saving Arrays To Multiple Lines");

            string[] myArray = new string[] { "some", "data", "in", "multiple", "lines" };
            File.WriteAllLines("multiLineFile.txt", myArray);
            // read it back
            var outputArray = File.ReadAllLines("multiLineFile.txt");
            // print array using fancy Lambda syntax
            Array.ForEach(outputArray, item => Console.WriteLine(item));


            Console.WriteLine("\n=== Logging ===\n");

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("myLogFile.log", $"Event happened at time {DateTime.Now}\n");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine(File.ReadAllText("myLogFile.log"));




  



        }
    }
}
