using System;

class Program
{
    static void Main()
    {
        char[] delimeters = { ' ', ',' };
        Tuple<int, int> size = read_grid_size(delimeters);
        int rows = size.Item1;
        int cols = size.Item2;

        Grid grid = GridFactory.create_grid(rows, cols);

        Tuple<int, int, int> position_generations = read_position_and_generations(delimeters, rows, cols);
        int row_index = position_generations.Item1;
        int col_index = position_generations.Item2;
        int generations = position_generations.Item3;

        Func<int, bool> red_rule = (int count) => { return count == 3 || count == 6; };
        Func<int, bool> green_rule = (int count) => { return count != 2 && count != 3 && count != 6; };

        Generator gen = new Generator(red_rule, green_rule);

        int count = get_count(gen, grid, row_index, col_index, generations);

        Console.WriteLine(count);
    }

    static Tuple<int, int> read_grid_size(char[] delimeters)
    {
        string[] tokens = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
        int cols = int.Parse(tokens[0]);
        int rows = int.Parse(tokens[1]);

        while (cols > rows || rows > 1000 || cols > 1000 || rows <= 0 || cols <= 0)
        {
            Console.WriteLine("Invalid input! Please try again.");
            tokens = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
            cols = int.Parse(tokens[0]);
            rows = int.Parse(tokens[1]);
        }

        return new Tuple<int, int>(rows, cols);
    }

    static Tuple<int, int, int> read_position_and_generations(char[] delimeters, int rows, int cols)
    {
        string[] tokens = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
        int col_index = int.Parse(tokens[0]);
        int row_index = int.Parse(tokens[1]);
        int generations = int.Parse(tokens[2]);

        while (col_index < 0 || col_index >= cols || row_index < 0 || row_index >= rows || generations < 0)
        {
            Console.WriteLine("Invalid input! Please try again.");
            tokens = Console.ReadLine().Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
            col_index = int.Parse(tokens[0]);
            row_index = int.Parse(tokens[1]);
            generations = int.Parse(tokens[2]);
        }

        return new Tuple<int, int, int>(row_index, col_index, generations);
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

