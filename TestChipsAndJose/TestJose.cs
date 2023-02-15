using ChipsAndJose;

namespace TestChipsAndJose
{
    [TestClass]
    public class TestJose
    {
        [TestMethod]
        public void TestDealWithChips1()
        {
            // Array
            int[] seats = { 1, 5, 9, 10, 5 };
            int expected = 12;

            // Act
            int result = new Jose().DealWithChips(seats);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDealWithChips2()
        {
            // Array
            int[] seats = { 1, 2, 3 };
            int expected = 1;

            // Act
            int result = new Jose().DealWithChips(seats);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDealWithChips3()
        {
            // Array
            int[] seats = { 0, 1, 1, 1, 1, 1, 1, 1, 1, 2 };
            int expected = 1;

            // Act
            int result = new Jose().DealWithChips(seats);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDealWithChips4()
        {
            // Array
            int[] seats = { 6, 6, 6, 4, 3 };
            int expected = 4;

            // Act
            int result = new Jose().DealWithChips(seats);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestDealWithChips5()
        {
            // Array
            int[] seats = { 2, 7, 4, 2, 4, 10, 5, 7, 2, 7 };
            int expected = 16;

            // Act
            int result = new Jose().DealWithChips(seats);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}