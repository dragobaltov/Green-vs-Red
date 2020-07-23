using System;
using System.Linq;

static class GridFactory
{
    public static Grid create_grid(int rows, int cols)
    {
        char[][] grid = new char[rows][];
        bool read = read_grid(rows, cols, grid);

        while (!read)
        {
            Console.WriteLine("Invalid input! Please try again.");
            read = read_grid(rows, cols, grid);
        }

        return new Grid(rows, cols, grid);
    }

    private static bool read_grid(int rows, int cols, char[][] grid)
    {
        string row_text = "";

        for (int i = 0; i < rows; ++i)
        {
            row_text = Console.ReadLine();

            if (row_text.Length != cols)
                return false;

            grid[i] = new char[cols];

            for (int j = 0; j < cols; ++j)
            {
                if (row_text[j] != '0' && row_text[j] != '1')
                    return false;

                grid[i][j] = row_text[j];
            }
        }

        return true;
    }
}
