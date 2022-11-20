namespace Calculator;

public partial class ThemePage : ContentPage
{
	public ThemePage()
	{
		InitializeComponent();
	}
	private void gotoMainPage(Object sender,EventArgs e)
	{
        Button button = (Button)sender;
        Navigation.PushAsync(new MainPage(button.BackgroundColor));
	}


}
