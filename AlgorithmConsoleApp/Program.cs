using AlgorithmConsoleApp.Helpers;

namespace AlgorithmConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[] A = new int[10000];
            for (int i = 0; i < 10000; i++) A[i] = i;

            //var watch = System.Diagnostics.Stopwatch.StartNew();

            int indx = SearchHelper.BinarySearch(A, 70);
            Console.WriteLine($"result of BinarySearch = {indx}");

            int indx2 = SearchHelper.BinarySearchRecursive(A, 70,0,200);

            Console.WriteLine($"result of BinarySearchRecursive = {indx2}");
            //watch.Stop();
            //Console.WriteLine($"Total Execution 1 Time: {watch.ElapsedMilliseconds} ms and result = {indx}");
            //watch.Reset();

            //watch.Start();
            //int indx2 = Array.IndexOf(A, 70);
            //watch.Stop();
            //Console.WriteLine($"Total Execution 2 Time: {watch.ElapsedMilliseconds} and result = {indx2}");

            int[] notSorted = {12,1,5,2,9};
            var sortedArray = SearchHelper.SortByInsertionSorted(notSorted);
            Console.WriteLine(sortedArray.ToList().ToString());


            Console.ReadLine();
        }
    }
}