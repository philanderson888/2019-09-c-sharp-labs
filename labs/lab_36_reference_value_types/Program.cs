using System;
using System.Collections.Generic;

namespace lab_36_reference_value_types
{
    class Program
    {
        static void Main(string[] args)
        {
            // PRIMITIVE TYPE : int, bool, char, struct
            // STORED IN FAST STACK MEMORY
            // values stored with declaration in live, fast code.
            // destroyed immediately as well (if local variable) 
            // == VALUE TYPES as VALUE stored in STACK MEMORY with declaration
            // var x=10;   x and 10 stored on STACK
            // COPY OF VALUE TYPE IS INDEPENDENT
            decimal x = 10;  // 128 bit
            decimal y = x;
            x = 1000;
            y = 3333;
            Console.WriteLine($"x is {x} and y is {y}");

            // Pass x,y into a method
            DoThis(x, y);
            Console.WriteLine($"x is {x} and y is {y}");
            // pass x,y BY REFERENCE into DoThisPermanently(x,y);
            DoThisPermanently(ref x, ref y);
            Console.WriteLine($"x is {x} and y is {y}");



            // reference types
            // value types are primitives eg int, held on FAST STACK
            // reference types are LARGE OBJECTS
            // SHORTCUT = POINTER held on FAST STACK
            // ACTUAL OBJECT held on SLOWER HEAP (LARGER MEMORY)
            // stack                             heap
            //  int x=10
            //  list<string> mylist -----------> {"one","two"}

            // COPY REFERENCE TYPE : BY DEFAULT YOU ONLY COPY THE POINTER !!!!
            var myArray = new int[] { 100, 200, 300 };
            var myArray2 = myArray; // copy pointer only!!! NOT A NEW OBJECT IN HEAP MEMORY

            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));
            myArray[2] = 5000;
            myArray2[1] = 14000;
            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));

            // REFERENCE TYPES NATURALLY ARE TREATED AS GLOBAL WHEN PASSED INTO A
            // METHOD
            var myList = new List<string>() { "first", "second" };
            DoThisToMyList(myList);
            Console.WriteLine(String.Join(",",myList));

        }

        // method to change x, y : x=> x*x and y=>y*y*y
        static void DoThis(decimal x, decimal y)
        {
            x = x * x;
            y = y * y * y;
            Console.WriteLine($"local x is {x} and y is {y}");
        }

        static void DoThisPermanently(ref decimal x, ref decimal y)
        {
            x = x * x;
            y = y * y * y;
            Console.WriteLine($"ref x is {x} and y is {y}");
        }

        static void DoThisToMyList(List<string> list)
        {
            list.Add("hello");
            list.Add("sir");


        }

    }
}
