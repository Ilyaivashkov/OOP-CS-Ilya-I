using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkVariant10
{
    /// <summary>
    /// A class that represents an integer array and basic operations on it.
    /// </summary>
    public class Massiv
    {
        private List<int> _data;

        public Massiv()
        {
            _data = new List<int>();
        }

        /// <summary>
        /// Reads the array from keyboard input.
        /// </summary>
        /// <param name="name">The name of the array (A, B or C).</param>
        public void InputFromKeyboard(string name)
        {
            Console.Write($"Enter the elements of array {name} separated by spaces: ");
            string input = Console.ReadLine();

            try
            {
                string[] parts = input.Split(' ');
                List<int> numbers = new List<int>();

                foreach (string part in parts)
                {
                    int number = int.Parse(part);
                    numbers.Add(number);
                }

                _data = numbers;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Input must contain only integers.");
                _data = new List<int>();
            }
        }

        /// <summary>
        /// Prints the array to the console.
        /// </summary>
        /// <param name="name">The name of the array.</param>
        public void Output(string name)
        {
            string joinedData = string.Join(" ", _data);
            Console.WriteLine($"Array {name}: {joinedData}");
        }

        /// <summary>
        /// Returns the list of array elements.
        /// </summary>
        public List<int> GetData()
        {
            return _data;
        }

        /// <summary>
        /// Sets the array elements to a new list.
        /// </summary>
        public void SetData(List<int> newData)
        {
            _data = newData;
        }

        /// <summary>
        /// Counts how many elements are equal to the sum of numbers between min and max.
        /// </summary>
        public int CountEqualToSumBetweenMinAndMax()
        {
            if (_data.Count < 3)
            {
                return 0;
            }

            int min = _data.Min();
            int max = _data.Max();

            int minIndex = _data.IndexOf(min);
            int maxIndex = _data.IndexOf(max);

            if (minIndex > maxIndex)
            {
                int temp = minIndex;
                minIndex = maxIndex;
                maxIndex = temp;
            }

            int sum = 0;
            for (int i = minIndex + 1; i < maxIndex; i++)
            {
                sum += _data[i];
            }

            int count = 0;
            foreach (int item in _data)
            {
                if (item == sum)
                {
                    count++;
                }
            }

            return count;
        }
    }

    /// <summary>
    /// The main class of the program. Contains the Main method to execute Variant 10 logic.
    /// </summary>
    internal class Program
    {
        private const int Variant = 10;
        private const int MultiplierA = 2;
        private const int MultiplierB = 3;
        private const int CosinePower = 3;

        private static void Main()
        {
            try
            {
                // Calculate variant-specific values
                int a = Variant;
                int b = Variant * 2;
                double c = Variant / 2.0;

                // Create and fill arrays A and B
                Massiv arrayA = new Massiv();
                Massiv arrayB = new Massiv();

                arrayA.InputFromKeyboard("A");
                arrayB.InputFromKeyboard("B");

                arrayA.Output("A");
                arrayB.Output("B");

                // Form array C based on rules
                List<int> arrayCData = new List<int>();

                // Elements from B after the first minimum
                List<int> dataB = arrayB.GetData();
                int minB = dataB.Min();
                int minIndexB = dataB.IndexOf(minB);

                for (int i = minIndexB + 1; i < dataB.Count; i++)
                {
                    arrayCData.Add(dataB[i]);
                }

                // Elements from A between last minimum and variant index
                List<int> dataA = arrayA.GetData();
                int minA = dataA.Min();
                int minIndexA = dataA.LastIndexOf(minA);
                int variantIndex = Math.Min(Variant, dataA.Count - 1);

                int start = Math.Min(minIndexA, variantIndex);
                int end = Math.Max(minIndexA, variantIndex);

                for (int i = start + 1; i < end; i++)
                {
                    arrayCData.Add(dataA[i]);
                }

                // Create array C and print it
                Massiv arrayC = new Massiv();
                arrayC.SetData(arrayCData);
                arrayC.Output("C");

                // Calculate the function value
                double numerator = MultiplierA * Math.Sin(a) + MultiplierB * b * Math.Pow(Math.Cos(c), CosinePower);
                double denominator = a + b;
                double result = numerator / denominator;

                Console.WriteLine($"Function value f = {result:F4}");

                // Count elements equal to the sum between min and max
                int count = arrayC.CountEqualToSumBetweenMinAndMax();
                Console.WriteLine($"Number of elements in array C equal to the sum between min and max: {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
