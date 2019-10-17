using System;

namespace lab_02_class
{
    class Program
    {
        static void Main()
        {
            // use the class : create new Dog object ==> call this an INSTANCE (of a class)
            var dog01 = new Dog();  // create new empty blank Dog object
            dog01.Name = "Fido";
            dog01.Age = 1;
            dog01.Height = 400;
            // GROW OUR DOG
            dog01.Grow();
            // PRINT NEW AGE AND HEIGHT
            Console.WriteLine("Age is " + dog01.Age + " and height is " + dog01.Height);
            dog01.Grow();
            // $ literal syntax : just print what's inside
            // EXCEPT {} CURLY BRACES : PUT VARIABLES IN THEM
            Console.WriteLine($"Age is {dog01.Age} and height is {dog01.Height}");

        }
    }


    // INSTRUCTIONS (BLUEPRINT) FOR CREATING NEW DOG OBJECT
    class Dog
    {
        public string Name;
        public int Age;
        public int Height;

        public void Grow()          // have the method but return nothing
        {
            // LET COMPUTER KNOW : IS IT RETURNING ANY VALUE???
            // NO ==> VOID
            // YES ==> SPECIFY TYPE EG INT, STRING
            this.Age++;
            this.Height += 10;
        }
    }


}
