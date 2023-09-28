using System;

namespace NumbersGameE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to the guessing game. I hope you have fun.\n\nPlease enter your name:");
            Console.ResetColor();
            string playerName = Console.ReadLine();
            Console.WriteLine($"Hi! \"{playerName}\" Remember You have a limited number of attempts.\n\n");

            //I start by declaring a boolean variable playAgain and initializing it to true.
            //This variable is used to control the game loop. As long as playAgain is true,
            //the game will continue to prompt the player for a game level and attempt to guess the number.
            bool playAgain = true;
            while (playAgain)
            {
                Console.WriteLine("Please choose your level:\n1. Easy\n2. Normal\n3. Hard");
                string gameLevel = Console.ReadLine();
                
                //I set the maxNumber and maxAttempts variables based on the chosen game level.
                //For example, if the player chooses level 1 (easy),
                //the maxNumber will be set to 10 and the maxAttempts will be set to 7.
                int maxNumber;
                int maxAttempts;
               
                // Use a switch statement to set the maximum number and maximum attempts based on the chosen game level
                switch (gameLevel)
                {
                    case "1":
                        maxNumber = 10; // Maximum number for easy level
                        maxAttempts = 7; // Maximum attempts for easy level
                        
                        break;
                    case "2":
                        maxNumber = 25; // Maximum number for normal level
                        maxAttempts = 5; // Maximum attempts for normal level
                        break;
                    case "3":
                        maxNumber = 50; // Maximum number for hard level
                        maxAttempts = 3; // Maximum attempts for hard level
                        break;
                    default:
                        // Output error message for invalid level input
                        Console.WriteLine("Invalid input. Please choose a valid level."); 
                        continue;
                }
                // Set color to Red
                Console.ForegroundColor = ConsoleColor.Red;
                // Output message with the selected game level
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine($"|You have selected the level {gameLevel}. Good luck \"{playerName}\"!|" );
                Console.WriteLine("------------------------------------------------");
                Console.ResetColor(); // Reset color to default

                //Generate a random number within the specified range
                //This line declares and initializes an integer variable named machineRandomNumber.
                //It uses the Next() method of the randomNumber object to generate a random number between 0 (inclusive) and maxNumber (exclusive).
                //The generated random number is then assigned to machineRandomNumber.
                int machineRandomNumber = randomNumber.Next(maxNumber);
                
                //This line declares and initializes an integer variable named attempts with the value 0.
                //This variable keeps track of the number of attempts the player has made to guess the correct number.
                int attempts = 0;

                //This line declares and initializes a boolean variable named isPlayerWinner with the value false.
                //This variable is used to determine whether the player has won the game.
                bool isPlayerWinner = false;

                while (attempts < maxAttempts)
                {
                    if ( attempts == maxAttempts - 1)//This line checks if the current attempt is the last attempt.
                                                     //If it is, the following statements inside the if block will be executed.
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n!!!!This is your last attempt. Guess well!!!!\n");
                        Console.ResetColor();
                    }
                    Console.WriteLine($"Attempt {attempts + 1} - Enter your guess:");
                    
                    int playerGuessingNumber;

                    //This line reads the player's input from the console.
                    //It then attempts to parse the input as an integer using int.TryParse(). If the parsing is successful,
                    //the parsed value is assigned to playerGuessingNumber, and isValidGuess is set to true. Otherwise, isValidGuess is set to false.
                    bool isValidGuess = int.TryParse(Console.ReadLine(), out playerGuessingNumber);

                    if (!isValidGuess)// This line checks if the player's input was not a valid integer.
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Invalid input. Please enter a valid number."); // Output error message for invalid guess input
                        Console.ResetColor();
                        continue;
                    }

                    if (CheckGuess(playerGuessingNumber, machineRandomNumber))
                    {
                        isPlayerWinner = true;
                        break;
                    }

                    attempts++;
                }

                if (isPlayerWinner)//tatement checks whether the isPlayerWinner variable is true or false.
                                   //If it is true, it means the player has won the game.
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Wohoo! You did it"); // Output success message for winning the game
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\nSorry, you couldn't guess the number. Better luck next time!"); // Output failure message for losing the game
                    Console.ResetColor();

                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDo you want to play again? (Y/N)"); // Prompt user to play again
                string playAgainInput = Console.ReadLine();
                Console.ResetColor();


                if (!playAgainInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    playAgain = false;
                }

                Console.WriteLine("Goodbye. It was fun to playing with you. I hope you come back again");
            }
        }

       //The CheckGuess method takes two parameters: playerGuessingNumber and machineRandomNumber.
       //It calculates the difference between the player's guess and the randomly generated number
      //using the line int difference = playerGuessingNumber - machineRandomNumber;.
     //The method then checks if the player's guess is equal to the randomly generated number
     //using the line if (playerGuessingNumber == machineRandomNumber). If the guess is correct, the method returns true.
        static bool CheckGuess(int playerGuessingNumber, int machineRandomNumber)
        {
            int difference = playerGuessingNumber - machineRandomNumber;
            if (playerGuessingNumber == machineRandomNumber)
            {
                return true; // Return true if player guesses the correct number
            }
            else if (playerGuessingNumber > machineRandomNumber)
            {
                if (difference <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Close, but not quite there!"); // Output message when player is close to the correct number
                    Console.ResetColor();

                }
                else if (difference <= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You're getting warmer!"); // Output message when player is getting closer to the correct number
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, you guessed too high!"); // Output message when player guesses a number higher than the correct number
                    Console.ResetColor();

                }
            }
            else if (playerGuessingNumber < machineRandomNumber)
            {
                if (difference <= 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You were one step closer to winning!"); // Output message when player is close to the correct number
                    Console.ResetColor();

                }
                else if (difference <= 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("I think you will make it!"); // Output message when player is getting closer to the correct number
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, you guessed too low!"); // Output message when player guesses a number lower than the correct number
                    Console.ResetColor();

                }
            }
            return false;
        }
    }
}