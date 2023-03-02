namespace ChallengeApp
{
    public interface IEmployee
    {
        string Name { get; }
        string LastName { get; }
        string Personals { get; }
        void GiveGrade(float grade);
        void GiveGrade(double grade);
        void GiveGrade(int grade);
        void GiveGrade(long grade);
        void GiveGrade(string grade);
        void GiveGrade(char grade);

        Statistics GetStatistics();

    }
}
