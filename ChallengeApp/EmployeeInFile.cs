namespace ChallengeApp
{
    public class EmployeeInFile : EmployeeBase
    {
        private const string fileName = "grades.txt";
        public EmployeeInFile(string name, string lastName)
            : base(name, lastName)
        { }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    int count = 0;
                    while (line != null)
                    {
                        var grade = float.Parse(line);

                        stats.Min = Math.Min(stats.Min, grade);
                        stats.Max = Math.Max(stats.Max, grade);
                        stats.Average += grade;

                        count++;

                        line = reader.ReadLine();
                    }
                    stats.Average /= count;
                    stats.Count = count;
                }
            }
            else
            {
                throw new Exception("Grade file missing");
            }
            return stats;
        }


        public override void GiveGrade(float grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
            }
        }

        public override void GiveGrade(double grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
            }
        }

        public override void GiveGrade(int grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
            }
        }

        public override void GiveGrade(long grade)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
            }
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
    }
}
