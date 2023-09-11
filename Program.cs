using System;

public class SudokuSolver
{
    public static void Main()
    {
        int[,] board = new int[,]
        {
            { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
            { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
            { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
            { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
            { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
            { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
            { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
            { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
            { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        if (SolveSudoku(board))
        {
            Console.WriteLine("Sudoku solved:");
            PrintBoard(board);
        }
        else
        {
            Console.WriteLine("No solution exists.");
        }
    }

    public static bool SolveSudoku(int[,] board)
    {
        int row, col;
        if (!FindEmptyCell(board, out row, out col))
            return true;

        for (int num = 1; num <= 9; num++)
        {
            if (IsValidPlacement(board, row, col, num))
            {
                board[row, col] = num;

                if (SolveSudoku(board))
                    return true;

                board[row, col] = 0;
            }
        }

        return false;
    }

    public static bool FindEmptyCell(int[,] board, out int row, out int col)
    {
        for (row = 0; row < 9; row++)
        {
            for (col = 0; col < 9; col++)
            {
                if (board[row, col] == 0)
                    return true;
            }
        }

        row = -1;
        col = -1;
        return false;
    }

    public static bool IsValidPlacement(int[,] board, int row, int col, int num)
    {
        // Check row and column
        for (int i = 0; i < 9; i++)
        {
            if (board[row, i] == num || board[i, col] == num)
                return false;
        }

        // Check 3x3 box
        int startRow = (row / 3) * 3;
        int startCol = (col / 3) * 3;

        for (int i = startRow; i < startRow + 3; i++)
        {
            for (int j = startCol; j < startCol + 3; j++)
            {
                if (board[i, j] == num)
                    return false;
            }
        }

        return true;
    }

    public static void PrintBoard(int[,] board)
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                Console.Write(board[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}