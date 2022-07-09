using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSALgo
{
   public static class ArraysAndStrings
    {
      
        public static bool IsUnique(string lettersToCheck)
        {
            //check if the characters in the string are unique
            //loop tru
            char currentChar = lettersToCheck[0];

            for (int i = 1; i < lettersToCheck.Length; i++)
            {
               
                for (int j = i; j < lettersToCheck.Length; j++)
                {
                    //if found, return 
                    if (lettersToCheck[j] == currentChar)
                    {
                        Console.WriteLine($" i == {i} and J == {j}");
                        return false;
                    }

                }
                currentChar = lettersToCheck[i];
            }

            return true;
        }

        static int removeDuplicates(int[] arr, int n)
        {

            if (n == 0 || n == 1)
                return n;

            // To store index of next
            // unique element
            int j = 0;

            // Doing same as done in Method 1
            // Just maintaining another updated
            // index i.e. j
            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine();

                if (arr[i] != arr[i + 1])
                {
                    //  int count = j++;
                    Console.WriteLine($"j++ == {j++}");
                    arr[j] = arr[i];
                }
                Console.WriteLine($"When i=> {i} and j=> {j}");
                foreach (var item in arr)
                {
                    Console.Write(item);
                }
            }
            arr[j++] = arr[n - 1];
            return j;
        }

        public static int Fibonacci(int Nth)
        {
            //formular
            //F(n) = ((O ^ n) + (1 - O)^n)/Math.Sqrt(5)
            //where O = 1.618034

            //uisng array
            //F(n) = F(n-1) + F(n - 2)
            //check that N is greater than 1
            if (Nth <2)
            {
                return Nth;
            }
            //create an array of length of Nth
            var fibonnaciArray = new int[Nth+1];
            fibonnaciArray[0] = 0;
            fibonnaciArray[1] = 1;

            //declare the first 2 elemnts of the array
            //initializa a loop at index 2 and use the formula
            for (int i = 2; i < Nth+1; i++)
            {
                fibonnaciArray[i] = fibonnaciArray[i - 1] + fibonnaciArray[i - 2];
            }
            //return last index of array when done
            return fibonnaciArray[Nth];

        }

        public static bool IsPrime(int N)
        {
            // 0 and 1 are not prime
            if (N < 2)  return false;
             
            return (N % 2 != 0 && N > 2);
        }

        public static int Str2Int(string str)
        {
            ///3894
            //define all numbers
            var allNumber = "0123456789";
            //check the lenth
            if (str.Length == 1)
            {
                return allNumber.LastIndexOf(str);
            }
            //creat a toal variable to hold the first stirng value
            int total = 0;
            //loop tru the string and multiply by 10 plus value
            for (int i = 0; i < str.Length; i++)
            {
                int number = allNumber.LastIndexOf(str[i]);
                if (number != -1)
                {
                    total = (total * 10) + number;
                }
               
            }
 

            return total;
        }

        public static void CountStringOccurence(string str)
        {
            //use a dictionary
            var dic = new Dictionary<char, int>();
      
            //loop tru the string
            foreach (var item in str)
            {
                //check if it exist
                dic.TryGetValue(item, out int counter);
                dic[item] = counter + 1;
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"Key {item.Key} => Value {item.Value}");
            }
        }

        public static int MaxSubArray(int[] nums)
        {
            //using kadanes algorithm for maximum sub array
            //local_max = Max(A[i], A[i]+local_max);
            if (nums.Length == 1) return nums[0];
            int global_max = -100000;
            int local_max = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                local_max = Math.Max(nums[i], nums[i] + local_max);

                if (local_max > global_max)
                {
                    global_max = local_max;
                }
            }
            return global_max;
        }

        public static void RotatingArrayByKpositions(int [] arr, int k)
        {
            // 1, 2, 3, 4, 5, 6 }, 2
            var newArr = new int[arr.Length];
            Array.Copy(arr, k, newArr, 0, arr.Length -k);
             
            Console.WriteLine("======");
            Array.Copy(arr, 0, newArr, arr.Length - k, k);

            foreach (var item in newArr)
            {
                Console.WriteLine(item);
            }
        }


        public static void MostFrequentInteger(int [] arr)
        {
            //use a dictionary to keep track
             

            var dico = new SortedDictionary<int, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                
                dico.TryGetValue(arr[i], out int counter);
                dico[arr[i]] = counter +1;
            }

            foreach (var item in dico)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            Console.WriteLine("=======");
            var maxim = dico.OrderByDescending( c=> c.Value).FirstOrDefault();

            Console.WriteLine($"{maxim.Key}: {maxim.Value}");
        }

        public static void CountDecreasingRatings(int [] arr)
        {
            //4321
            //45321
            //43543
            //have a counter
            int counter =0;
            //loop tru
            for (int i = 0; i < arr.Length; i++)
            {
                int temp = i;
                while ( temp < arr.Length -1 && (arr[temp] == arr[temp + 1] + 1))
                {
                    temp++;
                    counter++; 
                }
                counter++;

                Console.WriteLine($"{i} => {arr[i]} => {counter}");
            }
            //while loop

            Console.Write(counter);
        }

        public static int MinimumSwapsRequired(string s)
        {
            //validation
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            //check if it can be a palindrome or not
            //loop tru the string, count zeros and ones, subract
            var charString = s.ToCharArray();
            int countZero = 0;
            int countOnes = 0;
            foreach (var item in s)
            {
                if (item == '0') countZero++;
                else countOnes++;
            }

            if (countOnes % 2 == 1 && countZero % 2 == 1)
            {
                return -1;
            }
            //loop tru to get displaced count
            int displacedCounts=0;

            for (int i = 0; i < s.Length/2; i++)
            {
                if (s[i] != s[s.Length -1 -i])
                {
                    displacedCounts++;
                }
            }

            int numberOfSwaps = (displacedCounts / 2) + (displacedCounts % 2);

            return numberOfSwaps;
        }

    }
}
