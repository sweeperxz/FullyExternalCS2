using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CS2Cheat.Utils;

namespace CS2Cheat.Graphics;

public sealed class OverlayMenuViewModel : INotifyPropertyChanged
{
    private readonly ConfigurationService _configurationService;
    private ConfigManager _config;

    public OverlayMenuViewModel(ConfigurationService configurationService)
    {
        _configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
        _config = configurationService.Current;
    }

    public bool AimBot
    {
        get => _config.AimBot;
        set => UpdateSetting(value, c => c.AimBot, (config, newValue) => config.AimBot = newValue);
    }

    public bool TriggerBot
    {
        get => _config.TriggerBot;
        set => UpdateSetting(value, c => c.TriggerBot, (config, newValue) => config.TriggerBot = newValue);
    }

    public bool BombTimer
    {
        get => _config.BombTimer;
        set => UpdateSetting(value, c => c.BombTimer, (config, newValue) => config.BombTimer = newValue);
    }

    public bool EspBox
    {
        get => _config.EspBox;
        set => UpdateSetting(value, c => c.EspBox, (config, newValue) => config.EspBox = newValue);
    }

    public bool EspAimCrosshair
    {
        get => _config.EspAimCrosshair;
        set => UpdateSetting(value, c => c.EspAimCrosshair,
            (config, newValue) => config.EspAimCrosshair = newValue);
    }

    public bool SkeletonEsp
    {
        get => _config.SkeletonEsp;
        set => UpdateSetting(value, c => c.SkeletonEsp, (config, newValue) => config.SkeletonEsp = newValue);
    }

    public bool TeamCheck
    {
        get => _config.TeamCheck;
        set => UpdateSetting(value, c => c.TeamCheck, (config, newValue) => config.TeamCheck = newValue);
    }

    public void UpdateFromConfig(ConfigManager config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
        OnPropertyChanged(nameof(AimBot));
        OnPropertyChanged(nameof(TriggerBot));
        OnPropertyChanged(nameof(BombTimer));
        OnPropertyChanged(nameof(EspBox));
        OnPropertyChanged(nameof(EspAimCrosshair));
        OnPropertyChanged(nameof(SkeletonEsp));
        OnPropertyChanged(nameof(TeamCheck));
    }

    private void UpdateSetting<T>(T value, Func<ConfigManager, T> getter, Action<ConfigManager, T> setter)
    {
        if (EqualityComparer<T>.Default.Equals(getter(_config), value)) return;

        _configurationService.Update(config =>
        {
            setter(config, value);
            _config = config;
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
