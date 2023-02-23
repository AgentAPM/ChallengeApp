using ChallengeApp;

Employee pearson1 = new Employee("Jan", "Kowalski", 31);
Employee pearson2 = new Employee("Anna", "Nowak", 27);
Employee pearson3 = new Employee("Mariusz", "Oberża", 42);

pearson1.AssignGrade(6);
pearson1.AssignGrade(8);
pearson1.AssignGrade(7);
pearson1.AssignGrade(6);
pearson1.AssignGrade(8);

pearson2.AssignGrade(10);
pearson2.AssignGrade(7);
pearson2.AssignGrade(8);
pearson2.AssignGrade(10);
pearson2.AssignGrade(8);

pearson3.AssignGrade(3);
pearson3.AssignGrade(10);
pearson3.AssignGrade(7);
pearson3.AssignGrade(8);
pearson3.AssignGrade(7);

List<Employee> people = new List<Employee>() { pearson1, pearson2, pearson3 };

int bestScore = -1;
Employee bestEmployee = null;
foreach (Employee e in people)
{
    int score = e.GetScore();
    if (score > bestScore)
    {
        bestEmployee = e;
        bestScore = score;
    }
}

Console.WriteLine($"Najwyższy wynik, czyli {bestScore} ma {bestEmployee.GetPersonals()}.");