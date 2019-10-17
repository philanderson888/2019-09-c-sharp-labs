using System;

namespace lab_33_oop_events
{
    class Program
    {
        static void Main(string[] args)
        {

            var James = new Child();
            James.Name = "James";
            for(int i = 0; i < 10; i++)
            {
                James.Grow($"Special Party For Year {i+1}");
            }


        }
    }

    class Child
    {
        public delegate int BirthdayDelegate(string TypeOfParty);
        public event BirthdayDelegate HaveABirthday;

        public string Name { get; set; }
        public int Age { get; set; }
        public Child()
        {
            this.Age = 0;
            Console.WriteLine("Congratulations !!!!  Beautiful Baby :) ");
            HaveABirthday += Celebrate;
        }
        public void Grow(string TypeOfParty)
        {
            int AgeNow = HaveABirthday(TypeOfParty);
        }

        int Celebrate(string TypeOfParty)
        {
            Age++; // one year older
            Console.WriteLine($"Celebrating another birthday : Age is {this.Age} : {TypeOfParty}");
            return Age;
        }
    }
}
