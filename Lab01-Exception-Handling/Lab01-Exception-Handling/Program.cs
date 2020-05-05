using System;
using System.Runtime.InteropServices.WindowsRuntime;

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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oh no! Something went wrong: {0}", ex.Message);
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
            try
            {
                // Ask the user for a number to define array length
                Console.Write("Please enter a number greater than 0: ");
                string userDefinedArrayLength = Console.ReadLine();
                Console.WriteLine(userDefinedArrayLength);

                // Instantiate array where user defines the length
                int[] userDefinedArray = new int[Convert.ToInt32(userDefinedArrayLength)];

                // Subsequent methods are called here for the full number game
                Populate(userDefinedArray);

                // Variables to capture the return integers for displaying in console
                int sum = GetSum(userDefinedArray);
                int product = GetProduct(userDefinedArray, sum);
                decimal quotient = GetQuotient(product);

                // These variables are for capturing specific numbers for console display
                int dividendOfProduct = product / sum;
                decimal userDividendForQuotient = product / quotient;

                // Variable to hold array as string for console display
                string stringifiedArray = string.Join(",", userDefinedArray);

                // Displaying all results after user prompts are done
                Console.WriteLine("Your array size is : {0}", userDefinedArray.Length);
                Console.WriteLine("The numbers in the array are {0} ", stringifiedArray);
                Console.WriteLine("Your sum is {0}", sum);
                Console.WriteLine("{0} * {1} = {2}", sum, dividendOfProduct, product);
                Console.WriteLine("{0} / {1} = {2}", product, userDividendForQuotient, quotient);
            }
            catch (FormatException fex)
            {
                Console.WriteLine("FOOORRRMAT: {0}", fex.Message);
            }
            catch (OverflowException oex)
            {
                Console.WriteLine("That number is out of bounds {0}", oex.Message);
            }

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

        // Method to get the sum of a given array
        static int GetSum(int[] array)
        {
            int sum = 0;

            try
            {
                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }
                ValidateSum(sum);  // Method defined below for checking size of value
            }
            catch (Exception ex)  // Exception is thrown if ValidateSum comes back as true
            {
                Console.WriteLine("Value of {0} is too low: {1}", sum, ex);
            }
            
            return sum;
        }

        // Custom exception handler for GetSum method
        static void ValidateSum(int sum)
        {
            if (sum < 20)
                throw new Exception(sum.ToString());
            
        }

        // Product method defined here
        static int GetProduct(int[] array, int sum)
        {
            Console.WriteLine("Please elect a number between 1 and {0}", array.Length);
            int dealersChoice = int.Parse(Console.ReadLine());
            int actualIndex = dealersChoice - 1;

            try
            {
                int product = array[actualIndex] * sum;
                return product;
            }
            catch (IndexOutOfRangeException iex)
            {
                Console.WriteLine("The product is out of range: {0}", iex);
                throw;
            }
        }

        // Quotient method defined
        static decimal GetQuotient(int product)
        {
            Console.WriteLine("Please enter a number to divide {0} by: ", product);
            int dealersDividend = int.Parse(Console.ReadLine());

            try
            {
                int quotient = product / dealersDividend;
                return quotient;
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine("Cannot divide by 0: {0}", dex);
                return 0;
            }
        }


    }
}
