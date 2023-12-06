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

    public class Day5
    {
        //public Dictionary<BigInteger, BigInteger> seedToSoil = new Dictionary<BigInteger, BigInteger>();
        //public Dictionary<BigInteger, BigInteger> soilToFertilizer = new Dictionary<BigInteger, BigInteger>();
        //public Dictionary<BigInteger, BigInteger> fertilizerToWater = new Dictionary<BigInteger, BigInteger>();
        //public Dictionary<BigInteger, BigInteger> waterToLight = new Dictionary<BigInteger, BigInteger>();
        //public Dictionary<BigInteger, BigInteger> lightToTemp = new Dictionary<BigInteger, BigInteger>();
        //public Dictionary<BigInteger, BigInteger> tempToHumidity = new Dictionary<BigInteger, BigInteger>();
        //public Dictionary<BigInteger, BigInteger> himidityToLocation = new Dictionary<BigInteger, BigInteger>();

        public List<Converter> seedToSoilConv = new List<Converter>();
        public List<Converter> soilToFertilizer = new List<Converter>();
        public List<Converter> fertilizerToWater = new List<Converter>();
        public List<Converter> waterToLight = new List<Converter>();
        public List<Converter> lightToTemp = new List<Converter>();
        public List<Converter> tempToHumidity = new List<Converter>();
        public List<Converter> himidityToLocation = new List<Converter>();
        //public Converter soilToFertilizer = new Converter();
        //public Converter fertilizerToWater = new Converter();
        //public Converter waterToLight = new Converter();
        //public Converter lightToTemp = new Converter();
        //public Converter tempToHumidity = new Converter();
        //public Converter himidityToLocation = new Converter();

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
            var answer = 0;
            List<BigInteger> seeds = new List<BigInteger>();
            var seedsRange = Regex.Matches(input[0], @"\d+").ToList().Select(x => BigInteger.Parse(x.Value)).ToList();

            var f = seedsRange.Count / 2;
            for(int c = 0; c < seedsRange.Count; c++)
            {
                Console.WriteLine($"c: {c}");
                for (BigInteger i = 0; i < seedsRange[c+1]; i++)
                {
                    seeds.Add(seedsRange[c] + i);
                }
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

            BigInteger lowest = -1;
            foreach (var seed in seeds)
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

            Console.WriteLine("LOWEST:");
            Console.WriteLine(lowest);
            return lowest;
        }
    }
}
