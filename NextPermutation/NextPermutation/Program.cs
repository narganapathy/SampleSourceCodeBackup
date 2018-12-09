using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{NextPermutation(2143)}");
            Console.ReadLine();

        }

        static int GetNextHigherElement(int index, List<int> digits)
        {
            // ignore the higher elements than index
            List<int> digitSet = new List<int>();
            for (int i = index; i >= 0; i--)
            {
                digitSet.Add(digits[i]);
            }
            digitSet.Sort();

            foreach (int i in digitSet)
            {
                if (i > digits[index])
                    return i;
            }
            return digits[index];
        }
        static int GetLowestElement(HashSet<int> digitSet)
        {
            int minDigit = int.MaxValue;
            foreach (int i in digitSet)
            {
                if (i < minDigit) minDigit = i;
            }
            return minDigit;
        }


        static int NextPermutation(int source)
        {
            // find digits and add them to the set
            HashSet<int> digitSet = new HashSet<int>();
            List<int> digits = new List<int>();
            int maxDigit = -1;
            int maxDigitIndex = -1;
            int i = 0;
            while (source > 0)
            {
                int digit = source % 10;
                if (digit > maxDigit)
                {
                    maxDigit = digit;
                    maxDigitIndex = i;
                }

                digits.Add(digit);
                digitSet.Add(digit);
                source /= 10;
                i++;
            }
            List<int> sortedDigits = new List<int>(digits);
            sortedDigits.Sort();

            digits[maxDigitIndex + 1] = GetNextHigherElement(maxDigitIndex+1, digits);
            for (i = maxDigitIndex+1; i < digits.Count; i++)
            {
                digitSet.Remove(digits[i]); // remove the higher index values;
            }

            for (i = maxDigitIndex; i >=0; i--)
            {
                digits[i] = GetLowestElement(digitSet);
                digitSet.Remove(digits[i]);
            }

            int newValue = 0;
            for (int j = digits.Count - 1; j >= 0; j--)
            {
                newValue = newValue * 10 + digits[j];
            }
            return newValue;
        }
    }
}
