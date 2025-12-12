
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

using System.Numerics;
using System.Threading.Tasks.Sources;


int score = 0;









int GenerateQuestionAndAnswer(string operation, int difficulty = 1)
{
    Random random = new Random();

    int num1 = random.Next(1, 11);
    int num2 = random.Next(1, 11);

    switch (operation)
    {
        case "addition":

            Console.WriteLine($"Question: {num1} + {num2} = ?");
            return num1 + num2;

        case "subtraction":

            if (num1 >= num2)
            {
                Console.WriteLine($"Question: {num1} - {num2} = ?");
                return num1 - num2;
            }
            else
            {
                Console.WriteLine($"Question: {num2} - {num1} = ?");
                return num2 - num1;
            }

        case "multiplication":

            Console.WriteLine($"Question: {num1} x {num2} = ?");
            return num1 * num2;

        case "division":

            while (num1 % num2 != 0 && num1 < num2)
            {
                num1++;
            }

            Console.WriteLine($"Question: {num1} / {num2} = ?");
            return num1 / num2;

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
        return false;
    else
        score++;
        return true;
}