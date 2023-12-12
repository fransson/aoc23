using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day12
{
    public  class Day12
    {
        public class SpringLine
        {
            public List<Node> Nodes = new List<Node>();
            public List<int> Numbers = new List<int>();
            public int LineNumber { get; set; }
        }
        public class Node
        {
            public int Position { get; set; }
            public char Value { get; set; }
        }
        public Int64 matchingPatterns = 0;

        public List<string> PatternMatched = new List<string>();

        public Int64 Part1(string[] input)
        {
            var lines = new List<SpringLine>();


            foreach(var line in input)
            {
                var splittedLine = line.Split(' ');
                var springs = splittedLine[0].ToCharArray();
                var numbers = splittedLine[1].Split(',').Select(x => Int32.Parse(x)).ToList();

                
                LoopThroughString(0, springs, numbers);
                PatternMatched.Clear();
            }

            return matchingPatterns;
        }


        public void LoopThroughString(int i, char[] springs, List<int> numbers)
        {
            for (; i < springs.Length; i++)
            {
                char[] copySprings = new char[springs.Length];
                Array.Copy(springs, copySprings, springs.Length);

                var c = copySprings[i];
                if (c == '?')
                {
                    copySprings[i] = '.';
                    if(CheckPatternMatch(copySprings, numbers))
                    {
                        matchingPatterns++;
                    }
                    LoopThroughString(i+1, copySprings, numbers);

                    copySprings[i] = '#';
                    if(CheckPatternMatch(copySprings, numbers))
                    {
                        matchingPatterns++;
                    }
                    LoopThroughString(i + 1, copySprings, numbers);
                }
            }
        }

        public bool CheckPatternMatch(char[] springs, List<int> numbers)
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

        public Int64 Part2(string[] input)
        {

            var lines = new List<SpringLine>();
            Console.WriteLine($"ANSWER: {matchingPatterns}");

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
                LoopThroughString(0, newSprings.ToArray(), newNumbers);
                PatternMatched.Clear();
                Console.WriteLine("Line complete...");
            }
            Console.WriteLine($"ANSWER: {matchingPatterns}");
            return matchingPatterns;
        }

    }
}
