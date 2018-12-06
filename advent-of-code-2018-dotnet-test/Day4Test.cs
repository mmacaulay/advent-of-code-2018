using NUnit.Framework;
using advent_of_code_2018_dotnet;

namespace advent_of_code_2018_dotnet_test
{
    public class Day4Test
    {
        private Day4 day4;

        [SetUp]
        public void Setup()
        {
            day4 = new Day4();
        }

        [Test]
        public void TestGetMinute()
        {
            Assert.AreEqual(4, day4.GetMinute("1518-09-16 00:04"));
            Assert.AreEqual(48, day4.GetMinute("1518-07-14 00:48"));
            Assert.AreEqual(58, day4.GetMinute("1518-02-06 23:58"));
        }
    }
}