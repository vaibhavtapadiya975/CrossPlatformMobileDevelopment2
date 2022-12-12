using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Project5.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project5.Models;
using Project5.Services;
using Plugin.ValidationRules;
using Project5.Validations;

namespace Project5.ViewModel
{

    [QueryProperty(nameof(User), "User")]
    public partial class SignupViewModel : ObservableObject
    {
        [ObservableProperty]
        private User _user = new User();

        private readonly IUserService _userService;
        public SignupViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [ICommand]
        public async void AddUser()
        {
            var u = await _userService.GetUser(User.Email);
            if (u == null)
            {
                int response = -1;
                response = await _userService.AddUser(new Models.User
                {
                    Fname = User.Fname,
                    Lname = User.Lname,
                    Email = User.Email,
                    mobileNo = User.mobileNo,
                    password = User.password,
                });
                Console.WriteLine("Response:", response);
                if (response > 0)
                {
                    await Shell.Current.DisplayAlert("Account Created", "Registration Successful", "OK");
                    AppShell.Current.Dispatcher.Dispatch(async () =>
                    {
                        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                    });
                }
                else
                {
                    await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Message","User Already Registered", "Ok");
                AppShell.Current.Dispatcher.Dispatch(async () =>
                {
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                });
            }
            
            /*
            */
        }
        

    }
}
