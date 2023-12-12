using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    public class Graph
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
    }
    public class Node
    {
        public int coordX { get; set; }
        public int coordY { get; set; }
        public char Value { get; set; }

        public bool isExpandedX { get; set; } = false;
        public bool isExpandedY { get; set; } = false;

    }
    public  class Day11
    {
        public int Part1(string[] input)
        {
            var graph = new Graph();

            for(int y = 0; y < input.Length; y++)
            {
                for(int i = 0; i< input[y].Length; i++)
                {
                    graph.Nodes.Add(new Node()
                    {
                        coordX = i,
                        coordY = y,
                        Value = input[y][i]
                    });
                }

                //if (graph.Nodes.Any(x => x.coordY == y && x.Value == '#') == false)
                //{
                //    var nodeList = graph.Nodes.Where(x => x.coordY == y ).Select(x => new Node()
                //    {
                //        coordX = x.coordX,
                //         coordY = x.coordY + 1,
                //         Value = x.Value
                //    }).ToList();
                //    graph.Nodes.AddRange(nodeList);
                //}
            }



            var rowCount = graph.Nodes.GroupBy(x => x.coordX).Count();
            var rowList = new List<Node>();
            for (int i = 0; i < rowCount; i++)
            {
                if (graph.Nodes.Where(x => x.coordY == i).Any(x => x.Value == '#') == false)
                {
                    var n = graph.Nodes.Where(x => x.coordY == i).Select(x => new Node()
                    {
                        coordX = x.coordX,
                        coordY = x.coordY,
                        Value = x.Value,
                        isExpandedY = true
                    }).ToList();
                    rowList.AddRange(n);
                }
            }

            var groupedRow = rowList.GroupBy(x => x.coordY).OrderByDescending(x => x.Key);
            foreach (var k in groupedRow)
            {

                foreach (var node in graph.Nodes.Where(x => x.coordY >= k.Key))
                {
                    node.coordY = node.coordY + 1;
                }
                graph.Nodes.AddRange(k);
            }


            var columnCount = graph.Nodes.GroupBy(x => x.coordX).Count();
            var columnsList = new List<Node>();
            for (int i = 0; i < columnCount; i++)
            {
                if (graph.Nodes.Where(x => x.coordX == i).Any(x => x.Value == '#') == false)
                {
                    var n = graph.Nodes.Where(x => x.coordX == i).Select(x => new Node()
                    {
                        coordX = x.coordX,
                        coordY = x.coordY,
                        Value = x.Value,
                        isExpandedX = true
                    }).ToList();
                    columnsList.AddRange(n);
                }
            }


            var groupedColumn = columnsList.GroupBy(x => x.coordX);
            int ff = 0;
            foreach (var k in groupedColumn)
            {
                foreach (var item in k)
                {
                    item.coordX += ff;
                }

               
                foreach (var node in graph.Nodes.Where(x => x.coordX >= (k.Key + ff)))
                {
                    node.coordX = node.coordX + 1;
                }
                
               
                graph.Nodes.AddRange(k);
                ff++;
            }

            var s = graph.Nodes.GroupBy(x => x.coordY).OrderBy(x => x.Key).ToList();
            for (int i = 0; i < s.Count(); i++)
            {
                var nodes = s[i].OrderBy(x => x.coordX).ToList();
                foreach (var node in nodes)
                {
                    Console.Write(node.Value);
                }
                Console.WriteLine();
            }


            var steps = 0;
            int pairs = 0;

            var allGalaxies = graph.Nodes.Where(x => x.Value == '#').OrderBy(x => x.coordY).ToList();


            for (int i = 0; i < allGalaxies.Count; i++)
            {
                for (int j = i+1; j < allGalaxies.Count; j++)
                {
                    //gå från allGaxaxies[i] till allGalaxies [y]
                    var goalX = allGalaxies[j].coordX;
                    var goalY = allGalaxies[j].coordY;

                    var startX = allGalaxies[i].coordX;
                    var startY = allGalaxies[i].coordY;
                    while (startX != goalX || startY != goalY)
                    {
                        if (startX > goalX)
                        {
                            startX--;
                        }
                        else if(startX < goalX)
                        {
                            startX++;
                        }
                        else if(startY > goalY)
                        {
                            startY--;
                        }
                        else if(startY < goalY)
                        {
                            startY++;
                        }
                        steps++;
                    }
                    pairs++;
                }
            }

            return steps;
        }




        public Int64 Part2(string[] input)
        {
            var graph = new Graph();

            for (int y = 0; y < input.Length; y++)
            {
                for (int i = 0; i < input[y].Length; i++)
                {
                    graph.Nodes.Add(new Node()
                    {
                        coordX = i,
                        coordY = y,
                        Value = input[y][i]
                    });
                }
            }

            var rowCount = graph.Nodes.GroupBy(x => x.coordX).Count();
            var rowList = new List<Node>();
            for (int i = 0; i < rowCount; i++)
            {
                if (graph.Nodes.Where(x => x.coordY == i).Any(x => x.Value == '#') == false)
                {
                    var n = graph.Nodes.Where(x => x.coordY == i).Select(x => new Node()
                    {
                        coordX = x.coordX,
                        coordY = x.coordY,
                        Value = x.Value,
                        isExpandedY = true
                    }).ToList();
                    rowList.AddRange(n);
                }
            }

            var groupedRow = rowList.GroupBy(x => x.coordY).OrderByDescending(x => x.Key);
            foreach (var k in groupedRow)
            {

                foreach (var node in graph.Nodes.Where(x => x.coordY >= k.Key))
                {
                    node.coordY = node.coordY + 1;
                }
                graph.Nodes.AddRange(k);
            }


            var columnCount = graph.Nodes.GroupBy(x => x.coordX).Count();
            var columnsList = new List<Node>();
            for (int i = 0; i < columnCount; i++)
            {
                if (graph.Nodes.Where(x => x.coordX == i).Any(x => x.Value == '#') == false)
                {
                    var n = graph.Nodes.Where(x => x.coordX == i).Select(x => new Node()
                    {
                        coordX = x.coordX,
                        coordY = x.coordY,
                        Value = x.Value,
                        isExpandedX = true
                    }).ToList();
                    columnsList.AddRange(n);
                }
            }


            var groupedColumn = columnsList.GroupBy(x => x.coordX);
            int ff = 0;
            foreach (var k in groupedColumn)
            {
                foreach (var item in k)
                {
                    item.coordX += ff;
                }


                foreach (var node in graph.Nodes.Where(x => x.coordX >= (k.Key + ff)))
                {
                    node.coordX = node.coordX + 1;
                }


                graph.Nodes.AddRange(k);
                ff++;
            }

            var s = graph.Nodes.GroupBy(x => x.coordY).OrderBy(x => x.Key).ToList();
            for (int i = 0; i < s.Count(); i++)
            {
                var nodes = s[i].OrderBy(x => x.coordX).ToList();
                foreach (var node in nodes)
                {
                    Console.Write(node.Value);
                }
                Console.WriteLine();
            }


            Int64 steps = 0;
            int pairs = 0;

            var allGalaxies = graph.Nodes.Where(x => x.Value == '#').OrderBy(x => x.coordY).ToList();
            var lastWasExpanableX = false;
            var lastWasExpanableY = false;

            var allExpandalbes = graph.Nodes.Where(x => x.isExpandedY == true || x.isExpandedX == true).ToList();
            for (int i = 0; i < allGalaxies.Count; i++)
            {
                for (int j = i + 1; j < allGalaxies.Count; j++)
                {
                    
                    var goalX = allGalaxies[j].coordX;
                    var goalY = allGalaxies[j].coordY;

                    var startX = allGalaxies[i].coordX;
                    var startY = allGalaxies[i].coordY;
                    while (startX != goalX || startY != goalY)
                    {
                        if (startX > goalX)
                        {
                            startX--;
                            var node = allExpandalbes.Where(x => x.coordX == startX && x.coordY == startY).FirstOrDefault();
                            if (node != null && node.isExpandedX && lastWasExpanableX == false)
                            {
                                steps = steps + (1000000 - 1);
                                lastWasExpanableX = true;
                            }
                            else 
                            {
                                lastWasExpanableX = false;
                                steps++;
                            }
                        }
                        else if (startX < goalX)
                        {
                            startX++;
                            var node = allExpandalbes.Where(x => x.coordX == startX && x.coordY == startY).FirstOrDefault();
                            if (node != null && node.isExpandedX && lastWasExpanableX == false)
                            {
                                steps = steps + (1000000 - 1);
                                lastWasExpanableX = true;
                            }
                            else
                            {
                                lastWasExpanableX = false;
                                steps++;
                            }
                        }
                        else if (startY > goalY)
                        {
                            startY--;
                            var node = allExpandalbes.Where(x => x.coordX == startX && x.coordY == startY).FirstOrDefault();
                            if (node != null && node.isExpandedY && lastWasExpanableY == false)
                            {
                                steps = steps + (1000000 - 1);
                                lastWasExpanableY = true;
                            }
                            else 
                            {
                                lastWasExpanableY= false;
                                steps++;
                            }
                        }
                        else if (startY < goalY)
                        {
                            startY++;
                            var node = allExpandalbes.Where(x => x.coordX == startX && x.coordY == startY).FirstOrDefault();
                            if (node != null && node.isExpandedY && lastWasExpanableY == false)
                            {
                                steps = steps + (1000000 - 1);
                                lastWasExpanableY = true;
                            }
                            else
                            {
                                lastWasExpanableY = false;
                                steps++;
                            }
                        }
                    }
                    pairs++;
                }
            }
            return steps;
        }
    }
}