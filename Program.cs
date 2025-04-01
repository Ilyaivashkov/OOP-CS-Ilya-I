using System;
using System.Linq;

class Teacher
{
    private string surname;
    private string department;
    private int[] workload;

    public Teacher(string surname, string department, int[] workload)
    {
        this.surname = surname;
        this.department = department;
        this.workload = new int[10];
        for (int i = 0; i < 10; i++)
        {
            this.workload[i] = workload[i];
        }
    }

    public string GetSurname()
    {
        return surname;
    }

    public string GetDepartment()
    {
        return department;
    }

    public int GetTotalWorkload()
    {
        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += workload[i];
        }
        return sum;
    }

    public double GetAverageWorkload()
    {
        return GetTotalWorkload() / 10.0;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of teachers:");
        int n = int.Parse(Console.ReadLine());
        Teacher[] teachers = new Teacher[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter the teacher's last name:");
            string surname = Console.ReadLine();
            Console.Write("Enter the department:");
            string department = Console.ReadLine();
            int[] workload = new int[10];
            Console.WriteLine("Use the load for 10 months:");
            for (int j = 0; j < 10; j++)
            {
                workload[j] = int.Parse(Console.ReadLine());
            }
            teachers[i] = new Teacher(surname, department, workload);
        }

        Array.Sort(teachers, (a, b) => a.GetSurname().CompareTo(b.GetSurname()));
        Console.WriteLine("\nList of teachers A-Z:");
        foreach (var teacher in teachers)
        {
            Console.WriteLine(teacher.GetSurname());
        }

        string[] departments = new string[n];
        int[] minWorkloads = new int[n];
        int departmentCount = 0;

        for (int i = 0; i < n; i++)
        {
            string dept = teachers[i].GetDepartment();
            int totalLoad = teachers[i].GetTotalWorkload();
            bool found = false;
            for (int j = 0; j < departmentCount; j++)
            {
                if (departments[j] == dept)
                {
                    if (totalLoad < minWorkloads[j])
                    {
                        minWorkloads[j] = totalLoad;
                    }
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                departments[departmentCount] = dept;
                minWorkloads[departmentCount] = totalLoad;
                departmentCount++;
            }
        }

        Console.WriteLine("\nMinimum load by department:");
        for (int i = 0; i < departmentCount; i++)
        {
            Console.WriteLine($"Department: {departments[i]}, Minimum load: {minWorkloads[i]} hours");
        }

        double universityAverage = 0;
        for (int i = 0; i < n; i++)
        {
            universityAverage += teachers[i].GetAverageWorkload();
        }
        universityAverage /= n;

        Console.WriteLine("\nTeachers with a workload above the university average:");
        bool foundTeacher = false;
        for (int i = 0; i < n; i++)
        {
            if (teachers[i].GetAverageWorkload() > universityAverage)
            {
                Console.WriteLine($"{teachers[i].GetSurname()}, Average load: {teachers[i].GetAverageWorkload()} hours");
                foundTeacher = true;
            }
        }
        if (!foundTeacher)
        {
            Console.WriteLine("No Teachers");
        }
    }
}
