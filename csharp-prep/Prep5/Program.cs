using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome() {
            Console.WriteLine("Welcome to the program!");
        }
        static string PromptUserName() {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            return name;
        }
        static int PromptUserNumber() {
            Console.Write("What is your favorite number? ");
            string numberAnswer = Console.ReadLine();
            int number = int.Parse(numberAnswer);
            return number;
        }
        static int SquareNumber(int inputNum) {
            int squareNum = inputNum * inputNum;
            return squareNum;
        }
        static void DisplayMessage(string inputName, int inputSquare) {
            Console.WriteLine($"{inputName}, the square of your number is {inputSquare}");
        }
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int userSquare = SquareNumber(userNumber);
        DisplayMessage(userName, userSquare);
    }
}