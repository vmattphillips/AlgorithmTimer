using System;
using System.Diagnostics;
using DataStructures;

public class Program
{
    public static void Main()
    {
        // Driver

        int dataSetSize = 50000;
        int searchValue = 0;
        int index = 0;

        string optionSelect = "************************************ \n" +
                            "Enter your option: \n" +
                            "Create a [n]ew random dataset \n" +
                            "[P]rint the dataset \n" +
                            "Run [i]nsertion sort on the dataset \n" +
                            "Run [q]uick sort on the dataset \n" +
                            "[B]inary search the dataset";

        string? choice;

        int[] arr = new int[] { };
        BinarySearchTree tree = new BinarySearchTree();
        Stopwatch watch;
        double ms;

        while (true)
        {
            Console.WriteLine(optionSelect);
            Console.Write("Choice: ");
            choice = Console.ReadLine();
            choice = choice.ToLower();

            switch (choice)
            {
                case "n":
                    Console.Write("Dataset Size: ");
                    int.TryParse(Console.ReadLine(), out dataSetSize);
                    Console.WriteLine("[A]rray or [B]ST?");
                    choice = Console.ReadLine();
                    if (choice.ToLower() == "a")
                    {
                        Console.WriteLine("Generating New Data! Array size: " + dataSetSize);
                        arr = GenerateDataSet(dataSetSize);
                    }
                    else if (choice.ToLower() == "b")
                    {
                        Console.WriteLine("Generating New Data! Tree size: " + dataSetSize);
                        tree = GenerateBST(dataSetSize); // Nothing to do with this yet in the driver
                    }
                    else
                    {
                        Console.WriteLine("Unknown input");
                    }
                    break;
                case "p":
                    PrintArray(arr);
                    break;
                case "i":
                    if (arr.Length == 0)
                    {
                        Console.WriteLine("Dataset is empty!");
                        break;
                    }
                    Console.WriteLine("Running InsertionSort on dataset...");
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    arr = InsertionSort(arr);
                    watch.Stop();
                    ms = watch.ElapsedMilliseconds;

                    Console.WriteLine("COMPLETED InsertionSort! Time to complete: " + ms + "ms!");
                    break;

                case "q":
                    if (arr.Length == 0)
                    {
                        Console.WriteLine("Dataset is empty!");
                        break;
                    }
                    Console.WriteLine("Running QuickSort on dataset...");
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    QuickSort(ref arr);
                    watch.Stop();
                    ms = watch.ElapsedMilliseconds;

                    Console.WriteLine("COMPLETED QuickSort! Time to complete: " + ms + "ms!");
                    break;

                case "b":
                    if (arr.Length == 0)
                    {
                        Console.WriteLine("Dataset is empty!");
                        break;
                    }
                    Console.Write("What value to search for? ");
                    int.TryParse(Console.ReadLine(), out searchValue);
                    Console.WriteLine("Searching the dataset for " + searchValue + " with BinarySearch");
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    index = BinarySearch(arr, searchValue);
                    watch.Stop();
                    ms = watch.ElapsedMilliseconds;

                    Console.WriteLine("COMPLETED BinarySearch! Time to complete: " + ms + "ms!");
                    Console.WriteLine("Value was found at index: " + index);
                    break;

                default:
                    Console.WriteLine("Unknown input");
                    break;
            }
            Console.Write("Press any key to go back to main menu...");
            Console.ReadLine();
        }
    }

    static void PrintArray(int[] arr)
    {
        Console.Write("[");
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == arr.Length - 1)
            {
                Console.Write(arr[i]);
            }
            else
            {
                Console.Write(arr[i] + ", ");
            }
        }
        Console.WriteLine("]");
    }

    // Generates a random BST
    static BinarySearchTree GenerateBST(int size)
    {
        Random r = new Random();
        BinarySearchTree tree = new BinarySearchTree();

        for (int x = 0; x < size; x++)
        {
            tree.Insert(r.Next(Int32.MaxValue));
        }
        return tree;
    }

    // Generates a random int array
    static int[] GenerateDataSet(int size)
    {
        Random r = new Random();
        int[] arr = new int[size];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = r.Next(Int32.MaxValue);
        }

        return arr;
    }

    // sorts the given list using Insertion Sort
    static int[] InsertionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j > 0; j--)
            {
                if (arr[j - 1] > arr[j])
                {
                    int temp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = temp;
                }
            }
        }
        return arr;
    }


    // good visualization here https://anim.ide.sk/sorting_algorithms_2.php
    // sorts the given list using Quick Sort
    static void QuickSort(ref int[] arr)
    {
        QuickSort(ref arr, 0, arr.Length - 1);
    }

    // Overloaded Quicksort that calls itself recusively
    static void QuickSort(ref int[] arr, int left, int right)
    {
        int l = left;
        int r = right;

        int pivot = arr[(left + right) / 2];

        while (l <= r)
        {
            while (arr[l] < pivot)
            {
                l++;
            }

            while (arr[r] > pivot)
            {
                r--;
            }

            if (l <= r)
            {
                int tmp = arr[l];
                arr[l] = arr[r];
                arr[r] = tmp;

                l++;
                r--;
            }
        }

        if (left < r)
        {
            QuickSort(ref arr, left, r);
        }

        if (l < right)
        {
            QuickSort(ref arr, l, right);
        }
    }

    // Returns the index of the target, -1 if not found
    static int BinarySearch(int[] arr, int target)
    {
        return BinarySearch(arr, target, 0, arr.Length - 1);
    }

    // Overloaded BinarySearch that calls itself recursively
    static int BinarySearch(int[] arr, int target, int lower, int upper)
    {

        if (lower < upper)
        {
            int middleIndex = lower + (upper - lower) / 2;
            if (target == arr[middleIndex])
            {
                return middleIndex;
            }
            else if (target > arr[middleIndex])
            {
                return BinarySearch(arr, target, middleIndex + 1, upper);
            }
            else
            {
                return BinarySearch(arr, target, lower, middleIndex - 1);
            }
        }

        return -1;
    }

}