using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using static AlgorithmCSharp.AlgorithmSolution;

namespace AlgorithmCSharp
{
    #region 707. Design Linked List
    public class MyLinkedList
    {
        public int? val;
        public MyLinkedList? next;
        public int listSize;
        public MyLinkedList() 
        {
            val = null;
            next = null;
            listSize = 0;
        }
        public MyLinkedList(int? val)
        {
            this.val = val;
            next = null;
        }

        public int Get(int index)
        {
            if (index < 0 || index >= listSize) return -1;
            MyLinkedList dummyHead = new MyLinkedList();
            dummyHead.val = val;
            dummyHead.next = this;

            MyLinkedList tmp = dummyHead;
            while (index-- > 0) 
            {
                if (tmp.next != null) tmp = tmp.next;
                else return -1;
            }
            return tmp.next != null ? (int)tmp.next.val : -1;
        }

        public void AddAtHead(int val)
        {
            listSize++;
            if (this.val == null) { this.val = val; return; }
            MyLinkedList? tmp = new MyLinkedList(this.val);
            tmp.next = next;
            this.val = val;
            next = tmp;
        }

        public void AddAtTail(int val)
        {
            // Add a virtual head node called dummyhead
            MyLinkedList dummyHead = new MyLinkedList();
            dummyHead.val = val;
            dummyHead.next = this;
            listSize++;
            
            if (this.val == null) { this.val = val; return; }
            MyLinkedList tmp = dummyHead;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            tmp.next = new MyLinkedList(val);
        }

        public void AddAtIndex(int index, int val)
        {
            if (index < 0 || index > listSize) { return; }
            else if (index == listSize)
            {
                AddAtTail(val); return;
            }
            // Add a virtual head node called dummyhead
            MyLinkedList dummyHead = new MyLinkedList();
            dummyHead.val = val;
            dummyHead.next = this;
            listSize++;

            MyLinkedList tmp = dummyHead;
            while (index-- > 0)
            {
                tmp = tmp.next;
            }

            if (this.val != null)
            {
                MyLinkedList newNode = new MyLinkedList(tmp.next.val);
                newNode.next = tmp.next.next;
                tmp.next.next = newNode;
                tmp.next.val = val;
            }else
            {
                this.val = val; 
            }

        }

        public void DeleteAtIndex(int index)
        {
            if (index < 0 || index >= listSize) { return; }
            if (index == 0 && next != null)
            {
                val = next.val;
                next = next.next;
                listSize--;
                return;
            }
            // Add a virtual head node called dummyhead
            MyLinkedList dummyHead = new MyLinkedList();
            dummyHead.val = val;
            dummyHead.next = this;

            MyLinkedList tmp = dummyHead;
            
            while (index-- > 0)
            {
                tmp = tmp.next;
            }

            if (listSize-- == 1)
            {
                tmp.next = this;
                tmp.next.next = null;
                tmp.val = null;
                return;
            }
            else
            {
                tmp.next = tmp.next.next == null ? null : tmp.next.next;
            }
        }
        public static void PrintList(MyLinkedList head)
        {
            MyLinkedList? tmp = head;
            Console.Write("The list is :");
            while (tmp != null)
            {
                Console.Write(tmp.val + " ");
                if (tmp.val == null) Console.Write("damn");
                tmp = tmp.next;
            }
            Console.WriteLine();
        }
    }
    #endregion

    //LinkedList Definition
    public class ListNode
    {
        /* Definition of a list struct
         * 
         * unsafe public struct MyList
        {
            int val;
            MyList* next;

            public MyList() { this.val = 0; this.next = null; }
            public MyList(int val) : this() { this.val = val; this.next = null; }
        }*/
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public void AddNode(ListNode nodeToBeAdded) 
        {
            ListNode tmp = this;
            while(tmp.next != null) tmp = tmp.next;
            tmp.next = nodeToBeAdded;
        }
        public static void PrintList(ListNode head)
        {
            ListNode tmp = head;
            Console.Write("The list is :");
            while(tmp != null)
            {
                Console.Write(tmp.val + " ");
                tmp = tmp.next;
            }
            Console.WriteLine();
        }
    }
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

            if(list != null) Console.WriteLine(" the length of the list:" + list.Count);

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
            if(list != null) Console.WriteLine(" the length of the array:" + list.Length);

            return list;
        }
        public static ListNode ListNodesGenerator(int maxLen, int maxVal)
        {
            Random rnd = new Random();
            ListNode list = new ListNode(rnd.Next(maxVal));
            int len = rnd.Next(maxLen);
            Console.WriteLine("The length of the list is:" + len);
            if ( len == 0) return null;

            while (--len > 0)
            {
                list.AddNode(new ListNode(rnd.Next(maxVal)));
            }
            
            ListNode tmp = list;
            Console.WriteLine("The generated list is:");
            while (tmp != null)
            {
                Console.Write(tmp.val + " ");
                tmp = tmp.next;
            }
            Console.WriteLine();

            return list;
        }
        public static MyLinkedList MyListGenerator(int maxLen, int maxVal)
        {
            Random rnd = new Random();
            MyLinkedList tmp = new MyLinkedList(rnd.Next(maxVal));
            MyLinkedList head = tmp;
            int len = rnd.Next(maxLen);
            Console.WriteLine("The length is: " + len);
            for (int i = 0; i < len; i++)
            {
                tmp.next = new MyLinkedList(rnd.Next(maxVal));
                tmp = tmp.next;
            }

            return head.next;
        }

        public static void IntersectListsGenerator(int maxLen, int maxVal, ListNode head1, ListNode head2)
        {
            Random rnd = new Random();
            ListNode tail1 = head1;
            ListNode tail2 = head2;
            if (head1 == null || head2 == null) { return; }
            while (tail1.next != null) tail1 = tail1.next;
            while (tail2.next != null) tail2 = tail2.next;
            int len = rnd.Next(maxLen);
            Console.WriteLine("the length of the intersection is:" + len);
            for (int i = 0; i < len; i++)
            {
                tail1.next = new ListNode(rnd.Next(maxVal));
                tail2.next = tail1.next;
                tail1 = tail1.next;
                tail2 = tail2.next;
            }
        }
    }
    public static class AlgorithmSolution
    {
        #region Array Problems
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
            int len = int.MaxValue;
            int sumOfSubArray = 0;
            int head = 0, tail = 0;
            while(tail < nums.Length)
            {
                sumOfSubArray += nums[tail];
                while (sumOfSubArray >= target)
                {
                    len = (tail - head + 1) > len ? len : tail - head + 1;
                    sumOfSubArray -= nums[head++];
                }
                tail++;
            }

            return len != int.MaxValue ? len : 0;
        }
        #endregion

        #region 59. Spiral Matrix II
        public static int[][] GenerateMatrix(int n)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
            }

            int direction = 0;
            int x = 0, y = 0;
            for (int i = 0, val = 1; n - i > 0;)
            {
                switch (direction++ % 4)
                {
                    //向右，x不变，y递增
                    case 0:
                        for (int j = 0; j < n - i; j++)
                        {
                            matrix[x][y++] = val++;
                        }
                        y--;
                        x++;
                        i++;
                        Console.WriteLine(x + " " + y);
                        break;
                    //向下，x递增，y不变
                    case 1:
                        for (int j = 0; j < n - i; j++)
                        {
                            matrix[x++][y] = val++;
                        }
                        x--;
                        y--;
                        Console.WriteLine(x + " " + y);
                        break;
                    //向左，x不变，y递减
                    case 2:
                        for (int j = 0; j < n - i; j++)
                        {
                            matrix[x][y--] = val++;
                        }
                        y++;
                        x--;
                        i++;
                        Console.WriteLine(x + " " + y);
                        break;
                    //向上，x递减，y不变
                    case 3:
                        for (int j = 0; j < n - i; j++)
                        {
                            matrix[x--][y] = val++;
                        }
                        x++;
                        y++;
                        Console.WriteLine(x + " " + y);
                        break;
                }
            }
            return matrix;
        }
        #endregion
        #endregion

        #region List Problems
        #region 203. Remove Linked List Elements
        public static ListNode RemoveElements(ListNode head, int val)
        {
            ListNode current;
            ListNode last = head;
            while(last != null)
            {
                current = last.next;
                if (last.val == val && head == last) { head = last.next; last = last.next; continue; }
                else if (current == null) break;
                else if (current.val == val) last.next = current.next;
                else last = current;
            }

            ListNode.PrintList(head);
            return head;
        }
        #endregion

        #region 707. Design Linked List
        // See the public class MyLinkedList
        #endregion

        #region 206. Reverse Linked List
        // See the public class ListNode
        public static ListNode ReverseList(ListNode head)
        {
            if (head == null) return head;

            ListNode curr = head, prev = null, tmp =null;

            while (curr != null)
            {
                tmp = curr;
                curr = curr.next;
                tmp.next = prev;
                prev = tmp;
            }
            
            return prev;
        }
        #endregion

        #region 24. Swap Nodes in Pairs
        public static ListNode SwapPairs(ListNode head)
        {
            ListNode curr = head;
            while (curr != null && curr.next != null)
            {
                int tmp = curr.val;
                curr.val = curr.next.val;
                curr.next.val = tmp;
                curr = curr.next.next;
            }
            return head;
        }
        #endregion

        #region 19. Remove Nth Node From End Of The List
        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummyHead = new ListNode();
            dummyHead.next = head;

            ListNode fast = dummyHead, slow = dummyHead;
            for (int i = 0; i < n; i++)
            {
                if (fast.next == null) return dummyHead.next;
                fast = fast.next;
            }

            while(fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            slow.next = slow.next.next;
            return dummyHead.next;
        }
        #endregion

        #region 160. Intersection of Two Linked Lists
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode tailA = headA;
            ListNode tailB = headB;
            ListNode tmp1, tmp2;
            while (tailA != null && tailB != null) 
            {
                tailA = tailA.next;
                tailB = tailB.next;
            }
            tmp1 = tailA == null ? headB : headA;
            tmp2 = tailA == null ? headA : headB;
            while (tailA != null || tailB != null)
            {
                tmp1 = tmp1.next;
                if (tailA == null && tailB != null) tailB = tailB.next; 
                if (tailB == null && tailA != null) tailA = tailA.next;
            }
            while (tmp1 != tmp2 && tmp1 != null && tmp2 != null)
            {
                tmp1 = tmp1.next;
                tmp2 = tmp2.next;
            }
            if (tmp2 != null) Console.WriteLine("the intersection point is:" + tmp2.val);
            return tmp1;
        }
        #endregion
        #endregion
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Array Problems
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
            /*int[] nums = { 1, 4, 4 };
            Console.WriteLine("the len is " + AlgorithmSolution.MinSubArrayLen(4, nums));*/
            #endregion

            #region 59. Spiral Matrix II
            /*//real Solution
            int[][] matrix = AlgorithmSolution.GenerateMatrix(3);
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }

            //Test the matrix's elements position
            int[][] mt = new int[3][];
            for (int i = 0, val = 0 ; i < mt.Length; i++)
            {
                mt[i] = new int[3];
                for (int j = 0; j < mt[i].Length; j++)
                {
                    mt[i][j] = val++;
                    Console.Write("ij:" + i + " " + j + " "+ mt[i][j] + " ");
                }
                Console.WriteLine();
            }*/
            #endregion
            #endregion

            #region Linked List Problems
            #region 203. Remove Linked List Elements
            /*ListNode head = TestCaseGenerator.ListNodesGenerator(10, 20);
            RemoveElements(head, 10);*/
            #endregion

            #region 707. Design Linked List
            /*MyLinkedList myList = TestCaseGenerator.MyListGenerator(3, 20);
            MyLinkedList.PrintList(myList);

            if (myList != null) Console.WriteLine(myList.Get(3));*/
            /*
                        Console.WriteLine("111111111111111111111111");

                        MyLinkedList list2 = new MyLinkedList();
                        list2.AddAtHead(1);
                        list2.AddAtTail(3);
                        list2.AddAtIndex(1, 2);
                        MyLinkedList.PrintList(list2);
                        Console.WriteLine(list2.Get(1) + " size " + list2.listSize);
                        list2.DeleteAtIndex(0);
                        MyLinkedList.PrintList(list2);
                        Console.WriteLine("    " + list2.Get(0) + " " + list2.listSize);
                        MyLinkedList.PrintList(list2);*/
            #endregion

            #region 206. Reverse Linked List
            /*ListNode myListNode = TestCaseGenerator.ListNodesGenerator(5, 20);
            ListNode.PrintList(AlgorithmSolution.ReverseList(myListNode));*/
            #endregion

            #region 24. Swap Nodes in Pairs
            /*ListNode myListNode = TestCaseGenerator.ListNodesGenerator(2, 20);
            ListNode.PrintList(AlgorithmSolution.SwapPairs(myListNode));*/
            #endregion

            #region 19. Remove Nth Node From End Of The List
            /*ListNode myListNode = TestCaseGenerator.ListNodesGenerator(20, 20);
            ListNode.PrintList(AlgorithmSolution.RemoveNthFromEnd(myListNode, 5));*/
            #endregion

            #region 160. Intersection of Two Linked Lists
            /*ListNode head1 = TestCaseGenerator.ListNodesGenerator(10, 20);
            ListNode head2 = TestCaseGenerator.ListNodesGenerator(10, 20);
            TestCaseGenerator.IntersectListsGenerator(10, 20, head1, head2);
            ListNode.PrintList(head1);
            ListNode.PrintList(head2);
            Console.WriteLine("the result is:" + AlgorithmSolution.GetIntersectionNode(head1, head2));*/
            #endregion
            #endregion
        }
    }
}