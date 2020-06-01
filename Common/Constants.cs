namespace SudokuSolver.Common
{
    //Holds:
    // Range of possible values for each cell
    //Maximum and minimum row/column index in ( int[,] board )
    // Number of row/columns
    public static class Constants
    {
        public const int MinNumber = 1;
        public const int MaxNumber = 9;

        public const int MinRow = 0;
        public const int MaxRow = 8;

        public const int MinCol = 0;
        public const int MaxCol = 8;

        public const int RowsCount = MaxRow - MinRow + 1;
        public const int ColsCount = MaxCol - MinCol + 1;
    }
}
