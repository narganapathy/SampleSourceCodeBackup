﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    // find the kth permutation
    class Program
    {
        static void Main(string[] args)
        {
            GeneratePermutation("MAR");
            //FindPermutationForRank(3, 2);
        }


        static public string
        FindPermutationForRank(int n, int k)
        {
            int[] factorials = new int[n+1];
            int[] values = new int[n];
            int index = -1;
            int remainder = k-1;
            List<int> chosenValues = new List<int>();

            factorials[0] = 1;
            for (int i = 1; i<= n; i++)
            {
                factorials[i] = i * factorials[i - 1];
                Console.WriteLine($"Factorial {i} : {factorials[i]}");
            }

            for (int i = 1; i <=n; i++)
            {
                chosenValues.Add(i);
            }
            chosenValues.Sort();
            // go from left to right
            for (int i = n; i >= 1; i--)
            {
                index = remainder / factorials[i-1];
                remainder = remainder % factorials[i-1];
                int chosenIndex = chosenValues[index]; // remove the minimum value at that index;
                chosenValues.RemoveAt(index);
                values[i-1] = chosenIndex;
                Console.WriteLine($"{i} {index} {remainder} {chosenIndex}");
            }
            string finalString = string.Empty;
            for (int i = n-1; i >= 0; i--)
            {
                finalString += values[i];
            }
            Console.WriteLine(finalString);
            Console.ReadLine();
            return finalString;
        }

        static void PermutationHelper(List<char> sarray, string chosen)
        {
            //Console.Write($"Sarray {sarray.Count} chosen {chosen} ");
            //foreach (char c in sarray) Console.Write(c);
            //Console.WriteLine();
            if (0 == sarray.Count)
            {
                Console.WriteLine(chosen);
                return;
            }

            for (int i = 0; i < sarray.Count; i++)
            {
                char c = sarray[i];
                string newchosen = chosen + c;
                sarray.RemoveAt(i);
                PermutationHelper(sarray, newchosen);
                sarray.Insert(i, c);
            }
        }

        static void
        GeneratePermutation(string s)
        {
            PermutationHelper(s.ToList(), string.Empty);
            Console.ReadLine();
        }
    }
}
