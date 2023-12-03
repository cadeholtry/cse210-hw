using System;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        // Generate Map Info and disperse Bombs and Power Ups
        // I am generating 81 cells (9x9) with 10 maximum bombs, which is a standard 'Easy' minesweeper game
        int maxBombNum = 10;
        int gameLost = 0;
        int xValueGenerationHelper = 0;
        int yValueGenerationHelper = 0;
        string fileName = "Map.txt";
        Random random = new Random();
        using (StreamWriter outputFile = new StreamWriter(fileName)) {
            while (yValueGenerationHelper < 9) {
                if (maxBombNum != 0) {
                    int isBomb = random.Next(1,9);
                    if (isBomb == 1) {
                        outputFile.WriteLine($"{xValueGenerationHelper},{yValueGenerationHelper},bomb,false");
                        maxBombNum -= 1;
                    }
                    else {
                        outputFile.WriteLine($"{xValueGenerationHelper},{yValueGenerationHelper},blank,false");
                    }
                }
                else {
                    int isPowerUp = random.Next(1,40);
                    if (isPowerUp == 1){
                        outputFile.WriteLine($"{xValueGenerationHelper},{yValueGenerationHelper},powerup,false");
                    }
                    else {
                        outputFile.WriteLine($"{xValueGenerationHelper},{yValueGenerationHelper},blank,false");
                    }
                }
                xValueGenerationHelper += 1;
                if (xValueGenerationHelper == 9) {
                    xValueGenerationHelper = 0;
                    yValueGenerationHelper += 1;
                }
            }
        }
        // Now that we have the map information generated with bombs and power ups,
        // I am going to assign the different values Modules based on the bomb placements.
        // Unfortunately I came across a catch 22 in my program, so I have to do a work around.
        List<Module> modules = new List<Module>();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines) {
            string[] parts = line.Split(",");
            if (parts[2] == "blank") {
                modules.Add(new Blank(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], bool.Parse(parts[3])));
            }
            else if (parts[2] == "bomb") {
                modules.Add(new Bomb(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], bool.Parse(parts[3])));
            }
            else if (parts[2] == "powerup") {
                modules.Add(new PowerUp(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], bool.Parse(parts[3]), "ping"));
            }
        }
        // Here I am generating the proper numbers for each module, and then overwriting the previously generated
        // map with updated information to use later when displaying and assigning modules.
        using (StreamWriter outputFile = new StreamWriter(fileName)) {
            foreach (Module module in modules) {
                int currentXValue = module.GetXValue();
                int currentYValue = module.GetYValue();
                string moduleType = module.GetModuleType();
                int checkForBomb = 0;
                if (moduleType == "blank") {
                    foreach (Module bombCheck in modules) {
                        int checkXValue = bombCheck.GetXValue();
                        int checkYValue = bombCheck.GetYValue();
                        string checkType = bombCheck.GetModuleType();
                        if (((currentXValue == checkXValue) || (currentXValue == checkXValue + 1) || (currentXValue == checkXValue - 1)) && ((currentYValue == checkYValue) || (currentYValue == checkYValue + 1) || (currentYValue == checkYValue - 1)) && (checkType == "bomb")) {
                            checkForBomb = checkForBomb += 1;
                        }
                    }
                    if (checkForBomb > 0) {
                        module.SetNumCheck(checkForBomb);
                    }
                }
                string info = module.GetInformation();
                outputFile.WriteLine(info);
            }
        }
        // Now I make a new modules list for the newly generated information so that I can properly
        // display everything.
        List<Module> updatedModules = new List<Module>();
        string[] updatedLines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in updatedLines) {
            string[] parts = line.Split(",");
            if (parts[2] == "bomb") {
                updatedModules.Add(new Bomb(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], bool.Parse(parts[3])));
            }
            else if (parts[2] == "powerup") {
                int whichPower = random.Next(1,2);
                if (whichPower == 1) {
                    updatedModules.Add(new Ping(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], bool.Parse(parts[3]), "ping"));
                }
                else {
                    updatedModules.Add(new AutoFlag(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], bool.Parse(parts[3]), "autoflag"));
                }
            }
            else if (int.Parse(parts[4]) > 0) {
                updatedModules.Add(new Number(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], bool.Parse(parts[3]), int.Parse(parts[4])));
            }
            else {
                updatedModules.Add(new Blank(int.Parse(parts[0]), int.Parse(parts[1]), parts[2], bool.Parse(parts[3])));
            }
        }
        // Now that we have remade the list of items, its time to display the map and start the game
        int check = 0;
        while (check == 0) {    
            int displayHelper = 1;
            Console.Clear();
            foreach (Module updatedModule in updatedModules) {
                if ((updatedModule.GetModuleType() == "bomb") && (updatedModule.GetClicked() == true)) {
                    gameLost = 1;
                }
                if (displayHelper == 0) {
                    Console.WriteLine(updatedModule.DisplayModule());
                    displayHelper += 1;
                }
                else if ((displayHelper > 0) && (displayHelper < 8)) {
                    Console.Write(updatedModule.DisplayModule());
                    displayHelper += 1;
                }
                else if (displayHelper == 8) {
                    Console.Write(updatedModule.DisplayModule());
                    displayHelper = 0;
                }
            }
            if (gameLost == 1) {
                Console.WriteLine("You hit a Bomb!");
                System.Environment.Exit(1);
            }
            Console.WriteLine("Enter an X value (1-9): ");
            int xInput = (int.Parse(Console.ReadLine()) - 1);
            Console.WriteLine("Enter a Y value (1-9): ");
            int yInput = (int.Parse(Console.ReadLine()) - 1);
            foreach (Module checkModules in updatedModules) {
                if ((xInput == checkModules.GetXValue()) && (yInput == checkModules.GetYValue())) {
                    checkModules.OnClick();
                }
            }
        }
    }
}