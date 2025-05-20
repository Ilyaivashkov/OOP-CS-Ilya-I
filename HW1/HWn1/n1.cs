using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkVariant10
{
    /// Класс, представляющий массив и работу с ним.
    public class Massiv
    {
        private List<int> _data;

        public Massiv()
        {
            _data = new List<int>();
        }

        /// Ввод массива с клавиатуры.
        public void InputFromKeyboard(string name)
        {
            Console.WriteLine($"Введите элементы массива {name} через пробел:");
            string input = Console.ReadLine();
            _data = input.Split(' ').Select(int.Parse).ToList();
        }

        /// Вывод массива на экран.
        public void Output(string name)
        {
            Console.WriteLine($"Массив {name}: {string.Join(" ", _data)}");
        }

        /// <summary>
        /// Возвращает список элементов массива.
        /// </summary>
        public List<int> GetData()
        {
            return _data;
        }

        /// <summary>
        /// Устанавливает новый список элементов массива.
        /// </summary>
        public void SetData(List<int> newData)
        {
            _data = newData;
        }

        /// <summary>
        /// Считает, сколько элементов равны сумме между минимумом и максимумом.
        /// </summary>
        public int CountEqualToSumBetweenMinAndMax()
        {
            if (_data.Count < 3)
            {
                return 0;
            }

            int minIndex = _data.IndexOf(_data.Min());
            int maxIndex = _data.IndexOf(_data.Max());

            // Убедимся, что minIndex < maxIndex
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

            // Вычисление, сколько таких чисел есть в массиве
            return _data.Count(x => x == sum);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Исходные данные по варианту
                int variant = 10;
                int a = variant;
                int b = variant * 2;
                double c = variant / 2.0;

                // Создание объектов массивов
                Massiv arrayA = new Massiv();
                Massiv arrayB = new Massiv();

                // Ввод массивов с клавиатуры
                arrayA.InputFromKeyboard("A");
                arrayB.InputFromKeyboard("B");

                // Вывод массивов
                arrayA.Output("A");
                arrayB.Output("B");

                // Формируем массив C
                List<int> arrayCData = new List<int>();

                // Элементы из B после левого минимального
                List<int> dataB = arrayB.GetData();
                int minB = dataB.Min();
                int minIndexB = dataB.IndexOf(minB);

                if (minIndexB + 1 < dataB.Count)
                {
                    arrayCData.AddRange(dataB.GetRange(minIndexB + 1, dataB.Count - minIndexB - 1));
                }

                // Элементы из A между правым минимальным и элементом с номером варианта
                List<int> dataA = arrayA.GetData();
                int minA = dataA.Min();
                int minIndexA = dataA.LastIndexOf(minA);
                int variantIndex = Math.Min(variant, dataA.Count - 1);

                int start = Math.Min(minIndexA, variantIndex);
                int end = Math.Max(minIndexA, variantIndex);

                if (start + 1 < end)
                {
                    arrayCData.AddRange(dataA.GetRange(start + 1, end - start - 1));
                }

                // Создаем массив C и выводим
                Massiv arrayC = new Massiv();
                arrayC.SetData(arrayCData);
                arrayC.Output("C");

                // Вычисляем значение функции по формуле
                double numerator = 2 * Math.Sin(a) + 3 * b * Math.Pow(Math.Cos(c), 3);
                double denominator = a + b;
                double result = numerator / denominator;

                Console.WriteLine($"Значение функции f = {result:F4}");

                // Выполняем доп. задание для варианта 10
                int count = arrayC.CountEqualToSumBetweenMinAndMax();
                Console.WriteLine($"Количество элементов в массиве C, равных сумме между min и max: {count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ошибка: {ex.Message}");
            }
        }
    }
}
