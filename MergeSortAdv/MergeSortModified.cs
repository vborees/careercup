
namespace MergeSortAdv
{
    public class MergeSortModified
    {
        public void DoMerge(int[] arr, int[] arrindices, int[] resarray, int start, int middle, int end)
        {
            // create temp array to store sorted subarray
            int[] temp = new int[end - start + 1];
            int l = start;
            int m = middle + 1;

            int k = 0;

            // store the amount 
            int gr = 0;

            // run a marker until at least one source subarrays is not empty
            while (l <= middle && m <= end)
            {
                if (arr[arrindices[l]] >= arr[arrindices[m]])
                {
                    temp[k] = arrindices[l];

                    // increment the result array by the number of already found greater elements
                    resarray[arrindices[l]] += gr;
                    l++;
                    k++;
                }
                else
                {
                    // increment the amount of "greater" elements
                    gr++;
                    temp[k] = arrindices[m];
                    m++;
                    k++;
                }
            }

            // take the remaining elements from the first subarray is any
            while (l <= middle)
            {
                temp[k] = arrindices[l];

                // increment the result array by the number of already found greater elements
                resarray[arrindices[l]] += gr;
                k++;
                l++;
            }

            // take the remaining elements from the second subarray is any
            while (m <= end)
            {
                temp[k++] = arrindices[m++];
            }

            // copy sorted subarray of indices back to the indices array
            for (int pos = 0; pos < end - start + 1; pos++)
                arrindices[start + pos] = temp[pos];

        }

        public void Merge(int[] arr, int[] arrindices, int[] resarray, int start, int end)
        {
            // if array is long enough
            if (start < end)
            {  
                // divide array into two parts
                int m = (start + end) / 2;

                // sort the first half
                Merge(arr, arrindices, resarray, start, m);

                // sort the second half
                Merge(arr, arrindices, resarray, m + 1, end);

                // Merge sorted subarrays
                DoMerge(arr, arrindices, resarray, start, m, end);
            }

        }

    }
}
