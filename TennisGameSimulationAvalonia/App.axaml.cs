using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using TennisGameSimulationAvalonia.ViewModels;
using TennisGameSimulationAvalonia.Views;
using TennisGameSimulationInterfaces.Models;
using TennisGameSimulationInterfaces.ViewModels;
using TennisGameSimulationModels;

namespace TennisGameSimulationAvalonia
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);

                var services = new ServiceCollection();
                ConfigureServices(services);
                var serviceProvider = services.BuildServiceProvider();

                desktop.MainWindow = new MainWindow
                {
                    DataContext = serviceProvider.GetRequiredService<IGameViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGame, Game>();
            services.AddSingleton<IGameViewModel, GameViewModel>();
        }
    }
}