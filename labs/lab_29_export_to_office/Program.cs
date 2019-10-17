using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;
using System.Diagnostics;


namespace lab_29_export_to_office
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"RabbitReport.docx";
            string fileNameDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + fileName;
            string fileNameDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName;

           
           // var doc = DocX.Create(fileNameDesktop);

            Console.WriteLine(fileNameDocuments);
            Console.WriteLine(fileNameDesktop);

            //doc.InsertParagraph("Rabbit Report");

           // doc.InsertParagraph("Number of rabbits created : 1000");

         //   doc.InsertParagraph("Time taken : 7.256 seconds with one loop");
            
         //   doc.InsertParagraph("Time taken : 17.256 seconds with 1000 loops");

         //   doc.Save();

            // Run Word and View Report
            Process.Start("WINWORD.EXE", Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fileName);

        }
    }
}
