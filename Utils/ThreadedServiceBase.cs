using System.Threading;

namespace CS2Cheat.Utils;

public abstract class ThreadedServiceBase : IService
{
    private readonly object _threadLock = new();
    private CancellationTokenSource? _cancellationTokenSource;
    private Thread? _thread;

    protected virtual string ThreadName => nameof(ThreadedServiceBase);

    protected virtual TimeSpan ThreadTimeout { get; set; } = new(0, 0, 0, 3);

    protected virtual TimeSpan ThreadFrameSleep { get; set; } = new(0, 0, 0, 0, 1);

    public bool IsRunning
    {
        get
        {
            lock (_threadLock)
            {
                return _thread != null && _thread.IsAlive;
            }
        }
    }

    public virtual void Dispose()
    {
        Stop();
        GC.SuppressFinalize(this);
    }

    public void Start()
    {
        lock (_threadLock)
        {
            if (IsRunning) return;

            _cancellationTokenSource = new CancellationTokenSource();
            _thread = new Thread(() => ThreadStart(_cancellationTokenSource.Token))
            {
                Name = ThreadName,
                IsBackground = true
            };
            _thread.Start();
        }
    }

    public void Stop()
    {
        Thread? thread;
        CancellationTokenSource? tokenSource;

        lock (_threadLock)
        {
            thread = _thread;
            tokenSource = _cancellationTokenSource;
            _thread = null;
            _cancellationTokenSource = null;
        }

        if (thread == null) return;

        try
        {
            tokenSource?.Cancel();
            if (!thread.Join(ThreadTimeout))
            {
                thread.Interrupt();
                thread.Join();
            }
        }
        catch (ThreadInterruptedException)
        {
        }
        finally
        {
            tokenSource?.Dispose();
        }
    }

    private void ThreadStart(CancellationToken cancellationToken)
    {
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    FrameAction();
                }
                catch (NullReferenceException)
                {
                }

                if (cancellationToken.WaitHandle.WaitOne(ThreadFrameSleep))
                    break;
            }
        }
        catch (ThreadInterruptedException)
        {
        }
    }

    protected abstract void FrameAction();
}
