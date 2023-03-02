namespace ChallengeApp.Tests
{
    public class
        EmployeeTests
    {
        [Test]
        public void When_ShouldReturnPersonals()
        {
            //Assign
            var employee = new Employee("Imi�", "Nazwisko");
            //Act
            var personals = employee.GetPersonals();
            //Assert
            Assert.That(personals, Is.EqualTo("Imi� Nazwisko (M)"));
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
            Assert.That(given.Min, Is.EqualTo(expected.Min));
            Assert.That(given.Max, Is.EqualTo(expected.Max));
            Assert.That(given.Average, Is.EqualTo(expected.Average));
        }

        [Test]
        public void WhenZeroGrades_ShouldReturnZero()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            employee.GiveGrade(0);
            employee.GiveGrade(0);
            employee.GiveGrade(0);

            var given = employee.GetStatistics();
            var expected = new Statistics(0, 0, 0);
            //Assert
            Assert.That(given.Min, Is.EqualTo(expected.Min));
            Assert.That(given.Max, Is.EqualTo(expected.Max));
            Assert.That(given.Average, Is.EqualTo(expected.Average));
        }

        [Test]
        public void WhenPositiveGrades_ShouldReturnCorrect()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            employee.GiveGrade(50);
            employee.GiveGrade(10);

            var given = employee.GetStatistics();
            var expected = new Statistics(10, 50, 30);
            //Assert
            Assert.That(given.Min, Is.EqualTo(expected.Min));
            Assert.That(given.Max, Is.EqualTo(expected.Max));
            Assert.That(given.Average, Is.EqualTo(expected.Average));
        }

        [Test]
        public void WhenOutOfRangeGrades_ShouldThrowException()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            var actTooBig = () =>
            {
                employee.GiveGrade(101);
            };
            var actTooSmall = () =>
            {
                employee.GiveGrade(-1);
            };

            //Assert
            Assert.That(actTooBig, Throws.Exception);
            Assert.That(actTooSmall, Throws.Exception);
        }

        [Test]
        public void WhenStringGrades_ShouldReturnCorrect()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            employee.GiveGrade("40");
            employee.GiveGrade("60");

            var given = employee.GetStatistics();
            var expected = new Statistics(40, 60, 50);
            //Assert
            Assert.That(given.Min, Is.EqualTo(expected.Min));
            Assert.That(given.Max, Is.EqualTo(expected.Max));
            Assert.That(given.Average, Is.EqualTo(expected.Average));
        }

        [Test]
        public void WhenBadStringGrades_ShouldThrowException()
        {
            //Assign
            var employee = new Employee("", "");
            //Act
            var actBadParse = () =>
            {
                employee.GiveGrade("grade");
            };

            //Assert
            Assert.That(actBadParse, Throws.Exception);
        }

        [Test]
        public void WhenDifferentTypeGrades_ShouldReturnCorrect()
        {
            //Assign
            var employee = new Employee("", "");
            float grade1 = 10;
            int grade2 = 30;
            string grade5 = "50";
            double grade4 = 70;
            long grade3 = 90;

            //Act
            employee.GiveGrade(grade1);
            employee.GiveGrade(grade2);
            employee.GiveGrade(grade3);
            employee.GiveGrade(grade4);
            employee.GiveGrade(grade5);

            var given = employee.GetStatistics();
            var expected = new Statistics(10, 90, 50);
            //Assert
            Assert.That(given.Min, Is.EqualTo(expected.Min));
            Assert.That(given.Max, Is.EqualTo(expected.Max));
            Assert.That(given.Average, Is.EqualTo(expected.Average));
        }

        [Test]
        public void WhenLetterGrades_ShouldReturnCorrect()
        {
            //Assign
            var employee = new Employee("", "");

            //Act
            employee.GiveGrade('A');
            employee.GiveGrade('A');
            employee.GiveGrade('B');
            employee.GiveGrade('A');
            employee.GiveGrade('C');

            var given = employee.GetStatistics();
            //Assert
            Assert.That(given.AverageLetter, Is.EqualTo('A'));
        }

        [Test]
        public void WhenNoLetterGrades_ShouldReturnCorrect()
        {
            //Assign
            var employee = new Employee("", "");

            //Act

            var given = employee.GetStatistics();
            //Assert
            Assert.That(given.AverageLetter, Is.EqualTo('F'));
        }

        [Test]
        public void WhenBadLetterGrade_ShouldThrow_Exception()
        {
            //Assign
            var employee = new Employee("", "");

            //Act
            var actBadLetter = () =>
            {
                employee.GiveGrade('Z');
            };

            //Assert
            Assert.That(actBadLetter, Throws.Exception);
        }
    }
}