using System;
using System.Linq;

namespace University
{
    /// <summary>
    /// Represents a university teacher and their workload over 10 months.
    /// </summary>
    public class Teacher
    {
        private string _surname;
        private string _department;
        private int[] _workload = new int[10];

        /// <summary>
        /// Initializes a new teacher with surname, department and monthly workload.
        /// </summary>
        public Teacher(string surname, string department, int[] workload)
        {
            _surname = surname;
            _department = department;

            for (int i = 0; i < 10; i++)
            {
                _workload[i] = workload[i];
            }
        }

        /// <summary>
        /// Gets the surname of the teacher.
        /// </summary>
        public string Surname => _surname;

        /// <summary>
        /// Gets the department name.
        /// </summary>
        public string Department => _department;

        /// <summary>
        /// Gets the total workload over 10 months.
        /// </summary>
        public int TotalWorkload => _workload.Sum();

        /// <summary>
        /// Gets the average monthly workload.
        /// </summary>
        public double AverageWorkload => _workload.Average();

        /// <summary>
        /// Indexer to access workload for a specific month (0 to 9).
        /// </summary>
        public int this[int month]
        {
            get => _workload[month];
            set => _workload[month] = value;
        }
    }
}
