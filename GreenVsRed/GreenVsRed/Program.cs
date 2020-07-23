using System;

class Program
{
    static void Main()
    {
        char[] delimeters = { ' ', ',' };
        string[] tokens = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
        int cols = int.Parse(tokens[0]);
        int rows = int.Parse(tokens[1]);

        Grid grid = GridFactory.create_grid(rows, cols);

        tokens = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
        int col_index = int.Parse(tokens[0]);
        int row_index = int.Parse(tokens[1]);
        int generations = int.Parse(tokens[2]);

        Func<int, bool> red_rule = (int count) => { return count == 3 || count == 6; };
        Func<int, bool> green_rule = (int count) => { return count != 2 && count != 3 && count != 6; };

        Generator gen = new Generator(red_rule, green_rule);

        int count = get_count(gen, grid, row_index, col_index, generations);

        Console.WriteLine(count);
    }

    static int get_count(Generator gen, Grid grid, int row_index, int col_index, int generations)
    {
        int count = 0;

        if (grid[row_index][col_index] == '1')
            count++;

        for (int i = 0; i < generations; ++i)
        {
            gen.get_next_generation(grid);

            if (grid[row_index][col_index] == '1')
                count++;
        }

        return count;
    }
}

