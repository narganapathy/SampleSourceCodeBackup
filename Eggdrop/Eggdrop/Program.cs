using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eggdrop
{
    class Program
    {
    // A utility function to get maximum of two integers
    static int max(int a, int b) { return (a > b)? a: b; }

    static int eggDrop(int n, int k)
    {
        // If there are no floors, then no trials needed. OR if there is
        // one floor, one trial needed.
        if (k == 1 || k == 0)
        {
            Console.WriteLine("EggDrop {0} {1} = {2}", n, k, k);
            return k;
        }

        // We need k trials for one egg and k floors
        if (n == 1)
        {
            Console.WriteLine("EggDrop {0} {1} = {2}", n, k, k);
            return k;
        }

        int min = int.MaxValue, x, res, finalX = -1;

        // Consider all droppings from 1st floor to kth floor and
        // return the minimum of these values plus 1.
        for (x = 1; x <= k; x++)
        {
            res = max(eggDrop(n - 1, x - 1), eggDrop(n, k - x));
            if (res < min)
            {
                min = res;
                finalX = x;
            }

        }
        Console.WriteLine("EggDrop {0} {1} = {2} {3}", n, k, min+1, finalX);
        return min + 1;
    }
     
  

        static void Main(string[] args)
        {
                int n = 2, k = 100;
                Console.WriteLine ("\nMinimum number of trials in worst case with {0} eggs and {1} floors is {2}\n", n, k, eggDrop(n, k));
        }
    }
}
