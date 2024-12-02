using AdventOfCode;

string taskToRun = Console.ReadLine();
string result = null;

switch (taskToRun)
{
    case "D1P1": result = new D1P1().Execute(); break;
    case "D1P2": result = new D1P2().Execute(); break;
}

Console.WriteLine(result);