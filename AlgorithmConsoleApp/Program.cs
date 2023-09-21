using AlgorithmConsoleApp.Helpers;
using System;

namespace AlgorithmConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        start:

            //Console.WriteLine($"result of Math.Log10(100) = {Math.Log10(1000)}");
            Console.WriteLine("Hello, World!");

            TestQuickSort();

            Console.Write("Again?(Y)");
            var again = Console.ReadLine();
            if (again == "Y")
                goto start;
        }

        private static void TestQuickSort()
        {
            int[] arr = SearchHelper.CreateRandomArray(8);
            
            Console.WriteLine("Original array: " + string.Join(", ", arr));

            QuickSortHelper.Quicksort(arr, 0, arr.Length - 1);

            Console.WriteLine("Sorted array: " + string.Join(", ", arr));
        }

        public static void RabishCode()
        {
            int[] Arr = new int[10000];
            for (int i = 0; i < 10000; i++) Arr[i] = i;

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            int indx = SearchHelper.BinarySearch(Arr, 70);
            Console.WriteLine($"result of BinarySearch = {indx}");

            int indx2 = SearchHelper.BinarySearchRecursive(Arr, 70, 0, 200);

            Console.WriteLine($"result of BinarySearchRecursive = {indx2}");
            //watch.Stop();
            //Console.WriteLine($"Total Execution 1 Time: {watch.ElapsedMilliseconds} ms and result = {indx}");
            //watch.Reset();

            //watch.Start();
            //int indx2 = Array.IndexOf(A, 70);
            //watch.Stop();
            //Console.WriteLine($"Total Execution 2 Time: {watch.ElapsedMilliseconds} and result = {indx2}");
            /*
            int[] notSorted = { 12, 1, 5, 2, 9 };

            var sortedArray = SearchHelper.SortByInsertionSorted(notSorted);
            Console.WriteLine(sortedArray.ToList().ToString());
            Console.Write("EnterString:");
            string? inpStr = Console.ReadLine();
            if (inpStr != null)
            {
                var result = SearchHelper.IndexOfCapitals(inpStr);
                Console.WriteLine($"IndexOfCapitals({inpStr}) is {String.Join(",", result)}");
            }
            */
            //test quick sort:
            int[] staticNotQuickSorted = SearchHelper.CreateRandomArray(7);
            /*
            int[] staticNotQuickSorted = { 12, 1, 5};
            int[] notQuickSorted = (int[])staticNotQuickSorted.Clone();
            var quickSortedArray = SearchHelper.QuickSort(notQuickSorted,0, notQuickSorted.Length-1);
            Console.WriteLine($"the result of quickSortedArray({String.Join(",", staticNotQuickSorted)}) is {String.Join(",", quickSortedArray)}");
            */
            int[] Xs = SearchHelper.CreateRandomArray(5);
            Console.WriteLine($"Normal Sort");
            int[] normalSort = SearchHelper.SortArray(Xs);
            Console.WriteLine($"the result of Normal of({String.Join(",", Xs)}) Sort(A({String.Join(",", normalSort)})");

            //Merge sort:
            int[] A = SearchHelper.CreateRandomArray(5);
            int[] B = SearchHelper.CreateRandomArray(5);
            int[] C = new int[A.Length * 2];

            //var res = SearchHelper.MergeSort(A, 0, A.Length-1,B,0,B.Length-1, C);
            int[] res = A.Concat(B).ToArray();
            Array.Sort(res);

            Console.WriteLine($"the result of MergeSort(A({String.Join(",", A)}) and\n B({String.Join(",", B)}) is\n ({String.Join(",", res)})");

            Console.WriteLine("/////////////////////////////////");
            Console.WriteLine("Search Naive Algorithm");
            char[] t = "The final day!".ToCharArray();
            char[] w = "final".ToCharArray();


            bool r = SearchHelper.SearchNaiveAlgorithm(t, w);
            Console.WriteLine("result of SearchNaiveAlgorithm:" + r.ToString());



        }
    }
}