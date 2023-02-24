using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeApp.Tests
{
    internal class ValueReferenceTests
    {
        [Test]
        public void WhenTwoEqualInts_ShouldReturnTheSame()
        {
            var variable1 = 5;
            var variable2 = 5;

            Assert.That(variable1, Is.EqualTo(variable2));
        }
        [Test]
        public void WhenTwoEqualFloats_ShouldReturnTheSame()
        {
            var variable1 = 3.14f;
            var variable2 = 3.14f;

            Assert.That(variable1, Is.EqualTo(variable2));
        }
        [Test]
        public void WhenTwoEqualStrings_ShouldReturnTheSame()
        {
            var variable1 = "Witaj";
            var variable2 = "Witaj";

            Assert.That(variable1, Is.EqualTo(variable2));
        }
        [Test]
        public void WhenSameNameEmployees_ShouldReturnDifferent()
        {
            var variable1 = GetEmployee("Adam");
            var variable2 = GetEmployee("Adam");

            Assert.That(variable1, Is.Not.EqualTo(variable2));
        }
        [Test]
        public void WhenDuplicateEmployees_ShouldReturnEqual()
        {
            var variable1 = GetEmployee("Adam");
            var variable2 = variable1;

            Assert.That(variable1, Is.EqualTo(variable2));
        }
           

        private Employee GetEmployee(string name)
        {
            return new Employee(name, "", 0);
        }
    }
}
