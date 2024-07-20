using System.Diagnostics;

namespace SortingAlgos
{
    
    public class Program
    {

        public static void PrintArray(int[] arr)
        {
            foreach (int element in arr)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        public static void BubbleSort(int[] arrToSort)
        {
            int temp;
            for (int i = 0; i < arrToSort.Length - 1; i++) // how many times we need to go though the unsorted array  
            {
                for (int j = 0; j < arrToSort.Length - 1 - i; j++)
                {
                    // we need to swap  
                    if (arrToSort[j] > arrToSort[j + 1])
                    {
                        temp = arrToSort[j];
                        arrToSort[j] = arrToSort[j + 1];
                        arrToSort[j + 1] = temp;
                    }
                }
            }
        }

        public static void SelectionSort(int[] arrToSort)
        {
            // minIndex keeps track of the smallest index in each iteration  
            // temp is used as temporary storage  
            int minIndex, temp;

            // O(n) how many times we need to go though the unsorted array  
            for (int i = 0; i < arrToSort.Length; i++)
            {
                minIndex = i; // set the minIdex equal to current smallest index  
                for (int j = i; j < arrToSort.Length; j++) // loop through each element starting at i  
                {
                    // if the element is smaller than the current minIndex  
                    if (arrToSort[j] < arrToSort[minIndex])
                    {
                        // swap  
                        minIndex = j;
                    }
                }

                // swap elements  
                // swap current i (which is smallest position with the smallest/min element)  
                temp = arrToSort[i];
                arrToSort[i] = arrToSort[minIndex];
                arrToSort[minIndex] = temp;
            }
        }

        public static void InsertionSort(int[] arr)
        {
            // Overall worst case: O(n^2) == array is reverse sorted
            // Best case: O(n) == while loop never runs
            for(int i = 1;i < arr.Length; i++) // O (n)
            {
                int temp = arr[i];// store the current element as it might be overwritten
                int priorIndex = i - 1; // start comparing with element before the current element

                while (priorIndex >= 0 && arr[priorIndex] > temp) // O (n)
                {
                    arr[priorIndex + 1] = arr[priorIndex];
                    priorIndex--;
                }

                // need an assignment
                arr[priorIndex + 1] = temp;
            } 
        }


        // Responsible for splitting the array up and eventually putting it back together, recursive
        public static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return;

            int mid = arr.Length / 2;
            int[] leftSubArray = new int[mid];
            int[] rightSubArray = new int[arr.Length - mid];

            for (int i = 0; i < mid; i++)
            {
                leftSubArray[i] = arr[i];
            }

            for (int i = mid;i < arr.Length; i++)
            {
                rightSubArray[i - mid] = arr[i];
            }
            Console.WriteLine("Before sorting left subarray:");
            PrintArray(leftSubArray);
            Console.WriteLine("Before sorting right subarray:");
            PrintArray(rightSubArray);

            MergeSort(leftSubArray);
            MergeSort(rightSubArray);

            Merge(arr, leftSubArray, rightSubArray);
            Console.WriteLine("After merging:");
            PrintArray(arr);
        }

        public static void Merge(int[] arr, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }

        


        static void Main(string[] args)
        {
            int[] arr1 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arr1Sorted = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            int[] bigArr1 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };
            int[] bigArr1Sorted = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };
            //PrintArray(arr1);
            //BubbleSort(arr1);
            //PrintArray(arr1);
            Console.WriteLine("--------------------------------------------------");

            int[] arr2 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arr2Sorted = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            int[] bigArr2 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };
            int[] bigArr2Sorted = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };

            //PrintArray(arr2);
            //SelectionSort(arr2);
            //PrintArray(arr2);
            Console.WriteLine("--------------------------------------------------");

            int[] arr3 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arr3Sorted = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            int[] bigArr3 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };
            int[] bigArr3Sorted = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };

            //PrintArray(arr3);
            //InsertionSort(arr3);
            //PrintArray(arr3);
            Console.WriteLine("--------------------------------------------------");

            int[] arr4 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            int[] arr4Sorted = { 0, 1, 2, 3, 8, 32, 34, 56, 65, 68, 76, 90, 100 };
            int[] bigArr4 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };
            int[] bigArr4Sorted = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };

            PrintArray(arr4);
            MergeSort(arr4);
            PrintArray(arr4);
            Console.WriteLine("--------------------------------------------------");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            InsertionSort(bigArr1Sorted);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Insertion sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            BubbleSort(bigArr2Sorted);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Bubble sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            SelectionSort(bigArr3Sorted);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Selection sort: {stopwatch.ElapsedTicks}");


        }




    }
}


