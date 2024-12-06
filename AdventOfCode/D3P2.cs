using System.Text.RegularExpressions;
using AdventOfCode;
using static System.Math;

public class D3P2 : IAdventOfCodeTask
{
    public string Execute()
    {
        var fileData = ReadData();
        //var fileData = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        fileData = "do()" + fileData + "don't()";
        var rx = new Regex("(?s)(?:\\G(?!^)|do\\(\\))(?:(?!do\\(\\)|don't\\(\\)).)*?(mul\\(\\d{1,3},\\d{1,3}\\)+)(?=(?:(?!do\\(\\)).)*(?:don't\\(\\)|do\\(\\)))");
        var mults = rx.Matches(fileData).ToList();
        var rx_mult = new Regex("\\d{1,3}");

        var result = 0;
        foreach (var mult in mults)
        {
            var matches = rx_mult.Matches(mult.Groups[1].Value);
            result += int.Parse(matches[0].Value) * int.Parse(matches[1].Value);
        }
        return result.ToString();
    }

    private string ReadData()
    {
        return File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D3P1.txt");
    }
}