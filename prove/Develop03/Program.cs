using System;

class Program
{
    static void Main(string[] args)
    {
        // Some setup variables so that the program does what I want
        // quit is so that the program has something to check for the while loop
        int quit = 1;

        // initialDisplay allows for the program to display the full scripture first
        // while also having the loop that happens every time enter is pressed
        bool initialDisplay = true;

        // Initial scripture setup and first display before the loop
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.");
        scripture.DisplayScripture();

        while (quit == 1) {
            if (initialDisplay == false) {
                // HideWords iterates through the list of Words and randomly updates
                // the visibility of SPECIFICALLY vivible words to be invisible

                // I did in fact do the above and beyond thing!
                scripture.HideWords();

                // Display the scripture, basically just like iterates through the words 
                // and displays them. This is where the words are checked and the invisible
                // words are generated.
                scripture.DisplayScripture();

                // FinalCheck iterates through the list of Words and shuts down the
                // program if none of the words are visible.
                scripture.FinalCheck();
            }

            // Make sure the previously skipped stuff is no longer skipped each loop
            initialDisplay = false;

            // Get user input and stop the program if quit is typed.
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            Console.Write("> ");
            string userInput = Console.ReadLine();
            if (userInput == "quit") {
                quit = 2;
            }
        }
    }
}