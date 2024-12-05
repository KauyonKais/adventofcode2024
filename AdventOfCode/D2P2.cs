﻿using AdventOfCode;
using static System.Math;

public class D2P2 : IAdventOfCodeTask
{
    public string Execute()
    {
        var reports = ReadData();
        var countSafeReports = reports.Split("\n").Sum(report => IsSafe(report) ? 1 : 0);
        return countSafeReports.ToString();
    }

    private bool IsSafe(string report)
    {
        const int minStep = 1;
        const int maxStep = 3;
        var lives = 1;
        var values = report.Split(' ');
        var stepDirection = Sign(int.Parse(values[1]) - int.Parse(values[0]));
        for (int i = 1; i < values.Length; i++)
        {
            if (lives == 0) return false;
            var valueStep = int.Parse(values[i]) - int.Parse(values[i - 1]);
            var currentDirection = Sign(valueStep);
            if (stepDirection != currentDirection)
            {
                lives--;
                i++;
                continue;}

            if (minStep > Abs(valueStep) || Abs(valueStep) > maxStep)
            {
                lives--;
                i++;
                continue;
            }
        }
        return true;
    }
    private string ReadData()
    {
        return File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D2P2.txt");
    }
}