using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNO_4
{
    static class MathOperation
    {
        public static int Max(IntArray arr)
        {
            int max = arr[0], maxIndex = 0;
            for (int i = 0; i < arr.count; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                    maxIndex = i;
                }
            }
            return max;
        }
        public static int Min(IntArray arr)
        {
            int min = arr[0], minIndex = 0;
            for (int i = 0; i < arr.count; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                    minIndex = i;
                }
            }
            return min;
        }
        public static int Size(IntArray arr)
        {
            return arr.count;
        }
        public static bool CheckSymbol(string str, string symbol)
        {
            int check = 0;
            check = str.IndexOf(symbol);
            if (check > 0)
                return true;
            else return false;
        }
        public static IntArray Delete(IntArray arr)
        {
            int remcount = 0;
            for (int i = 0; i < arr.count; i++)
            {
                if (arr[i] < 0)
                {
                    remcount++;
                }
            }
            IntArray res = new IntArray(arr.count - remcount);
            for (int i = 0, k = 0; i < arr.count; i++,k++)
            {
                if (arr[i] < 0)
                {
                    continue;
                }
                else
                {
                    res[k] = arr[i];
                }
            }
            return res;
        }
    }
}
