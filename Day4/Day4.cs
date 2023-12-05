using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day4
{
    public class Day4
    {
        public int Part1(string[] input)
        {
            var answer = 0;

            foreach(var line in input)
            {
                var points = 0;

                var splittedline = line.Split('|');
                splittedline[0] = Regex.Replace(splittedline.First(), @"Card (.+?):", "");
                var winningNumbers = Regex.Matches(splittedline[0], @"\d+").ToList().Select(x => Int32.Parse(x.Value)).ToList();
                var ournumbers = Regex.Matches(splittedline[1], @"\d+").ToList().Select(x => Int32.Parse(x.Value)).ToList();

                var matchingcount = ournumbers.Where(x => winningNumbers.Contains(x)).Count();
                for(int i = 1; i <= matchingcount; i++)
                {
                    if (points == 0)
                    {
                        points = i;
                    }
                    else
                    {
                        points = points * 2;
                    }
                }
                answer += points;

            }


            return answer;
        }


        public int Part2(string[] input)
        {
            var answer = 0;
            //  card id, count
            var copies = new Dictionary<int, int>();

            var startindex = 0;
            foreach (var line in input)
            {
                var splittedline = line.Split('|');
                var cardId = Int32.Parse(Regex.Match(splittedline[0], @"Card (.+?):").Groups[1].Value);
                splittedline[0] = Regex.Replace(splittedline.First(), @"Card (.+?):", "");
                var winningNumbers = Regex.Matches(splittedline[0], @"\d+").ToList().Select(x => Int32.Parse(x.Value)).ToList();
                var ournumbers = Regex.Matches(splittedline[1], @"\d+").ToList().Select(x => Int32.Parse(x.Value)).ToList();
                var matchingcount = ournumbers.Where(x => winningNumbers.Contains(x)).Count();

                for (int i = 1; i <= matchingcount; i++)
                {
                    var copy = input[startindex + i];
                    var sp = copy.Split('|');
                    var copyId = Int32.Parse(Regex.Match(sp[0], @"Card (.+?):").Groups[1].Value);

                    if (copies.ContainsKey(copyId) == false)
                    {
                        if (copies.ContainsKey(cardId))
                        {
                            copies.Add(copyId, copies[cardId] + 1);
                        }
                        else
                        {
                            copies.Add(copyId, 1);
                        }
                    }
                    else
                    {
                        copies[copyId] += copies[cardId] + 1;
                    }
                }
                startindex++;
            }
            answer = copies.Sum(x => x.Value) + input.Count();

            return answer;
        }
    }
}
