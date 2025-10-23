using CS2Cheat.Data.Game;
using CS2Cheat.Features;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using static CS2Cheat.Core.User32;
using Application = System.Windows.Application;

namespace CS2Cheat;

public class Program :
    Application,
    IDisposable
{
    private Program()
    {
        Offsets.UpdateOffsets();
        Startup += (_, _) => InitializeComponent();
        Exit += (_, _) => Dispose();
    }

    private ConfigurationService ConfigurationService { get; set; } = null!;

    private ServiceRegistry ServiceRegistry { get; set; } = null!;

    private GameProcess GameProcess { get; set; } = null!;

    private GameData GameData { get; set; } = null!;

    private WindowOverlay WindowOverlay { get; set; } = null!;

    private Graphics.Graphics Graphics { get; set; } = null!;

    private OverlayMenuWindow? MenuWindow { get; set; }

    public void Dispose()
    {
        if (MenuWindow != null)
        {
            MenuWindow.Dispatcher.Invoke(() => MenuWindow.Close());
            MenuWindow = null;
        }

        if (ConfigurationService != null)
            ConfigurationService.ConfigurationChanged -= OnConfigurationChanged;

        ServiceRegistry?.Dispose();
        ConfigurationService?.Dispose();

        GameProcess = default!;
        GameData = default!;
        WindowOverlay = default!;
        Graphics = default!;
    }

    public static void Main()
    {
        new Program().Run();
    }

    private void InitializeComponent()
    {
        ConfigurationService = new ConfigurationService();
        ConfigurationService.ConfigurationChanged += OnConfigurationChanged;

        ServiceRegistry = new ServiceRegistry();

        GameProcess = new GameProcess();
        GameData = new GameData(GameProcess);
        WindowOverlay = new WindowOverlay(GameProcess);
        Graphics = new Graphics.Graphics(GameProcess, GameData, WindowOverlay, ConfigurationService);

        MenuWindow = new OverlayMenuWindow(ConfigurationService)
        {
            Left = -32000,
            Top = -32000
        };
        MenuWindow.Show();
        WindowOverlay.AttachMenuWindow(MenuWindow);

        ServiceRegistry.Register(nameof(GameProcess), GameProcess, _ => true);
        ServiceRegistry.Register(nameof(GameData), GameData, _ => true);
        ServiceRegistry.Register(nameof(WindowOverlay), WindowOverlay, _ => true);
        ServiceRegistry.Register(nameof(Graphics), Graphics, _ => true);

        FeatureRegistry.Register(ServiceRegistry, GameProcess, GameData, Graphics);

        ServiceRegistry.ApplyConfiguration(ConfigurationService.Current);

        SetWindowDisplayAffinity(WindowOverlay!.Window.Handle, 0x00000011); //obs bypass
    }

    private void OnConfigurationChanged(object? sender, ConfigManager config)
    {
        ServiceRegistry.ApplyConfiguration(config);
    }
}