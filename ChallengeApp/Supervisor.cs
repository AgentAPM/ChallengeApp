namespace ChallengeApp
{
    public class Supervisor : IEmployee
    {
        public Supervisor(string name, string lastName)
        {
            this.Name = name;
            this.LastName = lastName;
        }
        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string Personals
        {
            get
            {
                return $"spv. {this.Name} {this.LastName}";
            }
        }
        private List<float> Grades { get; set; } = new List<float>();

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
            switch (grade)
            {
                case "6":
                    GiveGrade(100);
                    break;
                case "-6":
                case "6-":
                    GiveGrade(95);
                    break;
                case "+5":
                case "5+":
                    GiveGrade(85);
                    break;
                case "5":
                    GiveGrade(80);
                    break;
                case "-5":
                case "5-":
                    GiveGrade(75);
                    break;
                case "+4":
                case "4+":
                    GiveGrade(65);
                    break;
                case "4":
                    GiveGrade(60);
                    break;
                case "-4":
                case "4-":
                    GiveGrade(55);
                    break;
                case "+3":
                case "3+":
                    GiveGrade(45);
                    break;
                case "3":
                    GiveGrade(40);
                    break;
                case "-3":
                case "3-":
                    GiveGrade(35);
                    break;
                case "+2":
                case "2+":
                    GiveGrade(25);
                    break;
                case "2":
                    GiveGrade(20);
                    break;
                case "-2":
                case "2-":
                    GiveGrade(15);
                    break;
                case "+1":
                case "1+":
                    GiveGrade(5);
                    break;
                case "1":
                    GiveGrade(0);
                    break;
                default:
                    if (float.TryParse(grade, out float gradeAsFloat))
                    {
                        GiveGrade(gradeAsFloat);
                    }
                    else
                    {
                        throw new Exception($"Failed to parse \"{grade}\" into a float");
                    }
                    break;

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
    }
}
