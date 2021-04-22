using System;
using System.Linq;

namespace Lab1.Arr
{
    public class Mat
    {
        private double[] arr;
        private int size = 0;

        public int Size { get => size; set => size = value; }
        public double[] Arr { get => arr; set => arr = value; }

        public void RandomGenerate()
        {
            Random rand = new Random();
            for (int i = 0; i < this.Size; i++)
            {
                this.Arr[i] = rand.Next(0, 100);
            }
        }

        public static double[] Sort(double[] array)
        {
            if (array.Length == 1)
                return array;
            int midPoint = array.Length / 2;
            return Merge(Sort(array.Take(midPoint).ToArray()), Sort(array.Skip(midPoint).ToArray()));
        }
        public static double[] Merge(double[] arr1, double[] arr2)
        {
            int a = 0, b = 0;
            double[] merged = new double[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length + arr2.Length; i++)
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