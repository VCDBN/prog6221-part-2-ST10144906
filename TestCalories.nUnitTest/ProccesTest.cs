using NUnit.Framework;
using System.Diagnostics;

namespace TestCalories.nUnitTest
{
    public class ProcessTest
    {
        private Process1 pro { get; set; } = null!;
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            //AAA - ASSIGN,ACT,ASSERT
            Assert.Pass();
        }
    }
}