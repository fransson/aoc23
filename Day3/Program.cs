var fileName = Environment.CurrentDirectory + "/Input.txt";
var lines = File.ReadAllLines(fileName);
var d = new Day3.Day3();
//Console.WriteLine(d.Part1(lines));
Console.WriteLine(d.Part2(lines));
Console.WriteLine(d.WorkingPart2(lines));
Console.ReadKey();