using System;

namespace Lab01_Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");

            try
            {
                StartSequence();
            
            catch (Exception ex)
            {
                Console.WriteLine("Oh no! Something went wrong: {0}", ex);
            }
            finally
            {
                Console.WriteLine("Program is complete.");
            }

            Console.ReadLine();
        }

        // Start sequence method that will be close to the bottom of the call stack where all my other methods will run in succession
        static void StartSequence()
        {
            // Ask the user for a number to define array length
            Console.Write("Please enter a number greater than 0: ");
            string userDefinedArrayLength = Console.ReadLine();
            Console.WriteLine(userDefinedArrayLength);

            // Instantiate array where user defines the length
            int[] userDefinedArray = new int[Convert.ToInt32(userDefinedArrayLength)];

            // Subsequent methods are called here for the full number game
            Populate(userDefinedArray);
            string stringifiedArray = string.Join(",", userDefinedArray); // Variable to hold array as string for console display

            Console.WriteLine("Your array size is : {0}", userDefinedArray.Length);
            Console.WriteLine("The numbers in the array are {0} ", stringifiedArray);
            Console.WriteLine("Your sum is {0}", GetSum(userDefinedArray));

        }

        // Method to populate a given array
        static int[] Populate(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Please enter number {0} of {1}: ", i + 1, array.Length);
                string userValue = Console.ReadLine();
                Console.WriteLine(userValue);
                array[i] = int.Parse(userValue);  // Stretch goal accomplished here
            }
            return array;
        }

        // Method to get the sum of
        static int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }

    }
}
