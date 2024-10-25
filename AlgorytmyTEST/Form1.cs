using System.Collections.Concurrent;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AlgorytmyTEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //BubbleSort
        //BubbleSort porównuje s¹siaduj¹ce ze sob¹ elementy, wielokrotnie przechodz¹c przez listê danych

        private void button1_Click(object sender, EventArgs e)
        {
            int[] BubbleSortTab = { 2, 3, 1, 99, 4, 0, 111, 65 };

            BubbleSort(BubbleSortTab);

            string result = string.Join(", ", BubbleSortTab);

            MessageBox.Show(result);
        }

        private void BubbleSort(int[] BubbleSortTab)
        {
            int n = BubbleSortTab.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (BubbleSortTab[j] > BubbleSortTab[j + 1])
                    {
                        int temp = BubbleSortTab[j];
                        BubbleSortTab[j] = BubbleSortTab[j + 1];
                        BubbleSortTab[j + 1] = temp;
                    }
                }
            }
        }


        //InsertSort
        //Algorytm uznaje pierwsz¹ liczbê za posortowan¹, 


        private void button2_Click(object sender, EventArgs e)
        {
            int[] InsertSortTab = { 33, 2, 1, 55, 99, 11, 133, 9 };

            InsertSort(InsertSortTab);
            string result = string.Join(", ", InsertSortTab);
            MessageBox.Show(result);

        }

        private void InsertSort(int[] InsertSortTab)
        {

            int n = InsertSortTab.Length;

            for (int i = 1; i < n; i++)
            {
                int sprawadzany_element = i;
                int j = i - 1;

                while (j >= 0 && j > sprawadzany_element)
                {
                    InsertSortTab[j + 1] = InsertSortTab[j];
                    j--;
                }
                InsertSortTab[j] = sprawadzany_element;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] MergeSortTab = { 3, 99, 4, 13, 77, 21, 12, 0, 45 };

            int n = MergeSortTab.Length;
            MergeSort(MergeSortTab, 0, n - 1);
            string result = string.Join(", ", MergeSortTab);
            MessageBox.Show(result);
        }

        //MergeSort

        private void MergeSort(int[] MergeSortTab, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(MergeSortTab, start, mid);
                MergeSort(MergeSortTab, mid + 1, end);
                Merge(MergeSortTab, start, mid, end);
            }
        }

        private void Merge(int[] MergeSortTab, int start, int mid, int end)
        {
            int i = start;
            int j = mid + 1;
            int k = 0;
            int[] temp = new int[end - start + 1];

            while (i <= mid && j <= end)
            {
                if (MergeSortTab[i] <= MergeSortTab[j])
                {
                    temp[k] = MergeSortTab[i];
                    i++;
                }
                else
                {
                    temp[k] = MergeSortTab[j];
                    j++;
                }
                k++;
            }

            while (i <= mid)
            {
                temp[k] = MergeSortTab[i];
                i++;
                k++;
            }

            while (j <= end)
            {
                temp[k] = MergeSortTab[j];
                j++;
                k++;
            }

            for (i = start; i <= end; i++)
            {
                MergeSortTab[i] = temp[i - start];
            }
        }

        //QuickSort

        private void button4_Click(object sender, EventArgs e)
        {
            int[] QuickSortTab = { 33, 2, 1, 4, 5, 99, 88, 72, 12 };

            QuickSort(QuickSortTab, 0, QuickSortTab.Length - 1);
            string result = string.Join(", ", QuickSortTab);
            MessageBox.Show(result);

        }

        private void QuickSort(int[] QuickSortTab, int left, int right)
        {
            if (left < right)
            {
                int PivotIndex = Partition(QuickSortTab, left, right);

                QuickSort(QuickSortTab, left, PivotIndex - 1);
                QuickSort(QuickSortTab, PivotIndex + 1, right);
            }
        }

        private int Partition(int[] QuickSortTab, int left, int right)
        {
            int pivot = QuickSortTab[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (QuickSortTab[j] <= pivot)
                {
                    i++;
                    Swap(QuickSortTab, i, j);
                }
            }

            Swap(QuickSortTab, i + 1, right);
            return i + 1;
        }

        private void Swap(int[] QuickSortTab, int i, int j)
        {
            int temp = QuickSortTab[i];
            QuickSortTab[i] = QuickSortTab[j];
            QuickSortTab[j] = temp;
        }

        //Counting Sort

        private void button5_Click(object sender, EventArgs e)
        {
            int[] CountingSortTab = { 3, 3, 2, 22, 1, 19, 77, 123, 34, 9 };
     
            CountingSort(CountingSortTab);

            string result = string.Join(", ", CountingSortTab);

            MessageBox.Show(result);
        }

        private void CountingSort(int[] CountingSortTab)
        {
            if (CountingSortTab.Length == 0)
                return;

            int max = CountingSortTab.Max();
            int min = CountingSortTab.Min();

            int range = max - min + 1;
            int[] count = new int[range];

            foreach (int number in CountingSortTab)
            {
                count[number - min]++;
            }

            int index = 0;
            for (int i = 0; i < range; i++)
            {
                while (count[i] > 0)
                {
                    CountingSortTab[index++] = i + min;
                    count[i]--;
                }
            }
        }
    }

}
