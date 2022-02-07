﻿using Mine.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    public class HomeMenuItemTests
    {
        /// <summary>
        /// Unit Test for ItemModel Constructor
        /// </summary>
        [Test]
        public void HomeMenuItem_Constructor_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();
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
            var result = new ItemModel();
            result.Description = "Description";
            result.Id = "Id";
            result.Text = "Text";
            result.Value = 1;
            // Reset

            // Assert 
            Assert.AreEqual("Description", result.Description);
            Assert.AreEqual("Id", result.Id);
            Assert.AreEqual("Text", result.Text);
            Assert.AreEqual(1, result.Value);
        }

        /// <summary>
        /// Unit Test for ItemModel Get function
        /// </summary>
        [Test]
        public void HomeMenuItem_Get_Valid_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new ItemModel();
            
            // Reset

            // Assert 
            Assert.AreEqual(0, result.Value);
        }

    }
}