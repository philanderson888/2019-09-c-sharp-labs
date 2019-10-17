using System;

namespace lab_09_constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            var merc01 = new Mercedes("CHASIS1234ABC","Silver",2500); // calling default constructor
            var merc02 = new Mercedes();

            var aclass01 = new AClass("Chassis123", "blue", 2600);

            var a104 = new A104("Chassis456", "red", 1800);

            var a104car02 = new A104("Chassis456", "red");
        }
    }


    class Mercedes
    {
        protected string engineChassisID;
        public string Color { get; set; }
        public int Length { get; set; }
        
        public Mercedes() { }                  // BLANK DEFAULT ONE : EXPLICITLY CODE IT

        public Mercedes(string engineChassisID, string color, int length)
        {
            this.engineChassisID = engineChassisID;
            this.Color = color;
            this.Length = length;
        }
    }

    class AClass : Mercedes
    {
        public AClass() { }
        public AClass(string engineChassisID, string color, int length)
        {
            this.engineChassisID = engineChassisID;
            this.Color = color;
            this.Length = length;
        }
    }

    class A104 : AClass
    {
        // different constructor : calling BASE (PARENT) constructor
        public A104(string engineChassisID, string color, int length = 2300) : base(engineChassisID,color,length) { }

    }


}


