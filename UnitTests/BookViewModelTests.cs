using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleContactBook.ViewModels;

namespace SimpleContactBook.UnitTests
{
    public class BookViewModelTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            var mockService = new Mock<IContactDataService>();

            // Act
            var bookViewModel = new BookViewModel(mockService.Object);

            // Assert
            Assert.NotNull(bookViewModel.ContactsVM);
            Assert.NotNull(bookViewModel.LoadContactsCommand);
        }

        [Fact]
        public void LoadContactsCommand_ExecutesLoadContacts()
        {
            // Arrange
            var mockService = new Mock<IContactDataService>();
            var bookViewModel = new BookViewModel(mockService.Object);

            // Act
            bookViewModel.LoadContactsCommand.Execute(null);

            // Assert
            mockService.Verify(service => service.GetContacts(), Times.Once);
            Assert.NotNull(bookViewModel.ContactsVM.Contacts);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("Anya Klukva")]
        [InlineData("Tony Stark")]
        public void LoadContacts_LoadsContactsIntoContactsVM(string contactName)
        {
            // Arrange
            var mockService = new Mock<IContactDataService>();
            var contactsList = contactName != null ? new List<Contact> { new Contact { Name = contactName } } : null;
            mockService.Setup(service => service.GetContacts()).Returns(contactsList);

            var bookViewModel = new BookViewModel(mockService.Object);

            // Act
            bookViewModel.LoadContactsCommand.Execute(null);

            // Assert
            if (contactName != null)
            {
                Assert.Single(bookViewModel.ContactsVM.Contacts);
                Assert.Equal(contactName, bookViewModel.ContactsVM.Contacts[0].Name);
            }
            else
            {
                Assert.Empty(bookViewModel.ContactsVM.Contacts);
            }
        }
    }
}
