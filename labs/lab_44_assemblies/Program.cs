using System;
using System.Reflection;

namespace lab_44_assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            // use INT type as an example
            var myType = typeof(int);
            // let's find DLL where INT LIVES IN WINDOWS
            // IE ASSEMBLY
            var myAssembly = Assembly.GetAssembly(myType);
            Console.WriteLine($"Assembly is called {myAssembly.GetName()}\n\n");
            Console.ReadLine();
            // CHECK OUT ALL OTHER TYPES IN SAME ASSEMBLY 
            // PRINT THEM OUT
            foreach(var type in myAssembly.GetTypes())
            {
                Console.WriteLine(type);
            }
        }
    }
}
