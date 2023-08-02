//Author: Jared Holston
//Date Created: 6/29/2023
//Date Updated: 6/29/2023
//Purpose: Library of basic functions for general use.



namespace lib_of_jared
{

	public class LibOfJared
	{
		//For every range of 1-100, it adds 1 to a variable y and returns the total. 
		//Requires an integer input.
		public static int OneForEveryRangeOfOneHundred(int x) 
		{
		int y = x/100;
		if ((x%100) > 0) {y+=1;}
		return y;
		}

		public static int[] BubbleSortIntArray(int[] arr)
		{

			return arr;
		}

		// A utility function to swap two elements
		public static void swap(int[] arr, int i, int j)
		{
			int temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}

		// This function takes last element as pivot,
		// places the pivot element at its correct position
		// in sorted array, and places all smaller to left
		// of pivot and all greater elements to right of pivot
		static int partition(int[] arr, int low, int high)
		{
			// Choosing the pivot
			int pivot = arr[high];
	
			// Index of smaller element and indicates
			// the right position of pivot found so far
			int i = (low - 1);
	
			for (int j = low; j <= high - 1; j++) {
	
				// If current element is smaller than the pivot
				if (arr[j] < pivot) {
	
					// Increment index of smaller element
					i++;
					swap(arr, i, j);
				}
			}
			swap(arr, i + 1, high);
			return (i + 1);
		}

		// The main function that implements QuickSort
		// arr[] --> Array to be sorted,
		// low --> Starting index,
		// high --> Ending index
		public static void QuickSortIntArray(int[] arr, int low, int high)
		{
			if (low < high) {
 
            // pi is partitioning index, arr[p]
            // is now at right place
            int pi = partition(arr, low, high);
 
            // Separately sort elements before
            // and after partition index
            QuickSortIntArray(arr, low, pi - 1);
            QuickSortIntArray(arr, pi + 1, high);
       		}
		}

		public static object[] ExpandArray(object[] arr) 
		{
			//Performs dynamic array expansion
			//This will need to be copied and modified for the  type of object used.
			int newBound = arr.Length * 2;
			object[] newArr = new object[newBound];

			for (int i = 0; i <  arr.Length; i++) {
				newArr[i] = arr[i];
			}
			return newArr;
		}
	}
}

