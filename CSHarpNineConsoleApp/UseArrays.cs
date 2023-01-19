using System;
using System.Text;

namespace CSHarpNineConsoleApp
{
    public class UseArrays
    {

        public static void Create2DArray()
        {


            //multi dim array:
            int[,] arr2x2 = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            int total = 0;
            for (int i = 0; i < arr2x2.GetLength(0); i++)
            {
                if (i != 0)
                    sb.AppendLine();
                for (int j = 0; j < arr2x2.GetLength(1); j++)
                {
                    sb.Append((j == 0 ? "" : ",") + arr2x2[i, j]);
                    total = total + arr2x2[i, j];
                }

            }
            sb.Append("]");

            Console.WriteLine(sb.ToString());

            Console.WriteLine($"total = {total}");


        }

        public static void Create3DArray()
        {


            //multi dim array:
            int[,,] arr2x2 = new int[3, 3, 2]
            {
                { {1,2 },{ 3,4 },{ 5,6 } },
                { {7,8 },{ 9,10 },{ 11,12 } },
                { {13,81 },{ 49,510 },{ 711,212 } }
            };

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            int total = 0;
            bool first=true;
            for (int i = 0; i < arr2x2.GetLength(0); i++)
                for (int j = 0; j < arr2x2.GetLength(1); j++)
                    for (int k = 0; k < arr2x2.GetLength(2); k++)
                    {
                        sb.Append( (first ? "":",") + arr2x2[i, j, k]);
                        total = total + arr2x2[i, j, k];
                        first = false;
                    }

            sb.Append("]");

            Console.WriteLine(sb.ToString());

            Console.WriteLine($"3D array total = {total}");


        }




    }
}
