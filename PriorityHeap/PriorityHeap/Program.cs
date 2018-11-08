using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityHeap
{
    class Program
    {
        class Heap
        {
            int?[] HeapArray;
            int length = 0;
            public Heap(int n)
            {
                HeapArray = new int?[n];
                for (int i = 0; i < n; i++) HeapArray[i] = null;
                length = 0;
            }

            public void
            Insert(int n)
            {
                HeapArray[length] = n;
                Swim(n, length );
                length++;
            }

            void
            Swim(int value, int currentPosition)
            {
                while (currentPosition > 0)
                {
                    int parentPosition = currentPosition / 2;
                    // if the parent has a smaller value then exchange
                    if (HeapArray[parentPosition].Value < value)
                    {
                        int temp = HeapArray[parentPosition].Value;
                        HeapArray[parentPosition] = value;
                        HeapArray[currentPosition] = temp;
                        //Console.WriteLine($"Exchanging for swim parent {parentPosition} <-> current {currentPosition}");
                    }
                    currentPosition = parentPosition;
                }
            }

            void Exchange(int childPosition, int currentPosition, int value)
            {
                // exchange 
                int temp = HeapArray[childPosition].Value;
                HeapArray[childPosition] = value;
                HeapArray[currentPosition] = temp;
                //Console.WriteLine($"Exchanging for sink {childPosition}: {temp} <-> {currentPosition}: {value}");
            }

            int GetLargerChild(int childPosition)
            {
                if (childPosition == length - 1) return childPosition;
                if (HeapArray[childPosition].HasValue && !HeapArray[childPosition + 1].HasValue) return childPosition;
                if (!HeapArray[childPosition].HasValue && HeapArray[childPosition + 1].HasValue) return childPosition + 1;
                if (HeapArray[childPosition].Value > HeapArray[childPosition + 1].Value) return childPosition;
                else return childPosition + 1;

            }

            void 
            Sink(int value, int currentPosition)
            {
                while (currentPosition < length - 1)
                {
                    int childPosition = currentPosition * 2;
                    if (childPosition > (length - 1)) break;
                    childPosition = GetLargerChild(childPosition);
                    Exchange(childPosition, currentPosition, value);
                    currentPosition = childPosition;
                }
            }

            public int
            DelMax()
            {
                if (length == 0) return -1;
                int maxvalue = HeapArray[0].Value;
                HeapArray[0] = HeapArray[length - 1].Value;
                Sink(HeapArray[0].Value, 0);
                HeapArray[length - 1] = null;
                length--;
                for (int i = 0; i < length; i++)
                {
                    Console.Write($" {HeapArray[i].Value}   ");
                }
                return maxvalue;
            }
        }

        static void Main(string[] args)
        {
            Heap priorityHeap = new Heap(10);
            priorityHeap.Insert(10);
            priorityHeap.Insert(20);
            priorityHeap.Insert(8);
            priorityHeap.Insert(6);
            priorityHeap.Insert(9);
            priorityHeap.Insert(11);
            priorityHeap.Insert(41);
            priorityHeap.Insert(55);
            priorityHeap.Insert(67);
            priorityHeap.Insert(58);

            int max = 0;
            do
            {
                max = priorityHeap.DelMax();
                Console.WriteLine($"Max is {max}");
            }
            while (max > -1);
            Console.ReadLine();
        }
    }
}
