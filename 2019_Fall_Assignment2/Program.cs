using System;

namespace _2019_Fall_Assignment2
{
    class Program
    {
        public static void Main(string[] args)
        { //test comment
            int target = 5;
            int[] nums = { 1, 3, 5, 6 };
            Console.WriteLine("Position to insert {0} is = {1}\n", target, SearchInsert(nums, target));

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
            if (isaPalindrome(s) == 0)
            {
                Console.Write("\nInput "+s+" is a palindrome");

            }
            else
            {
                if (ValidPalindrome(s))
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
            foreach(int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static void Display2DArray(int[,] a)
        {
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
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
                // Write your code here
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
                // Write your code here
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
                // Write your code here
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
                // Write your code here
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
                // Write your code here
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
                        startTimes[k] = intervals[i,0]; //adding start times to array
                        endTimes[k] = intervals[i,1]; //adding end times to array
                        k++;
                }
                
                Array.Sort(startTimes);// sort start times
                Array.Sort(endTimes);// sort end times
                int x = 1, y = 0;//start with start time of second meeting
                while(x< intervals.GetLength(0) && y< intervals.GetLength(0))
                {
                    if (startTimes[x]<=endTimes[y])//check if start time of a meeting  less than end time of another
                    {
                        temp_roomsNeeded++; //increment the number of rooms needed
                        x++;
                        if(temp_roomsNeeded> roomsNeeded)
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
                // Write your code here
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
                            flag=1;// flag is assigned 1 if after removing a character string becomes palindrome
                            break;
                        }
                    }
             }
            catch
    {
        Console.WriteLine("Exception occured while computing ValidPalindrome()");
    }
            if (flag==1)// check value of flag
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
                    ispal = 1;
                    break;
                }
            }  
            return ispal;
        }
    }
}
