using Project5.ViewModel;

namespace Project5.Views;

public partial class SignupPage1 : ContentPage
{
    SignupViewModel1 _context;
	public SignupPage1()
	{
		InitializeComponent();
        _context = new SignupViewModel1();
        BindingContext = _context;
    }
    private void nameEntry_Unfocused(object sender, FocusEventArgs e)
    {
        _context.User.Fname.Validate();
    }

    private void lastnameEntry_Unfocused(object sender, FocusEventArgs e)
    {
        _context.User.Lname.Validate();
    }

    private void emailEntry_Unfocused(object sender, FocusEventArgs e)
    {
        _context.User.Email.Validate();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var isValid = _context.Validate();

        if (isValid)
        {
            DisplayAlert(":)", "This form is valid", "OK");
        }
        else
        {
            DisplayAlert(":(", "This form is not valid", "OK");
        }
    }

    
  }