using System;
using external;

namespace lab_27_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Child();
            c.DoThis();
            c.DoThat();
            c.DoingSomeParentThing();
        }
    }

    class Parent
    {
        public void DoingSomeParentThing() { Console.WriteLine("I am doing some parent thing"); }
    }

    class Child : Parent,IDoThis,IDoThat,IAlsoDoThis {
        public void DoThis() { Console.WriteLine("I'm doing this.."); }

        public void DoThat() { Console.WriteLine("I'm doing that.."); }
        public void AlsoDoThis() { Console.WriteLine("I am also doing this");
        }
}

    interface IDoThis
    {
        void DoThis();
    }

    interface IDoThat
    {
        void DoThat();
    }
}


namespace external
{
    interface IAlsoDoThis {
        void AlsoDoThis();
    }
}
