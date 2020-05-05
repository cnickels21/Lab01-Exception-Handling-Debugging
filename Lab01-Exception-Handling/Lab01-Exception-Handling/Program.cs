using System;

namespace Lab01_Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my game! Let's do some math!");

            StartSequence();

            Console.ReadLine();
        }

        // Start sequence method that will be close to the bottom of the call stack where all my other methods will run in succession
        static void StartSequence()
        {
            Console.Write("Please enter a number greater than 0: ");
            string userDefinedArrayLength = Console.ReadLine();
            int[] userDefinedArray = new int[Convert.ToInt32(userDefinedArrayLength)];

            Populate(userDefinedArray);
            Console.WriteLine(string.Join(",", userDefinedArray));

        }

        static int[] Populate(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Please enter number {0} of {1}: ", i + 1, array.Length);
                string userValue = Console.ReadLine();
                Console.WriteLine(userValue);
                array[i] = int.Parse(userValue);
            }
            return array;
        }

    }
}
