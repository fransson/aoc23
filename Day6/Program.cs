var fileName = Environment.CurrentDirectory + "/Input.txt";
var lines = File.ReadAllLines(fileName);
var d = new Day6.Day6();
Console.WriteLine(d.Part1(lines));
Console.WriteLine(d.Part2(lines));