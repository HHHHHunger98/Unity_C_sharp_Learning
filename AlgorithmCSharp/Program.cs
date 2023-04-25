namespace AlgorithmCSharp
{
    public static class TestCaseGenerator
    {
        public static List<int> IntListGenerator(int maxLen, int maxVal)
        {
            List<int> list = new List<int>();
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(maxLen); i++)
            {
                list.Add(rnd.Next(maxVal));
            }

            // Sort the list
            list.Sort();

            foreach (int val in list ?? Enumerable.Empty<int>())
            {
                Console.Write(val + " ");
            }

            Console.WriteLine(" the length of the list:" + list.Count);

            return list;
        }
        public static int[] IntArrayGenerator(int maxLen, int maxVal)
        {
            Random rnd = new Random();
            int[] list = new int[rnd.Next(maxLen)];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = rnd.Next(maxVal);
            }

            //Sort the array
            Array.Sort(list);

            foreach (int i in list ?? Enumerable.Empty<int>())
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(" the length of the array:" + list.Length);

            return list;
        }
    }
    public static class AlgorithmSolution
    {
        #region 4. Median of Two Sorted Array
        public static double FindMedian (int[] nums)
        {
            return nums.Length % 2 == 0 ? (nums[nums.Length / 2] + nums[nums.Length / 2 + 1]) / 2.0 : nums[nums.Length / 2] + 0.0;
        }
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }
            else
            {
                if (nums1.Length == 0)
                {
                    if (nums2.Length == 0)
                    {
                        throw new Exception("both arrays are null");
                    }
                    return FindMedian(nums2);
                }

                int left = 0, right = nums1.Length;
                int target = (nums1.Length + nums2.Length + 1) / 2;
                while (left < right)
                {
                    int m1 = (left + right + 1) / 2;
                    int m2 = target - m1;
                    if (nums1[m1 - 1] < nums2[m2 - 1])
                    {
                        left = m1;
                    }
                    else
                    {
                        right = m1 - 1;
                    }
                }

                Console.WriteLine(left + " " + right);

                int leftMax = Math.Max(left == 0 ? 0 : nums1[left - 1], (target - left) == 0 ? 0 : nums2[target - left - 1]);
                int rightMin = Math.Min(right == 0 ? 0 : nums1[right - 1], (target - right) == 0 ? 0 : nums2[target - right - 1]);

                if ((nums1.Length + nums2.Length) % 2 == 0)
                {
                    return (leftMax + rightMin) / 2.0;
                }
                else
                {
                    return leftMax;
                }
            }
        }
        #endregion

        #region 704. Binary Search
        public static int Search (int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
        #endregion

        #region 27. Remove The Array Elements
        public static int RemoveElement (int[] nums, int val)
        {
            int tail = nums.Length - 1;
            int head = 0;
            int k = 0;
            int tmp;
            while(head <= tail)
            {
                if (nums[head] == val) { k++; tmp = nums[head]; nums[head] = nums[tail]; nums[tail--] = tmp; }
                else
                {
                    head++;
                }
            }
            /*Console.Write("The left elements are: ");
            for (int i = 0; i < tail + 1; i++)
            {
                Console.Write(nums[i] + " ");
            }
            Console.WriteLine();*/
            return (nums.Length - k);
        }
        #endregion

        #region 977. Squares Of A Sorted Array
        public static int[] SortedSquares(int[] nums)
        {
            int[] result = new int[nums.Length];
            int index = 0;
            while (nums[index++] < 0) {

                if (index == nums.Length) break;
            }

            int squareN, squareP;
            for (int i = 0, negN = index - 2, posN = index - 1; i < nums.Length; i++)
            {
                if (negN >= 0 && posN < nums.Length)
                {
                    squareN = nums[negN] * nums[negN];
                    squareP = nums[posN] * nums[posN];
                    if (squareN <= squareP)
                    {
                        result[i] = squareN;
                        negN--;
                        continue;
                    }
                    else
                    {
                        result[i] = squareP;
                        posN++;
                        continue;
                    }
                }

                if (negN < 0 && posN < nums.Length)
                {
                    result[i] = nums[posN] * nums[posN]; 
                    posN++;
                }
                else if (negN >= 0 && posN >= nums.Length)
                {
                    result[i] = nums[negN] * nums[negN];
                    negN--;
                }
            }
            return result;
        }

        /*
         * 其他解法：双指针方法，因为数组本身是有序的，平方后的最大值就在最左或最右边
         * 算法思路是从两边向内推进，最大的放在结果数组最后面
         * 
            public int[] SortedSquares(int[] nums) {
                int k = nums.Length - 1;
                int[] result = new int[nums.Length];
                for (int i = 0, j = nums.Length - 1;i <= j;){
                    if (nums[i] * nums[i] < nums[j] * nums[j]) {
                        result[k--] = nums[j] * nums[j];
                        j--;
                    } else {
                        result[k--] = nums[i] * nums[i];
                        i++;
                    }
                }
                return result;
            }
         */
        #endregion

        #region 209. Minimun Size Subarray Sum
        public static int MinSubArrayLen(int target, int[] nums)
        {
            int len = 0;
            int sumOfSubArray = 0;
            int head = 0, tail = 0;
            while(tail < nums.Length)
            {
                if (sumOfSubArray < 0)
                {

                }
            }
            return len;
        }
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 4. Median of Two Sorted Array
            /*int[] arr1 = TestCaseGenerator.IntArrayGenerator(7, 100);
            int[] arr2 = TestCaseGenerator.IntArrayGenerator(10, 100);
            Console.WriteLine(AlgorithmSolution.FindMedianSortedArrays(arr1, arr2));*/
            #endregion

            #region 704. Binary Search
            /*for (int i = 0; i < 10; i++)
            {
                int[] arr = TestCaseGenerator.IntArrayGenerator(10, 20);
                Console.WriteLine(AlgorithmSolution.Search(arr, 13));
            }*/
            #endregion

            #region 27. Remove The Array Elements
            /*for (int i = 0; i < 10; i++)
            {
                int[] arr = TestCaseGenerator.IntArrayGenerator(8, 10);
                Console.WriteLine(AlgorithmSolution.RemoveElement(arr, 3));
            }
            int[] arr1 = new int[] {1};
            Console.WriteLine(AlgorithmSolution.RemoveElement(arr1, 1));*/
            #endregion

            #region 977. Squares Of A Sorted Array
            /*int[] nums = new int[] { -1, 2, 2 };
            int[] result = AlgorithmSolution.SortedSquares(nums);
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }
            Console.WriteLine();*/
            #endregion

            #region 209. Minimun Size Subarray Sum
            #endregion
        }
    }
}