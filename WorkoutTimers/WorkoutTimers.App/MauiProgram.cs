using WorkoutTimers.Lib.Services;
using WorkoutTimers.Lib.ViewModels;

namespace WorkoutTimers.App
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
                })
                .Services
                .AddSingleton<IIntervalService, InMemoryIntervalService>()
                .AddSingleton<RegularIntervalsModel>()
                .AddTransient<NewRegularIntervalModel>()
                .AddSingleton<StaggeredIntervalsModel>()
                .AddTransient<NewStaggeredIntervalModel>()
                .AddSingleton<SettingsModel>()
                .AddSingleton<Views.StaggeredIntervals>()
                .AddSingleton<Views.RegularIntervals>()
                .AddTransient<Views.NewStaggeredInterval>()
                .AddTransient<Views.NewRegularInterval>()
                .AddSingleton<Views.Settings>()
                ;

            return builder.Build();
        }
    }
}