using System.Diagnostics;

namespace CS2Cheat.Utils;

public abstract class ThreadedServiceBase :
    IDisposable
{
    #region

    protected virtual string ThreadName => nameof(ThreadedServiceBase);

    protected virtual TimeSpan ThreadTimeout { get; set; } = new(0, 0, 0, 3);

    protected virtual TimeSpan ThreadFrameSleep { get; set; } = new(0, 0, 0, 0, 1);

    private Thread Thread { get; set; }

    #endregion

    #region

    protected ThreadedServiceBase()
    {
        Thread = new Thread(ThreadStart)
        {
            Name = ThreadName
        };
    }

    public virtual void Dispose()
    {
        Thread.Interrupt();
        if (!Thread.Join(ThreadTimeout)) Thread.Abort();

        Thread = default;
    }

    #endregion

    #region

    public void Start()
    {
        Thread.Start();
    }

    private void ThreadStart()
    {
        try
        {
            while (true)
            {
                FrameAction();
                Thread.Sleep(ThreadFrameSleep);
            }
        }
        catch (NullReferenceException)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
                { FileName = "steam://rungameid/730", UseShellExecute = true });
        }
    }

    protected abstract void FrameAction();

    #endregion
}