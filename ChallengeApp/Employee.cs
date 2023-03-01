namespace ChallengeApp
{

    public class Employee
    {
        public Employee(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public List<float> Grades { get; private set; } = new List<float>();
        public void AssignGrade(float grade)
        {
            Grades.Add(grade);
        }
        public Statistics GetStatistics()
        {
            var stats = new Statistics();
            foreach (var grade in Grades)
            {
                stats.Min = Math.Min(stats.Min, grade);
                stats.Max = Math.Max(stats.Max, grade);
                stats.Average += grade;
            }
            stats.Average /= Grades.Count;

            return stats;
        }
        public string GetPersonals()
        {
            string summary = $"{this.Name} {this.LastName}";
            return summary;
        }
    }
}
