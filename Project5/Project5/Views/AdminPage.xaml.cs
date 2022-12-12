using Project5.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Behaviors;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Maui.Controls;


namespace Project5.Views;

public partial class AdminPage : ContentPage
{
	public AdminPage(AdminPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}