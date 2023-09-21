using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int number = -1;
        while (number != 0)
        {
            Console.Write("Enter a number (0 to quit): ");
            string numberAnswer = Console.ReadLine();
            number = int.Parse(numberAnswer);
            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        int sum = 0;
        foreach (int eachNumber in numbers)
        {
            sum += eachNumber;
        }
        Console.WriteLine($"The sum is: {sum}");
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        int max = numbers[0];
        foreach (int eachNumber in numbers)
        {
            if (eachNumber > max)
            {
                max = eachNumber;
            }
        }
        Console.WriteLine($"The max is: {max}");
    }
}