var fileName = Environment.CurrentDirectory + "/Input.txt";
var lines = File.ReadAllLines(fileName);
var d = new Day8.Day8();
Console.WriteLine(d.Part1(lines));
Console.WriteLine(d.Part2(lines));

Console.ReadKey();
Console.ReadKey();