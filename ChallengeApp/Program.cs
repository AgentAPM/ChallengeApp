/// Napisz w Program.cs kod, który:
/// - zadeklarujesz zmienną z imieniem
/// zmienną z płcią
/// zmienną z wiekiem
/// zweryfikujesz dane i wyświetlisz jeden z komunikatów
/// "Kobieta poniżej 30 lat"
/// "Ewa, lat 33"
/// "Niepełnoletni mężczyzna"

string name = "Maciej";
string gender = "male";
int age = 23;

Console.WriteLine("Podaj imię");
name = Console.ReadLine();
Console.WriteLine("Podaj płeć (male/female/...)");
gender = Console.ReadLine();
Console.WriteLine("Podaj wiek");
age = int.Parse(Console.ReadLine());

if (gender == "female" && age < 30) Console.WriteLine("Kobieta poniżej 30 lat");
if (name == "Ewa" && age == 33) Console.WriteLine("Ewa, lat 30");
if (gender == "male" && age < 18) Console.WriteLine("Niepełnoletni mężczyzna");