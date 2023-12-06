using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day1
{
    public class Day1
    {
        public void Solve(string[] lines)
        {

            var dict = new Dictionary<string, int>()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },{ "four", 4 },{ "five",5 },
                { "six", 6 },{ "seven", 7 },{ "eight", 8 },{ "nine", 9 }
            };

            var output = new List<int>();
            var answer = 0;
            var answer2 = 0;

            for (var i = 0; i<lines.Length; i += 1)
            {
                var line = lines[i];
                var first = Regex.Match(line, @"\d+").Value;
                var last = Regex.Match(line, @"(\d+)(?!.*\d)").Value;

                //var first2 = Regex.Match(line, @"(\d+)\s+((\one\b)|(\two\b)|(\three\b)|(\four\b)|(\five\b))").Value;
                //var last2 = Regex.Match(line, @"(\d+)(?!.*\d)\s+((\one\b)|(\two\b)|(\three\b)|(\four\b)|(\five\b))").Value;

                var fir = Regex.Match(line, @"(\d+|(one|two|three|four|five|six|seven|eight|nine))").Value;
                var sec = Regex.Match(line, @"(\d+|(one|two|three|four|five|six|seven|eight|nine))", RegexOptions.RightToLeft).Value;


                if (dict.TryGetValue(fir, out int v))
                {
                    fir = v.ToString();
                }
                if(dict.TryGetValue(sec, out int v2))
                {
                    sec = v2.ToString();
                }

            var r = first.First().ToString() + last.Last().ToString();
            var r2 = fir.First().ToString() + sec.Last().ToString();


            answer += Int32.Parse(r);
            answer2 += Int32.Parse(r2);

                // Process line
            }

            Console.WriteLine(answer);
            Console.WriteLine(answer2);

        }
    }
}
