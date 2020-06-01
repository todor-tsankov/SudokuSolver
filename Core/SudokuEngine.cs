using SudokuSolver.Common;

namespace SudokuSolver.Core
{
    // Solves a given int[,] sudoku matrix
    // with the help of Validator class
    public class SudokuEngine
    {
        private bool solved;
        private int[,] solvedBoard;

        private Validator validator;

        public SudokuEngine()
        {
            this.validator = new Validator();
        }

        // Wraps the Solve(int[,] sudoku, int row, int col) method
        // to check if the given sudoku is valid in the
        // first place and returns null if it's not
        public int[,] SolveBoard(int[,] sudoku)
        {
            var startRow = 0;
            var startCol = 0;

            var valid = this.validator.ValidateSudoku(sudoku);

            if (valid)
            {
                this.Solve(sudoku, startRow, startCol);
            }

            return this.solvedBoard;
        }

        private void Solve(int[,] sudoku, int row, int col)
        {
            if (col == Constants.MaxCol + 1)
            {
                row++;
                col = 0;

                if (row == Constants.MaxRow + 1)
                {
                    this.solved = true;
                    this.solvedBoard = sudoku;
                    return;
                }
            }

            var currentNumber = sudoku[row, col];

            if (currentNumber != 0)
            {
                this.Solve(sudoku, row, col + 1);
            }
            else
            {
                for (int i = Constants.MinNumber; i <= Constants.MaxNumber; i++)
                {
                    if (this.solved)
                    {
                        break;
                    }

                    if (this.validator.CheckNumber(sudoku, row, col, i))
                    {
                        var boardCopy = (int[,])sudoku.Clone();
                        boardCopy[row, col] = i;

                        this.Solve(boardCopy, row, col + 1);
                    }
                }
            }
        }
    }
}
