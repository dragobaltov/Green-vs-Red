using System;

class Grid
{
    private int rows;
    private int cols;
    private char[][] grid;

    public Grid(int rows, int cols, char[][] grid)
    {
        this.rows = rows;
        this.cols = cols;
        this.grid = grid;
    }

    public int Rows { get { return rows; } }
    public int Cols { get { return cols; } }

    public char[] this[int i]
    {
        get { return grid[i]; }
    }

    public void print()
    {
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                Console.Write(grid[i][j]);
            }
            Console.WriteLine();
        }
    }

    public void change_colour(int row_index, int col_index)
    {
        grid[row_index][col_index] = (grid[row_index][col_index] == '0' ? '1' : '0');
    }

    public int count_green_neighbours(int row_index, int col_index)
    {
        char value = '1';
        int count = 0;

        if (row_index - 1 >= 0)
        {
            if (col_index - 1 >= 0 && grid[row_index - 1][col_index - 1] == value)
            {
                ++count;
            }
            if (grid[row_index - 1][col_index] == value)
            {
                ++count;
            }
            if (col_index + 1 < cols && grid[row_index - 1][col_index + 1] == value)
            {
                ++count;
            }
        }

        if (col_index - 1 >= 0 && grid[row_index][col_index - 1] == value)
        {
            ++count;
        }
        if (col_index + 1 < cols && grid[row_index][col_index + 1] == value)
        {
            ++count;
        }

        if (row_index + 1 < rows)
        {
            if (col_index - 1 >= 0 && grid[row_index + 1][col_index - 1] == value)
            {
                ++count;
            }
            if (grid[row_index + 1][col_index] == value)
            {
                ++count;
            }
            if (col_index + 1 < cols && grid[row_index + 1][col_index + 1] == value)
            {
                ++count;
            }
        }

        return count;
    }
}
