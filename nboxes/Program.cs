using System;
using System.Collections.Generic;

namespace nboxes
{
    class Program
    {
        static void Main(string[] args)
        {
            Box[] boxes = new Box[3];
            boxes[0] = new Box(10, 10, 10);
            boxes[1] = new Box(20, 12, 15);
            boxes[2] = new Box(21, 3, 2);
            Stack<Box> boxSet = new Stack<Box>();
            Box top;
            Console.WriteLine($"Height = {MaxHeight(boxSet, out top)}");
        }

        static void MaxHeight(Box[] boxes, Stack<Box> boxStack, ref int maxHeight)
        {
            if (boxStack.Count == boxes.Length)
            {
                int height = 0;
                while (boxStack.Count > 0)
                {
                    Box box = boxStack.Pop();
                    height = box.height;
                    Console.Write($"{box.height}");
                }
                maxHeight = Math.Max(maxHeight, height);
            }
            else
            {
                foreach (Box box in boxes)
                {
                    if (boxStack.Contains(box)) continue;
                    if (boxStack.Count == 0)
                    {
                        boxStack.Push(box);
                        MaxHeight(boxes, boxStack, ref maxHeight);
                    }
                    else
                    {
                        Box top = boxStack.Peek();
                        if ((top.width > box.width) && (top.height > box.height) && (top.depth > box.depth))
                        {
                            boxStack.Push(box);
                        }
                        MaxHeight(boxes, boxStack, ref maxHeight);
                    }
                }
            }
        }
    }

    class Box 
    {
        public int width;
        public int depth;
        public int height;
        public Box(int h, int w, int d)
        {
            width = w;
            height = h;
            depth = d;
        }
    }
}
