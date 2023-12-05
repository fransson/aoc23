using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    public class Day3
    {
        public int Part1(string[] input)
        {
            var answer = 0;

            for(int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var allNumbers = Regex.Matches(line, @"\d+").ToList();

                foreach(var number in allNumbers)
                {
                    var charBefore = '.';
                    var charAfter = '.';

                    if (number.Index > 0)
                    {
                        charBefore = line.Substring(number.Index - 1, 1).ToCharArray().FirstOrDefault();
                    }
                    if (number.Index + number.Length != line.Length) 
                    {
                        charAfter = line.Substring(number.Index + number.Length, 1).ToCharArray().FirstOrDefault();   
                    }
                    if (charBefore != '.' || charAfter != '.')
                    {
                        answer += Int32.Parse(number.Value);
                        continue;
                    }

                    //  kolla diagonalt
                    //  om det finns en övre linje
                    if (i > 0)
                    {
                        var aboveLine = input[i - 1];
                        var abstr = number.Index > 0 ? aboveLine.Skip(number.Index - 1).Take(number.Length + 2).ToArray() : aboveLine.Skip(number.Index).Take(number.Length + 1).ToArray();

                        if (abstr.Any(c => !char.IsDigit(c) && c != '.'))
                        {
                            answer += Int32.Parse(number.Value);
                            continue;
                        }
                    }


                    // om det finns en undre linje
                    if (i != input.Length-1)
                    {
                        var underLine = input[i + 1];

                        var undstr = number.Index > 0 ? underLine.Skip(number.Index - 1).Take(number.Length + 2).ToArray() : underLine.Skip(number.Index).Take(number.Length + 1).ToArray();

                        if (undstr.Any(c => !char.IsDigit(c) && c != '.'))
                        {
                            answer += Int32.Parse(number.Value);
                            continue;
                        }
                    }

                }
            }

            return answer;
        }




        public int Part2(string[] input)
        {
            var answer = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var allNumbers = Regex.Matches(line, @"\d+").ToList();
                var allAsterixs = Regex.Matches(line, @"\*").ToList();
                



                foreach (var number in allNumbers)
                {
                    var s = allNumbers.Where(x => (number.Index - x.Index) == 1).ToList();


                    var strBefore = line.Skip(0).Take(number.Index).ToArray();
                    var strAfter = line.Skip(number.Index).Take(input.Length-number.Index).ToArray();

                    if (strBefore.LastOrDefault() == '*')
                    {

                    }

                    if (strAfter.FirstOrDefault() == '*')



                    //  om det finns två övre linjer
                    if (i > 1)
                    {
                    }


                    // om det finns två undre linjer
                    if (i != input.Length - 2)
                    {
                    }

                }
            }

            return answer;
        }
    }
}
