using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph
    {
        bool[,] adjMatrix;
        bool[] visited;
        int _maxVertex;

        public Graph(int maxVertex)
        {
            adjMatrix = new bool[maxVertex, maxVertex];
            visited = new bool[maxVertex];
            _maxVertex = maxVertex;
        }

        public void
        AddEdge(int from, int to)
        {
            adjMatrix[from,to] = true;
            adjMatrix[to,from] = true;
        }

        public void
        RemoveEdge(int from, int to)
        {
            adjMatrix[from,to] = false;
            adjMatrix[to,from] = false;
        }

        public void
        ClearVisited()
        {
            for (int i = 0; i < _maxVertex; i++)
            {
                visited[i] = false;
            }
        }

        public void Dfs(int vert)
        {
            visited[vert] = true;
            Console.WriteLine("Visited {0}", vert);
            for (int i = 0; i < _maxVertex; i++)
            {
                if ( adjMatrix[vert, i] == true)
                {
                    if (!visited[i])
                        Dfs(i);
                }
            }
        }

        public void Bfs(int vert)
        {
            Queue<int> queue = new Queue<int>();
            if (visited[vert] == false)
                Console.WriteLine("Visited {0}", vert);
            for (int i = 0; i < _maxVertex; i++)
            {
                if (adjMatrix[vert, i] == true)
                {
                    if (!visited[i])
                    {
                        queue.Enqueue(i);
                    }
                }
            }
            visited[vert] = true;

            while (queue.Count > 0)
            {
                int adjVert = queue.Dequeue();
                Bfs(adjVert);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(4);
            g.AddEdge(0,1);
            g.AddEdge(1,3);
            g.AddEdge(1,2);
            g.AddEdge(0,2);
            Console.WriteLine("Doing DFS");
            g.Dfs(0);
            g.ClearVisited();
            Console.WriteLine("Doing BFS");
            g.Bfs(0);
        }
    }
}
