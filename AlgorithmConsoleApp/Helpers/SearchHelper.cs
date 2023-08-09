namespace AlgorithmConsoleApp.Helpers
{
    public static class SearchHelper
    {
        public static int BinarySearch(int[] A, int key)
        {
            int steps = 0;
            try
            {
                int middle;
                int left = 0, right = A.Length - 1;

                while (left <= right)
                {
                    middle = (left + right) / 2;// find the middle, round the result
                    if (A[middle] == key) return middle;
                    if (A[middle] > key) right = middle - 1;
                    if (A[middle] < key) left = middle + 1;
                    steps++;
                }
                return 0;
            }
            catch { return 0; }
            finally { Console.WriteLine("Steps:" + steps); }

        }

        public static int BinarySearchRecursive(int[] inputArray, int key, int min, int max)
        {
            if (min > max) return 0;
            int mid = (min + max) / 2;
            if (key == inputArray[mid]) //return ++mid;
                return mid++;

            if (key < inputArray[mid])
                return BinarySearchRecursive(inputArray, key, min, mid - 1);
            else
                return BinarySearchRecursive(inputArray, key, mid + 1, max);

        }


        public static int[] SortByInsertionSorted(int[] inputArray)
        {
            int[] A = inputArray;
            int Hand;
            for (int i = 1; i < inputArray.Length; i++)
            {
                int j = i;
                while (j >= 1 && A[j - 1] > A[j])
                {
                    Hand = A[j]; // exchange current book with left neighbor
                    A[j] = A[j - 1];
                    A[j - 1] = Hand;
                    j = j - 1;
                }
            }
            return A;
        }
    }
}
