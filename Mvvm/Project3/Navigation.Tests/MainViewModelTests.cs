using System.Threading.Tasks;
using Xunit;

namespace Navigation.Tests
{
    public class MainViewModelTests
    {
        [Fact]
        public void DisplayAlertCommand_displays_alert()
        {
            var dialogMessage = new DialogMessageMock();
            var viewModel = new MainViewModel(dialogMessage);

            viewModel.DisplayAlertCommand.Execute(null);

            Assert.Equal(1, dialogMessage.DisplayAlertCallCount);
        }
    }

    class DialogMessageMock : IDialogMessage
    {
        public int DisplayAlertCallCount { get; set; }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            DisplayAlertCallCount++;
            return Task.CompletedTask;
        }
    }
}
