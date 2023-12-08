using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day3
{
    public class xNumber
    {
        public Guid Id { get; set; }
        public int Value { get; set; }  
        public int IndexRangeStart { get; set; }
        public int IndexRangeEnd { get; set; }
        public int LineNumber { get; set; }
        public bool Invalid { get; set; } = false;
        public int? ConnectedToNumbervalue { get; set; }
        public Guid? ConnectedToNumberId { get; set; }
    }

    public class Asterix
    {
        public int Index { get; set; }
        public int LineNumber { get; set; }
    }

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
            var allNumbers = new List<xNumber>();
            var allAsterixs = new List<Asterix>();

            var finalValues = new List<int>();


            for (int i = 0; i < input.Length; i++)
            {
                var line = input[i];
                var numbers = Regex.Matches(line, @"\d+").ToList();
                var asterixs = Regex.Matches(line, @"\*").ToList();
                
                foreach(var n in numbers)
                {
                    allNumbers.Add(new xNumber()
                    {
                        LineNumber = i,
                        IndexRangeStart = n.Index,
                        IndexRangeEnd = n.Index + n.Length-1,
                        Value = Int32.Parse(n.Value),
                        Id = Guid.NewGuid()
                    });
                }

                foreach(var asterix in asterixs)
                {
                    allAsterixs.Add(new Asterix
                    {
                        LineNumber = i,
                        Index = asterix.Index
                    });
                }
            }

            foreach (var number in allNumbers)
            {
                var sameLineAsterix = allAsterixs.Where(x =>
                x.LineNumber == number.LineNumber &&
                (x.Index == number.IndexRangeStart - 1 || x.Index == number.IndexRangeEnd + 1)
                ).FirstOrDefault();

                if (sameLineAsterix != null)
                {
                    var numLeft = allNumbers.Where(x => x.Id != number.Id && x.LineNumber == number.LineNumber && x.IndexRangeEnd == sameLineAsterix.Index-1).FirstOrDefault();
                    if (numLeft != null)
                    {
                        
                        if (numLeft.ConnectedToNumbervalue.HasValue && numLeft.ConnectedToNumbervalue.Value != number.Value)
                        {
                            number.Invalid = true;
                           // numLeft.Invalid = true;
                            var go = true;
                            while (go)
                            {
                                if (numLeft.ConnectedToNumberId.HasValue && numLeft.Invalid == false)
                                {
                                    numLeft.Invalid = true;
                                    numLeft = allNumbers.Where(x => x.Id == numLeft.ConnectedToNumberId.Value).First();
                                    
                                }
                                else
                                {
                                    go = false;
                                }
                            }

                        }
                        else if (number.ConnectedToNumbervalue.HasValue && number.ConnectedToNumbervalue.Value != numLeft.Value)
                        {
                            number.Invalid = true;
                            numLeft.Invalid = true;
                        }
                        else
                        {
                            number.ConnectedToNumbervalue = numLeft.Value;
                            number.ConnectedToNumberId = numLeft.Id;
                            numLeft.ConnectedToNumbervalue = number.Value;
                            numLeft.ConnectedToNumberId = number.Id;
                        }
                    }

                    var numRight = allNumbers.Where(x => x.Id != number.Id && x.LineNumber == number.LineNumber && x.IndexRangeStart == sameLineAsterix.Index + 1).FirstOrDefault();
                    if (numRight != null)
                    {
                        if (numRight.ConnectedToNumbervalue.HasValue && numRight.ConnectedToNumbervalue.Value != number.Value)
                        {
                            number.Invalid = true;
                            //numRight.Invalid = true;

                            var go = true;
                            while (go)
                            {
                                if (numRight.ConnectedToNumberId.HasValue && numRight.Invalid == false)
                                {
                                    numRight.Invalid = true;
                                    numRight = allNumbers.Where(x => x.Id == numRight.ConnectedToNumberId.Value).First();
                                }
                                else
                                {
                                    go = false;
                                }
                            }

                        }
                        else if (number.ConnectedToNumbervalue.HasValue && number.ConnectedToNumbervalue.Value != numRight.Value)
                        {
                            number.Invalid = true;
                            numRight.Invalid = true;
                        }

                        number.ConnectedToNumbervalue = numRight.Value;
                        number.ConnectedToNumberId = numRight.Id;
                        numRight.ConnectedToNumbervalue = number.Value;
                        numRight.ConnectedToNumberId = number.Id;
                    }
                }

                var asterixAbove = allAsterixs.Where(x =>
                    x.LineNumber == number.LineNumber - 1 &&
                    (number.IndexRangeStart - 1 <= x.Index && x.Index <= number.IndexRangeEnd+1)
                    ).FirstOrDefault();

                if (asterixAbove != null)
                {
                    var numAbove = allNumbers.Where(x => x.Id != number.Id && x.LineNumber == asterixAbove.LineNumber - 1 &&
                    (x.IndexRangeEnd >= asterixAbove.Index - 1 && x.IndexRangeStart <= asterixAbove.Index + 1)
                    //((x.IndexRangeStart == asterixAbove.Index - 1 || x.IndexRangeStart == asterixAbove.Index + 1) ||
                    //(x.IndexRangeEnd == asterixAbove.Index - 1 || x.IndexRangeEnd == asterixAbove.Index + 1))
                    ).FirstOrDefault();

                    if (numAbove != null)
                    {
                        if (numAbove.ConnectedToNumbervalue.HasValue && numAbove.ConnectedToNumbervalue.Value != number.Value)
                        {
                            number.Invalid = true;
                            //numAbove.Invalid = true;
                            var go = true;
                            while (go)
                            {
                                if (numAbove.ConnectedToNumberId.HasValue && numAbove.Invalid == false)
                                {
                                    numAbove.Invalid = true;
                                    numAbove = allNumbers.Where(x => x.Id == numAbove.ConnectedToNumberId.Value).First();
                                }
                                else
                                {
                                    go = false;
                                }
                            }

                        }
                        else if (number.ConnectedToNumbervalue.HasValue && number.ConnectedToNumbervalue.Value != numAbove.Value)
                        {
                            number.Invalid = true;
                            numAbove.Invalid = true;
                        }

                        number.ConnectedToNumbervalue = numAbove.Value;
                        numAbove.ConnectedToNumbervalue = number.Value;

                        number.ConnectedToNumberId = numAbove.Id;
                        numAbove.ConnectedToNumberId = number.Id;
                    }
                }




                var asterixUnder = allAsterixs.Where(x =>
                    x.LineNumber == number.LineNumber + 1 &&
                    (number.IndexRangeStart - 1 <= x.Index && x.Index <= number.IndexRangeEnd+1)
                    ).FirstOrDefault();

                if (asterixUnder != null)
                {
                    var numUnder = allNumbers.Where(x => x.Id != number.Id && x.LineNumber == asterixUnder.LineNumber + 1 &&
                    (x.IndexRangeEnd >= asterixUnder.Index - 1 &&  x.IndexRangeStart <= asterixUnder.Index +1)    

                    //((x.IndexRangeStart -1 <= asterixUnder.Index || x.IndexRangeStart +1 <= asterixUnder.Index + 1) ||
                    //(x.IndexRangeEnd == asterixUnder.Index - 1 || x.IndexRangeEnd == asterixUnder.Index + 1))
                    ).FirstOrDefault();

                    if (numUnder != null)
                    {
                        if (numUnder.ConnectedToNumbervalue.HasValue && numUnder.ConnectedToNumbervalue.Value != number.Value)
                        {
                            number.Invalid = true;
                            //numUnder.Invalid = true;

                            var go = true;
                            while (go)
                            {
                                if (numUnder.ConnectedToNumberId.HasValue && numUnder.Invalid == false)
                                {
                                    numUnder.Invalid = true;
                                    numUnder = allNumbers.Where(x => x.Id == numUnder.ConnectedToNumberId.Value).First();
                                }
                                else
                                {
                                    go = false;
                                }
                            }

                        }
                        else if (number.ConnectedToNumbervalue.HasValue && number.ConnectedToNumbervalue.Value != numUnder.Value)
                        {
                            number.Invalid = true;
                            numUnder.Invalid = true;
                        }

                        number.ConnectedToNumbervalue = numUnder.Value;
                        numUnder.ConnectedToNumbervalue = number.Value;

                        number.ConnectedToNumberId = numUnder.Id;
                        numUnder.ConnectedToNumberId = number.Id;

                    }

                }

            }

            List<Guid> seenIds = new List<Guid>();

            var allCalcNumbers = allNumbers.Where(x => x.Invalid == false && x.ConnectedToNumbervalue.HasValue).ToList();

            foreach (var num in allNumbers.Where(x => x.Invalid == false && x.ConnectedToNumbervalue.HasValue))
            {
                if (seenIds.Contains(num.Id) == false && seenIds.Contains(num.ConnectedToNumberId.Value) == false)
                {
                    finalValues.Add(num.Value * num.ConnectedToNumbervalue.Value);
                    seenIds.Add(num.Id);
                    seenIds.Add(num.ConnectedToNumberId.Value);
                }
            }

            answer = finalValues.Sum();
            return answer;
        }
    }
}
