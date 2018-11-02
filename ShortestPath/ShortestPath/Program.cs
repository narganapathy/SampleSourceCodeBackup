using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadGraphInput(args[0]);
            graph.PrintGraph();
            graph.DepthFirstSearch("Node1");
            Console.ReadLine();
        }

        public class Edge
        {
            public Node Neighbor { get; set; }
            public int Cost { get; set; }
            public Edge(Node neighbor, int cost)
            {
                Neighbor = neighbor;
                Cost = cost;
            }
        }

        public class Node
        {
            int _nodeCost;
            List<Edge> _edges;
            public string Name { get; set; }
            public Node(string name, int cost)
            {
                _nodeCost = cost;
                _edges = new List<Edge>();
                Name = name;
            }

            // edge from current node -> neighbor
            public void
            AddEdge(Node neighbor, int cost)
            {
                Edge edge = new Edge(neighbor, cost);
                _edges.Add(edge);
            }

            public void
            RemoveEdge(Node neighbor)
            {
                Edge edgeToRemove = null;
                foreach (Edge edge in _edges)
                {
                    if (edge.Neighbor == neighbor)
                    {
                        edgeToRemove = edge;
                        break;
                    }
                }
                _edges.Remove(edgeToRemove);
            }

            public List<Node>
            GetAdjacentNodes()
            {
                List<Node> adjacentNodes = new List<Node>();
                foreach (Edge edge in _edges)
                {
                    adjacentNodes.Add(edge.Neighbor);
                }
                return adjacentNodes;
            }

            public List<Edge>
            GetEdges()
            {
                return _edges;
            }


        }

        public class Graph
        {
            List<Node> _nodes;
            public Graph()
            {
                _nodes = new List<Node>();
            }

            void
            AddNode(Node node)
            {
                _nodes.Add(node);
            }

            Node
            FindNode(string nodeName)
            {
                foreach (Node n in _nodes)
                {
                    if (n.Name == nodeName) return n;
                }
                return null;
            }

            void
            AddDirectedEdge(Node from, Node to, int cost)
            {
                from.AddEdge(to, cost);
            }

            void
            AddUndirectedEdge(Node from, Node to, int cost)
            {
                from.AddEdge(to, cost);
                to.AddEdge(from, cost);
            }

            public void
            PrintGraph()
            {
                foreach (Node n in _nodes)
                {
                    Console.Write($"{n.Name} : ");
                    List<Node> neighbors = n.GetAdjacentNodes();
                    foreach (Edge edge in n.GetEdges())
                    {
                        Console.Write($" {edge.Neighbor.Name}:{edge.Cost}");
                    }
                    Console.WriteLine();
                }
            }

            public void
            DepthFirstSearch(string nodeName)
            {
                Node n = FindNode(nodeName);
                HashSet<Node> visitedNodes = new HashSet<Node>();
                DepthFirstSearch(n, visitedNodes);
            }

            public void
            DepthFirstSearch(Node initialNode, HashSet<Node> visitedNodes)
            {
                if (visitedNodes.Add(initialNode) == false) return;
                Console.WriteLine($"Visited node {initialNode.Name}");
                List<Node> neighBours = initialNode.GetAdjacentNodes();
                foreach (Node n in neighBours)
                {
                    DepthFirstSearch(n, visitedNodes);
                }
            }

            public void
            ReadGraphInput(string fileName)
            {
                if (!File.Exists(fileName))
                {
                    Console.WriteLine($"File {fileName} does not exist");
                }
                string[] fileContent = File.ReadAllLines(fileName);

                // get all the nodes
                foreach (string s in fileContent)
                {
                    if (s.StartsWith("#")) continue; // ignore lines starting with #
                    string[] components = s.Split(' '); // this gives the nodename and edges
                    Node sourceNode = FindNode(components[0]);
                    if (sourceNode != null)
                    {
                        Console.WriteLine($"Node already exists {components[0]}");
                    }
                    else
                    {
                        AddNode(new Node(components[0], 0));
                    }
                }

                // add all the edges
                foreach (string s in fileContent)
                {
                    if (s.StartsWith("#")) continue; // ignore lines starting with #
                    string[] components = s.Split(' '); // this gives the nodename and edges
                    Node sourceNode = FindNode(components[0]);
                    for (int i = 1; i < components.Length; i++)
                    {
                        string[] edgeComponents = components[i].Split(':');
                        Node destinationNode = FindNode(edgeComponents[0]);
                        if (destinationNode == null)
                        {
                            Console.WriteLine($"Cannot find node with name {edgeComponents[0]}");
                        }
                        int cost;
                        if (!int.TryParse(edgeComponents[1], out cost))
                        {
                            Console.WriteLine($"Cannot find cost of edge with name {edgeComponents[0]}, {edgeComponents[1]}");
                        }
                        AddDirectedEdge(sourceNode, destinationNode, cost);
                    }
                }
            }
        }
    }
}
