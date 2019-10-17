using System;
using System.IO;
using System.Diagnostics;

namespace lab_50_CSV
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] data = new string[]
            {
                "Name, Age, Hobby","Phil,34,Gym",
                "Ryan,22,Coding", 
                "Fuat, 26,Football",
                "Mohssin, 22, Kickboxing MMA dont mess with me"
             
            };
            File.WriteAllLines("data.txt", data);
            File.WriteAllLines("data.csv", data);
            Console.WriteLine("Data written");

            Console.WriteLine("Reading data with Excel");
            Process.Start("EXCEL.exe", "data.csv");




        }
    }
}
