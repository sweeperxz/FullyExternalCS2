using System;
using System.Windows;
using CS2Cheat.Utils;

namespace CS2Cheat.Graphics;

public partial class OverlayMenuWindow : Window
{
    private readonly ConfigurationService _configurationService;
    private readonly OverlayMenuViewModel _viewModel;

    public OverlayMenuWindow(ConfigurationService configurationService)
    {
        _configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
        InitializeComponent();

        _viewModel = new OverlayMenuViewModel(configurationService);
        DataContext = _viewModel;

        Loaded += OnLoaded;
        Closed += OnClosed;
    }

    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _configurationService.ConfigurationChanged += OnConfigurationChanged;
        _viewModel.UpdateFromConfig(_configurationService.Current);
    }

    private void OnConfigurationChanged(object? sender, ConfigManager config)
    {
        Dispatcher.Invoke(() => _viewModel.UpdateFromConfig(config));
    }

    private void OnClosed(object? sender, EventArgs e)
    {
        _configurationService.ConfigurationChanged -= OnConfigurationChanged;
    }
}
