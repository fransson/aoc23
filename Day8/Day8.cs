using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8
{

    public class Instruction
    {
        public string Value { get; set; }

        public string Left { get; set; }
        public string Right { get; set; }

        public Instruction? ItemAt { get; set; }
        public int? Steps { get; set; }
    }
    public  class Day8
    {
        public Int64 Part1(string[] input)
        {
            char[] instructions = ['r'];

            var allValues = new List<Instruction>();

            for(int i = 0; i < input.Length; i++) 
            { 
                if(i == 0)
                {
                    instructions = input[i].Trim().ToCharArray();
                    i++;
                    continue;
                }

                var instr = new Instruction();

                var line = input[i];
                
                instr.Value = line.Split('=').FirstOrDefault().Trim();

                var s = line.Split('=')[1].Trim();
                var p = s.Split(',');
                instr.Left = Regex.Replace(p[0], @"[^A-Z]+", string.Empty);
                instr.Right = Regex.Replace(p[1], @"[^A-Z]+", string.Empty);
                allValues.Add(instr);
            }

            Int64 steps = 0;
            var goal = "ZZZ";
            bool go = true;
            var startpos = "AAA";
            var item = allValues.Where(x => x.Value == startpos).First();

            while (go)
            {
                foreach(var instruct in instructions)
                {
                    if (instruct == 'L')
                    {
                        var itemToGoTo = allValues.Where(x => x.Value == item.Left).First();
                        item = itemToGoTo;
                        steps++;
                    }
                    else if (instruct == 'R')
                    {
                        var itemToGoTo = allValues.Where(x => x.Value == item.Right).First();
                        item = itemToGoTo;
                        steps++;
                    }

                    if(item.Value == goal)
                    {
                        go = false;
                        break;
                    }
                }
            }


            return steps;
        }




        public Int64 Part2(string[] input)
        {
            char[] instructions = ['r'];

            var allValues = new List<Instruction>();

            for (int i = 0; i < input.Length; i++)
            {
                if (i == 0)
                {
                    instructions = input[i].Trim().ToCharArray();
                    i++;
                    continue;
                }

                var instr = new Instruction();

                var line = input[i];

                instr.Value = line.Split('=').FirstOrDefault().Trim();

                var s = line.Split('=')[1].Trim();
                var p = s.Split(',');
                instr.Left = Regex.Replace(p[0], @"[^A-Z0-9]+", string.Empty);
                instr.Right = Regex.Replace(p[1], @"[^A-Z0-9]+", string.Empty);
                allValues.Add(instr);
            }

            var startpositions = allValues.Where(x => x.Value.EndsWith('A')).ToList();
            
            foreach(var s in startpositions)
            {
                s.ItemAt = s;
                int steps = 0;
                bool go = true;
                while (go)
                {
                    foreach (var instruct in instructions)
                    {
                        
                        if (instruct == 'L')
                        {
                            s.ItemAt = allValues.Where(x => x.Value == s.ItemAt.Left).First();

                        }
                        else if (instruct == 'R')
                        {
                            s.ItemAt = allValues.Where(x => x.Value == s.ItemAt.Right).First();

                        }
                        
                        steps++;
                        if (s.ItemAt.Value.EndsWith('Z'))
                        {
                            s.Steps = steps;
                            go = false;
                            break;
                        }
                    }
                }
            }

            var ans = lcm_of_array_elements(startpositions.Select(x => x.Steps.Value).ToArray());

            return ans;
        }

        public static long lcm_of_array_elements(int[] element_array)
        {
            long lcm_of_array_elements = 1;
            int divisor = 2;

            while (true)
            {

                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < element_array.Length; i++)
                {

                    // lcm_of_array_elements (n1, n2, ... 0) = 0.
                    // For negative number we convert into
                    // positive and calculate lcm_of_array_elements.
                    if (element_array[i] == 0)
                    {
                        return 0;
                    }
                    else if (element_array[i] < 0)
                    {
                        element_array[i] = element_array[i] * (-1);
                    }
                    if (element_array[i] == 1)
                    {
                        counter++;
                    }

                    // Divide element_array by devisor if complete
                    // division i.e. without remainder then replace
                    // number with quotient; used for find next factor
                    if (element_array[i] % divisor == 0)
                    {
                        divisible = true;
                        element_array[i] = element_array[i] / divisor;
                    }
                }

                // If divisor able to completely divide any number
                // from array multiply with lcm_of_array_elements
                // and store into lcm_of_array_elements and continue
                // to same divisor for next factor finding.
                // else increment divisor
                if (divisible)
                {
                    lcm_of_array_elements = lcm_of_array_elements * divisor;
                }
                else
                {
                    divisor++;
                }

                // Check if all element_array is 1 indicate 
                // we found all factors and terminate while loop.
                if (counter == element_array.Length)
                {
                    return lcm_of_array_elements;
                }
            }
        }
    }
}
