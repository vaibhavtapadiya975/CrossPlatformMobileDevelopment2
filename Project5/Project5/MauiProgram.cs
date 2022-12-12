using CommunityToolkit.Maui;
using Project5.ViewModel;
using Project5.Views;
using Project5.Services;

namespace Project5;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).UseMauiCommunityToolkit();

        
        // Services
        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<IQuestionService, QuestionService>();

        //Views
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<SignupPage>();
        builder.Services.AddSingleton<SignupPage1>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<AdminPage>();
        builder.Services.AddSingleton<UserPage>();


        //View Models
        builder.Services.AddSingleton<LoginPageViewModel>();
        builder.Services.AddSingleton<SignupViewModel>();
        builder.Services.AddSingleton<SignupViewModel1>();
        builder.Services.AddSingleton<UserPageViewModel>();
        builder.Services.AddSingleton<AdminPageViewModel>();
        return builder.Build();
	}
}
