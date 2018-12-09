using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// the problem is this. Givena  tree, where each node has a _next pointer, set the _next pointer to the closest sibling
// at the same height.

namespace NextNodeInTree
{
    class Program
    {
        class Node
        {
            public Node(string val )
            {
                _value = val;
                _left = _right = _next = null;
            }
            public string _value;
            public Node _left;
            public Node _right;
            public Node _next;
        }

        static Node BuildTree()
        {
            //Node root = new NextNodeInTree.Program.Node("A");
            //root._left = new NextNodeInTree.Program.Node("B");
            //root._right = new NextNodeInTree.Program.Node("C");
            //root._left._left = new Node("D");
            //root._left._right = new Node("E");
            //root._right._left = new Node("F");
            //root._right._right = new Node("G");
            Node root = new NextNodeInTree.Program.Node("A");
            root._left = new NextNodeInTree.Program.Node("B");
            root._right = new NextNodeInTree.Program.Node("C");
            root._left._left = new Node("D");
            root._right._left = new Node("F");
            return root;
        }

        static void GetMaxheightOfTree(Node root, ref int maxHeight, int currentHeight)
        {
            if (root == null) return;
            if (root != null) currentHeight++;
            maxHeight = Math.Max(maxHeight, currentHeight);
            GetMaxheightOfTree(root._left, ref maxHeight, currentHeight); 
            GetMaxheightOfTree(root._left, ref maxHeight, currentHeight);
        }

        static void SetCousins(Node root, Node[] siblings, int height )
        {
            if (root == null) return;
            if (siblings[height] != null)
            {
                root._next = siblings[height];
                siblings[height]._next = root;
                siblings[height] = null;
            }
            else
            {
                siblings[height] = root;
            }
            SetCousins(root._left, siblings, height + 1);
            SetCousins(root._right, siblings, height + 1);
        }

        static void PrintTree(Node root)
        {
            if (root == null) return;
            string val, nextval;
            val = root._value;
            nextval = root._next != null ? root._next._value : "null";
            Console.WriteLine($"{val} {nextval}");
            PrintTree(root._left);
            PrintTree(root._right);
        }

        static void Main(string[] args)
        {
            Node root = BuildTree();
            PrintTree(root);
            int maxheight = 0;
            GetMaxheightOfTree(root, ref maxheight, 0);
            Node[] siblings = new Node[maxheight];
            SetCousins(root, siblings, 0);
            PrintTree(root);
            Console.ReadLine();
        }
    }
}
