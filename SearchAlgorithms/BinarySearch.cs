using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms
{
    internal class BinarySearch
    {
        public static int perform(double searchvalue, List<double> listtosearch)
        {
            int left = 0;
            int right = listtosearch.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;

                if (listtosearch[mid] == searchvalue)
                { return mid; }
                else if (listtosearch[mid]< searchvalue) 
                { left = mid + 1; }

                else { right = mid - 1; }
            }
            return -1;
            
        }

    }
}
