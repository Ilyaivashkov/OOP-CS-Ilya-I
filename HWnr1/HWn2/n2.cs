using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    class Teacher
    {
        private string surname;
        private string department;
        private int[] workload = new int[10];

        public Teacher(string surname, string department, int[] workload)
        {
            this.surname = surname;
            this.department = department;
            for (int i = 0; i < 10; i++)
            {
                this.workload[i] = workload[i];
            }
        }

        // Свойства
        public string Surname => surname;
        public string Department => department;
        public int TotalWorkload => workload.Sum();
        public double AverageWorkload => workload.Average();

        // Индексатор
        public int this[int month]
        {
            get => workload[month];
            set => workload[month] = value;
        }
    }

    static class Program
    {
        static void Main()
        {
            Console.Write("Enter the number of teachers: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Invalid input. Try again.");
            }

            List<Teacher> teachers = new List<Teacher>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nTeacher #{i + 1}:");

                Console.Write("Surname: ");
                string surname = Console.ReadLine();

                Console.Write("Department: ");
                string department = Console.ReadLine();

                int[] workload = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"Workload for month {j + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out workload[j]) || workload[j] < 0)
                    {
                        Console.WriteLine("Invalid input. Enter a non-negative number.");
                    }
                }

                teachers.Add(new Teacher(surname, department, workload));
            }

            // Сортировка и вывод
            Console.WriteLine("\nTeachers (A-Z):");
            foreach (var teacher in teachers.OrderBy(t => t.Surname))
            {
                Console.WriteLine(teacher.Surname);
            }

            // Минимальная нагрузка по кафедрам
            var minByDept = teachers
                .GroupBy(t => t.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    MinLoad = g.Min(t => t.TotalWorkload)
                });

            Console.WriteLine("\nMinimum total workload by department:");
            foreach (var dept in minByDept)
            {
                Console.WriteLine($"Department: {dept.Department}, Min workload: {dept.MinLoad} hours");
            }

            // Средняя нагрузка по университету
            double universityAverage = teachers.Average(t => t.AverageWorkload);

            Console.WriteLine("\nTeachers with above-average monthly workload:");
            var aboveAverage = teachers
                .Where(t => t.AverageWorkload > universityAverage)
                .ToList();

            if (aboveAverage.Count == 0)
            {
                Console.WriteLine("No such teachers.");
            }
            else
            {
                foreach (var teacher in aboveAverage)
                {
                    Console.WriteLine($"{teacher.Surname}, Avg workload: {teacher.AverageWorkload:F2} hours");
                }
            }
        }
    }
}
