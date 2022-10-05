using EmployeesListApp.Services;
using EmployeesListApp.Services.Interfaces;
using EmployeesListApp.ViewModels;
using EmployeesListApp.Views;

namespace EmployeesListApp;

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
			})
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews();

		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<EmployeesPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<EmployeePageViewModel>();
        mauiAppBuilder.Services.AddTransient<EditEmployeePageViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<EmployeesPage>();
        mauiAppBuilder.Services.AddSingleton<EmployeeDetailPage>();
        mauiAppBuilder.Services.AddTransient<EditEmployeePage>();

        return mauiAppBuilder;
    }
}
