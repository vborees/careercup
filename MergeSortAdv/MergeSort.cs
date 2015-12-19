
namespace MergeSortAdv
{
    public class MergeSort
    {
        public void DoMerge(int[] arr, int start, int middle, int end)
        {
            // create temp array to store sorted subarray
            int[] temp = new int[end - start + 1];
            int l = start;
            int m = middle + 1;

            int k = 0;

            // run a marker until at least one source subarrays is not empty
            while (l <= middle && m <= end)
            {
                if (arr[l] >= arr[m])
                    temp[k++] = arr[l++];
                else
                    temp[k++] = arr[m++];
            }

            // take the remaining elements from the first subarray is any
            while (l <= middle)
                temp[k++] = arr[l++];

            // take the remaining elements from the second subarray is any
            while (m <= end)
                temp[k++] = arr[m++];

            // copy sorted subarray back to the array
            for (int pos = 0; pos < end - start + 1; pos++)
                arr[start + pos] = temp[pos];

        }

        public void Merge(int[] arr, int start, int end)
        {
            // if array is long enough
            if (start < end)
            {
                // divide array into two parts
                int m = (start + end) / 2;

                // sort the first half
                Merge(arr, start, m);

                // sort the second half
                Merge(arr, m + 1, end);
                
                // Merge sorted subarrays
                DoMerge(arr, start, m, end);
            }
        }
    }
}
