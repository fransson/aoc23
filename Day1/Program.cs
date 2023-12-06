var fileName = Environment.CurrentDirectory + "/Input.txt";
var lines = File.ReadAllLines(fileName);
var d = new Day1.Day1();
d.Solve(lines);
