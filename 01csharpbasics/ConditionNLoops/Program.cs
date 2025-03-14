using System;

public class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Conditional Statements ...\n");
        // Conditional Statements

        int num1 = 5;
        int num2 = 10;

        if (num1 < num2 && (num1 * 2) == num2)
        {
            Console.WriteLine(Math.Pow(num1, 4));

        }
        else
        {
            Console.WriteLine($"Add:  {num1 + num2}");
        }

        string s = "cow";
        string r = "Cow";

        if (s == r)
        {
            Console.WriteLine("Equal");

        }
        else if (s == r.ToLower())
        {
            Console.WriteLine("Equal without case sensitivity");
        }

        else
        {
            Console.WriteLine("not equal");
        }

        // using switch statement. Similar to if, else if, else
        switch (s)
        {
            case "cow":
                Console.WriteLine("Equal");
                break;
            case "Cow":
                Console.WriteLine("Not Equal");
                break;
            default:
                Console.WriteLine("Default case");
                break;
        }

        Console.WriteLine("\nLoops....\n");


    }
}