using System;
using System.Collections.Generic;  // added library to use Dictionary
using System.Linq; //added Linq library to support code in Largest Unique number

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        {
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            int result = SearchInsert(nums, target);
            if (result != -1)
            {
                Console.WriteLine("Position to insert {0} is = {1}\n", target, result);
            }
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect = Intersect(nums1, nums2);
            Console.WriteLine("Intersection of two arrays is: ");
            DisplayArray(intersect);
            Console.WriteLine("\n");

            int[] A = { 5, 7, 3, 9, 4, 9, 8, 3, 1 };
            Console.WriteLine("Largest integer occuring once = {0}\n", LargestUniqueNumber(A));

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "cba";
            Console.WriteLine("Time taken to type with one finger = {0}\n", CalculateTime(keyboard, word));

            int[,] image = { { 1, 1, 0 }, { 1, 0, 1 }, { 0, 0, 0 } };
            int[,] flipAndInvertedImage = FlipAndInvertImage(image);
            Console.WriteLine("The resulting flipped and inverted image is:\n");
            Display2DArray(flipAndInvertedImage);
            Console.Write("\n");

            int[,] intervals = { { 0, 30 }, { 5, 10 }, { 15, 20 } };
            int minMeetingRooms = MinMeetingRooms(intervals);
            Console.WriteLine("Minimum meeting rooms needed = {0}\n", minMeetingRooms);

            int[] arr = { -4, -1, 0, 3, 10 };
            int[] sortedSquares = SortedSquares(arr);
            Console.WriteLine("Squares of the array in sorted order is:");
            DisplayArray(sortedSquares);
            Console.Write("\n");

            string s = "abca";
            // had to update this to accomodate the possibility that string is already a pallindrome
            if (isaPalindrome(s) == 0)// first checks if input is a pallindrome
            {
                Console.Write("\nInput " + s + " is a palindrome");

            }
            else
            {
                if (ValidPalindrome(s))// checks if input can be made a pallindrome by removing any one character
                {
                    Console.WriteLine("The given string \"{0}\" can be made PALINDROME", s);
                }
                else
                {
                    Console.WriteLine("The given string \"{0}\" CANNOT be made PALINDROME", s);
                }
            }
        }

        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.Write("\n");
            }
        }

        public static int SearchInsert(int[] nums, int target)
        {

            try
            {
                int minNum = 0;
                int maxNum = nums.Length - 1;


                while (minNum <= maxNum)
                {
                    int mid = (minNum + maxNum) / 2;
                    if (target == nums[mid])
                    {
                        Console.WriteLine(target + " found at position " + mid);
                        return -1;
                    }
                    else if (target < nums[mid])
                    {
                        maxNum = mid - 1;
                    }
                    else
                    {
                        minNum = mid + 1;
                    }
                }
                /*Console.Write("target not found.\n Index where the target should be inserted so that the array still " +
                "remains sorted is " + minNum + "\n");*/
                return minNum;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SearchInsert()");
            }
            return 0;
        }

        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                int len1 = nums1.Length, len2 = nums2.Length, i = 0, j = 0;
                List<int> l = new List<int>();  // Used list as size of array is not fixed.
                Array.Sort(nums1);
                Array.Sort(nums2);

                while (i < len1 && j < len2)
                {
                    if (nums1[i] > nums2[j])  // Increase the index of array with smaller value on comparison.
                    {
                        j++;
                    }
                    else if (nums2[j] > nums1[i])
                    {
                        i++;
                    }
                    else  // If elements in both arrays are equal add it to the list.
                    {
                        l.Add(nums1[i]);
                        i++;
                        j++;
                    }
                }
                return l.ToArray();  //Return the interseaction array.
            }
            catch
            {
                Console.WriteLine("Exception occured while computing Intersect()");
            }

            return new int[] { };
        }

        public static int LargestUniqueNumber(int[] A)
        {
            try
            {


                Dictionary<int, int> dict = new Dictionary<int, int>();
                int val;
                for (int i = 0; i < A.Length - 1; i++)
                {
                    if (dict.TryGetValue(A[i], out val)) //check if the number is already present in the dictionary
                    {
                        dict[A[i]]++;//if the number exists, then increase the value
                    }
                    else
                    {
                        dict.Add(A[i], 0); //if it doesn't exist then add it to the dictionary with value 0
                    }
                }
                return dict.Where(pair => pair.Value == 0).Select(pair => pair.Key).Max();
                //used where clause to find if the value is 0 and Max clause to find the maximum value

            }
            catch
            {
                Console.WriteLine("Exception occured while computing LargestUniqueNumber()");
            }

            return 0;
        }

        public static int CalculateTime(string keyboard, string word)
        {
            try
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                char[] keyArr = keyboard.ToCharArray();  // Convert keyboard to character array.
                char[] wordArr = word.ToCharArray();  // Convert word to character array.
                int time;

                for (int i = 0; i < keyArr.Length; i++)
                {
                    dict.Add(keyArr[i], i); // Add keyboard characters to dictionary.
                }

                time = dict[wordArr[0]];
                for (int i = 0; i < wordArr.Length - 1; i++)
                {
                    time = time + Math.Abs(dict[wordArr[i]] - dict[wordArr[i + 1]]); //Calculate the finger travel total time 
                }
                return time;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing CalculateTime()");
            }

            return 0;
        }

        public static int[,] FlipAndInvertImage(int[,] A)
        {
            try
            {
                try
                {
                    int[,] res = new int[A.GetLength(0), A.GetLength(1)];// create a result 2D array of size same as A
                    for (int i = 0; i < A.GetLength(0); i++) // outer loop is used to control rows
                    {
                        for (int j = 0; j < A.GetLength(1); j++) // inner loop is used to control columns
                        {
                            res[i, j] = A[i, Math.Abs(j - A.GetLength(1) + 1)] ^ 1; //first we will reverse the array and then use XOR operator to find the inverse image of the array
                        }

                    }
                    return res;
                }
                catch
                {
                    Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
                }

                return new int[,] { };
            }
            catch
            {
                Console.WriteLine("Exception occured while computing FlipAndInvertImage()");
            }

            return new int[,] { };
        }
        //Function to calculate minimum meeting rooms needed based on meeting intervals
        public static int MinMeetingRooms(int[,] intervals)
        {
            try
            {
                int[] startTimes = new int[intervals.GetLength(0)];//array to store start time of each meeting
                int[] endTimes = new int[intervals.GetLength(0)];  //array to store end time of each meeting
                int roomsNeeded = 1;             //roomsNeeded= Minimum number of meering rooms required(always atleast one)
                int temp_roomsNeeded = 1;   //temporary variable used
                int k = 0;
                for (int i = 0; i < intervals.GetLength(0); i++)//divide intervals into 2 arrays containing times and end times respectively
                {
                    startTimes[k] = intervals[i, 0]; //adding start times to array
                    endTimes[k] = intervals[i, 1]; //adding end times to array
                    k++;
                }

                Array.Sort(startTimes);// sort start times
                Array.Sort(endTimes);// sort end times
                int x = 1, y = 0;//start with start time of second meeting
                while (x < intervals.GetLength(0) && y < intervals.GetLength(0))
                {
                    if (startTimes[x] <= endTimes[y])//check if start time of a meeting  less than end time of another
                    {
                        temp_roomsNeeded++; //increment the number of rooms needed
                        x++;
                        if (temp_roomsNeeded > roomsNeeded)
                        {
                            roomsNeeded = temp_roomsNeeded;//assign temp value to final value of meeting rooms
                        }
                    }

                    else
                    {
                        temp_roomsNeeded--;// if meeting starts after another meeting ends no meeting room required
                        y++;
                    }
                }

                return roomsNeeded;// return the minimum number of rooms needed
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MinMeetingRooms()");
            }

            return 0;
        }


        public static int[] SortedSquares(int[] A)
        {
            try
            {
                int ALen = A.Length;
                int[] squared = new int[ALen];


                // Divides sorted array into negative and positive parts.
                int k = 0;
                for (k = 0; k < ALen; k++)
                {
                    if (A[k] >= 0)
                        break;
                }

                //We iterate through negative half in reverse.
                int i = k - 1; // first index of negative part of array.
                int j = k; // first index of positive part of array.
                int ind = 0; // Initial index of temp array  


                while (i >= 0 && j < ALen)
                {
                    if (A[i] * A[i] < A[j] * A[j])
                    {
                        squared[ind] = A[i] * A[i];
                        i--;
                    }
                    else
                    {
                        squared[ind] = A[j] * A[j];
                        j++;
                    }
                    ind++;
                }

                while (i >= 0)
                {
                    squared[ind++] = A[i] * A[i];
                    i--;
                }
                while (j < ALen)
                {
                    squared[ind++] = A[j] * A[j];
                    j++;
                }

                return squared;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing SortedSquares()");
            }

            return new int[] { };
        }

        //method to check if we can remove a character from a string to make it a palidrome
        public static bool ValidPalindrome(string s)
        {
            int flag = 0;
            try
            {
                Console.Write("\nInput is not a palindrome.Lets check if we can make it one by removing a character.\n");
                for (int i = 0; i < s.Length; i++)//iterate through the characters of the string
                {
                    string stringpart = s.Remove(i, 1);//remove a character from input string
                    if (isaPalindrome(stringpart) == 0)//check if the string is a palindrome after a character is removed
                    {
                        flag = 1;// flag is assigned 1 if after removing a character string becomes palindrome
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing ValidPalindrome()");
            }
            if (flag == 1)// check value of flag
                return true;//return true(string can be made palindrome)
            else
                return false;//return true(string can't be made palindrome)
        }
        //method to check if a string is a palindrome
        public static int isaPalindrome(string s)
        {
            int ispal = 0;
            int x = 0, y = s.Length - 1;
            while (x < y) //itterate until mid of the string is reached 
            {
                if (s[x] == s[y])// match charaters to check if string is a pallindrome
                {
                    x++;
                    y--;
                }
                else// if characters don't match assign 1 to ispal
                {
                    ispal = 1;// ispal  is one if not a palindrome
                    break;
                }
            }
            return ispal;
        }
    }
}
