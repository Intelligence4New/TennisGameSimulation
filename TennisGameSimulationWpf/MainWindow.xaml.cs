using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using TennisGameSimulationInterfaces.Models;
using TennisGameSimulationInterfaces.ViewModels;
using TennisGameSimulationModels;
using TennisGameSimulationWpf.ViewModels;

namespace TennisGameSimulationWpf;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();
        DataContext = serviceProvider.GetRequiredService<IGameViewModel>();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IGame, Game>();
        services.AddSingleton<IGameViewModel, GameViewModel>();
    }
}