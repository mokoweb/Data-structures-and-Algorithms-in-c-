using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DSALgo
{
    class Program
    {
        
        static void Main(string[] args)
        {
         
            String[] arr = new String[] { "0", "1", "10", "01", "00100", "010101", "101000", "0100101" };
            foreach (String str in arr)
            {
                Console.WriteLine($"Minimum swaps for {str} => is {ArraysAndStrings.MinimumSwapsRequired(str)}");
            }

        }

    }
}
