using System;

namespace HelloWorld { 
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello .Net Developers");
            Console.WriteLine("\nLearning Variables ....\n");


            //// 1 byte is made up of 8 bits 00000000 - these bits can be used to store a number as follows
            // //// Each bit can be worth 0 or 1 of the value it is placed in
            // ////// From the right we start with a value of 1 and double for each digit to the left
            // //// 00000000 = 0
            // //// 00000001 = 1
            // //// 00000010 = 2
            // //// 00000011 = 3
            // //// 00000100 = 4
            // //// 00000101 = 5
            // //// 00000110 = 6
            // //// 00000111 = 7
            // //// 00001000 = 8

            // 1 byte (8 bit) unsigned, where signed means it can be negative
            byte myByte = 255;
          
            // 1 byte (8 bit) signed, where signed means it can be negative
            sbyte mySbyte = 127;
            sbyte mySecondSbyte = -128;
            Console.WriteLine($"Byte: {myByte}, Signed Byte: {mySbyte}, Signed MySecondByte: {mySecondSbyte}");

            // 2 byte (16 bit) unsigned, where signed means it can be negative
            ushort myUshort = 65535;

            // 2 byte (16 bit) signed, where signed means it can be negative
            short myShort = -32768;
            Console.WriteLine($"Unsigned Short: {myUshort}, Signed Short: {myShort}");

            // 4 byte (32 bit) signed, where signed means it can be negative
            int myInt = 2147483647;
            int mySecondInt = -2147483648;

            Console.WriteLine("Signed Int: " + mySecondInt, " Unsigned Int: " + myInt);

            // 8 byte (64 bit) signed, where signed means it can be negative
            long myLong = -9223372036854775808;
            Console.WriteLine($"Long can be signed or unsigned. It's 8 byte (64 bit): {myLong}");


            // 4 byte (32 bit) floating point number
            float myFloat = 0.751f;
            float mySecondFloat = 0.75f;
            Console.WriteLine("Float is 4 byte (32 bit) floating point number.");
            Console.WriteLine(myFloat - mySecondFloat);

            // 8 byte (64 bit) floating point number
            double myDouble = 0.751;
            double mySecondDouble = 0.75d;
            Console.WriteLine("Float is 8 byte (64 bit) floating point number.");
            Console.WriteLine(myDouble - mySecondDouble);

            // 16 byte (128 bit) floating point number
            decimal myDecimal = 0.751m;
            decimal mySecondDecimal = 0.75m;
            Console.WriteLine("Float is 16 byte (128 bit) floating point number.");
            Console.WriteLine(myDecimal - mySecondDecimal);


            string myString = "Hello World";
            string myStringWithSymbols = "!@#$@^$%%^&(&%^*__)+%^@##$!@%123589071340698ughedfaoig137";
            Console.WriteLine(myString);
            Console.WriteLine(myStringWithSymbols);

            bool myBool = true;
            Console.WriteLine("Is Bool: " + myBool);

            // In Summary, all the types in C# are - byte, sbyte (signed), int (can be signed/unsigned), long (can be signed/unsigned), ushort (unsigned), short (signed), float, decimal, double (can be signed/unsigned), string, bool
        }
    }
}
