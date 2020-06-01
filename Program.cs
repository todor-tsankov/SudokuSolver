using System;
using System.Linq;

using SudokuSolver.Core;
using SudokuSolver.Common;

namespace SudokuSolver
{
    // Sample usage of the SudokuEngine class
    public class Program
    {
        public static void Main()
        {
            var solver = new SudokuEngine();
            var sudoku = ReadSudoku();

            var solved = solver.SolveBoard(sudoku);

            PrintSudoku(solved);
        }

        // Read a sudoku from the console where
        // each number is separated by space
        private static int[,] ReadSudoku()
        {
            var sudoku = new int[Constants.RowsCount, Constants.ColsCount];

            for (int row = Constants.MinRow; row <= Constants.MaxRow; row++)
            {
                var lineNumbers = Console.ReadLine()
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                         .Select(int.Parse)
                                         .ToArray();

                for (int col = Constants.MinCol; col <= Constants.MaxCol; col++)
                {
                    sudoku[row, col] = lineNumbers[col];
                }
            }

            return sudoku;
        }

        //Print sudoku on the console
        private static void PrintSudoku(int[,] sudoku)
        {
            if (sudoku == null)
            {
                Console.WriteLine("Invalid sudoku!");

                return;
            }

            Console.WriteLine();

            for (int row = Constants.MinRow; row <= Constants.MaxRow; row++)
            {
                for (int col = Constants.MinCol; col <= Constants.MaxCol; col++)
                {
                    Console.Write(sudoku[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
