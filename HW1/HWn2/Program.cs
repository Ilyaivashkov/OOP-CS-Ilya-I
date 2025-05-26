using System;
using System.Collections.Generic;
using System.Linq;

namespace University
{
    /// <summary>
    /// Main program class for managing teacher data and workload analysis.
    /// </summary>
    internal class Program
    {
        // Constants (instead of magic numbers)
        private readonly int _monthsPerYear = 10;
        private readonly int _minTeacherCount = 1;
        private readonly int _minMonthlyWorkload = 0;

        private List<Teacher> _teachers = new List<Teacher>();

        /// <summary>
        /// Entry point. Only static method required by C#.
        /// </summary>
        public static void Main()
        {
            Program program = new Program();
            program.Run();
        }

        /// <summary>
        /// Starts the full program flow: input, sorting, analysis.
        /// </summary>
        public void Run()
        {
            ReadTeachersFromInput();
            PrintTeachersAlphabetically();
            PrintMinimumWorkloadByDepartment();
            PrintAboveAverageWorkloadTeachers();
        }

        /// <summary>
        /// Reads teacher data from user input.
        /// </summary>
        private void ReadTeachersFromInput()
        {
            Console.Write("Enter the number of teachers: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n < _minTeacherCount)
            {
                Console.WriteLine("Invalid input. Try again.");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nTeacher #{i + 1}:");

                Console.Write("Surname: ");
                string surname = Console.ReadLine();

                Console.Write("Department: ");
                string department = Console.ReadLine();

                int[] workload = new int[_monthsPerYear];

                for (int j = 0; j < _monthsPerYear; j++)
                {
                    Console.Write($"Workload for month {j + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out workload[j]) || workload[j] < _minMonthlyWorkload)
                    {
                        Console.WriteLine("Invalid input. Enter a non-negative number.");
                    }
                }

                Teacher teacher = new Teacher(surname, department, workload);
                _teachers.Add(teacher);
            }
        }

        /// <summary>
        /// Prints all teachers in alphabetical order by surname.
        /// </summary>
        private void PrintTeachersAlphabetically()
        {
            Console.WriteLine("\nTeachers (A-Z):");

            List<Teacher> sorted = _teachers.OrderBy(t => t.Surname).ToList();

            foreach (Teacher teacher in sorted)
            {
                string name = teacher.Surname;
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Prints the minimum total workload per department.
        /// </summary>
        private void PrintMinimumWorkloadByDepartment()
        {
            Console.WriteLine("\nMinimum total workload by department:");

            IEnumerable<IGrouping<string, Teacher>> grouped = _teachers.GroupBy(t => t.Department);

            foreach (IGrouping<string, Teacher> group in grouped)
            {
                string department = group.Key;
                int minWorkload = int.MaxValue;

                foreach (Teacher teacher in group)
                {
                    int total = teacher.TotalWorkload;
                    if (total < minWorkload)
                    {
                        minWorkload = total;
                    }
                }

                Console.WriteLine("Department: " + department + ", Min workload: " + minWorkload + " hours");
            }
        }

        /// <summary>
        /// Prints the teachers whose average workload is above the university average.
        /// </summary>
        private void PrintAboveAverageWorkloadTeachers()
        {
            double universityAverage = _teachers.Average(t => t.AverageWorkload);

            Console.WriteLine("\nTeachers with above-average monthly workload:");

            List<Teacher> aboveAverage = new List<Teacher>();

            foreach (Teacher teacher in _teachers)
            {
                double avg = teacher.AverageWorkload;
                if (avg > universityAverage)
                {
                    aboveAverage.Add(teacher);
                }
            }

            if (aboveAverage.Count == 0)
            {
                Console.WriteLine("No such teachers.");
            }
            else
            {
                foreach (Teacher teacher in aboveAverage)
                {
                    string name = teacher.Surname;
                    double avg = teacher.AverageWorkload;
                    Console.WriteLine(name + ", Avg workload: " + avg.ToString("F2") + " hours");
                }
            }
        }
    }
}
