namespace ChallengeApp.Tests
{
    public class 
        EmployeeTests
    {
        [Test]
        public void When_ShouldReturnPersonals()
        {
            //Assign
            var employee = new Employee("Imiê", "Nazwisko");
            //Act
            var personals = employee.GetPersonals();
            //Assert
            Assert.That(personals, Is.EqualTo("Imiê Nazwisko"));
        }

        [Test]
        public void WhenNoGrades_ShouldReturnDefault()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            var given = employee.GetStatistics();
            var expected = new Statistics();
            //Assert
            Assert.That(given, Is.SameAs(expected));
        }

        [Test]
        public void WhenZeroGrades_ShouldReturnZero()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            employee.AssignGrade(0);
            employee.AssignGrade(0);
            employee.AssignGrade(0);

            var given = employee.GetStatistics();
            var expected = new Statistics(0,0,0);
            //Assert
            Assert.That(given, Is.SameAs(expected));
        }

        [Test]
        public void WhenPositiveGrades_ShouldReturnCorrect()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            employee.AssignGrade(50);
            employee.AssignGrade(10);

            var given = employee.GetStatistics();
            var expected = new Statistics(10, 50, 30);
            //Assert
            Assert.That(given, Is.SameAs(expected));
        }

        [Test]
        public void WhenNegativeGrades_ShouldReturnCorrect()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            employee.AssignGrade(-30);
            employee.AssignGrade(45);
            employee.AssignGrade(0);

            var given = employee.GetStatistics();
            var expected = new Statistics(-30, 45, 5);
            //Assert
            Assert.That(given, Is.SameAs(expected));
        }
    }
}