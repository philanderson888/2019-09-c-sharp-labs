using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace project_1000_console
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRabbitsToCreate = 1000;
            // stopwatch

            // one read
            using (var db = new RabbitDbEntities()) { }
            // 1000 reads
            for (int i = 0; i < numberOfRabbitsToCreate; i++)
            {
                using (var db = new RabbitDbEntities())
                {

                }
            }
            // report times to console
            // report times to CSV
            File.WriteAllText("RabbitOutput.csv","ID,Name,Age");
            File.AppendAllText("RabbitOutput.csv","\n1,Billy,12");  // Environment.NewLine
            File.AppendAllText("RabbitOutput.csv","\n2,Fluffy,13");
            Process.Start("RabbitOutput.csv");
            // report times to Word
            // Sprint 2 : move everything to WPF!!!
        }
    }
}
