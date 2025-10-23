using System;
using System.Collections.Generic;

namespace CS2Cheat.Utils;

public sealed class ServiceRegistry : IDisposable
{
    private readonly List<ServiceRegistration> _registrations = new();
    private readonly object _syncRoot = new();

    public void Register(string key, IService service, Func<ConfigManager, bool>? isEnabled = null)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Key must be provided", nameof(key));
        if (service == null) throw new ArgumentNullException(nameof(service));

        var registration = new ServiceRegistration(key, service, isEnabled ?? (_ => true));
        lock (_syncRoot)
        {
            _registrations.Add(registration);
        }
    }

    public void ApplyConfiguration(ConfigManager config)
    {
        if (config == null) throw new ArgumentNullException(nameof(config));

        lock (_syncRoot)
        {
            foreach (var registration in _registrations)
            {
                if (registration.Service is IConfigurableService configurableService)
                    configurableService.ApplyConfiguration(config);

                var shouldRun = registration.IsEnabled(config);
                if (shouldRun)
                    registration.Start();
                else
                    registration.Stop();
            }
        }
    }

    public void Dispose()
    {
        lock (_syncRoot)
        {
            foreach (var registration in _registrations)
            {
                registration.Stop();
                registration.Service.Dispose();
            }

            _registrations.Clear();
        }
    }

    private sealed record ServiceRegistration(string Key, IService Service, Func<ConfigManager, bool> IsEnabled)
    {
        public void Start()
        {
            if (!Service.IsRunning) Service.Start();
        }

        public void Stop()
        {
            if (Service.IsRunning) Service.Stop();
        }
    }
}
