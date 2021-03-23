using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Arr
{
    public class Mat
    {
        private int[] arr;
        private int size = 0;

        public int Size { get => size; set => size = value; }
        public int[] Arr { get => arr; set => arr = value; }

        public void RandomGenerate()
        {
            Random rand = new Random();
            for (int i = 0; i < Size; i++)
            {
                Arr[i] = rand.Next(0, 100);
            }
        }

        public static int[] Sort(int[] array)
        {
            if (array.Length == 1)
                return array;
            int midPoint = array.Length / 2;
            return Merge(Sort(array.Take(midPoint).ToArray()), Sort(array.Skip(midPoint).ToArray()));
        }
        public static int[] Merge(int[] arr1, int[] arr2)
        {
            int a = 0, b = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < merged.Length; i++)
            {
                if (b < arr2.Length && a < arr1.Length)
                    if (arr1[a] > arr2[b] && b < arr2.Length)
                        merged[i] = arr2[b++];
                    else
                        merged[i] = arr1[a++];
                else
                    if (b < arr2.Length)
                    merged[i] = arr2[b++];
                else
                    merged[i] = arr1[a++];
            }
            return merged;
        }
    }
}