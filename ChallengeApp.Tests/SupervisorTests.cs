namespace ChallengeApp.Tests
{
    public class
        SupervisorTests
    {
        [Test]
        public void When_ShouldReturnPersonals()
        {
            //Assign
            var supervisor = new Supervisor("Imię", "Nazwisko");
            //Act
            var personals = supervisor.Personals;
            //Assert
            Assert.That(personals, Is.EqualTo("spv. Imię Nazwisko"));
        }

        [Test]
        public void WhenNoGrades_ShouldReturnDefault()
        {
            //Assign
            var supervisor = new Supervisor("", "");
            //Act
            var given = supervisor.GetStatistics();
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
            var supervisor = new Supervisor("", "");
            //Act
            supervisor.GiveGrade(0);
            supervisor.GiveGrade(0);
            supervisor.GiveGrade(0);

            var given = supervisor.GetStatistics();
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
            var supervisor = new Supervisor("", "");
            //Act
            supervisor.GiveGrade(50);
            supervisor.GiveGrade(10);

            var given = supervisor.GetStatistics();
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
            var supervisor = new Supervisor("", "");
            //Act
            var actTooBig = () =>
            {
                supervisor.GiveGrade(101);
            };
            var actTooSmall = () =>
            {
                supervisor.GiveGrade(-1);
            };

            //Assert
            Assert.That(actTooBig, Throws.Exception);
            Assert.That(actTooSmall, Throws.Exception);
        }

        [Test]
        public void WhenStringGrades_ShouldReturnCorrect()
        {
            //Assign
            var supervisor = new Supervisor("", "");
            //Act
            supervisor.GiveGrade("40");
            supervisor.GiveGrade("60");

            var given = supervisor.GetStatistics();
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
            var supervisor = new Supervisor("", "");
            //Act
            var actBadParse = () =>
            {
                supervisor.GiveGrade("grade");
            };

            //Assert
            Assert.That(actBadParse, Throws.Exception);
        }

        [Test]
        public void WhenDifferentTypeGrades_ShouldReturnCorrect()
        {
            //Assign
            var supervisor = new Supervisor("", "");
            float grade1 = 10;
            int grade2 = 30;
            string grade5 = "50";
            double grade4 = 70;
            long grade3 = 90;

            //Act
            supervisor.GiveGrade(grade1);
            supervisor.GiveGrade(grade2);
            supervisor.GiveGrade(grade3);
            supervisor.GiveGrade(grade4);
            supervisor.GiveGrade(grade5);

            var given = supervisor.GetStatistics();
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
            var supervisor = new Supervisor("", "");

            //Act
            supervisor.GiveGrade('A');
            supervisor.GiveGrade('A');
            supervisor.GiveGrade('B');
            supervisor.GiveGrade('A');
            supervisor.GiveGrade('C');

            var given = supervisor.GetStatistics();
            //Assert
            Assert.That(given.AverageLetter, Is.EqualTo('A'));
        }

        [Test]
        public void WhenNoLetterGrades_ShouldReturnCorrect()
        {
            //Assign
            var supervisor = new Supervisor("", "");

            //Act

            var given = supervisor.GetStatistics();
            //Assert
            Assert.That(given.AverageLetter, Is.EqualTo('F'));
        }

        [Test]
        public void WhenBadLetterGrade_ShouldThrow_Exception()
        {
            //Assign
            var supervisor = new Supervisor("", "");

            //Act
            var actBadLetter = () =>
            {
                supervisor.GiveGrade('Z');
            };

            //Assert
            Assert.That(actBadLetter, Throws.Exception);
        }

        [Test]
        public void WhenStringGrade_ShouldReturnCorrect()
        {
            //Assign
            var supervisor = new Supervisor("", "");

            //Act
            supervisor.GiveGrade("6");
            supervisor.GiveGrade("6-");
            supervisor.GiveGrade("+5");
            supervisor.GiveGrade("5");
            supervisor.GiveGrade("5-");
            supervisor.GiveGrade("+4");
            supervisor.GiveGrade("4");
            supervisor.GiveGrade("-4");
            supervisor.GiveGrade("3+");
            supervisor.GiveGrade("3");
            supervisor.GiveGrade("3-");
            supervisor.GiveGrade("+2");
            supervisor.GiveGrade("2");
            supervisor.GiveGrade("2-");
            supervisor.GiveGrade("+1");
            supervisor.GiveGrade("1");

            var stats = supervisor.GetStatistics();

            //Assert
            Assert.That(stats.Min, Is.EqualTo(0));
            Assert.That(stats.Max, Is.EqualTo(100));
            Assert.That(stats.Average, Is.EqualTo(50));
        }
    }
}