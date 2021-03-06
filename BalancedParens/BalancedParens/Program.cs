﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParens
{
    // print all the balanced parens sub string
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Final string is {BalancedParens1("(())(()()")}");
            Console.ReadLine();
        }

        static string BalancedParens1(string s)
        {
            Stack<int> parentStack = new Stack<int>();
            List<int> indexesToIgnore = new List<int>();
            char[] sarray = s.ToCharArray();
            for (int i = 0; i < sarray.Length; i++)
            {
                if (sarray[i] == '(')
                {
                    parentStack.Push(i);
                }
                if (sarray[i] == ')')
                {
                    if (parentStack.Count == 0) 
                    {
                        indexesToIgnore.Add(i);
                        continue;
                    }
                    parentStack.Pop();
                }
            }
            while (parentStack.Count > 0)
            {
                indexesToIgnore.Add(parentStack.Pop());
            }
            string finalString = string.Empty;
            for (int i = 0; i < sarray.Length; i++)
            {
                if (!indexesToIgnore.Contains(i))
                {
                    finalString += sarray[i];     
                }
            }
            return finalString;
        }
        static string BalancedParens(string s)
        {
            int len = s.Length;
            char[] stringArray = s.ToCharArray();
            string finalString = string.Empty;
            for (int i = 1; i< len; i++)
            {
                string balancedParens = GetMatchingString(stringArray, i - 1, i);
                if (balancedParens != null)
                {
                    if (balancedParens.Length > finalString.Length)
                    {
                        finalString = balancedParens;
                    }
                }
            }
            return finalString;
        }

        static string GetMatchingString(char[] stringArray, int left, int right)
        {
            Console.WriteLine($"left {left} right {right}");
            while (left >= 0 && right < stringArray.Length)
            {
                if ((stringArray[left] == ')' && stringArray[right] == '(') ||
                    (stringArray[left] == '(' && stringArray[right] == ')'))
                {
                    Console.WriteLine($"Found matching parens {left} {right}");
                    left--;
                    right++;
                }
                else
                {
                    break;
                }
            }
            int startIndex = left + 1;
            int endIndex = right - 1;
            Console.WriteLine($"startIndx {startIndex} endIndex {endIndex}");
            if ((endIndex - startIndex) < 1) return null;
            // parens has to be closed
            if ((stringArray[startIndex] == ')') || (stringArray[endIndex] == '('))
            {
                startIndex++; endIndex--;    
            }
            string matchingString = new string(stringArray, startIndex, (endIndex - startIndex) + 1);
            Console.WriteLine($"matching {matchingString}");
            return matchingString;
        }
    }
}
