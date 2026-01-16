using Microsoft.Extensions.Logging;
using Supabase;

namespace SupaMaui
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
            var url = "https://fjvggyvxwzhvsyaohpvv.supabase.co";
            var key = "sb_publishable_H29ZwzWA1FRYQoXIQOrwXw_rv-yJNfD";
            var options = new SupabaseOptions
            {
                AutoRefreshToken = true,
                AutoConnectRealtime = true,
            };
            builder.Services.AddSingleton(provider => new Supabase.Client(url, key, options));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
