
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

/*

Plan for the code:
Create a method that generates the questions.
Create a method that checks the answer and potentially awards a point.
Create a menu.

 */

using System.IO.Pipelines;
using System.Numerics;
using System.Security.Authentication;
using System.Threading.Tasks.Sources;

string menuSelection = "";
string operation = "Addition";
string difficulty = "Easy";
int numberOfQuestions = 5;

do
{
    string readResult = "";
    int score = 0;

    Console.WriteLine("\nWelcome to the Math Game!");
    Console.WriteLine("\nPlease select an option (1,2,3,4,5).");
    Console.WriteLine("1) Play!");
    Console.WriteLine($"2) Select Operation (currently {operation}).");
    Console.WriteLine($"3) Select Difficulty (default {difficulty}).");
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
            for (int i = 0; i < numberOfQuestions; i++)
            {
                int correctAnswer = GenerateQuestionAndAnswer(operation, difficulty);
                int playerAnswer = AcceptInput();
                bool success = CheckAnswer(playerAnswer, correctAnswer);
                if (success) score++;
            }
            double finalScorePercent = 100*((double)score / (double)numberOfQuestions);
            Console.WriteLine($"\nYour final score is {score} out of {numberOfQuestions}. {finalScorePercent}%!");


            break;

        case "2":
            Console.WriteLine("\nPlease select an operation (1,2,3,4).");
            Console.WriteLine("1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Random");
            readResult = Console.ReadLine();
            string operationSelection = readResult;
            switch (operationSelection)
            {
                case "1":
                    operation = "Addition";
                    break;

                case "2":
                    operation = "Subtraction";
                    break;

                case "3":
                    operation = "Multiplication";
                    break;
                
                case "4":
                    operation = "Division";
                    break;

                case "5":
                    operation = "Random";
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
                    difficulty = "Easy";
                    break;

                case "2":
                    difficulty = "Medium";
                    break;

                case "3":
                    difficulty = "Hard";
                    break;

                default:
                    Console.WriteLine("Sorry. Your input is invalid.");

                    break;
            }
            break;

        case "4":

            break;

        case "5":
            Console.WriteLine("\nThanks for playing!");
            break;

        default:
            Console.WriteLine("\nInvalid Input. Please enter a number 1 - 5.");
            break;

    }
} while (menuSelection != "5");






int GenerateQuestionAndAnswer(string operation, string difficulty)
{
    Random random = new Random();

    int num1 = 0;
    int num2 = 0;

    if (difficulty == "Easy")
    {
        num1 = random.Next(1, 6);
        num2 = random.Next(1, 6);
    }
    else if (difficulty == "Medium")
    {
        num1 = random.Next(1, 21);
        num2 = random.Next(1, 21);
    }
    else
    {
        num1 = random.Next(1, 101);
        num2 = random.Next(1, 101);
    }

    if (operation == "Random")
    {
        int determineOperation = random.Next(1, 5);

        if (determineOperation == 1)
            operation = "Addition";
        if (determineOperation == 2)
            operation = "Subtraction";
        if (determineOperation == 3)
            operation = "Multiplication";
        if (determineOperation == 4)
            operation = "Division";
    }

    switch (operation)
    {
        case "Addition":

            Console.WriteLine($"\nQuestion: {num1} + {num2} = ?");
            return num1 + num2;

        case "Subtraction":

            if (num1 >= num2)
            {
                Console.WriteLine($"\nQuestion: {num1} - {num2} = ?");
                return num1 - num2;
            }
            else
            {
                Console.WriteLine($"\nQuestion: {num2} - {num1} = ?");
                return num2 - num1;
            }

        case "Multiplication":

            Console.WriteLine($"\nQuestion: {num1} x {num2} = ?");
            return num1 * num2;

        case "Division":

            int num3 = num1 * num2;
            Console.WriteLine($"\nQuestion: {num3} / {num1} = ?");
            return num3 / num1;

        default:
            return 0;
    }
}

int AcceptInput()
{
    bool validInput = false;
    do
    {
        string input = Console.ReadLine();
        if (int.TryParse(input, out int intInput))
        {
            validInput = true;
            return intInput;
        }
        else
            Console.WriteLine("Input was invalid. Try again.");

    } while (validInput == false);
    return 0;
}

bool CheckAnswer(int inputAnswer, int correctAnswer)
{
    if (inputAnswer != correctAnswer)
    {
        Console.WriteLine("Incorrect.");
        return false;
    }
    else
    {
        Console.WriteLine("Correct!");
        return true;
    }
}