using System.Diagnostics;

namespace CS2Cheat.Utils;

public class Module(global::System.Diagnostics.Process process, ProcessModule processModule) : IDisposable
{
    #region properties

    public global::System.Diagnostics.Process Process { get; private set; } = process;

    public ProcessModule ProcessModule { get; private set; } = processModule;

    #endregion


    #region routines

    public void Dispose()
    {
        Process.Dispose();
        Process = default;

        ProcessModule.Dispose();
        ProcessModule = default;
    }

    #endregion
}