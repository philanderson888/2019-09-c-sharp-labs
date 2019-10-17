using System;
using System.Collections.Generic;
using System.Collections;

namespace lab_04_class_summary
{
    class Program
    {
        static List<User> users = new List<User>();
        static ArrayList listofrandomobjects = new ArrayList();

        static void Main(string[] args)
        {
            // CREATE INSTANCE

            // CONSOLE.READLINE(); TO INPUT DATA FROM USER
            Console.WriteLine("Enter NINO please");
            string inputNINO = Console.ReadLine();

            var user = new User();
            // user.SetNINO("ABC123");
            user.SetNINO(inputNINO);
            Console.WriteLine(user.GetNINO());
            users.Add(user);
        }
    }

    // CREATE CLASS WITH PRIVATE / PUBLIC FIELD & GET;SET
    class User {
        private string NINO;
        public string GetNINO()
        {
            return NINO;
        }
        public void SetNINO(string nino)
        {
            this.NINO = nino;
        }
    }
}
