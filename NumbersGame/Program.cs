using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }

            catch
            {
                Console.WriteLine("Oops, Something is Wrong!!");
            }

            finally
            {
                Console.WriteLine("Program is complete");
            }
        }

        static void StartSequence()
        {
            try
            {
                Console.WriteLine("Welcome to my game! Let's do some math!");
                Console.WriteLine("Enter a number greater than zero ");
                //Convert user input to an integer 
                int arrLngth = Convert.ToInt32(Console.ReadLine());

                while (true)
                {
                    if (arrLngth < 0)
                    {
                        Console.WriteLine("The Number is lees than 0 Please enter number grater than 0");
                        arrLngth = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }
                int[] numArray = new int[arrLngth];
                int[] result = Populate(numArray);
                int sum = GetSum(result);
                int product = GetProduct(numArray, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine($"Your array is size {arrLngth}");
                Console.Write($"The numbers in the array are: ");
                for (int i = 0; i < result.Length - 1; i++)
                {
                    Console.Write($"{result[i]},");
                }
                Console.WriteLine(result[result.Length - 1]);
                Console.WriteLine($"The sum of the array is {sum}");
                Console.WriteLine($"{sum} * {(product / sum)} = {product}");
                Console.WriteLine($"{product} / {product / quotient} = {quotient}");
            }
            catch (FormatException e) // if user enter non-number
            {
                Console.WriteLine("Oops, wrong " + e.Message);
            }

        }
        static int[] Populate(int[] array)
        {
            //Iterate through the array, prompting the user for input each time
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Please enter a number ({i + 1} of {array.Length}): ");

                //Convert user input to an integer 
                string input = Console.ReadLine();

                //Add the number to the array
                array[i] = Convert.ToInt32(input);
            }
            //Return the populated array
            return array;
        }
        static int GetSum(int[] array)
        {
            int sum = 0;
            foreach (int num in array)
            {
                sum += num;
            }
            //if the sum is less than 20, throw an exception
            /* 
             * Throw exception *

             the flow of execution of the program is stopped and the control is transferred to the 
             nearest enclosing try-catch block that matches the type of exception thrown
             */
            if (sum < 20) throw new Exception($"Value of {sum} is too low");

            //return sum
            return sum;
        }

        static int GetProduct(int[] array , int sum)
        {

            Console.WriteLine($"Please select a random number between 1 and {array.Length} : ");
            // Prompt the user to enter a number to multiply 
            //Convert user input to an integer 
            int index = Convert.ToInt32(Console.ReadLine());
            int product;

            // Multiply sum by the random number index
            if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException($"{index + 1} is not a number between 1 and {array.Length}!");
            }
            else {
                product = sum * array[index-1]; 
            }
            // Return the product variable.
            return product;
        }
        static decimal GetQuotient(int product)
        {
            decimal quotient;
             // Prompt the user to enter a number to divide 
             Console.WriteLine($"Enter a number to divide {product} by: ");

             //Convert user input to an decimal 
             decimal divisor = Convert.ToDecimal(Console.ReadLine());

             //divide the product by the inputted number
             try
             {
                 quotient = Decimal.Divide(product, divisor);
             }
             catch (DivideByZeroException e) 
             {
                 Console.WriteLine("You divided by 0...!");
                 return 0;
             }
             return quotient;          

        }
    }
}
