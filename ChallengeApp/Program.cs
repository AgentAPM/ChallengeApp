

namespace ChallengeApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            EmployeeBase employee = new EmployeeInMemory("Jan", "Kowalski");

            employee.GradeAdded += (sender, e) =>
            {
                Console.WriteLine("Przyznano ocenę");
            };

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
                try
                {
                    if (input.Length == 1)
                    {
                        employee.GiveGrade(input[0]);
                    }
                    else
                    {
                        employee.GiveGrade(input);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            var stats = employee.GetStatistics();
            if (stats.Count > 0)
            {
                Console.WriteLine($"Pracownik {employee.Personals} otrzymał oceny z zakresu {stats.Min} - {stats.Max}. Jego ogólna ocena to {stats.AverageLetter}.");
            }
            else
            {
                Console.WriteLine($"Pracownik {employee.Personals} nie otrzymał żadnych ocen.");
            }
            Console.WriteLine("Dziękujemy za korzystanie z programu XYZ");
            return 0;
        }

    }
}