using System;
using System.Collections.Generic;
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

            List<double> listofdouble = new List<double>();

            populateListwithrandomdoubles(ref listofdouble, 10);
            printlist(listofdouble);

            requestsearch(listofdouble);
            printlist(listofdouble);

            Console.ReadKey();
        }

        static void requestsearch(List<double> list)
        {
            double searchvalue;
            Console.WriteLine("what value would you like to search for?");

            if (double.TryParse(Console.ReadLine(), out searchvalue))
            {
                //   int index = LinearSearch.Perform(searchvalue, list);
                int index = BinarySearch.perform(searchvalue, list);
                if (index < 0) { Console.WriteLine("NOT FOUND"); }
                else { Console.WriteLine("Found at: " + index); }
             } 
        }  

        static void populateListwithrandomdoubles(ref List<double> list, int size)
        {
            for (int i = 0; i < size; i++)
            {
                double twodigitdouble = double.Parse(randomGenerator.NextDouble().ToString("0.00"));
                list.Add(twodigitdouble);
            }
            list.Sort() ; printlist(list);
        }

        static void printlist(List<double> list)
        {
            Console.WriteLine("\n\nList Print:\n");

            for (int i = 0;i < list.Count; i++)
            {
                Console.WriteLine("  "+ list[i].ToString());
            }
            Console.WriteLine("\nEND\n");
        }
    }
}
