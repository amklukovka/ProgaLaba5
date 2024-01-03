using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleContactBook.Models;

namespace SimpleContactBook.UnitTests
{
    public class ContactTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            var contact = new Contact();

            // Act & Assert
            Assert.Null(contact.Name);
            Assert.Null(contact.PhoneNumber);
            Assert.Null(contact.Email);
        }

        [Theory]
        [InlineData("Valid Name", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        public void IsValid_ReturnsCorrectValue(string name, bool expectedIsValid)
        {
            // Arrange
            var contact = new Contact { Name = name };

            // Act
            bool isValid = contact.IsValid;

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }
    }
}
