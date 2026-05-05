namespace CS2Cheat.Utils;

public abstract class ThreadedServiceBase :
    IDisposable
{
    #region Properties

    protected virtual string ThreadName => nameof(ThreadedServiceBase);

    protected virtual TimeSpan ThreadTimeout { get; set; } = new(0, 0, 0, 3);

    protected virtual TimeSpan ThreadFrameSleep { get; set; } = new(0, 0, 0, 0, 1);

    private Thread? Thread { get; set; }

    private readonly CancellationTokenSource _cts = new();

    #endregion

    #region Lifecycle

    protected ThreadedServiceBase()
    {
        Thread = new Thread(ThreadStart)
        {
            Name = ThreadName,
            IsBackground = true
        };
    }

    public virtual void Dispose()
    {
        _cts.Cancel();

        if (Thread is { IsAlive: true })
        {
            if (!Thread.Join(ThreadTimeout))
                Console.WriteLine($"[WARN] Thread '{ThreadName}' did not stop within timeout.");
        }

        _cts.Dispose();
        Thread = null;
    }

    #endregion

    #region Threading

    public void Start()
    {
        Thread?.Start();
    }

    private void ThreadStart()
    {
        Console.WriteLine($"[INFO] Thread '{ThreadName}' started.");
        try
        {
            while (!_cts.Token.IsCancellationRequested)
            {
                try
                {
                    FrameAction();
                }
                catch (Exception ex) when (ex is not ThreadInterruptedException and not OperationCanceledException)
                {
                    Console.WriteLine($"[ERROR] [{ThreadName}] {ex.Message}");
                }

                Thread.Sleep(ThreadFrameSleep);
            }
        }
        catch (ThreadInterruptedException)
        {
        }
        catch (OperationCanceledException)
        {
        }

        Console.WriteLine($"[INFO] Thread '{ThreadName}' stopped.");
    }

    protected abstract void FrameAction();

    #endregion
}