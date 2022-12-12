using Project5.ViewModel;

namespace Project5.Views;

public partial class UserPage : Shell
{

	public UserPage(UserPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
        //OnPropertyChanged();
    }

	/*public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		var Name = query["Name"];
		fullName.Text = (String)Name;
        OnPropertyChanged();

    }*/
}