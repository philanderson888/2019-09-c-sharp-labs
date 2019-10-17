using NUnit.Framework;
using lab_12_test_me_out;
using just_do_it_11_rabbit_explosion;
using labs_just_do_it_17_enum_with_tests;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMeSomething_RunTestMeNow()
        {
            var expected = 100;
            var actual = TestMeSomething.RunThisTestNow(10);
            Assert.AreEqual(expected, actual);
        }
        [TestCase(10,100)]
        [TestCase(100,10000)]
        [TestCase(9,81)]
        public void TestMeSomething_RunTestMeNow_Tests(int input, int expected)
        {
            System.Console.WriteLine("Printing " + input);
            var actual = TestMeSomething.RunThisTestNow(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1000,20)]
        public void TestRabbitExplosion(int populationLimit,int expectedYears)
        {
            // arrange

            // act
            var actualYears = just_do_it_11_rabbit_explosion_test.Rabbit_Exponential_Growth(populationLimit);
            // assert
            Assert.AreEqual(expectedYears, actualYears);
        }

        [TestCase(1,2,"Monday","February")]
        [TestCase(2,3,"Tuesday","March")]
        public void TestGetDayMonth(int day, int month,string expectedDay,
            string expectedMonth)
        {
            // arrange
            // act
            var actual = TestEnums.GetDayMonth(day, month);
            // assert
            Assert.AreEqual(actual, (expectedDay, expectedMonth));
        }


    }
}