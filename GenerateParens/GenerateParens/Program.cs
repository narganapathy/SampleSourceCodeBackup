using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateParens
{
    class Program
    {
        static void Main(string[] args)
        {
            //HashSet<string> parentSet;
            //parentSet= GenerateParens(3);
            //foreach (string s in parentSet)
            //{
            //    Console.WriteLine(s);
            //}
            GenerateParens1(3);
            Console.ReadLine();
        }

        static void
        GenerateParens1(int n)
        {
            char[] str = new char[2 * n];
            printParenthesis(str, n);
        }



        static HashSet<string> GenerateParens(int numParens)
        {
            if (numParens == 1)
            {
                HashSet<string> smallSet = new HashSet<string>();
                smallSet.Add("()");
                return smallSet;
            }

            HashSet<string> smallerSet = GenerateParens(numParens - 1);
            HashSet<string> largeSet = new HashSet<string>();
            foreach (string s in smallerSet)
            {
                largeSet.Add("(" + s + ")");
                largeSet.Add("(" + ")" + s);
                largeSet.Add(s + "(" + ")");
            }
            return largeSet;
        }

        // Function that print all combinations of  
        // balanced parentheses 
        // open store the count of opening parenthesis 
        // close store the count of closing parenthesis 
        static void _printParenthesis(char[] str,
                int pos, int n, int open, int close)
        {
            Console.WriteLine($" {new string(str)} {pos} {open} {close}");
            if (close == n)
            {
                // print the possible combinations 
                for (int i = 0; i < str.Length; i++)
                    Console.Write(str[i]);

                Console.WriteLine();
                return;
            }
            else
            {
                if (open > close)
                {
                    str[pos] = '}';
                    _printParenthesis(str, pos + 1,
                                    n, open, close + 1);
                    str[pos] = '\0';
                }
                if (open < n)
                {
                    str[pos] = '{';
                    _printParenthesis(str, pos + 1,
                                    n, open + 1, close);
                    str[pos] = '\0';
                }
            }
        }

        // Wrapper over _printParenthesis() 
        static void printParenthesis(char[] str, int n)
        {
            if (n > 0)
                _printParenthesis(str, 0, n, 0, 0);
            return;
        }
    }
}
