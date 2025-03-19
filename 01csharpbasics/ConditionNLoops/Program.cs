using System;

public class Program
{
    static void Main(string[] args)
    {
        // Quicly split a string
        string names = "Bisi, Pupo, Olami, Sam, Abike";
        string[] splittedName = names.Split(", ");
        Console.WriteLine($"My name is {splittedName[0]}");
        Console.WriteLine($"My name is {splittedName[1]}");
        //Console.WriteLine($"My name is {splittedName[2]}");
        //Console.WriteLine($"My name is {String.Join(",", splittedName[3..])}\n");

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

        // using foreach

        //foreach (string item in splittedName)
        //{
        //    Console.WriteLine(item);
        //}

        // for loops

        for (int i = 0; i < splittedName.Length; i++)
        {
            Console.WriteLine(splittedName[i]);

        }

        // print even numbers from 1-20
        //for (int i = 1; i <= 10; i++)
        //{
        //    string type = (i % 2 == 0) ? "Even Number" : "Odd Number";
        //    Console.WriteLine($"{type} : {i}");
        //}

        int[] n = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        List<int> evenN = new List<int>();
        List<int> oddN = new List<int>();

        foreach (int i in n)
        {
            if (i % 2 == 0)
            {
                evenN.Add(i);
            }
            else
            {
                oddN.Add(i);
            }

        }

        var result = false ? string.Join(", ", evenN) : string.Join(", ", oddN);
        Console.WriteLine($"Result: {String.Join(", ", result)}");
        //Console.WriteLine($"Even Numbers: {String.Join(", ", evenN)}");
        //Console.WriteLine($"Odd Numbers: {String.Join(", ", oddN)}");

        // for loop

        int count = 0;

        double startTime = DateTime.Now.TimeOfDay.TotalSeconds;

        for (int i = 0; i < n.Length; i++)
        {
            count += n[i];
        }

        double endTime = DateTime.Now.TimeOfDay.TotalSeconds;
        Console.WriteLine($"Elapsed Time using for loop: {endTime - startTime}");
        Console.WriteLine("Sum: " + count);

        // foreach

        int sum = 0;
        double startTime1 = DateTime.Now.TimeOfDay.TotalSeconds;

        foreach (int i in n)
        {
            sum += i;
        }

        double endTime1 = DateTime.Now.TimeOfDay.TotalSeconds;
        Console.WriteLine($"Elapsed Time using foreach: {endTime1 - startTime1}"); 
        Console.WriteLine("Sum: " + sum);

        // while loop
        int iWhile = 0;
        int xSum = 0;

        while (iWhile < n.Length)
        {
            xSum += n[iWhile];
            iWhile++;
        }

        Console.WriteLine($"XSum: {xSum}");

        // do while loop
        int iDoWhile = 0;
        int doSum = 0;

        do
        {
            doSum += iDoWhile;
            iDoWhile++; // stop at length-1
        }

        while (iDoWhile <= n.Length);

        Console.WriteLine($"DoSUM: {doSum}");










    }
}