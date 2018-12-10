using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postfix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{BuildPostFix("A*(B+C*D)+E")}");
            Console.ReadLine();
        }

        static bool IsOperator(char c)
        {
            return (c == '*') || (c == '/') || (c == '+') || (c == '^') || (c == '-') || (c == ')') || (c == '(');
        }

        static int GetOperatorLevel(char c)
        {
            if (c == '(') return 4;
            if ((c == '*') || (c == '/')) return 2;
            if ((c == '+') || (c == '-')) return 1;
            if (c == '^') return 3;
            return 0;
        }

        static bool IsHigherPrecedence(char c1, char c2)
        {
            return (GetOperatorLevel(c1) > GetOperatorLevel(c2));
        }


        static string
        BuildPostFix(string s)
        {
            string finalString = string.Empty;
            char[] sarray = s.ToCharArray();
            Stack<char> currentStack = new Stack<char>();
            for (int i = 0; i < sarray.Length; i++)
            {
                char c = sarray[i];
                ProcessOperator(c, currentStack, ref finalString);
            }
            while (currentStack.Count > 0)
            {
                finalString += currentStack.Pop();
            }
            return finalString;
        }

        static void
        ProcessOperator(char c, Stack<char> opStack, ref string finalString)
        {
                if (IsOperator(c))
                {
                    if (opStack.Count == 0)
                    {
                        opStack.Push(c);
                        return;
                    }

                    if (c == ')')
                    {
                        while (opStack.Count > 0)
                        {
                            char c1 = opStack.Pop();
                            if (c1 == '(') break;
                            finalString += c1;
                        }
                        return;
                    }
                    
                    char topOfStack = opStack.Peek();
                    if (topOfStack == '(')
                    {
                        opStack.Push(c);
                        return;
                    }

                    if (IsHigherPrecedence(c, topOfStack))
                    {
                        opStack.Push(c);
                    }
                    else
                    {
                        finalString += opStack.Pop();
                        opStack.Push(c);
                    }
                }
                else
                {
                    finalString += c;
                }
        }
    }
}
