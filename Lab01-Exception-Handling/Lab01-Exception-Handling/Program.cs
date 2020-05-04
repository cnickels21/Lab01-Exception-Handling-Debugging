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

        static void StartSequence()
        {
            Console.Write("Please enter a number greater than 0: ");
            string userDefinedArrayLength = Console.ReadLine();
            Console.Write(userDefinedArrayLength);
        }

    }
}
