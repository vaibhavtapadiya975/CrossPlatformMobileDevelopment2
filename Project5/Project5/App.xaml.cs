using Project5.Views;
using Project5.ViewModel;
using Project5.Services;
using Project5.Models;
namespace Project5;

public partial class App : Application
{
	public static User UserDetails;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
