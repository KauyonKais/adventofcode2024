using AdventOfCode;

string taskToRun = Console.ReadLine();
string result = null;

switch (taskToRun)
{
    case "D1P1": result = new D1P1().Execute(); break;
    case "D1P2": result = new D1P2().Execute(); break;
    case "D2P1": result = new D2P1().Execute(); break;
    case "D2P2": result = new D2P2().Execute(); break;
    case "D3P1": result = new D3P1().Execute(); break;
    case "D3P2": result = new D3P2().Execute(); break;
    case "D4P1": result = new D4P1().Execute(); break;
    case "D4P2": result = new D4P2().Execute(); break;
	default: result = "Not found."; break;
}

Console.WriteLine(result);