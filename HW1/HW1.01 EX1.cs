using System;

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

    // Инкапсуляция через свойства:
    public string GetSurname() => surname;
    public string GetDepartment() => department;

    public int GetTotalWorkload()
    {
        int total = 0;
        for (int i = 0; i < 10; i++)
        {
            total += workload[i];
        }
        return total;
    }

    public double GetAverageWorkload()
    {
        return GetTotalWorkload() / 10.0;
    }

    public int GetWorkloadAt(int monthIndex)
    {
        return workload[monthIndex];
    }

    public void PrintInfo()
    {
        Console.WriteLine($"{surname}, {department}, Avg workload: {GetAverageWorkload()}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter number of teachers: ");
        int n = int.Parse(Console.ReadLine());
        Teacher[] teachers = new Teacher[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nTeacher #{i + 1}");
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Department: ");
            string department = Console.ReadLine();

            int[] workload = new int[10];
            for (int j = 0; j < 10; j++)
            {
                Console.Write($"Workload month {j + 1}: ");
                workload[j] = int.Parse(Console.ReadLine());
            }

            teachers[i] = new Teacher(surname, department, workload);
        }

        // Сортировка по фамилии (простая)
        Array.Sort(teachers, (a, b) => a.GetSurname().CompareTo(b.GetSurname()));

        Console.WriteLine("\nAll teachers (A-Z):");
        for (int i = 0; i < n; i++)
        {
            teachers[i].PrintInfo();
        }

        // Минимальная нагрузка по кафедре (упрощенно)
        Console.WriteLine("\nMinimum workload per department:");
        for (int i = 0; i < n; i++)
        {
            string dept = teachers[i].GetDepartment();
            int minLoad = teachers[i].GetTotalWorkload();

            for (int j = 0; j < n; j++)
            {
                if (i != j && teachers[j].GetDepartment() == dept)
                {
                    int otherLoad = teachers[j].GetTotalWorkload();
                    if (otherLoad < minLoad)
                        minLoad = otherLoad;
                }
            }

            bool alreadyPrinted = false;
            for (int k = 0; k < i; k++)
            {
                if (teachers[k].GetDepartment() == dept)
                {
                    alreadyPrinted = true;
                    break;
                }
            }

            if (!alreadyPrinted)
                Console.WriteLine($"{dept}: {minLoad} hours");
        }

        // Средняя нагрузка по университету
        double universityAverage = 0;
        for (int i = 0; i < n; i++)
        {
            universityAverage += teachers[i].GetAverageWorkload();
        }
        universityAverage /= n;

        Console.WriteLine("\nTeachers with above-university average workload:");
        bool found = false;
        for (int i = 0; i < n; i++)
        {
            if (teachers[i].GetAverageWorkload() > universityAverage)
            {
                teachers[i].PrintInfo();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No such teachers.");
        }
    }
}
