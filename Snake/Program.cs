using System;
using System.Linq;
using System.Collections.Generic;

namespace Snake
{
    class Program
    {
        static char[][] matrix;
        static int playerRow;
        static int playerCol;

        static bool isFound = false;
        static bool isBFound = false;
        static bool isOut = false;

        static string command;

        static int foodCounter = 10;
        static int foodEaten;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            InitializeMatrix(n, matrix);

            //command = Console.ReadLine();

            while (foodCounter > 0)
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                }
                if (isOut == true)
                {
                    break;
                }
            }

            if (foodCounter == 0)
            {
                matrix[playerRow][playerCol] = 'S';
                Console.WriteLine($"You won! You fed the snake.");
                Console.WriteLine($"Food eaten: {foodEaten}");
                PrintMatrix();
            }
        }

        private static void InitializeMatrix(int n, char[][] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                char[] currentInput = Console.ReadLine()
                    .ToCharArray();

                if (!isFound)
                {
                    for (int col = 0; col < currentInput.Length; col++)
                    {
                        if (currentInput[col] == 'S')
                        {
                            playerRow = row;
                            playerCol = col;
                            isFound = true;
                            break;
                        }
                    }
                }
                matrix[row] = currentInput;
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Length
                && col >= 0 && col < matrix.Length;
        }

        private static void Move(int row, int col)
        {
            if (IsInside(playerRow + row, playerCol + col))
            {
                if (matrix[playerRow][playerCol] == 'S')
                {
                    matrix[playerRow][playerCol] = '.';
                }

                playerRow += row;
                playerCol += col;

                if (matrix[playerRow][playerCol] == '*')
                {
                    foodEaten++;
                    foodCounter--;
                    matrix[playerRow][playerCol] = '.';
                }

                if (matrix[playerRow][playerCol] == 'B')
                {
                    matrix[playerRow][playerCol] = '.';

                    for (int rows = 0; rows < matrix.Length; rows++)
                    {
                        if (!isBFound)
                        {
                            for (int cols = 0; cols < matrix[rows].Length; cols++)
                            {
                                if (matrix[rows][cols] == 'B')
                                {
                                    matrix[rows][cols] = 'S';
                                    playerRow = rows;
                                    playerCol = cols;
                                    isBFound = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (matrix[playerRow][playerCol] == '-')
                {
                    matrix[playerRow][playerCol] = 'S';
                }
            }
            else
            {
                isOut = true;
                Console.WriteLine($"Game over!");
                Console.WriteLine($"Food eaten: {foodEaten}");
                PrintMatrix();
                Environment.Exit(0);
            }
        }
    }
}
