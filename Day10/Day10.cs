using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Day10
{
    //public Dictionary<char, List<char>> validConnections = new Dictionary<char, List<char>>()
    //{
    //    { '|' ,  new List<char>() { 'S', 'L', 'J', '7', 'F' } }
    //}

    public class Loop
    {
        public List<Link> Steps { get; set; }
        
    }

    public class Graph
    {
        public List<Node> Nodes = new List<Node>();
        public List<Link> Links = new List<Link>();
    }

    public class Link
    {
        public Node Source;
        public Node Target;

    }
    public class Node
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public char Value { get; set; }
        public bool Visited { get; set; } = false;

    }

    public  class Day10
    {

        public Graph GetGraph(string[] input)
        {
            var graph = new Graph();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[y].Length; x++)
                {
                    graph.Nodes.Add(new Node()
                    {
                        CoordinateX = x,
                        CoordinateY = y,
                        Value = input[y][x]
                    });
                }
            }

            foreach (var node in graph.Nodes)
            {
                var nodeValue = node.Value;
                switch (node.Value)
                {
                    case '|':
                        {
                            //  kolla uppåt och neråt
                            var nodeAbove = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX && x.CoordinateY == node.CoordinateY - 1).FirstOrDefault();
                            if (nodeAbove != null && (nodeAbove.Value == 'F' || nodeAbove.Value == '7' || nodeAbove.Value == '|' || nodeAbove.Value == 'S'))
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeAbove) || (x.Node1 == nodeAbove && x.Node2 == node)))
                                //{
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeAbove
                                    });
                                //}

                            }
                            var nodeBelow = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX && x.CoordinateY == node.CoordinateY + 1).FirstOrDefault();
                            if (nodeBelow != null && (nodeBelow.Value == 'J' || nodeBelow.Value == 'L' || nodeBelow.Value == '|' || nodeBelow.Value == 'S'))
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeBelow) || (x.Node1 == nodeBelow && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeBelow
                                    });
                              //  }
                            }
                            break;
                        }

                    case '-':
                        {
                            //  kolla vänster och höger

                            var nodeLeft = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX - 1 && x.CoordinateY == node.CoordinateY).FirstOrDefault();
                            if (nodeLeft != null && (nodeLeft.Value == 'L' || nodeLeft.Value == '-' || nodeLeft.Value == 'F' || nodeLeft.Value == 'S'))
                            {
                               // if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeLeft) || (x.Node1 == nodeLeft && x.Node2 == node)))
                              //  {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeLeft
                                    });
                               // }
                            }

                            var nodeRight = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX + 1 && x.CoordinateY == node.CoordinateY).FirstOrDefault();
                            if (nodeRight != null && (nodeRight.Value == '7' || nodeRight.Value == '-' || nodeRight.Value == 'J' || nodeRight.Value == 'S'))
                            {
                              //  if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeRight) || (x.Node1 == nodeRight && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeRight
                                    });
                               // }
                            }
                            break;
                        }

                    case 'L':
                        {
                            //  kolla uppåt och höger
                            var nodeAbove = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX && x.CoordinateY == node.CoordinateY - 1).FirstOrDefault();
                            if (nodeAbove != null && (nodeAbove.Value == 'F' || nodeAbove.Value == '7' || nodeAbove.Value == '|' || nodeAbove.Value == 'S'))
                            {
                              //  if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeAbove) || (x.Node1 == nodeAbove && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeAbove
                                    });
                               // }
                            }

                            var nodeRight = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX + 1 && x.CoordinateY == node.CoordinateY).FirstOrDefault();
                            if (nodeRight != null && (nodeRight.Value == '7' || nodeRight.Value == '-' || nodeRight.Value == 'J' || nodeRight.Value == 'S'))
                            {
                               // if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeRight) || (x.Node1 == nodeRight && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeRight
                                    });
                               // }
                            }
                            break;
                        }

                    case 'J':
                        {
                            //  kolla vänster och uppåt
                            var nodeLeft = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX - 1 && x.CoordinateY == node.CoordinateY).FirstOrDefault();
                            if (nodeLeft != null && (nodeLeft.Value == 'L' || nodeLeft.Value == '-' || nodeLeft.Value == 'F' || nodeLeft.Value == 'S'))
                            {
                               // if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeLeft) || (x.Node1 == nodeLeft && x.Node2 == node)))
                                //{
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeLeft
                                    });
                                //}
                            }

                            var nodeAbove = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX && x.CoordinateY == node.CoordinateY - 1).FirstOrDefault();
                            if (nodeAbove != null && (nodeAbove.Value == 'F' || nodeAbove.Value == '7' || nodeAbove.Value == '|' || nodeAbove.Value == 'S'))
                            {
                               // if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeAbove) || (x.Node1 == nodeAbove && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeAbove
                                    });
                                //}
                            }
                            break;
                        }

                    case '7':
                        {
                            //  kolla vänster och nedåt

                            var nodeLeft = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX - 1 && x.CoordinateY == node.CoordinateY).FirstOrDefault();
                            if (nodeLeft != null && (nodeLeft.Value == 'L' || nodeLeft.Value == '-' || nodeLeft.Value == 'F' || nodeLeft.Value == 'S'))
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeLeft) || (x.Node1 == nodeLeft && x.Node2 == node)))
                                //{
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeLeft
                                    });
                                //}
                            }

                            var nodeBelow = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX && x.CoordinateY == node.CoordinateY + 1).FirstOrDefault();
                            if (nodeBelow != null && (nodeBelow.Value == 'J' || nodeBelow.Value == 'L' || nodeBelow.Value == '|' || nodeBelow.Value == 'S'))
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeBelow) || (x.Node1 == nodeBelow && x.Node2 == node)))
                                //{
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeBelow
                                    });
                               // }
                            }
                            break;
                        }

                    case 'F':
                        {
                            //  kolla nedåt och höger

                            var nodeRight = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX + 1 && x.CoordinateY == node.CoordinateY).FirstOrDefault();
                            if (nodeRight != null && (nodeRight.Value == '7' || nodeRight.Value == '-' || nodeRight.Value == 'J' || nodeRight.Value == 'S'))
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeRight) || (x.Node1 == nodeRight && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeRight
                                    });
                                //}
                            }

                            var nodeBelow = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX && x.CoordinateY == node.CoordinateY + 1).FirstOrDefault();
                            if (nodeBelow != null && (nodeBelow.Value == 'J' || nodeBelow.Value == 'L' || nodeBelow.Value == '|' || nodeBelow.Value == 'S'))
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeBelow) || (x.Node1 == nodeBelow && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeBelow
                                    });
                                //}
                            }
                            break;
                        }

                    case 'S':
                        {
                            var nodeAbove = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX && x.CoordinateY == node.CoordinateY - 1).FirstOrDefault();
                            var nodeBelow = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX && x.CoordinateY == node.CoordinateY + 1).FirstOrDefault();
                            var nodeRight = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX + 1 && x.CoordinateY == node.CoordinateY).FirstOrDefault();
                            var nodeLeft = graph.Nodes.Where(x => x.CoordinateX == node.CoordinateX - 1 && x.CoordinateY == node.CoordinateY).FirstOrDefault();
                            if (nodeAbove != null && nodeAbove.Value != '.')
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeAbove) || (x.Node1 == nodeAbove && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeAbove
                                    });
                               // }
                            }
                            if (nodeBelow != null && nodeBelow.Value != '.')
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeBelow) || (x.Node1 == nodeBelow && x.Node2 == node)))
                                //{
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeBelow
                                    });
                                //}
                            }
                            if (nodeRight != null && nodeRight.Value != '.')
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeRight) || (x.Node1 == nodeRight && x.Node2 == node)))
                                //{
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeRight
                                    });
                                //}
                            }
                            if (nodeLeft != null && nodeLeft.Value != '.')
                            {
                                //if (!graph.Links.Any(x => (x.Node1 == node && x.Node2 == nodeLeft) || (x.Node1 == nodeLeft && x.Node2 == node)))
                               // {
                                    graph.Links.Add(new Link()
                                    {
                                        Source = node,
                                        Target = nodeLeft
                                    });
                               // }
                            }
                            break;
                        }
                }
            }

            return graph;
        }

        public List<Link> GetLoop(Graph graph)
        {
            var path = new List<Link>();
            var sNode = graph.Nodes.Where(x => x.Value == 'S').First();

            var link = graph.Links.Where(x => x.Source == sNode).FirstOrDefault();
            path.Add(link);
            sNode = link.Target;
            sNode.Visited = true;
            int i = 0;
            while (link != null && link.Target.Value != 'S')
            {
                link = graph.Links.Where(x => x.Source == sNode && x.Target.Visited == false).FirstOrDefault();
                if (link != null)
                {
                    path.Add(link);
                    sNode = link.Target;
                    sNode.Visited = true;
                }
            }
            return path;
        }

        public int Part1(string[] input)
        {
            var graph = GetGraph(input);
            var path = GetLoop(graph);
            var longest = path.Count() / 2;

            return longest;
        }

        public int Part2(string[] input)
        {
            var graph = GetGraph(input);
            var path = GetLoop(graph);

            var s = path.Where(x => x.Target.Value == 'S').FirstOrDefault();
            return 0;
        }
    }
}
