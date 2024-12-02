﻿namespace AdventOfCode;

class D1P1 : IAdventOfCodeTask
{
    public string Execute(){
        const string seperator = "   ";
        var difference = 0;

        var input = File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D1P1.txt");

        List<int> list1 = [];

        List<int> list2 = [];
        foreach (var line in input.Split("\n"))
        {
            var parts = line.Split(seperator);
            if (parts.Length != 2) continue;
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }

        list1.Sort();
        list2.Sort();
        for (var i = 0; i<list1.Count;
             i++)
        {
            var lineDiff = Math.Abs(list1[i] - list2[i]);
            difference += lineDiff;
        }

        return difference.ToString();
    }

}