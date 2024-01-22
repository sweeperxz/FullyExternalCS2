namespace CS2Cheat.Utils;

public abstract class ThreadedServiceBase : IDisposable
{
    #region properties

    protected virtual string ThreadName => nameof(ThreadedServiceBase);

    protected TimeSpan ThreadTimeOut { get; set; } = new(0, 0, 0, 3);

    protected virtual TimeSpan ThreadFrameSleep { get; set; } = new(0, 0, 0, 0, 1);
    private CancellationTokenSource CancellationTokenSource { get; set; }

    private Task Task { get; set; }

    #endregion

    #region routines

    protected ThreadedServiceBase()
    {
        CancellationTokenSource = new CancellationTokenSource();
        Task = new Task(ThreadStart, CancellationTokenSource.Token, TaskCreationOptions.LongRunning);
    }

    public void Start()
    {
        Task.Start();
    }


    private void ThreadStart()
    {
        try
        {
            while (!CancellationTokenSource.IsCancellationRequested)
            {
                FrameAction();
                Thread.Sleep(ThreadFrameSleep);
            }
        }
        catch (ThreadInterruptedException){}
    }

    public virtual void Dispose()
    {
        CancellationTokenSource.Cancel();
        Task.Wait();
        CancellationTokenSource.Dispose();

        Task = null;
        CancellationTokenSource = null;
    }

    protected abstract void FrameAction();

    #endregion
}