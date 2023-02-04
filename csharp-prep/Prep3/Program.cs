using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        int number = rand.Next(1,100);
        int guess = 0;
        while (guess != number){
            Console.Write("\nWhat is your guess? ");
            guess = Int32.Parse(Console.ReadLine());
            if (guess > number){
                Console.WriteLine("\nLower");
            } else if (guess < number){
                Console.WriteLine("\nHigher");
            }
        }
        Console.WriteLine("\nYou guessed it!");
    }
}