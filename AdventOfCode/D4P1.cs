namespace AdventOfCode;

public class D4P1 : IAdventOfCodeTask
{
    char[][] grid;
    public string Execute()
    {
        var fileData = ReadData() + "O";
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
        
        Console.WriteLine(gridXLength + " " + gridYLength);
        var sum = 0;
        for (var x = 0; x < gridXLength; x++)
        {
            for (var y = 0; y < gridYLength; y++)
            {
                Console.Write(" " + x + "-" + y);
                if (grid[x][y] == 'X')
                {
                    sum += getXMASinRange(x, y);
                }
            }
            Console.Write("\n");
        }

        return sum.ToString();
    }

    private int getXMASinRange(int x, int y)
    {
        int sum = 0;
        sum += readNorth(x, y);
        sum += readSouth(x, y);
        sum += readWest(x, y);
        sum += readEast(x, y);
        sum += readNorthEast(x, y);
        sum += readSouthEast(x, y);
        sum += readNorthWest(x, y);
        sum += readSouthWest(x, y);
        return sum;
    }
//x is north, y is east
    private int readNorth(int x, int y)
    {
        if (x < 3) return 0;
        if (grid[x-1][y] == 'M' && grid[x-2][y] == 'A' && grid[x-3][y] == 'S') return 1;
        return 0;
    }
    private int readSouth(int x, int y){ 
        if (x > grid.Length - 4) return 0;
        if (grid[x+1][y] == 'M' && grid[x+2][y] == 'A' && grid[x+3][y] == 'S') return 1;
        return 0;
    }
    private int readWest(int x, int y){ 
        if (y < 3) return 0;
        if (grid[x][y-1] == 'M' && grid[x][y-2] == 'A' && grid[x][y-3] == 'S') return 1;
        return 0;
    }

    private int readEast(int x, int y)
    {
        if (y > grid[0].Length - 4) return 0;
        if (grid[x][y+1] == 'M' && grid[x][y+2] == 'A' && grid[x][y+3] == 'S') return 1;
        return 0;
    }

    private int readNorthWest(int x, int y)
    {
        if (x < 3 || y < 3) return 0;
        if (grid[x-1][y-1] == 'M' && grid[x-2][y-2] == 'A' && grid[x-3][y-3] == 'S') return 1;
        return 0;
    }

    private int readNorthEast(int x, int y)
    {
        if (x < 3 || y > grid[0].Length - 4) return 0;
        if (grid[x-1][y+1] == 'M' && grid[x-2][y+2] == 'A' && grid[x-3][y+3] == 'S') return 1;
        return 0;
    }

    private int readSouthEast(int x, int y)
    {
        if (x > grid.Length - 4 || y > grid.Length - 4 ) return 0;
        if (grid[x+1][y+1] == 'M' && grid[x+2][y+2] == 'A' && grid[x+3][y+3] == 'S') return 1;
        return 0;
    }

    private int readSouthWest(int x, int y)
    {
        if (x > grid.Length - 4 || y < 3 ) return 0;
        if (grid[x+1][y-1] == 'M' && grid[x+2][y-2] == 'A' && grid[x+3][y-3] == 'S') return 1;
        return 0;
    }
    private string ReadData()
    {
        return File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D4P1.txt");
    }
}