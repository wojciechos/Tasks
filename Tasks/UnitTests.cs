using NUnit.Framework;

namespace Tasks
{
    [TestFixture]
    public class UnitTests
    {
        [TestCase(-2, false)]
        [TestCase(0, false)]
        [TestCase(2, true)]
        [TestCase(1024, true)]
        [TestCase(1025, false)]

        public void CheckingIsPowerOfTwoMethod(int power, bool isTrue)
        {
            var result = Task1.IsPowerOfTwo(power);

            Assert.AreEqual(isTrue, result);
        }

        [TestCase("Hello", "olleH")]
        [TestCase("Hello KiTy", "yTiK olleH")]
        public void CheckingReversingString(string text, string reversedText)
        {
            var result = Task2.ReverseText(text);

            Assert.AreEqual(reversedText, result);
        }

        [TestCase("Hi", 0, "")]
        [TestCase("Hi", 3, "HiHiHi")]
        [TestCase("A", 10, "AAAAAAAAAA")]
        public void CheckingReplicatingString(string text, int how, string expectedText)
        {
            var result = Task3.ReplicateText(text, how);

            Assert.AreEqual(expectedText, result);
        }
    }
}
