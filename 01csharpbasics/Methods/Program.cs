using System;
using System.Numerics;

public class Program
{
    static void Main(string[] args)
    {

        int[] num = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        Console.WriteLine($"Sum: {GetSum(num)}");

        int n = 16;
        int r = 3;

        Console.WriteLine($"The factorial of {n} = {Factorial(n)}");

        //use string "perm" or "comb" to specify if you want to do permuation or combination respectively
        Console.WriteLine($"P({n},{r}) = {PermutationCombination("perm", n, r)}");
        Console.WriteLine($"C({n},{r}) = {PermutationCombination("comb", n, r)}");

    }


    static private long GetSum(int[] n)
    {

        long sum = 0; // increment counter
        for (int i = 0; i < n.Length; i++)
        {
            sum += n[i];
        }

        return sum;

    }

    static private BigInteger Factorial(int n)
    {

        if (n < 1)
        {
            return 1;
        }

        BigInteger fact = 1;

        for (int i = 1; i <= n; i++)
        {
            fact *= i;
        }

        return fact;

    }

    // permutation = n! / (n-r)! - where n is the number of things to choose from, and r is what we choose from n.No repetition
    // combination = n! / r!(n-r)!
    static private BigInteger PermutationCombination(string PC, int n, int r)
    {
        PC = PC.ToLower();

        if (PC == "perm")
        {
            return Factorial(n) / Factorial(n - r);
        }

        else if (PC == "comb")
        {
            return Factorial(n) / (Factorial(r) * Factorial(n - r));
        }

        else
        {
            throw new ArgumentException("Invalid input. Use 'perm' or 'comb' for permutation or combination");
        }

    }
}