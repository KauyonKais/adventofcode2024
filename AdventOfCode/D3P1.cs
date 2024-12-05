using System.Text.RegularExpressions;
using AdventOfCode;
using static System.Math;

public class D3P1 : IAdventOfCodeTask
{
    public string Execute()
    {
        var fileData = ReadData();
        var rx = new Regex("mul\\(\\d{1,3},\\d{1,3}\\)");
        var mults = rx.Matches(fileData).ToList();
        var rx_mult = new Regex("\\d{1,3}");

        var result = 0;
        foreach (var mult in mults)
        {
            var matches = rx_mult.Matches(mult.Value);
            result += int.Parse(matches[0].Value) * int.Parse(matches[1].Value);
        }
        return result.ToString();
    }

    private string ReadData()
    {
        return File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D3P1.txt");
    }
}