using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProgram
{
    class Program
    {
        class KnapSack
        {
            int[] _numItemsInPile;
            int[] _weights;
            int[] _volumes;
            int[] sortedOrder = { 0, 1, 2};
            int _maxVolume;
            enum findPileAction {done, goforward, goback};
            public KnapSack(int[] weights, int [] volume, int maxVolume)
            {
                _numItemsInPile = new int[volume.Length];
                _weights =  weights;
                _volumes = volume;
                _maxVolume = maxVolume;
            }

            findPileAction FindBestPile(int sortIndex, int remainingVolume) 
            {
                if (remainingVolume == 0) {
                    // hit the jackpot
                    Console.WriteLine("{0} volume zero Done", sortIndex);
                    return findPileAction.done;
                }

                if (sortIndex >= sortedOrder.Length)
                {
                    Console.WriteLine("{0} lenght exceeded Done", sortIndex);
                    return findPileAction.done;
                }

                int pileIndex = sortedOrder[sortIndex];

                // fill to the most possible number
                int numItemsInPile = remainingVolume/_volumes[pileIndex];
                remainingVolume = remainingVolume % _volumes[pileIndex];

                _numItemsInPile[pileIndex] = numItemsInPile;
                for (int i = 0; i < _numItemsInPile.Length; i++)
                {
                    Console.Write("{0}:{1}, ",i, _numItemsInPile[i]);
                }
                Console.WriteLine(" ");

                // the remainder is too small to accomodate
                // current sort index. So go to next one
                // 
                if (numItemsInPile == 0)  {

                    Console.WriteLine(" Going back");

                    return findPileAction.goback;
                }

                do {
                    ClearItemsInPile(sortIndex);
                    findPileAction action =  FindBestPile((sortIndex+1), remainingVolume);
                    if (action == findPileAction.goback)
                    {
                        if (numItemsInPile == 0)
                            break;
                        numItemsInPile--;
                        _numItemsInPile[pileIndex] = numItemsInPile;
                        remainingVolume += _volumes[pileIndex];
                    }
                    else
                    {
                        break;
                    }
                } while (numItemsInPile >= 0);
                return findPileAction.goback;
            }

            public void ClearItemsInPile(int sortedIndex)
            {
                for (int i = sortedIndex + 1; i < sortedOrder.Length; i++)
                {
                    int pileIndex = sortedOrder[i];
                    _numItemsInPile[pileIndex] = 0;
                }
            }

            public void StartFindBestPile()
            {
                FindBestPile(0, _maxVolume);
            }
        }

        static void Main(string[] args)
        {
            int [] volumes = {4, 5, 3};
            int [] weights = {11, 12, 7};
            int maxVolume = 10;
            KnapSack ks = new KnapSack(weights, volumes, maxVolume);
            ks.StartFindBestPile();
        }
    }
}
