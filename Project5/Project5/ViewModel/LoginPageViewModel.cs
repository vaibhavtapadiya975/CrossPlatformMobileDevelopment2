using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Project5.Models;
using Project5.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project5.Services;

namespace Project5.ViewModel
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;

        private readonly IUserService _userService;

        public LoginPageViewModel(IUserService userService)
        {
            _userService = userService;
        }
        [ICommand]
        async void Signup()
        {
            AppShell.Current.Dispatcher.Dispatch(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(SignupPage)}");
            });
        }

        [ICommand]
        async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                if (Email == "Admin" && Password == "Admin")
                {                    
                    AppShell.Current.Dispatcher.Dispatch(async () =>
                    {
                        await Shell.Current.GoToAsync($"//{nameof(AdminPage)}");
                    });
                }
                else
                {
                    User u = await _userService.GetUser(Email);
                    if (u == null)
                    {
                        await Shell.Current.DisplayAlert("Warning", "Wrong Credentials", "Ok");
                    }
                    else if (Email == u.Email && Password == u.password)
                    {
                        AppShell.Current.Dispatcher.Dispatch(async () =>
                        {
                            var navigationParameter = new Dictionary<string, object>
                        {
                            {"Name",u.Fname+" "+u.Lname },
                            {"Emailid",u.Email },
                            {"MobileNo",u.mobileNo }
                        };
                            //await Shell.Current.GoToAsync($"//{nameof(UserPage)}", navigationParameter);
                            await Shell.Current.GoToAsync($"//{nameof(QuizPage)}");
                        });
                    }
                }
                
                
            }
        }
    }
}
