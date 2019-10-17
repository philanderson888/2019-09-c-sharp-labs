using System;

namespace lab_03_private_public_fields
{
    class Program
    {
        static void Main(string[] args)
        {
            var person01 = new Person();
            person01.Name = "Fantasia";
            // person01.NINO = "ABC123";
            person01.SetNINO("ABC123");
            // print NINO
            string output = person01.GetNINO();
            Console.WriteLine(output);

            var person02 = new Person();
            person02.Name = "Roberta";
            person02.SetNINO("Some Data Here");
        }
    }

    class Person
    {
        private string NINO;
        public string Name;

        // Getter / Setter Methods to read/write private data
        public string GetNINO() {
            return this.NINO;
        }

        // PARAMETER IS DATA PASSED INTO METHOD
        public void SetNINO(string nino) {
            this.NINO = nino;
        }

    }
}
