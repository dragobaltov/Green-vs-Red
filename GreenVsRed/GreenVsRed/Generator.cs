using System;
using System.Collections.Generic;
using System.Text;

class Generator
{
    private Func<int, bool> red_rule;
    private Func<int, bool> green_rule;

    public Generator(Func<int, bool> red_rule, Func<int, bool> green_rule)
    {
        this.red_rule = red_rule;
        this.green_rule = green_rule;
    }
    public void get_next_generation(Grid grid)
    {
        List<Tuple<int, int>> positions_to_change = new List<Tuple<int, int>>();

        for (int i = 0; i < grid.Rows; ++i)
        {
            for (int j = 0; j < grid.Cols; ++j)
            {
                int green_neighbours = grid.count_green_neighbours(i, j);

                if ((grid[i][j] == '0' && red_rule(green_neighbours)) || 
                    (grid[i][j] == '1' && green_rule(grid.count_green_neighbours(i, j))))
                {
                    positions_to_change.Add(new Tuple<int, int>(i, j));
                }
            }
        }

        foreach (var pair in positions_to_change)
        {
            grid.change_colour(pair.Item1, pair.Item2);
        }
    }
}
