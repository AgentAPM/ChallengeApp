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
        public void GiveGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);
            }
            else
            {
                Console.WriteLine($"Podana ocena {grade} nie jest w przedziale 0-100.");
            }
        }
        public void GiveGrade(double grade)
        {
            var gradeFloat = (float)grade;
            GiveGrade(gradeFloat);
        }
        public void GiveGrade(long grade)
        {
            var gradeFloat = (float)grade;
            GiveGrade(gradeFloat);
        }
        public void GiveGrade(int grade)
        {
            var gradeFloat = (float)grade;
            GiveGrade(gradeFloat);
        }
        public void GiveGrade(string gradeText)
        {
            if (float.TryParse(gradeText, out float grade))
            {
                this.GiveGrade(grade);
            }
            else
            {
                Console.WriteLine($"Podany string \"{grade}\" nie jest prawidłową liczbą.");
            }
        }
        public Statistics GetStatistics()
        {
            var stats = new Statistics();
            if (Grades.Count > 0)
            {
                foreach (var grade in Grades)
                {
                    stats.Min = Math.Min(stats.Min, grade);
                    stats.Max = Math.Max(stats.Max, grade);
                    stats.Average += grade;
                }
                stats.Average /= Grades.Count;
            }

            return stats;
        }
        public string GetPersonals()
        {
            string summary = $"{this.Name} {this.LastName}";
            return summary;
        }
    }
}
