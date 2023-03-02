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
                throw new Exception($"'{grade}' is outside the valid range");
            }
        }
        public void GiveGrade(double grade)
        {
            var gradeAsFloat = (float)grade;
            GiveGrade(gradeAsFloat);
        }
        public void GiveGrade(long grade)
        {
            var gradeAsFloat = (float)grade;
            GiveGrade(gradeAsFloat);
        }
        public void GiveGrade(int grade)
        {
            var gradeAsFloat = (float)grade;
            GiveGrade(gradeAsFloat);
        }
        public void GiveGrade(string gradeText)
        {
            if (float.TryParse(gradeText, out float gradeAsFloat))
            {
                this.GiveGrade(gradeAsFloat);
            }
            else
            {
                throw new Exception($"Failed to parse \"{gradeText}\" into a float");
            }
        }
        public void GiveGrade(char grade)
        {

            switch(grade)
            {
                case 'A':
                case 'a':
                    GiveGrade(100);
                    break;
                case 'B':
                case 'b':
                    GiveGrade(80);
                    break;
                case 'C':
                case 'c':
                    GiveGrade(60);
                    break;
                case 'D':
                case 'd':
                    GiveGrade(40);
                    break;
                case 'E':
                case 'e':
                    GiveGrade(20);
                    break;
                case 'F':
                case 'f':
                    GiveGrade(0);
                    break;
                default:
                    throw new Exception($"'{grade}' is not a valie grade");
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
