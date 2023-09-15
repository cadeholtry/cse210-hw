using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade as a percentage? ");
        string userInput = Console.ReadLine();
        int percentage = int.Parse(userInput);
        string letter = "F";
        if (percentage > 89) {
            letter = "A";
        }
        else if (percentage > 79) {
            letter = "B";
        }
        else if (percentage > 69) {
            letter = "C";
        }
        else if (percentage > 59) {
            letter = "D";
        }
        Console.WriteLine($"Your grade is {letter}.");
        if (percentage > 69) {
            Console.WriteLine("Congrats! You passed!");
        }
        else {
            Console.WriteLine("You failed! Better luck next time!");
        }
    }
}