using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleContactBook;
using SimpleContactBook.ViewModels;

namespace SimpleContactBook.UnitTests
{
    public class AppViewModelTests
    {
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            // Arrange
            var appViewModel = new AppViewModel();

            // Act & Assert
            Assert.NotNull(appViewModel.BookVM);
            Assert.NotNull(appViewModel.CurrentView);
            Assert.IsType<BookViewModel>(appViewModel.CurrentView);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("TestView")]
        public void SetCurrentView_ChangesCurrentViewProperty(object newView)
        {
            // Arrange
            var appViewModel = new AppViewModel();

            // Act
            appViewModel.CurrentView = newView;

            // Assert
            Assert.Equal(newView, appViewModel.CurrentView);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("New Book View")]
        public void SetBookVM_ChangesBookVMProperty(object newBookView)
        {
            // Arrange
            var appViewModel = new AppViewModel();

            // Act
            appViewModel.BookVM = new BookViewModel();

            // Assert
            Assert.IsType<BookViewModel>(appViewModel.BookVM);
        }
    }
}
