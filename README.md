# 2019-09-c-sharp-labs

Labs built and run while learning C#

# Intro To C# and .NET

## History of coding

Operating System ==> makes a bit of hardware (motherboard, processor, RAM, network card) 'work'.

	Common operating systems we know have been written originally in 'C'

		UNIX (original) 				PAID, CLOSED-SOURCE
		APPLE IOS and OSX 				UNIX DERIVATIVE, CLOSED SOURCE
		WINDOWS 						CLOSED 
		LINUX (UNIX-like) 				OPEN SOURCE

			OPEN SOURCE WINS!!!

				WINDOWS ==> .NET is now OPEN SOURCE !!!

				LINUX ==> World's top 500 supercomputers

						TFLOP TERA (10^12) FLOATING POINT OPERATIONS/SEC
							1,000,000,000,000

	Programming Language

		'C'

		then

		C++  ==> in use today.

			'raw' coding ==> C++

	However!!!

		Java
			run in 'JVM' Virtual Machine (install Java)
		C#
			Microsoft ==> main 'push' using this language
				F# Functional Programming Language
		Python
			Engineering
			Data Science

Cloud
	
	Traditional computing ran on local hardware

	Today - everything has changed

		Traditional : local
		Newer       : services to cloud

				1) AWS Amazon 			No 1 provider  70%???
				2) Azure                25% market      *** Microsoft : MOST REVENUE IN THIS SPACE ***
				3) Google Cloud         5% ???

	Container : Mini Virtual Machine : run individual 'apps' 
	
		Group of containers : manage with 'Kubernetes' from Google (now open source)

	Function as a service ==> individual methods : call in cloud !!!!	



Structure Of An Application

	.NET  old, huge, cumulative libraries for ALL WINDOWS !!!

	.NET Core   new, streamlined version : valid LINUX, MAC


	.sln  XML file with all NAMES OF ALL OF THE PROJECTS INSIDE

		'CONTAINER' which has no function of itself ==> just to hold multiple projects

	.csproj

		METADATA for individual project

	Program.cs

		class Program{

			public static void Main(){

					// CODE RUN HERE
			}
		}


.NET structure

	In order to build a program with C# / .NET we need the following

	CLI Common Language Infrastructure : RULES FOR THE LANGUAGE 

	CLR                 Runtime         : Run inside this environment

		Garbage Collector               : Reclaim memory when we are finished with an object

	CSC C Sharp Compiler 			    : Turn .cs text into .exe BINARY RUNTIME EXECUTABLE FILE 

	CIL Common Intermediate Language    : Half-compiled code  'assembly language' 


			CS  ==>  CIL (half-way-house)   ==> CLR runtime
			raw 
			code

					Tool 'ILDASM'  ==> inspect .exe and view this 'CIL' compiled code




# OOP Object Oriented Programming

Traditional computing has been LINEAR PROGRAMMING where code starts at line 1 and runs to the end.

	OK but when GUI was invented, screen objects appeared

		Button ==> Click (event)  ==> Method (function)   (event 'handler')

		OBJECT          EVENT                METHOD (CODE)


	Object looks like

	{
		id:1,                               field:value  (key/value pairs)
		name:"bob",
		dob:"10/10/2001"		
		likes:["strawberries","pizza"]
	}

	Array [1,2,3]

	String "some text"

	Number  

		Whole number   integer 
		Decimal        float 32 bits long / double 64 bits long / decimal type 128 bits

	Char 
		'f'


# Creating Basic Objects

Class = Template = Blueprint for creating object

```cs

using System;

namespace lab_02_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // use the class : create new Dog object
            var dog01 = new Dog();  // create new empty blank Dog object
            dog01.Name = "Fido";
            dog01.Age = 1;
            dog01.Height = 400;
        }
    }


    // INSTRUCTIONS (BLUEPRINT) FOR CREATING NEW DOG OBJECT
    class Dog
    {
        public string Name;
        public int Age;
        public int Height;
    }


}

```


# Method

Method = Function

	Call a Method to get something done

		Let's GROW OUR DOG

			Grow(){
				Age = Age+1;
				Height = Height + 10;
			}


```cs

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

```


# Private and Public fields

class Person{
	private string NINO;
	public string Name;
}

```cs
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

```



# Fields and Properties

In a class we can have

	fields - tend to be private     private string NINO;

		   - convention camelCase   private string privateData;

		   - convention _camelCase  private string _privateData;

	properties - tend to be PUBLIC  public string Name {get;set;}

			   - convention PascalCase  public string ThisIsAPublicProperty

			   - {get;set;}  // abbreviations for GET/SET methods which we
			   					already coded


```using System;

namespace lab_04_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbit = new Rabbit();
            rabbit.Name = "Cute01";
            // rabbit._bloodType.. INVALID
            rabbit.Age = -10;
            Console.WriteLine(rabbit.Age);

            int x = default; // 0
        }
    }

    class Rabbit
    {
        private int _bloodType;            // FIELD
        private int _age;
        public string Name { get; set; }   // AUTO-IMPLEMENTED PROPERTY

        public int Age { 
            get {
                return this._age;
            } 
            set {
                if (value > 0)
                {
                    this._age = value; // value is c# code word
                }
            } 
        }
    }
}



```



# Creating Multiple Objects

Array written [1,2,3] has FIXED SIZE

List written  List<int>() has VARIABLE SIZE and we can use this to ADD items
		to a list


	// create a lab

	// count 1 to 10

	// create Rabbits

	// name = "Rabbit" + 0 + i    Rabbit01, Rabbit02,  
	// age = i
	// add to list of rabbits
	// print out list at end 


```cs
using System;
using System.Collections.Generic; // list

namespace lab_05_rabbits
{
    class Program
    {
        static List<Rabbit> rabbits = new List<Rabbit>();
        static void Main(string[] args)
        {
            for(int i = 1; i<=20; i++)
            {
                var r = new Rabbit();
                r.Age = i;
                if (i < 10)
                {
                    r.Name = $"Rabbit0{i}";
                }
                else
                {
                    r.Name = $"Rabbit{i}";
                }
                //r.Name = String.Format("Rabbit{0:G2}", i);
                rabbits.Add(r);
            }
            foreach(var rabbit in rabbits)
            {
                Console.WriteLine($"Name is {rabbit.Name} and age is {rabbit.Age}");
            }
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

```


# Inheritance

Natural world we think Species eg Mammal class ==> Cats ==> Lions ==> African Lion


```cs
using System;

namespace lab_06_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dog();
            d.Name = "Fido";
            var labrador01 = new Labrador();
            labrador01.Name = "MansBestFriend";
            labrador01.Age = 2; // child only
        }
    }

    class Dog {
        public string Name { get; set; }
    }

    class Labrador : Dog { 
        public int Age { get; set; }
    }
}



```


# Methods In More Detail

	convention   name is PascalCase       void DoThis(){}
	parameters   passed IN                void DoThis(int x, string y){}
	return       passed OUT               string DoThis(){ return "hi"; }
	optional     passed IN                void DoThis(int x = 1000){}
	                          pass in x but if missing set value to 1000

	out parameters pass OUT               void DoThis(int x, int y, out int z)

	Tuple is a fancy new variable from C#

		(int x, string y, bool z)  IS NOW A CUSTOM DATA TYPE!!!  


```cs
using System;

namespace lab_07_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            DoThisAswell();
            var m = new Mammal();       // m is an INSTANCE (REAL EXAMPLE) of class mammal
            m.GetOlder(); // INCREASE AGE TO 1

            // method INSIDE method
            void DoThis(){
                Console.WriteLine("I am doing something");
            }

            CountNumbers(5000);       // y only
            CountNumbers(5000, 300);  // y and x

            OutParameters(10, 10, out int a);
            Console.WriteLine($"out parameter was {a}");

            TupleMethod();         // Not gathering output; output is wasted

            var tupleOutput = TupleMethod();   // OUTPUT Sent to custom object
            Console.WriteLine($"{tupleOutput.x}, {tupleOutput.y},{tupleOutput.z}");

        }

        // ATTACH METHOD TO CLASS : ADD 'STATIC' KEYWORD
        static void DoThisAswell() {
            Console.WriteLine("I am doing something aswell");
        }


        static void CountNumbers(int y, int x = 100)
        {
            Console.WriteLine(x*y);
        }

        static void OutParameters(int x, int y, out int z)
        {
            z = x * y;   // WILL RETURN THIS AS z
        }

        static (int x, string y, bool z) TupleMethod()
        {
            return (10, "hi", false);
        }


    }


    class Mammal
    {
        public int Age { get; set; }
        // INSTANCE METHOD
        public void GetOlder() { Age++; }
    }
}


```








# OOP Revision : Wed 4 Sept 2019

```cs
private
public

class x{
    private field _y

    public property Z {get;set;}

    public void Method01(int param1, string param2,
            bool param3=false, out string a){}

    (int x, string y)   Tuple - on-the-fly data type
}
```


class       blueprint / tempate for new objects (think of an
            architect's plan for a new building) 
instance    object created from a class
                eg Chrome : many instances 
new         var instance01 = new MyClass();     new calls a special method!!!!
Constructor method is run when we use the 'new' keyword
var         general data type
C#          Strongly typed : all types verified at COMPILE TIME
Javascript  Loosely typed : data type NOT VERIFIED UNTIL RUN TIME 
'dynamic'   keyword - turns data type same as Javascript : ie change it on the fly
field       private _
property    public PascalCase
method : function
    return value     void : nothing 
    string DoThis(){ return "a string"; }




```cs
            // object : undefined data type

            object o = 10;

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = "a string";

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = new int[1, 2, 3];

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());


            dynamic obj2 = 10;
            obj2 = "a string";
            obj2 = new int[1, 2, 3];
```



# Naming

camelCaseLikeThis    private fields

PascalCaseLikeThis   

    1) Methods (Verb eg DoThis())  
    2) Class names (Noun)
    3) Properties  public string Name {get;set;}     Name is PascalCase

```cs
_privateField       underscore prefix : clearly tell everyone it's private
```


SQL_column_name_like_this_snake_case  

File names and Folder names and Paths to folder

        C:\Parent\Child\file1.txt    Path 

            Avoid spaces always  

            "Strings with spaces always enclosed in quotes"

 html-web-page-always-write-like-this-kebab-case.html

    %20 means someone has put space in html page (not good!)



# Constructor

```cs
Class MyClass{
    private string _NINO;
    public string MyName {get;set;}
    public string DateOfBirth {get;set;}
}

    // instantiate
    var instance01 = new MyClass();       new keyword : invoking (calling) a special method
                                          called the CONSTRUCTOR METHOD

                                          CONSTRUCTOR : use it when constructing a new object
```



```cs
using System;

namespace lab_09_constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            var merc01 = new Mercedes("CHASIS1234ABC","Silver",2500); // calling default constructor
            var merc02 = new Mercedes();
        }
    }


    class Mercedes
    {
        private string engineChassisID;
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

    }

    class A104 : AClass
    {
       
    }


}




```


Constructors are NOT INHERITED SO CHILD CONSTRUCTORS HAVE TO BE EXPLICITLY CODED

```cs
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




```


## Constructor summary

Constructors just help us create new INSTANCES with MINIMUM OF HARD WORK
They are NOT INHERITED
Default one is BLANK and is present initially.  Must add it in if we create our own constructor and still want the default one present.



# Overloading

Method01(){}

Method01(int x){}

Method01(string y){}

Method01(int x, string y){}

                            OVERLOADS OF SAME METHOD

```cs
using System;

namespace lab_10_overloading
{
    class Program
    {
        static void Main(string[] args)
        {

            Method01();
            Method01(100);
            Method01("hello");
            Method01(1000,"goodbye");
        }

        static void Method01() { Console.WriteLine("blank"); }

//    static void Method01(int x) { Console.WriteLine(x); }

            static void Method01(int x) { Method01(x, "some value");  }

        static void Method01(string y) { Console.WriteLine(y); }

        static void Method01(int x, string y) { Console.WriteLine(x + " " + y); }


    }
}



```



# Polymorphism

Interviews : favourite question
    What are the 4 pillars of OOP?
        1. Inheritance   Parent=> Child        class Child : Parent {}
        2. Encapsulation   private keyword to hide NINO data / engineChassisID
        3. Abstraction   Public Getter/Setter methods to access and 
                            manipulate private data

             Picture

                Driver           Accelerator                Encapsulated
                                  Pedal                     Combustion Engine

                  driver is 'abstracted' away from engine by middle layer
                            (accelerator pedal)


                instance           public get/set           private field
                                    property
        4. Polymorphism


Polymorphism

    Picture : Family

        Parents : virtual HaveAParty(){   // INVITE FRIENDS : DINNER PARTY }
                virtual ==> can override this idea if you want (optional)

        Child5yrs : override HaveAParty() {  // bouncy castle }
               override ==> child can optionally replace method with own version

        Child 10yrs :  override HaveAParty()   // Quasar

        Child18yrs  :  override HaveAParty()  // Evening out 


    Minor side note : two keywords with similar uses here
                a) override
                b) new






```cs

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
```






# Working With Files

using System.IO;      Input/Output

```cs
using System;
using System.IO;
using System.Linq;

namespace lab_13_files
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("===Just a single line of text===\n\n");
            if (File.Exists("myFile.txt"))
            {
                var string1 = File.ReadAllText("myFile.txt");
                Console.WriteLine(string1);
            }

            File.WriteAllText("output.txt", "some data to be saved");

            Console.WriteLine("\n===Save multiple lines===\n");

            File.WriteAllText("multiplelines.txt", "some\ndata\non\ndifferent\nlines");
            Console.WriteLine(File.ReadAllText("multiplelines.txt"));

            File.WriteAllText("multiplelines.txt", "some" + Environment.NewLine +
                    "text" + Environment.NewLine + "here");
            Console.WriteLine(File.ReadAllText("multiplelines.txt"));

            Console.WriteLine("=== Saving Arrays To Multiple Lines");

            string[] myArray = new string[] { "some", "data", "in", "multiple", "lines" };
            File.WriteAllLines("multiLineFile.txt", myArray);
            // read it back
            var outputArray = File.ReadAllLines("multiLineFile.txt");
            // print array using fancy Lambda syntax
            Array.ForEach(outputArray, item => Console.WriteLine(item));


            Console.WriteLine("\n=== Logging ===\n");

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("myLogFile.log", $"Event happened at time {DateTime.Now}\n");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine(File.ReadAllText("myLogFile.log"));

        }
    }
}



```




# Adding Timing To Your App To Keep Track Of Execution Time


```cs
using System;
using System.Diagnostics;
using System.IO;

namespace lab_14_stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();

            var counter = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                counter++;
            }

            var b = 0b_1010_1010_1010;
            var hex = 0x_ff_ee_dd_cc_bb;

            s.Stop();

            Console.WriteLine(s.Elapsed + " seconds");
            Console.WriteLine(s.ElapsedMilliseconds + " ms");
            Console.WriteLine(s.ElapsedTicks + " ticks which are 10-7 seconds");
        }
    }
}

```

# How To Crash Your Computer

```cs
for(int i=0;i<10;i++)
{
    var path = $"C:\\scripts\\{DateTime.Now.ToLongDateString()}_{i}.txt";
    Console.WriteLine(path);
    File.AppendAllText(path, "some text");
}

```


# Rabbit Tests

Let's add some tests to our Rabbit Explosion app


```cs
        [TestCase(1000,20)]
        public void TestRabbitExplosion(int populationLimit,int expectedYears)
        {
            // arrange

            // act
            var actualYears = just_do_it_11_rabbit_explosion_test.Rabbit_Exponential_Growth(populationLimit);
            // assert
            Assert.AreEqual(expectedYears, actualYears);
        }

```





# OOP Continued

# Abstract Classes

So far we have

    Class Mercedes{                             class is BLUEPRINT/TEMPLATE FOR NEW OBJECTS

        private int `_privateField`;             field (private, encapsulated)                 

        public string Name {get;set;}            property (Public, provides the abstraction
                                                        layer in OOP 4 pillars)

        public void DoThis(){}                   method : Verb : Action code

        public Mercedes(){}                      constructor : same name as class
    }


    var instance = new Mercedes();              instance = new object FROM CLASS 

    A normal class is called a 'CONCRETE' class because we can create REAL OBJECTS 
                (REAL INSTANCES) from it.


## Mind Picture For Abstract Classes

Think about a holiday in planning

    abstract class Holiday{

        public void TravelPlans(){}

        public void PlacesToVisit(){ cw("This list is now complete"); }

        public void Activities(){ cw("All Activities Planned Out"); }

                                |---- CODE IMPLEMENTATION-----------|

    }    

    One method has NO CODE IMPLEMENTATION (NO CODE 'BODY')

        This method is 'ABSTRACT' because it exists but has no code implementation

            public abstract void TravelPlans();


    Solution is to derive a SUB-CLASS and INHERIT from ABSTRACT class

        PARENT : ABSTRACT      public abstract void TravelPlans();

        CHILD  :               public override void TravelPlans(){}


```cs
using System;

namespace lab_15_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // var h = new Holiday();
            var h = new HolidayWithTravel();
        }
    }

    abstract public class Holiday
    {
        public abstract void Travel();

        public void Places() { Console.WriteLine("Visiting Vienna, Salzburg"); }

        public void Activities() { Console.WriteLine("Skiiing, Walking, Fishing"); }
    }

    public class HolidayWithTravel : Holiday
    {
        public override void Travel() { Console.WriteLine("By Train Eurostar Then Hire A Car"); }
    }

}
```



# Sealed Classes

When dealing with security, it might not be a good idea that people can inherit from a secure class but then introduce vulnerabilities.

Think car engine : seal inside secure chassis so amateurs don't mess up the engine and cause
accidents

Think CPU : discourage overclocking

sealed class Security{
    
}

// cannot inherit from this


# Extending A Sealed Class

string is a sealed class with lots of methods like this one

```cs
string x = "Hello World";
if (x.StartsWith("hello"))
{
    Console.WriteLine("world");
}
```

Imagine we want our own custom string method

Let's build one

```cs
public static class AddingToStrings{
    public static void AmazingExtraStringMethod(this string s){
        s = s + "--->add your comment ";
    }
}


    public static class AddingToStrings
    {
        public static string AmazingExtraStringMethod(this string s)
        {
            Console.WriteLine("Changing string");
            s = s + "--->add your comment ";
            return s;
        }
    }
```




# WPF application

With this course we are going to have 3 areas of learning

    CONSOLE : MOST OF LEARNING HERE!  CORE WORK

    WPF     : SCREEN WHICH CAN PLACE OBJECTS EG : CRUDE APP

                    GOAL 1) BUSINESS INTERFACE
                         2) CANVAS : SIMPLE IMAGES FOR GAME (CRUDE)

                ((WINDOWS FORMS WERE BEFORE WPF))

    WEBSITES : FOCUS ON BUSINESS STYLE APPLICATION
                FUNCTIONING DATA ETC
                    A)  ASP REGULAR WEBSITE
                    B)  MVC WEBSITE 

WPF Windows Presentation Foundation

    xml skeleton for GUI
    C# code behind

            XML is a TEXT FILE into which we can put MEANINGFUL, STRUCTURED DATA
                EXTENSIBLE MARKUP LANGUAGE

                <root>
                    <row>
                        <col attribute="dataherealso">data</col>
                    </row>
                    <row>
                        <col attribute="dataherealso">data</col>
                    </row>
                                        <row>
                        <col attribute="dataherealso">data</col>
                    </row>
                </root>

            Microsoft LOVES XML.

            Everyone else loves JSON











































# Random
Comment = Control K C
Uncomment = Control K U


This is a big mistake