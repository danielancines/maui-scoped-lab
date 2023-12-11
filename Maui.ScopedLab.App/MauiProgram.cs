using Maui.ScopedLab.App.Services;
using Maui.ScopedLab.App.ViewModel;
using Maui.ScopedLab.App.Views;
using Microsoft.Extensions.Logging;

namespace Maui.ScopedLab.App
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddScoped<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<AppShell>();
            builder.Services.AddTransient<MyView>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();

            var app = builder.Build();
            Container = app.Services;

            return app;
        }

        public static IServiceProvider? Container { get; private set; }
    }
}
