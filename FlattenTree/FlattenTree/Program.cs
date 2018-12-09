using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Flatten a tree into a doubly linked list.
// the flattening has to be done in place (where the left and right pointers are the same as prev and next pointers in a linked list)
namespace FlattenTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root = BuildTree();
            PrintTree(root);
            ConvertTreeToList(root);
            Console.ReadLine();
        }

        class Node
        {
            public Node(string val)
            {
                _value = val;
                _left = _right = null;
            }
            public string _value;
            public Node _left;
            public Node _right;
        }

        static Node BuildTree()
        {
            Node root = new Node("A");
            root._left = new Node("B");
            root._right = new Node("C");
            root._left._left = new Node("D");
            root._left._right = new Node("E");
            root._right._left = new Node("F");
            root._right._right = new Node("G");
            return root;
        }

        static void PrintTree(Node root)
        {
            if (root == null) return;
            string val;
            val = root._value;
            Console.WriteLine($"{val}");
            PrintTree(root._left);
            PrintTree(root._right);
        }

        static void PrintList(Node head)
        {
            Console.Write("Printing list :");
            Node current = head;
            Node prev = null;
            while (current != null)
            {
                Console.Write($"{current._value} ");
                if (prev != null)
                {
                    if (prev != current._left)
                    {
                        Console.WriteLine("Prev does not match what's in current");
                    }
                }
                prev = current;
                current = current._right;
            }
            Console.WriteLine();
        }

        static void ConvertTreeToListHelper(Node current, ref Node head, ref Node prev)
        {
            Console.WriteLine($"Evaluating {current._value}");
            if (current._left == null)
            {
                if (head == null)  head = current;
                if (prev == null)
                {
                    prev = current;
                }
                else
                {
                    current._left = prev;
                    prev._right = current;
                    prev = current;
                }
            }
            else
            {
                ConvertTreeToListHelper(current._left, ref head, ref prev);
                current._left = prev;
                prev._right = current;
                prev = current;
            }
            if (current._right != null)
            {
                ConvertTreeToListHelper(current._right, ref head, ref prev);
            }
        }

        static void
        ConvertTreeToList(Node root)
        {
            Node head, prev;
            head = prev = null;
            ConvertTreeToListHelper(root, ref head, ref prev);
            PrintList(head);
        }
    }
}
