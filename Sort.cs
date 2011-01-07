using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Scratchy
{
    public static class Sort
    {
        internal static T[] MergeSort<T>(T[] unsorted)where T : IComparable<T>
        {

            if (unsorted.Length == 1)
                return unsorted;
            int mid = (int)Math.Ceiling((double)unsorted.Length/2);

            T[] left = new T[mid];
            T[] right = new T[unsorted.Length- mid];

            for (int i = 0; i < mid; i++)
            {
                left[i] = unsorted[i];
            }
            int counter=0;
            
            for (int i = mid; i < unsorted.Length; i++)
            {
                right[counter++] = unsorted[i];
            }


            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);

        }

        internal static T[] Merge<T>(T[] left, T[] right)where T : IComparable<T>
        {
            List<T> ret = new List<T>();
            int leftCounter=0, rightCounter=0, retCounter=0;

            while (leftCounter< left.Length || rightCounter< right.Length)
            {
                if (leftCounter < left.Length && rightCounter < right.Length)
                {
                    int comp = left[leftCounter].CompareTo(right[rightCounter]);
                    if (comp < 0)
                    {
                        ret.Add(left[leftCounter]);
                        retCounter++;
                        leftCounter++;
                    }
                    else if (comp > 0)
                    {
                        ret.Add(right[rightCounter]);
                        retCounter++;
                        rightCounter++;
                    }
                }
                else if (leftCounter < left.Length)
                {
                    ret.Add(left[leftCounter]);
                    retCounter++;
                    leftCounter++;
                }
                else if (rightCounter < right.Length)
                {
                    ret.Add(right[rightCounter]);
                    retCounter++;
                    rightCounter++;
                }

            }

            return ret.ToArray();

        }


        internal static T[] BubbleSort<T>(T[] unsorted) where T : IComparable<T>
        {
            bool haveAnyBeenSwitched =true;
            while (haveAnyBeenSwitched)
            {
                haveAnyBeenSwitched = false;
                for (int i = 0; i < unsorted.Length-1; i++)
                {
                    
                    int result = unsorted[i].CompareTo(unsorted[i + 1]);

                    if (result > 0)
                    {
                        T temp = unsorted[i];
                        T temp1 = unsorted[i + 1];
                        unsorted[i] = temp1;
                        unsorted[i + 1] = temp;
                        haveAnyBeenSwitched = true;
                    }
                    
                    
                }
            }
            return unsorted;
        }
        public static void QuickSort(int[] unsorted, int left, int right)
        {
           
            int pivotValue = unsorted[(left+right)/2];
            int i = left, j = right;
            while (i<=j)
            {
                while (unsorted[i] < pivotValue) i++; // find val > pivot
                while (unsorted[j] > pivotValue) j--; // find val < pivot

                if (i <= j) // swap if larger val is at a lower index
                {
                    int temp = unsorted[i];
                    unsorted[i] = unsorted[j];
                    unsorted[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j)
                QuickSort(unsorted, left, j);
            if (i< right)
                QuickSort(unsorted, i, right);
        }
        public static void QuickSortVis(int[] unsorted, int left, int right)
        {
            
            int pivotValue = unsorted[(left + right) / 2];
            Console.WriteLine(BuildDebug(unsorted, left, right, pivotValue));
            int i = left, j = right;
            while (i <= j)
            {
                Console.WriteLine(string.Format("i={0}| j={1}", i, j));
                while (unsorted[i] < pivotValue) i++; // find val > pivot
                while (unsorted[j] > pivotValue) j--; // find val < pivot

                if (i <= j) // swap if larger val is at a lower index
                {
                    Console.WriteLine(string.Format("{0} >> and << {1}", unsorted[i], unsorted[j]));
                    int temp = unsorted[i];
                    unsorted[i] = unsorted[j];
                    unsorted[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j)
                QuickSortVisualizer(unsorted, left, j);
            if (i < right)
                QuickSortVisualizer(unsorted, i, right);
        }
        static string BuildDebug(IEnumerable<int> unsorted, int left, int right, int pivot)
        {
            return string.Format("Left={0}|Right={1}|Pivot={2}||{3}", left, right, pivot, GetArrayValues(unsorted));
        }

        static string GetArrayValues(IEnumerable<int> values)
        {
            var vals = values.Select(p => p.ToString());

            
            return string.Join("|", vals.ToArray());


        }
    }
}
