using System;

namespace GuessingGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Generate random number and assign it to a variable.
            int randomNumber = new Random().Next(1, 101);

            // Welcome users
            Console.WriteLine("Welcome to Guess Game!");

            // Count each guess and stop if attemtps reach to 7.
            int guess;
            int countGuess = 0;
            Boolean userWin = false;

            // Validate number function and returns number
            Boolean validateInput(String userInput){

                if(int.TryParse(userInput, out guess)) {
                    return true;
                } else {
                    return false;
                }
            }

			// Evaluate answer function to determine WIN or LOST
            String evaluateAnswer() {
                if(guess == randomNumber) {
                    userWin = true;
                    return $"YOU WIN. The number is { randomNumber } and your guess is { guess } :) \n";
                } else if(countGuess == 7){
                    return $"\nYou Lost! You have tried { countGuess } times with no luck :( Random Number is { randomNumber } \n";
                }
                else {
                    if (guess < randomNumber)
                    {
                        return $"Guess is too low! You have attempted { countGuess } times. \n";
                    } else {
						return $"Guess is too high! You have attempted { countGuess } times. \n";
					}
				}
            }

            // Play game function. calls validateInput and evaluateAnswer methods.
            void playGame()
            {
                while (countGuess != 7 && userWin != true)
                {
					// Ask user for input
					Console.WriteLine("Please enter your guess between 1 and 100!");

					// Increase by one each time student attempt an answer
					countGuess++;

                    var userInput = Console.ReadLine();

                    if (validateInput(userInput))
                    {
                        Console.WriteLine(evaluateAnswer());
                    }
                    else
                    {
                        Console.WriteLine("Not a valid number! You also lost an attempt.");
                    }
                }
            }

            playGame();

            String playAgain = "";

            // Reset game function to start again or quite game
            void resetGame(){
				Console.WriteLine("Do you want to play again? Y or N");
				userWin = false;
                countGuess = 0;
				playAgain = Console.ReadLine().ToUpper();  
            }

            resetGame();


            // Keep playing if user is interested.
            while(playAgain == "Y") {
				playGame();
				resetGame();
			}
		}
    }
}
