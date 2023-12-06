using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day6
{
    public class Day6
    {
        public int Part1(string[] input)
        {
            var answer = 0;
            var times = Regex.Matches(input[0], @"\d+").ToList().Select(x => Int32.Parse(x.Value)).ToList(); 
            var distances = Regex.Matches(input[1], @"\d+").ToList().Select(x => Int32.Parse(x.Value)).ToList();

            var differentWaysToWin = new List<int>();

            for(int i= 0; i < times.Count; i++)
            {
                var time = times[i];
                var distance = distances[i];

                var waysToWin = 0;

                for(int j = 0; j < time; j++) //varje millisekund
                {
                    var holdTime = j;
                    var millisecoundsLeft = time - holdTime;
                    var travelDistance = holdTime * millisecoundsLeft;
                    if (travelDistance > distance)
                    {
                        waysToWin++;
                    }
                }

                differentWaysToWin.Add(waysToWin);
            }
            answer = differentWaysToWin.Aggregate((a, x) => a * x);
            return answer;
        }




        public int Part2(string[] input)
        {
            var answer = 0;
            var timesStr = Regex.Matches(input[0], @"\d+").ToList();
            var distancesStr = Regex.Matches(input[1], @"\d+").ToList();

            var differentWaysToWin = new List<int>();

            var time = Int32.Parse(string.Concat(timesStr));
            var distance = BigInteger.Parse(string.Concat(distancesStr));

           
            var waysToWin = 0;

            for (int j = 0; j < time; j++) //varje millisekund
            {
                BigInteger holdTime = j;
                BigInteger millisecoundsLeft = time - holdTime;
                BigInteger travelDistance = holdTime * millisecoundsLeft;
                if (j == 150)
                {

                }
                if (travelDistance > distance)
                {
                    waysToWin++;
                }
            }

            differentWaysToWin.Add(waysToWin);
          
            answer = differentWaysToWin.Aggregate((a, x) => a * x);
            return answer;
        }
    }
}
