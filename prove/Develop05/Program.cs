using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int check = 1;
        List<Goal> goals = new List<Goal>();
        int points = 0;
        while (check == 1) {
            Console.WriteLine($"\nCurrent points: {points}\n");
            Console.WriteLine("Menu Options:\n  1. Create New Goal\n  2. List Goals\n  3. Save Goals\n  4. Load Goals\n  5. Record Event\n  6. Quit");
            Console.WriteLine("Select a choice from the menu: ");
            string userInput = Console.ReadLine();
            if (userInput == "1") {
                Console.WriteLine("The types of Goals are:\n  1. Simple Goal\n  2. Eternal Goal\n  3. Checklist Goal");
                Console.WriteLine("What type of goal would you like to create? ");
                string goalChoice = Console.ReadLine();
                if (goalChoice == "1") {
                    Console.WriteLine("What is the name of your goal? ");
                    string name = Console.ReadLine();
                    Console.WriteLine("What is a short description of the goal? ");
                    string description = Console.ReadLine();
                    Console.WriteLine("What is the amount of points associated with this goal? ");
                    int point = int.Parse(Console.ReadLine());
                    goals.Add(new SimpleGoal("Simple Goal", name, description, point, false));
                }
                else if (goalChoice == "2") {
                    Console.WriteLine("What is the name of your goal? ");
                    string name = Console.ReadLine();
                    Console.WriteLine("What is a short description of the goal? ");
                    string description = Console.ReadLine();
                    Console.WriteLine("What is the amount of points associated with this goal? ");
                    int point = int.Parse(Console.ReadLine());
                    goals.Add(new EternalGoal("Eternal Goal", name, description, point, false));
                }
                else if (goalChoice == "3") {
                    Console.WriteLine("What is the name of your goal? ");
                    string name = Console.ReadLine();
                    Console.WriteLine("What is a short description of the goal? ");
                    string description = Console.ReadLine();
                    Console.WriteLine("What is the amount of points associated with this goal? ");
                    int point = int.Parse(Console.ReadLine());
                    Console.WriteLine("How many times does this goal need to be accomplished for a bonus? ");
                    int times = int.Parse(Console.ReadLine());
                    Console.WriteLine("What is the bonus for accomplishing it that many times? ");
                    int bonusPoints = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal("Checklist Goal", name, description, point, false, bonusPoints, times, 0));
                }
            }
            else if (userInput == "2") {
                int number = 1;
                Console.WriteLine("The goals are:");
                foreach (Goal goal in goals) {
                    string fullGoal = goal.WriteOutGoal();
                    Console.WriteLine($"{number}. {fullGoal}");
                    number += 1;
                }
            }
            else if (userInput == "3") {
                Console.WriteLine("What is the file name for the goal file? ");
                string fileName = Console.ReadLine();
                using (StreamWriter outputFile = new StreamWriter(fileName)) {
                    outputFile.WriteLine(points);
                    foreach (Goal goal in goals) {
                        outputFile.WriteLine(goal.GenerateStorageInfo());
                    }
                }
            }
            else if (userInput == "4") {
                Console.WriteLine("What is the file name for the goal file? ");
                string filename = Console.ReadLine();
                string[] lines = System.IO.File.ReadAllLines(filename);
                foreach (string line in lines) {
                    string[] parts = line.Split(",");
                    if (parts[0] == "Simple Goal") {
                        goals.Add(new SimpleGoal(parts[0], parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    }
                    else if (parts[0] == "Eternal Goal") {
                        goals.Add(new EternalGoal(parts[0], parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    }
                    else if (parts[0] == "Checklist Goal") {
                        goals.Add(new ChecklistGoal(parts[0], parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7])));
                    }
                    else {
                        points = int.Parse(parts[0]);
                    }
                }
            }
            else if (userInput == "5") {
                int number = 1;
                Console.WriteLine("The goals are:");
                foreach (Goal goal in goals) {
                    string goalName = goal.GetName();
                    Console.WriteLine($"{number}. {goalName}");
                    number += 1;
                }
                Console.WriteLine("What goal did you accomplish? ");
                int goalIndex = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine($"Congratulations! You have earned {goals[goalIndex].GetPoints()} points!");
                points += goals[goalIndex].GetPoints();
                Console.WriteLine($"You now have {points} points");
                goals[goalIndex].SetComplete();
            }
            else if (userInput == "6") {
                Console.WriteLine("Thank you for using this program!");
                check = 0;
            }
        }
    }
}