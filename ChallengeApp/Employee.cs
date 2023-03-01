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
                Console.WriteLine($"Podany string \"{gradeText}\" nie jest prawidłową liczbą.");
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
        public Statistics GetStatisticsWithForEach()
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
        public Statistics GetStatisticsWithFor()
        {
            var stats = new Statistics();
            if (Grades.Count > 0)
            {
                for (int i = 0; i < Grades.Count; i++)
                {
                    var grade = Grades[i];

                    stats.Min = Math.Min(stats.Min, grade);
                    stats.Max = Math.Max(stats.Max, grade);
                    stats.Average += grade;
                }
                stats.Average /= Grades.Count;
            }

            return stats;
        }
        public Statistics GetStatisticsWithWhile()
        {
            var stats = new Statistics();
            if (Grades.Count > 0)
            {
                int i = 0;
                while (i < Grades.Count)
                {
                    var grade = Grades[i];

                    stats.Min = Math.Min(stats.Min, grade);
                    stats.Max = Math.Max(stats.Max, grade);
                    stats.Average += grade;

                    i++;
                }
                stats.Average /= Grades.Count;
            }

            return stats;
        }
        public Statistics GetStatisticsWithDoWhile()
        {
            var stats = new Statistics();
            if (Grades.Count > 0)
            {
                int i = 0;
                do
                {
                    var grade = Grades[i];

                    stats.Min = Math.Min(stats.Min, grade);
                    stats.Max = Math.Max(stats.Max, grade);
                    stats.Average += grade;

                    i++;
                }while(i<Grades.Count);

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
