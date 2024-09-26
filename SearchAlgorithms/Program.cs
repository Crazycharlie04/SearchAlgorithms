using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms
{
    internal class Program
    {
        static Random randomGenerator = new Random();
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            List<double> listofdouble = new List<double>();

            populateListwithrandomdoubles(ref listofdouble, 10);
            printlist(listofdouble);

            requestsearch(listofdouble);
            printlist(listofdouble);
            stopwatch.Stop();

            // Output the elapsed time
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"Time elapsed: {elapsedTime.TotalSeconds} seconds");
            Console.ReadKey();
        }

        static void requestsearch(List<double> list)
        {
            double searchvalue;
            Console.WriteLine("What value would you like to search for?");
            if (double.TryParse(Console.ReadLine(), out searchvalue))
            {
                Console.WriteLine("Choose a search algorithm:\n1. Binary Search\n2. Jump Search \n3.linear Search");
                int choice = int.Parse(Console.ReadLine());

                int index = -1;  // Initialize index

                // Change here: Handling the search algorithm selection
                if (choice == 1)
                {
                    index = BinarySearch.perform(searchvalue, list);
                }
                else if (choice == 2)
                {
                    index = JumpSearch.perform(searchvalue, list);  // New Jump Search call
                }
                else if(choice == 3)
                {
                      index = LinearSearch.Perform(searchvalue, list);
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                    return;
                }

                if (index < 0)
                {
                    Console.WriteLine("NOT FOUND");
                }
                else
                {
                    Console.WriteLine("Found at: " + index);
                }
            }
        }

        static void populateListwithrandomdoubles(ref List<double> list, int size)
        {
            for (int i = 0; i < size; i++)
            {
                double twodigitdouble = double.Parse(randomGenerator.NextDouble().ToString("0.00"));
                list.Add(twodigitdouble);
            }
            list.Sort();
            printlist(list);
        }

        static void printlist(List<double> list)
        {
            Console.WriteLine("\n\nList Print:\n");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("  " + list[i].ToString());
            }
            Console.WriteLine("\nEND\n");
        }
    }

    // New JumpSearch class
    public static class JumpSearch
    {
        public static int perform(double searchValue, List<double> list)
        {
            int n = list.Count;
            int step = (int)Math.Floor(Math.Sqrt(n));  // Calculate jump step
            int prev = 0;

            // Finding the block where element is present
            while (list[Math.Min(step, n) - 1] < searchValue)
            {
                prev = step;
                step += (int)Math.Floor(Math.Sqrt(n));

                if (prev >= n)
                    return -1; // Element not found
            }

            // Performing linear search within the block
            while (list[prev] < searchValue)
            {
                prev++;

                // If we reach the next block or end of the array
                if (prev == Math.Min(step, n))
                    return -1;
            }

            // If element is found
            if (list[prev] == searchValue)
                return prev;

            return -1;
        }
    }

   
}
