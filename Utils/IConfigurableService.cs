namespace CS2Cheat.Utils;

public interface IConfigurableService : IService
{
    void ApplyConfiguration(ConfigManager config);
}
