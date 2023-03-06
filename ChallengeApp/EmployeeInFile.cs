using System.Runtime.Serialization;

namespace ChallengeApp
{
    public class EmployeeInFile : EmployeeBase
    {
        private readonly string fileName;
        public EmployeeInFile(string name, string lastName, string filename)
            : base(name, lastName)
        {
            fileName = filename;
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics();
            if (File.Exists(fileName))
            {
                using (var reader = File.OpenText(fileName))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var grade = float.Parse(line);

                        stats.AddGrade(grade);
                    }
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

            EmitEventGradeAdded();
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
