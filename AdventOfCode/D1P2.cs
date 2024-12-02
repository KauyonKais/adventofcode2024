using System.Collections;
using AdventOfCode;

class D1P2 : IAdventOfCodeTask
{
    public string Execute()
    {
        const string seperator = "   ";
        var difference = 0;

        var input = File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D1P2.txt");

        List<int> list1 = [];
        List<int> list2 = [];
        foreach (var line in input.Split("\n"))
        {
            var parts = line.Split(seperator);
            if (parts.Length != 2) continue;
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }

        foreach (var line in list1)
        {
            var count = list2.Count(line2 => line == line2);
            difference += count * line; 
        }

        return difference.ToString();
    }
}