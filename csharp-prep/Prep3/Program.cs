using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNum = randomGenerator.Next(1, 101);
        int guess = -1;
        while (magicNum != guess) { 
            Console.Write("What is your guess? ");
            string guessAnswer = Console.ReadLine();
            guess = int.Parse(guessAnswer);  
            if (guess > magicNum) {
                Console.WriteLine("Lower");
            }
            else if (guess < magicNum) {
                Console.WriteLine("Higher");
            }
            else {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}