
// MATH GAME PROJECT

/*
Requirements:
1) Create a game that asks a player the result of a math question. (9 x 9 = ?) Add a point in the case of a right answer.
2) Game needs to have at least 5 questions.
3) Answers to division questions should be integers only. (Don't offer 7/2)
4) Users should be presented with a menu to choose an operation.
5) Record previous game history in a list that the user can access from the menu. Results can be deleted when program closes.

Additional Challenges:
1) Implement levels of difficulty.
2) Add a timer that tracks how long it took to finish the game.
3) Create a "random game" where the operations presented are random.

*/


using MathGame;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Numerics;
using System.Security.Authentication;
using System.Threading.Tasks.Sources;


string menuSelection = "";
Game game = new Game();

Console.WriteLine("\nWelcome to the Math Game!");

do
{
    string readResult = "";

    Console.WriteLine("\nPlease select an option (1,2,3,4,5).");
    Console.WriteLine("1) Play!");
    Console.WriteLine($"2) Select Operation (currently {game.Operation}).");
    Console.WriteLine($"3) Select Difficulty (default {game.Difficulty}).");
    Console.WriteLine("4) View History.");
    Console.WriteLine("5) Exit.");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult;
    }

    switch (menuSelection)
    {
        case "1":

            game.PlayGame();

            break;

        case "2":
            Console.WriteLine("\nPlease select an operation (1,2,3,4).");
            Console.WriteLine("1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Random");
            readResult = Console.ReadLine();
            string operationSelection = readResult;
            switch (operationSelection)
            {
                case "1":
                    game.Operation = "Addition";
                    break;

                case "2":
                    game.Operation = "Subtraction";
                    break;

                case "3":
                    game.Operation = "Multiplication";
                    break;
                
                case "4":
                    game.Operation = "Division";
                    break;

                case "5":
                    game.Operation = "Random";
                    break;

                default:
                    Console.WriteLine("Sorry. Your input is invalid.");
                    break;
            }
            break;

        case "3":
            Console.WriteLine("\nPlease select a difficulty (1,2,3).");
            Console.WriteLine("1) Easy\n2) Medium\n3) Hard");
            readResult = Console.ReadLine();
            string difficultySelection = readResult;
            switch (difficultySelection)
            {
                case "1":
                    game.Difficulty = "Easy";
                    break;

                case "2":
                    game.Difficulty = "Medium";
                    break;

                case "3":
                    game.Difficulty = "Hard";
                    break;

                default:
                    Console.WriteLine("Sorry. Your input is invalid.");

                    break;
            }
            break;

        case "4":
            game.PrintGameHistory();
            break;

        case "5":
            Console.WriteLine("\nThanks for playing!");
            break;

        default:
            Console.WriteLine("\nInvalid Input. Please enter a number 1 - 5.");
            break;

    }
} while (menuSelection != "5");

