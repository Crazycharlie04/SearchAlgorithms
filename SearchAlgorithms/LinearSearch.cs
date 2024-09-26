using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithms
{
    internal class LinearSearch
    {

        public static int Perform(double searchvalue, List<double> ListToSearch)
        {
            for (int i = 0; i < ListToSearch.Count; i++) { 

                if (ListToSearch[i] == searchvalue) 
                
                { return i; }

            }

            return -1;
        }

        public static int Perform(string searchvalue, List<string> ListToSearch) {
            for (int i = 0; i < ListToSearch.Count; i++)
            {

                if (string.Compare(ListToSearch[i],searchvalue) == 0)

                { return i; }

            }

            return -1;
        }
    }

}

