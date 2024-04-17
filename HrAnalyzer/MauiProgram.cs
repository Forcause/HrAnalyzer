using HrAnalyzer.Db;
using HrAnalyzer.Helpers;
using HrAnalyzer.Services;
using Microsoft.EntityFrameworkCore;

namespace HrAnalyzer
{
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
                });

            builder.Services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseInMemoryDatabase("AppDatabase");
                });

            builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
            builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddSingleton<StartPage>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LoginPage>();

            var app = builder.Build();
            ServiceLocator.Initialize(app.Services);

            return builder.Build();
        }
    }
}
