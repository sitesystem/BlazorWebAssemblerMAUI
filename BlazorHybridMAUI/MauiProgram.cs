using BlazorHybridMAUI.Data;
using BlazorHybridMAUI.CapaServices.BusinessLogic;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;

namespace BlazorHybridMAUI
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            // INYECTACCIÓN DE DEPENDENCIAS (INTERFACES)
            //builder.Services.AddSingleton<IPrueba, Prueba>();
            builder.Services.AddScoped<IPersona, RPersona>();
            builder.Services.AddSingleton<IRickAndMorty, RickAndMorty>();

            builder.Services.AddMudServices();

            return builder.Build();
        }
    }
}