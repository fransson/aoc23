﻿var fileName = Environment.CurrentDirectory + "/Input_Test.txt";
var lines = File.ReadAllLines(fileName);
var d = new Day5.Day5();
//Console.WriteLine(d.Part1(lines));
Console.WriteLine(d.Part2(lines));

Console.ReadKey();