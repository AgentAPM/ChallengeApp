

namespace ChallengeApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var employee = new Employee("Jan", "Kowalski");

            Console.Clear();
            Console.WriteLine("Witamy w programie XYZ do oceny pracowników");
            Console.WriteLine("===========================================");

            while (true)
            {
                Console.WriteLine("Dodaj ocenę, lub 'end', aby podsumować:");
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }
                if (input.Length == 1)
                {
                    employee.GiveGrade(input[0]);
                }
                else
                {
                    employee.GiveGrade(input);
                }

            }
            var stats = employee.GetStatistics();
            if (employee.Grades.Count > 0)
            {
                Console.WriteLine($"Pracownik {employee.GetPersonals()} otrzymał oceny z zakresu {stats.Min} - {stats.Max}. Jego ogólna ocena to {stats.AverageLetter}.");
            }
            else
            {
                Console.WriteLine($"Pracownik {employee.GetPersonals()} nie otrzymał żadnych ocen.");
            }
            Console.WriteLine("Dziękujemy za korzystanie z programu XYZ");
            return 0;
        }
    }
}