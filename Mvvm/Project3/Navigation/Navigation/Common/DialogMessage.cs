﻿using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation
{
    public interface IDialogMessage
    {
        Task DisplayAlert(string title, string message, string cancel);
    }

    public class DialogMessage : IDialogMessage
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
