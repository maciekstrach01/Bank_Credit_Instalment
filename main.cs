using System;

namespace InstalmentCreditCalculator
{
    class Program
    {
        static double GetValidDoubleInput(string prompt, double minValue, double maxValue)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string userInput = Console.ReadLine();
                    double result = double.Parse(userInput);

                    if (result < minValue || result > maxValue)
                        throw new ArgumentOutOfRangeException();

                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Input out of range. Please enter a number between {minValue} and {maxValue}.");
                }
            }
        }

        static int GetValidIntInput(string prompt, int minValue, int maxValue)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string userInput = Console.ReadLine();
                    int result = int.Parse(userInput);

                    if (result < minValue || result > maxValue)
                        throw new ArgumentOutOfRangeException();

                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Input out of range. Please enter an integer between {minValue} and {maxValue}.");
                }
            }
        }

        static void Main(string[] args)
        {
            double minLoanAmount = 10000;
            double maxLoanAmount = 100000;
            int minNumberOfRates = 6;
            int maxNumberOfRates = 96;

            double loanamount = GetValidDoubleInput($"Specify the loan amount ({minLoanAmount} to {maxLoanAmount} PLN): ", minLoanAmount, maxLoanAmount);
            int numberofrates = GetValidIntInput($"Enter the number of instalments ({minNumberOfRates} to {maxNumberOfRates}): ", minNumberOfRates, maxNumberOfRates);

            double rate = 0.05;
            double interests = loanamount * rate;
            double instalmentamount = (loanamount + interests) / numberofrates;

            Console.WriteLine($"The monthly loan instalment is: {instalmentamount:N2} PLN.");
        }
    }
}

