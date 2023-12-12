var fileName = Environment.CurrentDirectory + "/Input_Test.txt";
var lines = File.ReadAllLines(fileName);
//var d = new Day12.Day12();
//Console.WriteLine(Day12.Day12.Part1(lines));
Console.WriteLine(Day12.Day12.Part2(lines));

Console.ReadKey();
Console.ReadKey();