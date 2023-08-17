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
        public static int[] IndexOfCapitals(string str)
        {
            List<int> lst = new List<int>();
            string[] AllCaps = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');
            for (int i = 0; i < str.Length; i++)
            {
                //str.Substring(i,1)

                if (AllCaps.Contains(str.Substring(i, 1)))
                {
                    lst.Add(i);
                }
            }
            return lst.ToArray();
        }

        public static int[] QuickSort(int[] array, int leftIndex, int rightIndex)
        {

            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex);
            return array;
        }

        public static int[] SortArray(int[] inputArray)
        {
            int s3 = inputArray.Length;
            int[] arr3 = new int[s3];

            for (int i = 0; i < s3; i++)
            {
                for (int k = 0; k < s3 - 1; k++)
                {
                    if (arr3[k] >= arr3[k + 1])
                    {
                        int j = arr3[k + 1];
                        arr3[k + 1] = arr3[k];
                        arr3[k] = j;
                    }
                }
            }
            return arr3;

        }
        public static void MergeSort(int[] A, int al, int ar, int[] B, int bl, int br, int[] C)
        {

            // merges a sorted array-Segment A[al]...A[ar] with
            // B[bl]..B[br] to a sorted segment C[0] ...
            int i = al, j = bl;
            for (int k = 0; k <= ar - al + br - bl + 1; k++)
            {
                if (i > ar) // A is finished
                { C[k] = B[j++]; continue; }
                if (j > br) // B is finished
                { C[k] = A[i++]; continue; }
                C[k] = (A[i] < B[j]) ? A[i++] : B[j++];
            }
        }


        public static int[] CreateRandomArray(int size)
        {
            var array = new int[size];
            var rand = new Random();
            for (int i = 0; i < size; i++)
                array[i] = rand.Next(1, 100);
            return array;
        }


        public static bool SearchNaiveAlgorithm(char[] t, char[] w)
        {
            //My Code:
            //int counter;
            //for (int j = 0; j < t.Length; j++)
            //{
            //    counter = 0;

            //        for (int i = 0; i < w.Length; i++)
            //        {
            //            if (t[j+ counter] == w[i])
            //                counter++;
            //        }
            //        if (counter == w.Length) return true;
            //}
            //return false;
            //Improved:
            
            for (int j = 0; j <= t.Length - w.Length; j++)
            {
                int counter = 0;
                while (counter < w.Length && t[j + counter] == w[counter]) counter++;
                if (counter == w.Length) return true;
            }
            return false;
        }

    }
}
