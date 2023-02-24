namespace ChallengeApp.Tests
{
    public class Tests
    {
        [Test]
        public void When_ShouldReturnPersonals()
        {
            var employee = new Employee("Imiê", "Nazwisko", 15);

            var personals = employee.GetPersonals();

            Assert.That(personals, Is.EqualTo("Imiê Nazwisko, lat 15"));
        }

        [Test]
        public void WhenNoGrades_ShouldReturnZero()
        {
            var employee = new Employee("", "", 0);

            int score = employee.GetScore();

            Assert.That(score, Is.EqualTo(0));
        }

        [Test]
        public void WhenZeroGrades_ShouldReturnZero()
        {
            var employee = new Employee("", "", 0);

            employee.AssignGrade(0);
            employee.AssignGrade(0);
            int score = employee.GetScore();

            Assert.That(score, Is.EqualTo(0));
        }

        [Test]
        public void WhenNegativeGrades_ShouldReturnCorrect()
        {
            var employee = new Employee("", "", 0);

            employee.AssignGrade(-3);
            employee.AssignGrade(9);
            int score = employee.GetScore();

            Assert.That(score, Is.EqualTo(6));
        }
    }
}