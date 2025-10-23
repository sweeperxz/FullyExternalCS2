using System;
using System.IO;
using System.Threading;

namespace CS2Cheat.Utils;

public sealed class ConfigurationService : IDisposable
{
    private readonly string _configFilePath;
    private readonly FileSystemWatcher _fileWatcher;
    private readonly object _syncRoot = new();
    private ConfigManager _current;
    private Timer? _reloadTimer;
    private int _suppressWatcher;

    public ConfigurationService()
    {
        _configFilePath = Path.Combine(AppContext.BaseDirectory, ConfigManager.ConfigFileName);
        _current = ConfigManager.Load();

        var directory = Path.GetDirectoryName(_configFilePath);
        var fileName = Path.GetFileName(_configFilePath);
        _fileWatcher = new FileSystemWatcher(directory ?? ".", fileName)
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Size |
                           NotifyFilters.FileName,
            EnableRaisingEvents = true
        };

        _fileWatcher.Changed += OnConfigFileChanged;
        _fileWatcher.Created += OnConfigFileChanged;
        _fileWatcher.Renamed += OnConfigFileRenamed;
    }

    public event EventHandler<ConfigManager>? ConfigurationChanged;

    public ConfigManager Current
    {
        get
        {
            lock (_syncRoot)
            {
                return _current.Clone();
            }
        }
    }

    public void Update(Action<ConfigManager> updateAction)
    {
        if (updateAction == null) throw new ArgumentNullException(nameof(updateAction));

        ConfigManager updated;
        lock (_syncRoot)
        {
            updated = _current.Clone();
        }

        updateAction(updated);
        Update(updated, true);
    }

    public void Update(ConfigManager config, bool persist)
    {
        if (config == null) throw new ArgumentNullException(nameof(config));

        lock (_syncRoot)
        {
            _current = config.Clone();
        }

        if (persist)
        {
            Interlocked.Increment(ref _suppressWatcher);
            ConfigManager.Save(_current);
            Interlocked.Decrement(ref _suppressWatcher);
        }

        OnConfigurationChanged();
    }

    private void OnConfigurationChanged()
    {
        ConfigurationChanged?.Invoke(this, Current);
    }

    private void OnConfigFileChanged(object sender, FileSystemEventArgs e)
    {
        if (IsWatcherSuppressed()) return;
        ScheduleReload();
    }

    private void OnConfigFileRenamed(object sender, RenamedEventArgs e)
    {
        if (IsWatcherSuppressed()) return;
        ScheduleReload();
    }

    private bool IsWatcherSuppressed()
    {
        return Interlocked.CompareExchange(ref _suppressWatcher, 0, 0) > 0;
    }

    private void ScheduleReload()
    {
        lock (_syncRoot)
        {
            _reloadTimer?.Dispose();
            _reloadTimer = new Timer(_ => ReloadConfiguration(), null, 200, Timeout.Infinite);
        }
    }

    private void ReloadConfiguration()
    {
        try
        {
            var config = ConfigManager.Load();
            Update(config, false);
        }
        catch (IOException)
        {
            // Ignore transient IO errors and retry on next change notification
        }
    }

    public void Dispose()
    {
        _fileWatcher.Dispose();
        lock (_syncRoot)
        {
            _reloadTimer?.Dispose();
            _reloadTimer = null;
        }
    }
}
