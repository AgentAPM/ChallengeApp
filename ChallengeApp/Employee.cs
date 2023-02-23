namespace ChallengeApp
{

    class Employee
    {
        private string name;
        private string lastName;
        private int age;
        private List<int> grades;
        public Employee(string name, string lastName, int age)
        {
            this.name = name;
            this.lastName = lastName;
            this.age = age;
            this.grades = new List<int>();
        }

        public void AssignGrade(int grade)
        {
            grades.Add(grade);
        }
        public int GetScore()
        {
            return grades.Sum();
        }
        public string GetPersonals()
        {
            string summary = $"{this.name} {this.lastName}, lat {this.age}";
            return summary;
        }
    }
}
