using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Project5.Models;
using Project5.Services;

namespace Project5.ViewModel
{
    public partial class UserPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private User _user = new User();

        private readonly IUserService _userService;
        public UserPageViewModel(IUserService userService)
        {
            _userService = userService;
        }
    }
}
