namespace ChallengeApp
{
    public class EmployeeInMemory : EmployeeBase
    {
        public EmployeeInMemory(string name, string lastName)
            : base(name, lastName)
        { }
        private List<float> Grades { get; set; } = new List<float>();
        public override void GiveGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                Grades.Add(grade);

                EmitEventGradeAdded();
            }
            else
            {
                throw new Exception($"'{grade}' is outside the valid range");
            }
        }
        public override void GiveGrade(double grade)
        {
            var gradeAsFloat = (float)grade;
            GiveGrade(gradeAsFloat);
        }
        public override void GiveGrade(long grade)
        {
            var gradeAsFloat = (float)grade;
            GiveGrade(gradeAsFloat);
        }
        public override void GiveGrade(int grade)
        {
            var gradeAsFloat = (float)grade;
            GiveGrade(gradeAsFloat);
        }
        public override void GiveGrade(string grade)
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
        public override void GiveGrade(char gradeLetter)
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
                    throw new Exception($"'{gradeLetter}' is not a valid grade");
            }
        }
        public override Statistics GetStatistics()
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
