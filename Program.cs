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
            for (int i = 1; i < arr.Length; i++) // O (n)
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

            for (int i = mid; i < arr.Length; i++)
            {
                rightSubArray[i - mid] = arr[i];
            }
            //Console.WriteLine("Before sorting left subarray:");
            //PrintArray(leftSubArray);
            //Console.WriteLine();
            //Console.WriteLine("Before sorting right subarray:");
            //PrintArray(rightSubArray);
            //Console.WriteLine();

            MergeSort(leftSubArray);
            MergeSort(rightSubArray);
            Merge(arr, leftSubArray, rightSubArray);

            //Console.WriteLine("After merging:");
            //PrintArray(arr);
            //Console.WriteLine();
        }

        public static void Merge(int[] arr, int[] leftArr, int[] rightArr)
        {
            int leftIndex = 0, rightIndex = 0, arrIndex = 0;

            // While the leftArr has values and the right array has values
            // Evaluate which value is lesser - and make assignments
            while (leftIndex < leftArr.Length && rightIndex < rightArr.Length)
            {
                if (leftArr[leftIndex] <= rightArr[rightIndex])
                {
                    arr[arrIndex++] = leftArr[leftIndex++];
                }
                else
                {
                    arr[arrIndex++] = rightArr[rightIndex++];
                }
            }

            // copy remaining elemts from left array, if any
            while (leftIndex < leftArr.Length)
            {
                arr[arrIndex++] = leftArr[leftIndex++];
            }

            // copy remaining elemts from right array, if any
            while (rightIndex < rightArr.Length)
            {
                arr[arrIndex++] = rightArr[rightIndex++];
            }
        }

        /// <summary>
        /// Utilizes a quick sort algo to sort the passed in array
        /// </summary>
        /// <param name="arr">The array to be sorted</param>
        /// <param name="low">The smaller index of the (sub)array</param>
        /// <param name="hi">The larger index of the (sub)array</param>
        public static void QuickSort(int[] arr, int low, int hi)
        {
            if (low < hi)
            {
                // Partition return pivot location
                int pivotIndex = Partition(arr, low, hi);

                // Call quick sort again on new subarrays based on pivots position
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, hi);
            }
        }

        public static int Partition(int[] arr, int low, int hi)
        {
            int pivot = arr[hi]; // setting pivot to be the last value in the array
            int i = low - 1;

            for (int j = low; j < hi; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, ++i, hi);
            return i;

        }

        public static void Swap(int[] arr, int i, int j)
        {
            int temp;
            temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }

        public static void Race()
        {
            int[] bigArr1 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };
            int[] bigArr2 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };
            int[] bigArr3 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };
            int[] bigArr4 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };
            int[] bigArr5 = { 6, 24, 68, 97, 14, 90, 43, 51, 30, 36, 73, 39, 82, 11, 2, 37, 54, 63, 18, 69, 31, 72, 87, 45, 46, 12, 71, 61, 59, 49, 13, 88, 53, 27, 99, 58, 75, 47, 25, 19, 1, 93, 84, 86, 35, 21, 55, 57, 48, 60, 95, 70, 76, 80, 28, 78, 40, 20, 42, 17, 66, 56, 74, 44, 7, 29, 22, 91, 15, 62, 23, 8, 79, 94, 77, 5, 65, 0, 34, 81, 10, 67, 9, 26, 83, 64, 41, 50, 98, 85, 33, 32, 3, 89, 4, 16, 96, 92, 52, 38 };


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            InsertionSort(bigArr1);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Insertion sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            BubbleSort(bigArr2);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Bubble sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            SelectionSort(bigArr3);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Selection sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            MergeSort(bigArr4);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Merge sort: {stopwatch.ElapsedTicks}");

            stopwatch.Restart();
            stopwatch.Start();
            QuickSort(bigArr5, 0, bigArr5.Length - 1);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for Quick sort: {stopwatch.ElapsedTicks}");
        }


        static void Main(string[] args)
        {
            int[] arr1 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };
            //PrintArray(arr1);
            //BubbleSort(arr1);
            //PrintArray(arr1);
            //Console.WriteLine("--------------------------------------------------");

            int[] arr2 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };

            //PrintArray(arr2);
            //SelectionSort(arr2);
            //PrintArray(arr2);
            //Console.WriteLine("--------------------------------------------------");

            int[] arr3 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };

            //PrintArray(arr3);
            //InsertionSort(arr3);
            //PrintArray(arr3);
            //Console.WriteLine("--------------------------------------------------");

            int[] arr4 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };

            //PrintArray(arr4);
            //MergeSort(arr4);
            //PrintArray(arr4);
            //Console.WriteLine("--------------------------------------------------");

            int[] arr5 = { 90, 3, 2, 56, 32, 34, 65, 68, 76, 1, 0, 100, 8 };

            //PrintArray(arr5);
            //QuickSort(arr5, 0, arr5.Length - 1);
            //PrintArray(arr5);
            //Console.WriteLine("--------------------------------------------------");


            Race();

        }



    }
}


