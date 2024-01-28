using System.Diagnostics;

namespace CS2Cheat.Utils;

public class Module(System.Diagnostics.Process process, ProcessModule processModule) : IDisposable
{
    #region routines

    public void Dispose()
    {
        Process.Dispose();
        Process = default;

        ProcessModule.Dispose();
        ProcessModule = default;
    }

    #endregion

    #region properties

    public System.Diagnostics.Process Process { get; private set; } = process;

    public ProcessModule ProcessModule { get; private set; } = processModule;

    #endregion
}