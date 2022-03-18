using System;

/******************************************************************************** 
 * File: Exercise1.cs                                                           *
 * Author: Yosef D. Figueroa 841-17-9954                                        *
 * Date: 02/24/2022                                                             *
 * Purpose: This application calculates the compound interest of the principal  *
 *          after the user enters the principal, annual interest rate, and      *
 *          number of years. Validates that the numbers entered are valid.      *
 * Modified: 02/17/2022                                                         *
 *********************************************************************************/
namespace ExerciseExam1
{
    class CompoundInterest
    {
        static void Main()
        {
            //Utilizes ReadDecimalMinMax to save the principal and validates it
            decimal principal = ReadDecimalMinMax("Enter the principal: $", 100.00M, 10000.00M);
            //Utilizes ReadDecimalMinMax to save the annual interest rate and validates it
            decimal annual = ReadDecimalMinMax("Enter the annual interest rate (%): ", 0.0M, 100.0M);
            //Utilizes ReadInt32MinMax to save the number of years and validates it
            int years = ReadInt32MinMax("Enter the number of years: ", 1, 20);

            Console.WriteLine();
            Console.WriteLine("Yearly account balance...\n");
            Console.WriteLine();
            Console.WriteLine($"{"Year",6} {"Amount on Deposit",17}");
            //Calls calculateAmountMethod to process the compound interest rate
            CalculateAmount(principal, annual, years);
        }
        //Method to calculate the compound interest
        static void CalculateAmount(decimal principal, decimal ann, int years)
        {
            for (int i = 0; i < years; i++)
            {
                decimal amountDeposit = principal * (decimal)Math.Pow((double)(1 + (ann / 100)), i + 1);
                Console.WriteLine($"{ i + 1,6} { amountDeposit,17:c}");
            }
        }
        //Method that reads the string entered to validate that it is a decimal
        private static decimal ReadDecimal(string numberEntered)
        {
            decimal value = 0m;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(numberEntered);
                isValid = decimal.TryParse(Console.ReadLine(), out value);
                if (!isValid)
                {
                    Console.WriteLine("\tError: Value should be a decimal.");
                }
            }
            return value;
        }
        //Method to verify that the decimal entered does not surpass the maximum value or go below the minimum value
        private static decimal ReadDecimalMinMax(string numberEntered, decimal min, decimal max)
        {
            decimal value = 0m;
            bool isValid = false;

            while (!isValid)
            {
                value = ReadDecimal(numberEntered);
                if (value < min || value > max)
                {
                    Console.WriteLine($"\tError: Value should be between {min} and {max}.");
                }
                else
                    isValid = true;
            }
            return value;
        }
        //Method to verify that the string entered is an integer
        private static int ReadInt32(string numberEntered)
        {
            int value = 0;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write(numberEntered);
                isValid = int.TryParse(Console.ReadLine(), out value);
                if (!isValid)
                {
                    Console.WriteLine("\tError: Value should be an integer.");
                }
            }
            return value;
        }
        //Method to validate that the integer provided is in the range of the minimum and the maximum
        private static int ReadInt32MinMax(string numberEntered, int min, int max)
        {
            int value = 0;
            bool isValid = false;

            while (!isValid)
            {
                value = ReadInt32(numberEntered);
                if (value < min || value > max)
                {
                    Console.WriteLine($"\tError: Value should be between {min} and {max}.");
                }
                else
                    isValid = true;
            }
            return value;
        }
    }
}


