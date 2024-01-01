using CS2Cheat.Utils;

namespace CS2Cheat.Data;

public class GameData(GameProcess gameProcess) : ThreadedServiceBase
{
    #region properties

    protected override string ThreadName => nameof(GameData);

    private GameProcess GameProcess { get; set; } = gameProcess;

    public Player Player { get; set; } = new();

    #endregion

    #region methods

    public override void Dispose()
    {
        base.Dispose();

        Player = default;
        GameProcess = default;
    }

    protected override void FrameAction()
    {
        if (!GameProcess.IsValid) return;
        Player.Update(GameProcess);
    }

    #endregion
}