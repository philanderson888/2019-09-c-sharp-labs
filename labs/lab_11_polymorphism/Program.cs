using System;

namespace lab_11_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Parent();

            var c = new Child();
            for (int i = 0; i < 10; i++)
            {
                p.HaveABirthday();
                c.HaveABirthday();
                Console.WriteLine($"parent age is {p.Age} and child age is {c.Age}");
            }

        }
    }

    class Parent { 
        public int Age { get; set; }
        public string Name { get; set; }

        public virtual void HaveABirthday()
        {
            Age++;
        }
        public Parent() { }
        public Parent(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
    }

    class Child : Parent {
        public override void HaveABirthday() { 
            Age += 2;
            base.HaveABirthday();
        }
        public Child(int age, string name) : base(age, name) { }  // call parent

        public Child() { }


    }


}
