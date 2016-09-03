using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Palindrome
{
    class Program
    {

        static void Main(string[] args)
        {
            Stack<char> myStack = new Stack<char>();

            String s = args[0];
            bool matchState = false;
            int currentPalindromeLength = 0;
            int maxLength = 0;

            foreach (char c in s)
            {
                //
                // If matchstate then keep popping until you find a mismatch
                //

                if (matchState) {
                    if (myStack.Count > 0)  {
                        char top = myStack.Pop();
                        if (c == top) {
                            matchState = true;
                            currentPalindromeLength += 2;
                            if (currentPalindromeLength > maxLength) {
                                maxLength = currentPalindromeLength;
                            }

                            continue;
                        } 
                    }
                    matchState = false;
                    continue;
                }

                // Check against the top and top -1
                if (myStack.Count > 0) {
                    char top = myStack.Pop();
                    char nexttotop;

                    if (c == top)
                    { // goto match state
                        currentPalindromeLength = 2;
                        matchState = true;
                        continue;
                    }

                    if (myStack.Count > 0)
                    {
                        nexttotop = myStack.Pop();
                        if (c == nexttotop)
                        {
                            matchState = true;
                            currentPalindromeLength = 3;
                            continue;
                        }
                        myStack.Push(nexttotop);
                    }
                    myStack.Push(top);
                }
                myStack.Push(c);
            }

            Console.WriteLine("Max Palindrome length in " + s + " is " + maxLength);
        }
    }
}
