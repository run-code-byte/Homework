namespace Order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //内置集合自带排序算法

            //List<T>.Sort()
            //List<int> list = new List<int> { 3,1,4,2};
            //list.Sort();
            ////list.Sort((a,b)=>b.CompareTo(a));
            //foreach(int i in list) Console.WriteLine(i);

            //LINQ OrderBy()
            //List<int> list = new List<int> { 3,1,4,2};
            //var newList = list.OrderBy(X => X).ToList();
            //var newListDesc=list.OrderByDescending(X => X).ToList();
            //foreach (var item in newList) Console.Write($"  {item}");
            //Console.WriteLine();
            //foreach (var item in newListDesc) Console.Write($"  {item}");

            // 二、基础排序算法（面试手写）

            /*
                1. 冒泡排序（BubbleSort）
                 核心：相邻两两比较，大的往后 “冒泡”
                 复杂度：O (n²)，简单，数据量大很慢，只适合少量数据
             */
            //int[] sort = [3, 5, 7, 8, 9, 4, 2, 6];
            //BubbleSort(sort);
            //foreach (int i in sort) Console.Write(" " + i);

            /*
               2. 选择排序（SelectSort）
                每次找到最小元素，放到前面
                复杂度 O (n²)
            */
            //int[] arr= [3, 5, 7, 8, 9, 4, 2, 6];
            //SelectSort(arr);
            //foreach (int i in arr) Console.Write(" " + i);

            /*
              3. 快速排序 QuickSort（面试最常问）
                分治思想，选基准值，小的放左边，大的放右边，递归
                平均复杂度 O (n log n)，**大数据首选**
           */
            //int[] Qsort = [3, 5, 7, 8, 9, 4, 2, 6,11,1,17,14];
            //int n = 0, m = 11;
            //QuickSort(Qsort, n, m);
            //foreach(int i in Qsort) Console.Write(" "+i);


        }

        //1. 冒泡排序（BubbleSort）
        static void BubbleSort(int[] arr)
        {
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 0; j < len - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int tmp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = tmp;
                    }
                }
            }
        }

        //2. 选择排序（SelectSort）
        static void SelectSort(int[] arr)
        {
            int len = arr.Length;
            for(int i = 0;i < len - 1; i++)
            {
                int minIndex = i;
                for(int j = i+1;j< len; j++)
                {
                    if (arr[j] < arr[minIndex])minIndex = j;
                }
                int tmp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = tmp;
            }
        }

        //3. 快速排序 QuickSort（面试最常问）
        static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return;
            int pivot = arr[left];
            int i = left, j = right;
            while (i < j)
            {
                while (i < j && arr[j] >= pivot) j--;
                arr[i] = arr[j];
                while (i < j && arr[i] <= pivot) i++;
                arr[j] = arr[i];
            }
            arr[i] = pivot;
            QuickSort(arr, left, i - 1);
            QuickSort(arr, i + 1, right);
        }

    }
}
