using System;

namespace intstream
{
    class Program
    {
        static void Main(string[] args)
        {
            Bst bst = new Bst();
            bst.Track(5);
            bst.Track(1);
            bst.Track(4);
            bst.Track(4);
            bst.Track(5);
            bst.Track(9);
            bst.Track(7);
            bst.Track(13);
            bst.Track(3);
            bst.PrintTree();
            Console.WriteLine($"Rank of 1 is {bst.GetRankOfNumber(1)}");
            Console.WriteLine($"Rank of 3 is {bst.GetRankOfNumber(3)}");
            Console.WriteLine($"Rank of 4 is {bst.GetRankOfNumber(4)}");
        }
    }

    class Node 
    {
        public int val;
        public Node left;
        public Node right;
        public Node(int v)
        {
            val = v;
            left = right = null;
        }
    }

    class Bst
    {
        Node root;
        public Bst()
        {
            root = null;
        }

        public void Track(int x)
        {
            Insert(x, ref root);
        }

        void
        Insert(int x, ref Node current)
        {
            if (current == null)
            {
                current =  new Node(x);
            }
            else
            {
                if (current.val > x)
                {
                    Insert(x, ref current.left);
                }
                else
                {
                    Insert(x, ref current.right);
                }
            }
        }

        public void PrintTree()
        {
            PrintTree(root);
        }
        void PrintTree(Node current)
        {
            if (current == null) return;;
            PrintTree(current.left);
            Console.WriteLine($"{current.val}");
            PrintTree(current.right);
        }

        public int GetRankOfNumber(int x)
        {
            int rank = 0;
            FindRank(x, root, ref rank);
            return rank;
        }

        void
        FindRank(int x, Node current, ref int rank)
        {
            if (current == null) return;
            FindRank(x, current.left, ref rank );
            if (current.val >= x) 
            {
                return;
            }
            else
            {
                rank++;
                FindRank(x, current.right, ref rank );
            }
        }
    }
}
