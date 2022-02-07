using Mine.Models;
using NUnit.Framework;
using Mine.Helpers;

namespace UnitTests.Helpers
{
    [TestFixture]
    public class DiceHelperTests
    {
        /// <summary>
        /// Unit Test for Invalid roll
        /// </summary>
        [Test]
        public void RollDice_Invalid_Roll_Zero_Should_Return_Zero()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 1);

            // Reset

            // Assert 
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Unit Test for Roll between 1 and 6
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_1_Dice_6_Should_Return_Between_1_And_6()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 6);

            // Reset

            // Assert 
            Assert.AreEqual(true, result >= 1);
            Assert.AreEqual(true, result <= 6);
        }

        /// <summary>
        /// Unit Test for 2 Dice have Roll between 2 and 12
        /// </summary>
        [Test]
        public void RollDice_Valid_Roll_2_Dice_6_Should_Return_Between_2_and_12()
        {
            // Arrange

            // Act
            var result1 = DiceHelper.RollDice(1, 6);
            var result2 = DiceHelper.RollDice(1, 6);
            var result = result1 + result2;

            // Reset

            // Assert 
            Assert.AreEqual(true, result >= 2);
            Assert.AreEqual(true, result <= 12);
        }

        /// <summary>
        /// Unit Test for an invalid roll 
        /// a ten-side dice 0 roll 
        /// should return 0
        /// </summary>
        [Test]
        public void RollDice_InValid_Roll_0_Dice_10_Should_Return_Zero()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(0, 10);

            // Reset

            // Assert 
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Unit Test for an invalid roll 
        /// when roll once a 0 value dice
        /// should return 0
        /// </summary>
        [Test]
        public void RollDice_InValid_Roll_1_Dice_0_Should_Return_Zero()
        {
            // Arrange

            // Act
            var result = DiceHelper.RollDice(1, 0);

            // Reset

            // Assert 
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Unit Test for invalid roll force change value to 1
        /// </summary>
        [Test]
        public void RollDice_Invalid_Roll_Forced_1_Should_Return_1()
        {
            // Arrange
            DiceHelper.ForceRollsToNotRandom = true;
            DiceHelper.ForcedRandomValue = 1;

            // Act
            var result = DiceHelper.RollDice(1, 1);

            // Reset
            DiceHelper.ForceRollsToNotRandom = false;

            // Assert 
            Assert.AreEqual(1, result);
        }
    }
}

