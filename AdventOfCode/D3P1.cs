using AdventOfCode;
using static System.Math;

public class D2P2 : IAdventOfCodeTask
{
    public string Execute()
    {
        var fileData = ReadData();
        Regex rx = new Regex("mul\\(\\d{1,3},\\d{1,3}\\)");
        return rx.Matches(fileData).Count.ToString();
    }

    private string ReadData()
    {
        return File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D3P1.txt");
    }
}