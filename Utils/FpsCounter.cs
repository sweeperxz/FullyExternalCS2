using System.Diagnostics;

namespace CS2Cheat.Utils;

public class FpsCounter
{
    #region

    public void Update()
    {
        var fpsTimerElapsed = FpsTimer.Elapsed;
        if (fpsTimerElapsed > TimeSpanFpsUpdate)
        {
            Fps = (int)(FpsFrameCount / fpsTimerElapsed.TotalSeconds);
            FpsTimer.Restart();
            FpsFrameCount = 0;
        }

        FpsFrameCount++;
    }

    #endregion

    #region

    private static readonly TimeSpan TimeSpanFpsUpdate = new(0, 0, 0, 1);


    private Stopwatch FpsTimer { get; } = Stopwatch.StartNew();


    private int FpsFrameCount { get; set; }


    public int Fps { get; private set; }

    #endregion
}