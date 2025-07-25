using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Popups;
using Blazored.LocalStorage;
using System.Reflection;
using Microsoft.Extensions.Configuration;


namespace DSScanner
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            var getAssemebly = Assembly.GetExecutingAssembly();
            using var stream = getAssemebly.GetManifestResourceStream("DSScanner.appsettings.json");
            var config = new ConfigurationBuilder()
                .AddJsonStream(stream)
                .Build();

            builder.Configuration.AddConfiguration(config);
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();

#endif
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Services.AddSingleton<HttpClient>();
            //builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddScoped<SfDialogService>(); /*Added by Amish as per requirement*/
            builder.Services.AddSyncfusionBlazor(); /*Added by Amish as per requirement*/
            builder.Services.AddBlazoredLocalStorage();/*Added by Amish as per requirement*/
            builder.Services.AddHttpClient();
            

            return builder.Build();
        }
    }
}
