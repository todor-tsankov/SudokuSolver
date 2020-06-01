using SudokuSolver.Common;

namespace SudokuSolver.Core
{
    public class Validator
    {
        // Validates a given sudoku by validating
        // all individual numbers with CheckNumber()
        public bool ValidateSudoku(int[,] sudoku)
        {
            if (sudoku == null)
            {
                return false;
            }
            else if (sudoku.GetLength(0) != Constants.RowsCount
                  || sudoku.GetLength(1) != Constants.ColsCount)
            {
                return false;
            }

            for (int row = Constants.MinRow; row <= Constants.MaxRow; row++)
            {
                for (int col = Constants.MinCol; col <= Constants.MaxCol; col++)
                {
                    var number = sudoku[row, col];

                    if (number != 0 && !this.CheckNumber(sudoku, row, col, number))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //Check if a given number is valid on a certain [row, col]
        public bool CheckNumber(int[,] sudoku, int row, int col, int number)
        {
            return this.CheckRow(sudoku, row, col, number)
                && this.CheckCol(sudoku, row, col, number)
                && this.CheckSquare(sudoku, row, col, number);
        }

        // Checks if there already is the same number on a given row
        private bool CheckRow(int[,] sudoku, int row, int col, int number)
        {
            for (int i = Constants.MinCol; i <= Constants.MaxCol; i++)
            {
                if (sudoku[row, i] == number && i != col)
                {
                    return false;
                }
            }

            return true;
        }

        //Checks if there already is the same number on the same column
        private bool CheckCol(int[,] sudoku, int row, int col, int number)
        {
            for (int i = Constants.MinRow; i <= Constants.MaxRow; i++)
            {
                if (sudoku[i, col] == number && row != i)
                {
                    return false;
                }
            }

            return true;
        }

        //Check if there already is the same number in the 3x3 square
        private bool CheckSquare(int[,] sudoku, int row, int col, int number)
        {
            var startRow = this.GetStartIndex(row);
            var startCol = this.GetStartIndex(col);

            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if (sudoku[i, j] == number && (row != i || col != j))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int GetStartIndex(int index)
        {
            var result = 0;

            if (index <= 2)
            {
                result = 0;
            }
            else if (index <= 5)
            {
                result = 3;
            }
            else
            {
                result = 6;
            }

            return result;
        }
    }
}
