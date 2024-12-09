using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class D5P2 : IAdventOfCodeTask
{
    char[][] grid;
    public string Execute()
    {
        var fileData = ReadData();
        var fileRules = ReadRules();
        
        FilterRelevantData(fileData, fileRules);
        

        var sum = 0;
        foreach (var line in fileData.Split('\n'))
        {
            var columns = line.Split(',');
            var middleColumn = columns[columns.Length/2];
            sum += middleColumn != "" ? int.Parse(middleColumn) : 0;
        }
        
        return sum.ToString();
    }

    private string FilterRelevantData(string fileData, string fileRules)
    {
        var rules = fileRules.Split(Environment.NewLine);
        var rulePattern = "";
        foreach (var rule in rules)
        {
            var subRules = rule.Split("|");
            if (subRules.Length < 2) continue;
            rulePattern += $@"^.*{subRules[1]}.*?{subRules[0]}.*$\n?\r?" + "|";
        }
        rulePattern = rulePattern.Remove(rulePattern.Length - 1);

        var matches = Regex.Matches(fileData, rulePattern, RegexOptions.Multiline);
        var newData = "";
        foreach (Match match in matches){ newData += match.Value; }
        return newData;
    }

    private string ReadTestData()
    {
        return "75,47,61,53,29\n97,61,53,29,13\n75,29,13\n75,97,47,61,53\n61,13,29\n97,13,75,29,47\n";
    }

    private string ReadTestRules()
    {
        return "47|53\n97|13\n97|61\n97|47\n75|29\n61|13\n75|53\n29|13\n97|29\n53|29\n61|53\n97|53\n61|29\n47|13\n75|47\n97|75\n47|61\n75|61\n47|29\n75|13\n53|13\n";
    }
    private string ReadData()
    {
        return File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D5P1_data.txt");
    }

    private string ReadRules()
    {
        return File.ReadAllText("C:\\Users\\kauyo\\RiderProjects\\adventofcode2024\\AdventOfCode\\Data\\D5P1_rules.txt");
    }
}