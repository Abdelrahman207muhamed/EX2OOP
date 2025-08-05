using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX2OOP
{
    public static class Helper_methods
    {
        // Method to get a valid string input from the user
        public static string GetValidStringInput(string Inp)
        {
            Console.Write(Inp);
            string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write("Please enter a valid non-empty text: ");
                input = Console.ReadLine();
            }
            return input.Trim();
        }

        // Method to get a valid integer input from the user within a specified range
        public static int GetValidIntInput(int minValue, int maxValue, string prompt)
        {
            Console.Write(prompt);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < minValue || input > maxValue)
            {
                Console.Write($"Please enter a number between {minValue} and {maxValue}: ");
            }
            return input;
        }
        // Method to get a valid integer input from the user with a minimum value
        public static int GetValidIntInput(int minValue, string prompt)
        {
            Console.Write(prompt);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input < minValue)
            {
                Console.Write($"Please enter a number greater than or equal to {minValue}: ");
            }
            return input;
        }
    }
}
