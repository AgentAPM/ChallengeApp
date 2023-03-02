namespace ChallengeApp
{

    public class Employee : IEmployee
    {
        public Employee(string name, string lastName) { 
            Name = name;
            LastName = lastName;
        }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Personals
        {
            get
            {
                return $"{this.Name} {this.LastName}";
            }
        }
        private List<float> Grades { get; set; } = new List<float>();
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
        public void GiveGrade(string grade)
        {
            if (float.TryParse(grade, out float gradeAsFloat))
            {
                GiveGrade(gradeAsFloat);
            }
            else
            {
                throw new Exception($"Failed to parse \"{grade}\" into a float");
            }
        }
        public void GiveGrade(char gradeLetter)
        {

            switch (gradeLetter)
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
                    throw new Exception($"'{gradeLetter}' is not a valie grade");
            }
        }
        public Statistics GetStatistics()
        {
            var stats = new Statistics();
            stats.Count = Grades.Count;
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
    }
}
