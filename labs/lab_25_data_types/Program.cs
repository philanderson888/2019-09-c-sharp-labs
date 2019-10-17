using System;

namespace lab_25_data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            // integers
            byte bmin = 0;
            byte bmax = 255;      

            byte bmin_in_binary = 0b_00000000;     // 0
            byte bmax_in_binary = 0b_11111111;  // 255

            byte bmin_in_hex = 0x_00;
            byte bmax_in_hex = 0x_ff;   // f=1111  which converts to 15 in decimal

            // byte bnegative_is_invalid = -1;


            // letters are also stored as numbers
            char letter_01 = 'a';
            Console.WriteLine(letter_01);
            Console.WriteLine((int)letter_01);

            // CHECK OUT ASCII TABLE WHICH IS PRIMITIVE COMPUTERS THE BASIC CHARACTER SET

            // Be aware a STRING is stored as an ARRAY OF CHARACTERS

            string s = "Hello";
            char[] s2 = "Hello".ToCharArray();

            Console.WriteLine($"First letter has index 0 ie {s[0]} and {s2[0]}");


            // whole numbers
            // int    
            var numberOfAnyType = 27;
            // int is 32 bits   10101010   10101010  10101010  10101010
            // but!  one bit stored the 'sign' which is either + or -
            // so int has 31 bits for number storage
            // POSITIVE 0 to max-1          0, 1, 2,  3
            // NEGATIVE -1 to max           -1,-2,-3,-4
            Console.WriteLine(int.MaxValue);  //  check out google - does this make sense??
            // 2,147,483,647
            Console.WriteLine(int.MinValue);
            // ..........648   is 2 to power what 31

            // short 
            short short01 = 25; // 16 bits
            // long   
            long long01 = 2345234523452345;  // 64 bits

            short short02 = 12345;
            int int01     = 1234567890;
            long long02   = 1234567890123456789L;

            // DECIMAL NUMBERS
            // float 32 bit
            float f = 1.23F;
            // double 64
            double double01 = 1.23D;
            // decimal 128 bits
            decimal decimal01 = 1.23M;

            // floats and doubles are NOT EXACT EVER BECAUSE CONVERT FROM BINARY TO DECIMAL 
            double total = 0;
            for(int i = 0; i < 8192; i++)
            {
                total += 0.7;
            }
            Console.WriteLine(total);


            decimal total02 = 0M;
            for (int i = 0; i < 8192; i++)
            {
                total02 += 0.7M;
            }
            Console.WriteLine(total02);

            // CARE - WITH MONEY - can you avoid errors though by just multiplying by 100, doing
            // calculation, then dividing by 100 to get answer?

            // Positive numbers only  // UNSIGNED MEANS PURE 32 BITS FOR NUMBER
            uint positiveinteger = 500;
            Console.WriteLine(uint.MaxValue);   // 2 to power 32

            // Operators

            // a+b=c    Expression
            // a, b     Operands
            // +        Operator

            // Unary (one input)
            // Increment
            int x = 10;
            x++;
            ++x;
            // both of the above add 1
            // in general just use x++; and use if possible on separate line
            int y1 = 1000;
            int y2 = 1000;
            int z1 = y1++;             // z1 = 1000 then increment y1 to 1001
            int z2 = ++y2;             // z2 = (increment y2 first to 1000)
            Console.WriteLine(z1);
            Console.WriteLine(z2);

            // NOT 
            Console.WriteLine(!true);  // false
            Console.WriteLine(!!true);  // true

            // Binary (two inputs)
            // modulus
            // integer division : take care because int/int = int
            Console.WriteLine(9/4);
            // Create a fractional answer it's easy
            // 9/4 =    2 remainder 1     =    2  1/4
            // integer part : easy : divide integers
            // fractional part : use modulus (remainder) operator
            Console.WriteLine(9%4);  // 1

            // Proper division : one number has to be non-integer

            // Ternary operator
            // if(condition) ? return this if true : return this if false;
            Console.WriteLine(     (10>4)   ?  "high" :  "low"    );
            Console.WriteLine(     (10 < 4) ? "high"  : "low"     );


            // Nullable 
            int number = 100;
            int? number2 = 1000;
            // number2 is useful if we read from database and it's possible
            // the box is blank so returns NULL
            number2 = null;


            // Null coalesce operator : shorthand for 
            Console.WriteLine("somevalue"??"returnthisifnull"); //somevalue
            Console.WriteLine(null??"returnthisifnull");

            // Default value
            int somenumber = default;  // assign 0
            int? somenumber2 = default; // null
            if (somenumber2 == null) Console.WriteLine( "it's null");// it's null

            // bit shift (interest only)
            //                       8421
            // watch this    binary  1010 is ?? decimal 8+0+2+0 is 10(decimal)
            // shift binary to right >> make half in size  1010=>101 which is 5
            // shift        to left  << make double        1010=>10100 ie 20
            Console.WriteLine(0b_1010>>1);  // 5
            Console.WriteLine(0b_1010<<1);  // 20

        }
    }
}
