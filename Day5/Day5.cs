using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5
{
    public class Converter
    {
        public Int64 sourceStart { get; set; }
        public Int64 destinationStart { get; set; }

        public Int64 rangeLength { get; set; }
    }

    public class SeedRange
    {
        public Int64 Start { get; set; }
        public Int64 End { get; set; }
    }

    public class Day5
    {
        public List<Converter> seedToSoilConv = new List<Converter>();
        public List<Converter> soilToFertilizer = new List<Converter>();
        public List<Converter> fertilizerToWater = new List<Converter>();
        public List<Converter> waterToLight = new List<Converter>();
        public List<Converter> lightToTemp = new List<Converter>();
        public List<Converter> tempToHumidity = new List<Converter>();
        public List<Converter> himidityToLocation = new List<Converter>();



        public BigInteger Part1(string[] input)
        {
            var answer = 0;

            var seeds = Regex.Matches(input[0], @"\d+").ToList().Select(x => BigInteger.Parse(x.Value)).ToList();

            for(int i = 1; i< input.Length; i++)
            {
                var startLine = input[i];
                if (startLine.StartsWith("seed-to-soil"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        seedToSoilConv.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }

                if (startLine.StartsWith("soil-to-fertilizer"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        soilToFertilizer.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength 
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }

                if (startLine.StartsWith("fertilizer-to-water"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        fertilizerToWater.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength 
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }
                if (startLine.StartsWith("water-to-light"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        waterToLight.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength 
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }
                if (startLine.StartsWith("light-to-temperature"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        lightToTemp.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength 
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }

                if (startLine.StartsWith("temperature-to-humidity"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        tempToHumidity.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength 
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }
                if (startLine.StartsWith("humidity-to-location"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        himidityToLocation.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength 
                        });
                        i++;
                        if (i >= input.Length || string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }
            }

            BigInteger lowest = -1;
            foreach(var seed in seeds)
            {
                var nextVal = seed;

                //var conv = seedToSoilConv.Where(x => )

                //nextVal = seedToSoil.ContainsKey(nextVal) ? seedToSoil[nextVal] : nextVal;

                var conv = seedToSoilConv.Where(x => (x.sourceStart <= nextVal) && (x.sourceStart + x.rangeLength) >= nextVal).FirstOrDefault();
                if (conv != null)
                {
                    nextVal += conv.destinationStart - conv.sourceStart;
                }

                conv = soilToFertilizer.Where(x => (x.sourceStart <= nextVal) && (x.sourceStart + x.rangeLength) >= nextVal).FirstOrDefault();
                if (conv != null)
                {
                    nextVal += conv.destinationStart - conv.sourceStart;
                }

                conv = fertilizerToWater.Where(x => (x.sourceStart <= nextVal) && (x.sourceStart + x.rangeLength) >= nextVal).FirstOrDefault();
                if (conv != null)
                {
                    nextVal += conv.destinationStart - conv.sourceStart;
                }

                conv = waterToLight.Where(x => (x.sourceStart <= nextVal) && (x.sourceStart + x.rangeLength) >= nextVal).FirstOrDefault();
                if (conv != null)
                {
                    nextVal += conv.destinationStart - conv.sourceStart;
                }

                conv = lightToTemp.Where(x => (x.sourceStart <= nextVal) && (x.sourceStart + x.rangeLength) >= nextVal).FirstOrDefault();
                if (conv != null)
                {
                    nextVal += conv.destinationStart - conv.sourceStart;
                }

                conv = tempToHumidity.Where(x => (x.sourceStart <= nextVal) && (x.sourceStart + x.rangeLength) >= nextVal).FirstOrDefault();
                if (conv != null)
                {
                    nextVal += conv.destinationStart - conv.sourceStart;
                }

                conv = himidityToLocation.Where(x => (x.sourceStart <= nextVal) && (x.sourceStart + x.rangeLength) >= nextVal).FirstOrDefault();
                if (conv != null)
                {
                    nextVal += conv.destinationStart - conv.sourceStart;
                }
              

                if (lowest == -1 || nextVal < lowest)
                {
                    lowest = nextVal;
                }
            }


            return lowest;
        }




        public BigInteger Part2(string[] input)
        {
            List<BigInteger> seeds = new List<BigInteger>();
            var seedsRange = Regex.Matches(input[0], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();

            var seedRanges = new List<SeedRange>();

            for(int c = 0; c < seedsRange.Count; c++)
            {
                seedRanges.Add(new SeedRange()
                {
                    Start = seedsRange[c],
                    End = seedsRange[c] + seedsRange[c + 1]
                });
                c++;
            }
            for (int i = 1; i < input.Length; i++)
            {
                var startLine = input[i];
                if (startLine.StartsWith("seed-to-soil"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        seedToSoilConv.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }

                if (startLine.StartsWith("soil-to-fertilizer"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        soilToFertilizer.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }

                if (startLine.StartsWith("fertilizer-to-water"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        fertilizerToWater.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }
                if (startLine.StartsWith("water-to-light"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        waterToLight.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }
                if (startLine.StartsWith("light-to-temperature"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        lightToTemp.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }

                if (startLine.StartsWith("temperature-to-humidity"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        tempToHumidity.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength
                        });
                        i++;
                        if (string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }
                if (startLine.StartsWith("humidity-to-location"))
                {
                    i++;
                    while (true)
                    {
                        var numbers = Regex.Matches(input[i], @"\d+").ToList().Select(x => Int64.Parse(x.Value)).ToList();
                        var destinationRangeStart = numbers[0];
                        var sourceRangeStart = numbers[1];
                        var rangeLength = numbers[2];
                        himidityToLocation.Add(new Converter()
                        {
                            destinationStart = destinationRangeStart,
                            sourceStart = sourceRangeStart,
                            rangeLength = rangeLength
                        });
                        i++;
                        if (i >= input.Length || string.IsNullOrWhiteSpace(input[i]))
                        {
                            break;
                        }
                    }
                }
            }

            Int64 lowest = 1; 
            while (true)
            {
                var seedNr = checkLocationToSeed(lowest);
                if (seedRanges.Any(x => x.Start <= seedNr && seedNr <= x.End))
                {
                    break;
                }
                else
                {
                    lowest++;
                }
            }

            Console.WriteLine("LOWEST:");
            Console.WriteLine(lowest);
            Console.ReadKey();
            return lowest;
        }

        public Int64 checkLocationToSeed(Int64 location)
        {
            var conv = himidityToLocation.Where(x => (x.destinationStart + x.rangeLength) >= location && (x.destinationStart <= location)).FirstOrDefault();
            if (conv != null)
            {
                location += conv.sourceStart - conv.destinationStart ;
            }

            conv = tempToHumidity.Where(x => (x.destinationStart + x.rangeLength) >= location && (x.destinationStart <= location)).FirstOrDefault();
            if (conv != null)
            {
                location += conv.sourceStart - conv.destinationStart;
            }

            conv = lightToTemp.Where(x => (x.destinationStart + x.rangeLength) >= location && (x.destinationStart <= location)).FirstOrDefault();
            if (conv != null)
            {
                location += conv.sourceStart - conv.destinationStart;
            }

            conv = waterToLight.Where(x => (x.destinationStart + x.rangeLength) >= location && (x.destinationStart <= location)).FirstOrDefault();
            if (conv != null)
            {
                location += conv.sourceStart - conv.destinationStart;
            }

            conv = fertilizerToWater.Where(x => (x.destinationStart + x.rangeLength) >= location && (x.destinationStart <= location)).FirstOrDefault();
            if (conv != null)
            {
                location += conv.sourceStart - conv.destinationStart;
            }

            conv = soilToFertilizer.Where(x => (x.destinationStart + x.rangeLength) >= location && (x.destinationStart <= location)).FirstOrDefault();
            if (conv != null)
            {
                location += conv.sourceStart - conv.destinationStart;
            }

            conv = seedToSoilConv.Where(x => (x.destinationStart + x.rangeLength) >= location && (x.destinationStart <= location)).FirstOrDefault();
            if (conv != null)
            {
                location += conv.sourceStart - conv.destinationStart;
            }

            return location;
        }
    }
}
