using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day9
{
    public class Row
    {
        public int RowNumber { get; set; }
        public List<int> Values { get; set; } = new List<int>();
    }
    public class History
    {
        public List<Row> Rows { get; set; } = new List<Row>();
    }
    public  class Day9
    {
        

        public int Part1(string[] input)
        {
            var answer = 0;
            var histories = new List<History>();

            foreach(var line in input) 
            {
                int rowNum = 1;
                var history = new History();

                var numbers = Regex.Matches(line, @"-?\d+").ToList().Select(x => Int32.Parse(x.Value)).ToList();

                history.Rows.Add(new Row()
                {
                    RowNumber = rowNum,
                    Values = numbers,
                });

                while(true)
                {
                    rowNum++;
                    var newNumbers = new List<int>();
                    for (int i = 0; i < numbers.Count - 1; i++)
                    {
                        var diff = numbers[i + 1] - numbers[i];
                        newNumbers.Add(diff);
                    }

                    history.Rows.Add(new Row()
                    {
                        RowNumber = rowNum,
                        Values = newNumbers
                    });

                    if (newNumbers.All(x => x == 0))
                    {
                        break;
                    }
                    else
                    {   
                        numbers = newNumbers;
                    }
                }

                histories.Add(history);
            }

            foreach(var history in histories)
            {
                for(int i = history.Rows.Count-1; i>=0; i--)
                {
                    if (i == history.Rows.Count-1)
                    {
                        history.Rows[i].Values.Add(0);
                    }
                    else
                    {
                        var lastDigit = history.Rows[i].Values.Last();
                        var numUnder = history.Rows[i + 1].Values.Last();
                        history.Rows[i].Values.Add(lastDigit + numUnder);
                    }
                    
                }
            }

            answer = histories.SelectMany(x => x.Rows).Where(x => x.RowNumber == 1).Select(x => x.Values.Last()).Sum();

            return answer;
        }




        public int Part2(string[] input)
        {
            var answer = 0;

            var histories = new List<History>();

            foreach (var line in input)
            {
                int rowNum = 1;
                var history = new History();

                var numbers = Regex.Matches(line, @"-?\d+").ToList().Select(x => Int32.Parse(x.Value)).ToList();

                history.Rows.Add(new Row()
                {
                    RowNumber = rowNum,
                    Values = numbers,
                });

                while (true)
                {
                    rowNum++;
                    var newNumbers = new List<int>();
                    for (int i = 0; i < numbers.Count - 1; i++)
                    {
                        var diff = numbers[i + 1] - numbers[i];
                        newNumbers.Add(diff);
                    }

                    history.Rows.Add(new Row()
                    {
                        RowNumber = rowNum,
                        Values = newNumbers
                    });

                    if (newNumbers.All(x => x == 0))
                    {
                        break;
                    }
                    else
                    {
                        numbers = newNumbers;
                    }
                }

                histories.Add(history);
            }

            foreach (var history in histories)
            {
                for (int i = history.Rows.Count - 1; i >= 0; i--)
                {
                    if (i == history.Rows.Count - 1)
                    {
                        history.Rows[i].Values.Insert(0, 0);
                    }
                    else
                    {
                        var lastDigit = history.Rows[i].Values.First();
                        var numUnder = history.Rows[i + 1].Values.First();
                        history.Rows[i].Values.Insert(0, lastDigit - numUnder);
                    }

                }
            }

            answer = histories.SelectMany(x => x.Rows).Where(x => x.RowNumber == 1).Select(x => x.Values.First()).Sum();

            return answer;
        }
    }
}
