
// C# program to print all 
// combination of size r 
// in an array of size n 
using System; 

class GFG 
{ 
	// /* arr[] ---> Input Array 
	// data[] ---> Temporary array to 
	// 			store current combination 
	// start & end ---> Staring and Ending 
	// 				indexes in arr[] 
	// index ---> Current index in data[] 
	// r ---> Size of a combination 
	// 		to be printed */
	// static void combinationUtil(int []arr, int []data, 
	// 							int start, int end, 
	// 							int index, int r) 
	// { 
    //     Console.WriteLine($"CU {start} {end} {index} {r}");
	// 	// Current combination is 
	// 	// ready to be printed, 
	// 	// print it 
	// 	if (index == r) 
	// 	{ 
	// 		for (int j = 0; j < r; j++) 
	// 			Console.Write(data[j] + " "); 
	// 		Console.WriteLine(""); 
	// 		return; 
	// 	} 

	// 	// replace index with all 
	// 	// possible elements. The 
	// 	// condition "end-i+1 >= 
	// 	// r-index" makes sure that 
	// 	// including one element 
	// 	// at index will make a 
	// 	// combination with remaining 
	// 	// elements at remaining positions 
	// 	for (int i = start; i <= end ; // && end - i + 1 >= r - index; 
    //                     i++) 
	// 	{ 
	// 		data[index] = arr[i]; 
	// 		combinationUtil(arr, data, i + 1, 
	// 						end, index + 1, r); 
	// 	} 
	// } 

	// // The main function that prints 
	// // all combinations of size r 
	// // in arr[] of size n. This 
	// // function mainly uses combinationUtil() 
	// static void printCombination(int []arr, 
	// 							int n, int r) 
	// { 
	// 	// A temporary array to store 
	// 	// all combination one by one 
	// 	int []data = new int[r]; 

	// 	// Print all combination 
	// 	// using temprary array 'data[]' 
	// 	combinationUtil(arr, data, 0, 
	// 					n - 1, 0, r); 
	// } 

	// Driver Code 
	static public void Main () 
	{ 
		int []arr = {1, 2, 3, 4, 5}; 
		int r = 5; 
		int n = arr.Length; 
		printCombination1(arr, n, r); 
	} 

    static void combinationUtil1(int[] arr, int[] data, int start, int end, int index, int r)
    {
        Console.WriteLine($"CU {start} {end} {index} {r}");
        if (index == r) // we can print the combination
        {
            for (int j = 0; j  < r; j++)
            {
                Console.Write(data[j]);
            }
            Console.WriteLine();
        }
        else
        {
            for (int i = start; i <= end; i++ )
            {
                data[index] = arr[i];
                combinationUtil1(arr, data, i+1, end, index+1, r);
            }
        }
    }

	static void printCombination1(int []arr, int n, int r) 
    {
        int[] data  = new int[r];
        combinationUtil1(arr, data, 0, n-1, 0, r );
    }
} 