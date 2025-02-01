using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
        Console.WriteLine("What is the magic number? ");
        int magic = int.Parse(Console.ReadLine());
        int guess = 0;

        while (guess != magic)

        {Console.WriteLine("What is your guess?");
        guess = int.Parse(Console.ReadLine());

        if (guess > magic)
        {
            Console.WriteLine("lower");
        }

        else if (guess < magic)
        {
            Console.WriteLine("higher");
        }

        else
        {
            Console.WriteLine("You guessed the number!");
        }
    }

    
}}