using System;
using LibPrint;
using System.Diagnostics;
using System.IO;

namespace Laba7
{
    class Task2
    {
        public static void Second()
        {
            int[] Array = new int[100000];
            int[] ArrayIncrease = new int[100000];
            int[] ArrayDecrease = new int[100000];
            Random rand = new Random();
            for (int i = 0; i < Array.Length; i++)
            {
                Array[i] = rand.Next(0, 100000);               
            }          
            A:
            Pt.P("Введите номер нужной сортировки\n" +
                "1 - Сортировка выбором\n" +
                "2 - Сортировка вставками\n" +
                "3 - Сортировка пузырьком\n" +
                "4 - Сортировка шейкером\n" +
                "5 - Сортировка Шелла\n" +
                "6 - Прочитать записаный файл\n" +
                "7 - Записать и выйти");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.Clear(); RandomSelectionSort(Array,ref ArrayIncrease); 
                    DecreaseSelectionSort(Array,ref ArrayDecrease);Console.ReadKey();goto A;
                case 2:
                    Console.Clear();RandomInsertionSort(Array);
                    IncreaseInsertionSort(ArrayIncrease);DecreaseInsertionSort(ArrayDecrease); Console.ReadKey();goto A;
                case 3:
                    Console.Clear();RandomBubbleSort(Array);
                    IncreaseBubbleSort(ArrayIncrease);DecreaseBubbleSort(ArrayDecrease); Console.ReadKey();goto A;
                case 4:
                    Console.Clear();RandomShakerSort(Array);
                    IncreaseShakerSort(ArrayIncrease);DecreaseShakerSort(ArrayDecrease); Console.ReadKey();goto A;
                case 5:
                    Console.Clear();RandomShellSort(Array);IncreaseShellSort(ArrayIncrease);DecreaseShellSort(ArrayDecrease); Console.ReadKey(); goto A;
                case 6:
                    Console.Clear();Reading();Console.ReadKey();goto A;
                case 7:
                    Console.Clear();Recording(Array, ArrayIncrease, ArrayDecrease);break;
            }                    
        }
        public static void Swap(ref int i,ref int j)
        {
            int tmp = i;
            i = j;
            j = tmp;
        }
        public static void SwapCount(ref int i, ref int j, ref int count)
        {
            int tmp = i;
            i = j;
            j = tmp;
            count++;
        }
        public static void Recording(int[] R, int[] I, int[] D)
        {
            string path = @"D:\sorted.dat";
            if (!File.Exists(path))
            {
                BinaryWriter file = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
                /*for(int i = 0; i < R.Length; i++)
                {
                   file.Write(I[i] + " ");
                }*/

                for (int i = 0; i < I.Length; i++)
                {
                    file.Write(I[i] + " ");
                }

                /*for(int i = 0; i < D.Length; i++)
                {
                        file.Write(I[i] + " ");
                }*/
                file.Close();
            }
            else
            {
                File.Delete(path);             
                BinaryWriter file = new BinaryWriter(File.Open(path,FileMode.OpenOrCreate));
                for (int i = 0; i < R.Length; i++)
                {
                    file.Write(R[i] + " ");
                }

                for (int i = 0; i < I.Length; i++)
                {
                    file.Write(I[i] + " ");
                }

                for (int i = 0; i < D.Length; i++)
                {
                    file.Write(D[i] + " ");
                }
                file.Close();
            }
        }
        public static void Reading()          
        {
            string path = @"D:\sorted.dat";
            BinaryReader file = new BinaryReader(File.OpenRead(path));
            while (file.PeekChar() > -1)
            {
                    Console.Write(file.ReadString() + " ");
            }
        }
        public static void Print(int[] A)
        {
            for(int i = 0; i < A.Length; i++)
            {
                Console.Write(A[i] + " ");
            }
        }
        public static void RandomSelectionSort(int[] A,ref int[]B)
        {
            Stopwatch First = new Stopwatch();
            First.Start();
            int count = 0, count1 = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int min = i;
                for (int j = i; j < A.Length; j++)
                {
                    if (A[j] < A[min])
                    {
                        min = j;
                        count++;
                        SwapCount(ref A[i], ref A[min], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                    //SwapCount(ref A[i], ref A[min], ref count1);
                }
            }
            First.Stop();
            for(int i = 0; i < A.Length; i++)
            {
                B[i] = A[i];
            }
            TimeSpan time = First.Elapsed;
            Console.WriteLine($"Для рандомного массива\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
            IncreaseSelectionSort(A);

        }
        public static void IncreaseSelectionSort(int[] A)
        {
            Stopwatch First = new Stopwatch();
            First.Start();
            int count = 0, count1 = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int min = i;
                for (int j = i; j < A.Length; j++)
                {
                    if (A[j] < A[min])
                    {
                        min = j;
                        count++;
                        SwapCount(ref A[i], ref A[min], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                    //SwapCount(ref A[i], ref A[min], ref count1);
                }
            }
            First.Stop();
            TimeSpan time = First.Elapsed;
            Console.WriteLine($"Для массива в порядке возрастания\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void DecreaseSelectionSort(int[] A,ref int[]B)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int max = A.Length - 1;
                for (int j = i; j < A.Length; j++)
                {
                    if (A[j] > A[max])
                    {
                        max = j;
                    }
                    Swap(ref A[i], ref A[max]);
                }
            }
            for(int i = 0; i < A.Length; i++)
            {
                B[i] = A[i];
            }
            Stopwatch First = new Stopwatch();
            First.Start();
            int count = 0, count1 = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int min = i;
                for (int j = i; j < A.Length; j++)
                {
                    if (A[j] > A[min])
                    {
                        min = j;
                        count++;
                        SwapCount(ref A[i], ref A[min], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                    //SwapCount(ref A[i], ref A[min], ref count1);
                }
            }
            First.Stop();
                TimeSpan time = First.Elapsed;
            Console.WriteLine($"Для массива в порядке убывания\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void RandomInsertionSort(int[] A)
        {
            Stopwatch Second = new Stopwatch();
            Second.Start();
            int count = 0,count1 = 0;
            for(int i = 1; i < A.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (A[j - 1] > A[j])
                    {
                        count++;
                        SwapCount(ref A[j - 1], ref A[j], ref count1);
                    }
                    else
                    {
                        count++;
                        break;
                    }
                }
            }
            Second.Stop();
            TimeSpan time = Second.Elapsed;
            Console.WriteLine($"Для рандомного массива\n" +
               $"Количество сравнений: {count}\n" +
               $"Количество перестановок: {count1}\n" +
               $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void IncreaseInsertionSort(int[]A)
        {
            Stopwatch Second = new Stopwatch();
            Second.Start();
            int count = 0, count1 = 0;
            for (int i = 1; i < A.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (A[j - 1] > A[j])
                    {
                        count++;
                        SwapCount(ref A[j - 1], ref A[j], ref count1);
                    }
                    else
                    {
                        count++;
                        break;
                    }
                }
            }
            Second.Stop();
            TimeSpan time = Second.Elapsed;
            Console.WriteLine($"Для массива в порядке возрастания\n" +
               $"Количество сравнений: {count}\n" +
               $"Количество перестановок: {count1}\n" +
               $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void DecreaseInsertionSort(int[] A)
        {
            Stopwatch Second = new Stopwatch();
            Second.Start();
            int count = 0, count1 = 0;
            for (int i = 1; i < A.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (A[j - 1] > A[j])
                    {
                        count++;
                        SwapCount(ref A[j - 1], ref A[j], ref count1);
                    }
                    else
                    {
                        count++;
                        break;
                    }
                }
            }
            Second.Stop();
            TimeSpan time = Second.Elapsed;
            Console.WriteLine($"Для массива в порядке вубывания\n" +
               $"Количество сравнений: {count}\n" +
               $"Количество перестановок: {count1}\n" +
               $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void RandomBubbleSort(int[] A)
        {
            Stopwatch Third = new Stopwatch();
            Third.Start();
            int count = 0, count1 = 0;
            for(int i = 0; i < A.Length; i++)
            {
                for(int j = A.Length-1; j > i; j--)
                {
                    if (A[j - 1] > A[j])
                    {
                        count++;
                        SwapCount(ref A[j - 1], ref A[j], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            Third.Stop();
            TimeSpan time = Third.Elapsed;
            Console.WriteLine($"Для рандомного массива\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void IncreaseBubbleSort(int[] A)
        {
            Stopwatch Third = new Stopwatch();
            Third.Start();
            int count = 0, count1 = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = A.Length-1; j > i; j--)
                {
                    if (A[j - 1] > A[j])
                    {
                        count++;
                        SwapCount(ref A[j - 1], ref A[j], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            Third.Stop();
            TimeSpan time = Third.Elapsed;
            Console.WriteLine($"Для массива в порядке возрастания\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void DecreaseBubbleSort(int[] A)
        {
            Stopwatch Third = new Stopwatch();
            Third.Start();
            int count = 0, count1 = 0;
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = A.Length-1; j > i; j--)
                {
                    if (A[j - 1] > A[j])
                    {
                        count++;
                        SwapCount(ref A[j - 1], ref A[j], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            Third.Stop();
            TimeSpan time = Third.Elapsed;
            Console.WriteLine($"Для массива в порядке убывания\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void RandomShakerSort(int[] A)
        {
            Stopwatch Fourth = new Stopwatch();
            Fourth.Start();
            int count = 0, count1 = 0, l = 0, r = A.Length - 1;
            do
            {
                for(int i = l; i <= r; i++)
                {
                    if (i!=r && A[i] > A[i + 1])
                    {
                        count++;
                        SwapCount(ref A[i], ref A[i + 1], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
                r--;
                for(int i = r; i > l; i--)
                {
                    if (A[i] < A[i - 1])
                    {
                        count++;
                        SwapCount(ref A[i], ref A[i - 1], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
                l++;
            }
            while (l <= r);
            Fourth.Stop();
            TimeSpan time = Fourth.Elapsed;
            Console.WriteLine($"Для рандомного массива\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void IncreaseShakerSort(int[] A)
        {
            Stopwatch Fourth = new Stopwatch();
            Fourth.Start();
            int count = 0, count1 = 0, l = 0, r = A.Length - 1;
            do
            {
                for (int i = l; i <= r; i++)
                {
                    if (i != r && A[i] > A[i + 1])
                    {
                        count++;
                        SwapCount(ref A[i], ref A[i + 1], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
                r--;
                for (int i = r; i > l; i--)
                {
                    if (A[i] < A[i - 1])
                    {
                        count++;
                        SwapCount(ref A[i], ref A[i - 1], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
                l++;
            }
            while (l <= r);
            Fourth.Stop();
            TimeSpan time = Fourth.Elapsed;
            Console.WriteLine($"Для массива в порядке возрастания\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void DecreaseShakerSort(int[] A)
        {
            Stopwatch Fourth = new Stopwatch();
            Fourth.Start();
            int count = 0, count1 = 0, l = 0, r = A.Length - 1;
            do
            {
                for (int i = l; i <= r; i++)
                {
                    if (i != r && A[i] > A[i + 1])
                    {
                        count++;
                        SwapCount(ref A[i], ref A[i + 1], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
                r--;
                for (int i = r; i > l; i--)
                {
                    if (A[i] < A[i - 1])
                    {
                        count++;
                        SwapCount(ref A[i], ref A[i - 1], ref count1);
                    }
                    else
                    {
                        count++;
                    }
                }
                l++;
            }
            while (l <= r);
            Fourth.Stop();
            TimeSpan time = Fourth.Elapsed;
            Console.WriteLine($"Для массива в порядке убывания\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void RandomShellSort(int[] A)
        {
            int count = 0, count1 = 0;
            Stopwatch Fifth = new Stopwatch();
            Fifth.Start();
            for (int step = A.Length / 2; step > 0; step /= 2)
            {
                for (int i = step; i < A.Length; i++)
                {
                    int tmp = A[i], j = i;
                    if (tmp > A[j - step])
                    {
                        count++;
                    }
                    while (j >= step && tmp < A[j - step])
                    {
                        count++;
                        A[j] = A[j - step];
                        j -= step;
                        count1++;
                    }
                    A[j] = tmp;
                }
            }
            Fifth.Stop();
            TimeSpan time = Fifth.Elapsed;
            Console.WriteLine($"Для рандомного массива\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
        public static void IncreaseShellSort(int[] A)
        {
            int count = 0, count1 = 0;
            Stopwatch Fifth = new Stopwatch();
            Fifth.Start();
            for (int step = A.Length / 2; step > 0; step /= 2)
            {
                for (int i = step; i < A.Length; i++)
                {
                    int tmp = A[i], j = i;
                    if (tmp > A[j - step])
                    {
                        count++;
                    }
                    while (j >= step && tmp < A[j - step])
                    {
                        count++;
                        A[j] = A[j - step];
                        j -= step;
                        count1++;
                    }
                    A[j] = tmp;
                }
            }
            Fifth.Stop();
            TimeSpan time = Fifth.Elapsed;
            Console.WriteLine($"Для массива в порядке возрастания\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");

        }
        public static void DecreaseShellSort(int[] A)
        {
            int count = 0, count1 = 0;
            Stopwatch Fifth = new Stopwatch();
            Fifth.Start();
            for (int step = A.Length / 2; step > 0; step /= 2)
            {
                for (int i = step; i < A.Length; i++)
                {
                    int tmp = A[i], j = i;
                    if (tmp > A[j - step])
                    {
                        count++;
                    }
                    while (j >= step && tmp < A[j - step])
                    {
                        count++;
                        A[j] = A[j - step];
                        j -= step;
                        count1++;
                    }
                    A[j] = tmp;
                }
            }
            Fifth.Stop();
            TimeSpan time = Fifth.Elapsed;
            Console.WriteLine($"Для массива в порядке убывания\n" +
                $"Количество сравнений: {count}\n" +
                $"Количество перестановок: {count1}\n" +
                $"Время работы: {Math.Round(time.TotalSeconds, 0)}:{time.Milliseconds}\n");
        }
    }
}
