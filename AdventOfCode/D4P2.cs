using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode;

public class D4P2 : IAdventOfCodeTask
{
    char[][] grid;
    public string Execute()
    {
        var fileData = ReadData() + "O";
        //var fileData =
        //    ".M.S......\n..A..MSMS.\n.M.S.MAA..\n..A.ASMSM.\n.M.S.M....\n..........\nS.S.S.S.S.\n.A.A.A.A..\nM.M.M.M.M.\n..........";
        var lines = fileData.Split('\n');
        grid = new char[lines.Length][];
        
        for (var x = 0; x < grid.Length; x++)
        {
            grid[x] = new char[lines[x].Length];
            for (var y = 0; y < grid[x].Length; y++)
            {
                grid[x][y] = lines[x][y];
            }
        }
        
        var gridXLength = grid.Length;
        var gridYLength = grid[0].Length;
        var sum = 0;
        for (var x = 0; x < gridXLength; x++)
        {
            for (var y = 0; y < gridYLength; y++)
            {
                if (grid[x][y] == 'A')
                {
                    sum += getMASinRange(x, y);
                }
            }
        }

        return sum.ToString();
    }

    private int getMASinRange(int x, int y)
    {
        var sum = 0;
        //var ns = checkNorthSouth(x, y);
        //var ew = checkEastWest(x, y);
        var nwse = checkNWSE(x, y);
        var nesw = checkNESW(x, y);
        
        sum += nesw && nwse ? 1 : 0;
        
        //sum += checkNorthSouth(x,y) && checkEastWest(x,y) ? 1 : 0;
        //sum += checkNWSE(x,y) && checkNESW(x,y) ? 1 : 0;
        return sum;
    }

    private bool checkNorthSouth(int x, int y)
    {
        if (y < 1 || y > grid[0].Length - 2 || x < 1 || x > grid.Length - 2) return false;
        var north = grid[x-1][y];
        var south = grid[x+1][y];
        if (north == 'M' && south == 'S') return true;
        if (north == 'S' && south == 'M') return true;
        return false;
    }

    private bool checkEastWest(int x, int y)
    {
        if (y < 1 || y > grid[0].Length - 2 || x < 1 || x > grid.Length - 2) return false;
        var west = grid[x][y-1];
        var east = grid[x][y+1];
        if (west == 'M' && east == 'S') return true;
        if (west == 'S' && east == 'M') return true;
        return false;
    }

    private bool checkNWSE(int x, int y)
    {
        if (y < 1 || y > grid[0].Length - 2 || x < 1 || x > grid.Length - 2) return false;
        var nw = grid[x-1][y-1];
        var se = grid[x+1][y+1];
        if (nw == 'M' && se == 'S') return true;
        if (nw == 'S' && se == 'M') return true;
        return false;
    }

    private bool checkNESW(int x, int y)
    {
        if (y < 1 || y > grid[0].Length - 2 || x < 1 || x > grid.Length - 2) return false;
        var ne = grid[x-1][y+1];
        var sw = grid[x+1][y-1];
        if (ne == 'M' && sw == 'S') return true;
        if (ne == 'S' && sw == 'M') return true;
        return false;
    }
    
    private string ReadData()
    {
        return File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D4P1.txt");
    }
}