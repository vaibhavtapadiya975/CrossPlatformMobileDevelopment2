using Project5.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace Project5.Views;

public partial class SignupPage : ContentPage
{
  
    public SignupPage(SignupViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }

    
}