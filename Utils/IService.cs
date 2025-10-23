namespace CS2Cheat.Utils;

public interface IService : IDisposable
{
    void Start();

    void Stop();

    bool IsRunning { get; }
}
