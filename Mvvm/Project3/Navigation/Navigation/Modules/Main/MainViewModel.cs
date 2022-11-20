using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Navigation
{
    public class MainViewModel : BindableObject
    {
        private IDialogMessage _dialogMessage;

        public MainViewModel(IDialogMessage dialogMessage)
        {
            _dialogMessage = dialogMessage;
        }

        public ICommand DisplayAlertCommand => new Command(async () => { await ShowAlert(); });

        private async Task ShowAlert()
        {
            await _dialogMessage.DisplayAlert("Hello", "Hello there!", "OK");
        }
    }
}
