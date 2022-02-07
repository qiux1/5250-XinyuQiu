using Mine.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    public class HomeMenuItemTests
    {
        /// <summary>
        /// Unit Test for HomeMenuItemModel Constructor
        /// </summary>
        [Test]
        public void HomeMenuItem_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItem();

            // Reset

            // Assert 
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Unit Test for ItemModel Set Get function
        /// </summary>
        [Test]
        public void HomeMenuItem_Set_Get_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new HomeMenuItem();
            result.Id = MenuItemType.About;
            result.Title = "About";

            // Reset

            // Assert 
            Assert.AreEqual("About", result.Title);
            Assert.AreEqual(MenuItemType.About, result.Id);
        }

    }
}