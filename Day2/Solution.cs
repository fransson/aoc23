using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day2
{
    public class Solution
    {
        Dictionary<string, int> maxColorsLoaded = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
        public int Part1()
        {
            var fileName = Environment.CurrentDirectory + "/Input.txt";
            var lines = File.ReadAllLines(fileName);
            int answer = 0;

            foreach (var line in lines)
            {
                var loadedColors = new Dictionary<string, int>();
                var splittedline = line.Split(';');
                var gameId = Int32.Parse(Regex.Match(splittedline[0], @"Game (.+?):").Groups[1].Value);
                splittedline[0] = Regex.Replace(splittedline.First(), @"Game (.+?):", "");

                var success = true;
                foreach(var wholeGameSet in splittedline)
                {
                    var gameSet = wholeGameSet.Split(',');
                    foreach(var l in gameSet)
                    {
                        var color = Regex.Replace(l, @"[\d-]", string.Empty).Trim();
                        var number = Int32.Parse(Regex.Match(l, @"\d+").Value);
                        if (maxColorsLoaded.ContainsKey(color) != true || maxColorsLoaded[color] < number)
                        {
                            success = false;
                            break;
                        }
                    }
                }
                if (success)
                {
                    answer += gameId;
                }
            }

            return answer;
        }


        public int Part2()
        {
            var fileName = Environment.CurrentDirectory + "/Input.txt";
            var lines = File.ReadAllLines(fileName);
            int answer = 0;

            foreach (var line in lines)
            {
                var loadedColors = new Dictionary<string, int>();
                var splittedline = line.Split(';');
                var gameId = Int32.Parse(Regex.Match(splittedline[0], @"Game (.+?):").Groups[1].Value);
                splittedline[0] = Regex.Replace(splittedline.First(), @"Game (.+?):", "");

                foreach (var wholeGameSet in splittedline)
                {
                    var gameSet = wholeGameSet.Split(',');
                    foreach (var l in gameSet)
                    {
                        var color = Regex.Replace(l, @"[\d-]", string.Empty).Trim();
                        var number = Int32.Parse(Regex.Match(l, @"\d+").Value);
                        if (loadedColors.ContainsKey(color))
                        {
                            if (loadedColors[color] < number)
                            {
                                loadedColors[color] = number;
                            }
                        }
                        else
                        {
                            loadedColors.Add(color, number);
                        }
                    }
                }
                answer = answer + (loadedColors.Select(x => x.Value).Aggregate((a, x) => a * x));
            }
            return answer;
        }
    }
}
