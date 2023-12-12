using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12
{
    public static class Day12
    {
      
        public class History
        {
            public int i { get; set; }
            public char[] springs { get; set; }
            public List<int> numbers { get; set; }
        }
        //public Int64 matchingPatterns = 0;

        public static List<string> PatternMatched = new List<string>();

        public static Int64 Part1(string[] input)
        {

            var matchingPatterns = 0;

            Func<History, int> fibonacci = LoopThroughString;
            var fibonacciMemoized = fibonacci.Memoize();


            foreach (var line in input)
            {
                var splittedLine = line.Split(' ');
                var springs = splittedLine[0].ToCharArray();
                var numbers = splittedLine[1].Split(',').Select(x => Int32.Parse(x)).ToList();

                var his = new History() { i = 0, springs = springs, numbers = numbers };

                matchingPatterns += fibonacciMemoized(his);
                PatternMatched.Clear();
            }

            return matchingPatterns;
        }


        public static int LoopThroughString(History hist)
        {
            var matchingpatrn = 0;
            Func<History, int> fibonacci = LoopThroughString;
            var fibonacciMemoized = fibonacci.Memoize();

            for (; hist.i < hist.springs.Length; hist.i++)
            {
                char[] copySprings = new char[hist.springs.Length];
                Array.Copy(hist.springs, copySprings, hist.springs.Length);

                var c = copySprings[hist.i];
                if (c == '?')
                {
                    copySprings[hist.i] = '.';
                    if(CheckPatternMatch(copySprings, hist.numbers))
                    {
                        matchingpatrn++;
                    }
                    //matchingpatrn += LoopThroughString(i+1, copySprings, hist.numbers);
                    matchingpatrn += fibonacciMemoized(new History() { i = hist.i + 1, springs = copySprings, numbers = hist.numbers });

                    copySprings[hist.i] = '#';
                    if(CheckPatternMatch(copySprings, hist.numbers))
                    {
                        matchingpatrn++;
                    }
                    //matchingpatrn += LoopThroughString(i + 1, copySprings, hist.numbers);
                    matchingpatrn += fibonacciMemoized(new History() { i = hist.i + 1, springs = copySprings, numbers = hist.numbers });
                }
            }
            return matchingpatrn;
        }


        public static Func<T, TResult> Memoize<T, TResult>(this Func<T, TResult> func)
        {
            var t = new Dictionary<T, TResult>();
            return (n) =>
            {
                
                if (t.ContainsKey(n)) return t[n];

                var result = func(n);
                t.Add(n, result);
                return result;
            };
        }


        public static bool CheckPatternMatch(char[] springs, List<int> numbers)
        {
            if(springs.Contains('?'))
            {
                return false;
            }
            var p = new String(springs);
            var regMatch = Regex.Matches(p, @"#+(?=[.]|$)").ToList();
            
            if(regMatch.Count == numbers.Count)
            {
                for(int i = 0; i < numbers.Count(); i++)
                {
                    if (regMatch[i].Length != numbers[i])
                    {
                        return false;
                    }
                }
                if (!PatternMatched.Contains(p))
                {
                    PatternMatched.Add(p);
                    return true;
                }
            }

            return false;
        }

        public static Int64 Part2(string[] input)
        {
            Int64 matchingPatterns = 0;

            Func<History, int> fibonacci = LoopThroughString;
            var fibonacciMemoized = fibonacci.Memoize();

            foreach (var line in input)
            {
                var splittedLine = line.Split(' ');
                var springs = splittedLine[0].ToCharArray();
                var numbers = splittedLine[1].Split(',').Select(x => Int32.Parse(x)).ToList();

                List<char> newSprings = new List<char>();
                List<int> newNumbers = new List<int>();
                for(int i = 0; i < 5; i++)
                {
                    newSprings.AddRange(springs);
                    if(i != 4) 
                    {
                        newSprings.Add('?');
                    }
                    newNumbers.AddRange(numbers);
                }
                var his = new History() { i = 0, springs = newSprings.ToArray(), numbers = newNumbers };

                matchingPatterns += fibonacciMemoized(his);
                PatternMatched.Clear();
                Console.WriteLine("Line complete...");
            }
            Console.WriteLine($"ANSWER: {matchingPatterns}");
            return matchingPatterns;
        }

    }
}
