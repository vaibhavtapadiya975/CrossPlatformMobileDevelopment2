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
using Plugin.ValidationRules.Extensions;

namespace Project5.ViewModel
{
    public partial class SignupViewModel1 : Plugin.ValidationRules.Extensions.ExtendedPropertyChanged
    {
 
        private UserValidator _user;
        public UserValidator User
        {
            get => _user;
            set => SetProperty(ref _user, value);
        }
        public SignupViewModel1()
        {
            _user = new UserValidator();
        }

        public bool Validate()
        {
            // Your logic goes here
            return User.Validate();
        }

        [ICommand]
        async public void AddUser()
        {
            await Shell.Current.DisplayAlert(":)", "Model Command Executed", "OK");
            
            
        }
    }
}
