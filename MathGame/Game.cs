using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MathGame
{
    public class Game
    {

        //Constants

        //Methods

        public void PlayGame()
        {
            roundScore = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            numberOfRoundsPlayed++;

            for (int i = 0; i < numberOfQuestions; i++)
            {
                GenerateNumbers();
                int correctAnswer = GenerateQuestionAndAnswer();
                int playerAnswer = AcceptInput();
                CheckAnswer(playerAnswer, correctAnswer);
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            int roundTimeTaken = ts.Seconds;

            double finalScorePercent = 100 * ((double)roundScore / (double)numberOfQuestions);
            Console.WriteLine($"\nYour final score is {roundScore} out of {numberOfQuestions}. {finalScorePercent}%! In a time of {roundTimeTaken} seconds.");
            roundHistory.Add($"Game {numberOfRoundsPlayed}\nOperation: {operation}\nDifficulty: {difficulty}\n{roundScore} out of {numberOfQuestions}\n{roundTimeTaken} seconds.\n");

            totalScore += roundScore;
            totalTime += roundTimeTaken;
        }

        public void PrintGameHistory()
        {
            Console.WriteLine("\nYour Game History:\n");
            for (int i = 0; i < roundHistory.Count; i++)
            {
                Console.WriteLine(roundHistory[i]);
            }
            Console.WriteLine($"Total Score is {totalScore} out of {(numberOfRoundsPlayed * numberOfQuestions)}");
            Console.WriteLine($"Total Time is {totalTime} seconds.");
        }

        //Properties

        public string Operation
        {   
            get { return operation; } 
            set { operation = value; }
        }

        public string Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        public int NumberOfQuestions
        {
            get { return numberOfQuestions; }
            set { numberOfQuestions = value; }
        }

        //Private Methods

        private void GenerateNumbers()
        {
            Random random = new Random();

            if (difficulty == "Easy")
            {
                numbers[0] = random.Next(1, 6);
                numbers[1] = random.Next(1, 6);
            }
            else if (difficulty == "Medium")
            {
                numbers[0] = random.Next(1, 21);
                numbers[1] = random.Next(1, 21);
            }
            else
            {
                numbers[0] = random.Next(1, 101);
                numbers[1] = random.Next(1, 101);
            }
        }

        private int GenerateQuestionAndAnswer()
        {
            Random random = new Random();
            string tempOperation = "";
            if (operation == "Random")
            {
                int determineOperation = random.Next(1, 5);

                if (determineOperation == 1)
                    tempOperation = "Addition";
                if (determineOperation == 2)
                    tempOperation = "Subtraction";
                if (determineOperation == 3)
                    tempOperation = "Multiplication";
                if (determineOperation == 4)
                    tempOperation = "Division";
            }
            else
            {
                tempOperation = operation;
            }

            switch (tempOperation)
            {
                case "Addition":

                    Console.WriteLine($"\nQuestion: {numbers[0]} + {numbers[1]} = ?");
                    return numbers[0] + numbers[1];

                case "Subtraction":

                    if (numbers[0] >= numbers[1])
                    {
                        Console.WriteLine($"\nQuestion: {numbers[0]} - {numbers[1]} = ?");
                        return numbers[0] - numbers[1];
                    }
                    else
                    {
                        Console.WriteLine($"\nQuestion: {numbers[1]} - {numbers[0]} = ?");
                        return numbers[1] - numbers[0];
                    }

                case "Multiplication":

                    Console.WriteLine($"\nQuestion: {numbers[0]} x {numbers[1]} = ?");
                    return numbers[0] * numbers[1];

                case "Division":

                    int num3 = numbers[0] * numbers[1];
                    Console.WriteLine($"\nQuestion: {num3} / {numbers[0]} = ?");
                    return num3 / numbers[0];

                default:
                    return 0;
            }
        }

        private int AcceptInput()
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

        void CheckAnswer(int inputAnswer, int correctAnswer)
        {
            if (inputAnswer != correctAnswer)
            {
                Console.WriteLine("Incorrect.");
            }
            else
            {
                Console.WriteLine("Correct!");
                roundScore++;
            }
        }

        //Private Properties

        private string operation;
        private string difficulty;
        private int numberOfQuestions;

        private int roundScore = 0;
        private int totalScore = 0;
        private int totalTime = 0;
        private int numberOfRoundsPlayed = 0;

        private int[] numbers = new int[2];

        private List<string> roundHistory = new List<string>();



        //Constructors

        public Game(string operation = "Addition", string difficulty = "Easy", int numberOfQuestions = 5)
        {
            this.operation = operation;
            this.difficulty = difficulty;
            this.numberOfQuestions = numberOfQuestions;
        }

    }
}
