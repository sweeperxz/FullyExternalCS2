using CS2Cheat.Utils;
using Color = SharpDX.Color;

namespace CS2Cheat.Features;

internal class BombTimer(Graphics.Graphics graphics) : ThreadedServiceBase
{
    private static string _bombPlanted = string.Empty;
    private static string _bombSite = string.Empty;
    private static bool _isBombPlanted;
    private static float _defuseLeft;
    private static float _timeLeft;
    private static float _defuseCountDown;
    private static float _c4Blow;
    private static bool _beingDefused;
    private float _currentTime;
    private IntPtr _globalVars;
    private IntPtr _plantedC4;
    private IntPtr _tempC4;


    protected override void FrameAction()
    {
        _globalVars = graphics.GameProcess.ModuleClient.Read<IntPtr>(Offsets.dwGlobalVars);
        _currentTime = graphics.GameProcess.Process.Read<float>(_globalVars + 0x2C);
        graphics.GameProcess.Process.Read<float>(_globalVars + 0x30);

        _tempC4 = graphics.GameProcess.ModuleClient.Read<IntPtr>(Offsets.dwPlantedC4);
        _plantedC4 = graphics.GameProcess.Process.Read<IntPtr>(_tempC4);
        _isBombPlanted = graphics.GameProcess.ModuleClient.Read<bool>(Offsets.dwPlantedC4 - 0x8);

        _defuseCountDown = graphics.GameProcess.Process.Read<float>(_plantedC4 + Offsets.m_flDefuseCountDown);
        _c4Blow = graphics.GameProcess.Process.Read<float>(_plantedC4 + Offsets.m_flC4Blow);
        _beingDefused = graphics.GameProcess.Process.Read<bool>(_plantedC4 + Offsets.m_bBeingDefused);

        _timeLeft = _c4Blow - _currentTime;
        _defuseLeft = _defuseCountDown - _currentTime;

        _timeLeft = Math.Max(_timeLeft, 0);
        _defuseLeft = Math.Max(_defuseLeft, 0);

        if (!_beingDefused)
            _defuseLeft = 0;

        if (_isBombPlanted)
            _bombSite = graphics.GameProcess.Process.Read<int>(_plantedC4 + Offsets.m_nBombSite) == 1 ? "B" : "A";

        _bombPlanted = _isBombPlanted ? $"Bomb is planted on site: {_bombSite}" : string.Empty;

        graphics.GameProcess.Process.Read<bool>(_plantedC4 + Offsets.m_bBombDefused);
    }

    public static void Draw(Graphics.Graphics graphics)
    {
        var timerText = _isBombPlanted ? $"Time left: {_timeLeft:0.00} seconds" : " ";
        var defuse = _isBombPlanted ? $"Defuse time: {_defuseLeft:0.00} seconds" : " ";

        graphics.FontAzonix64.DrawText(default,
            $"{_bombPlanted}{Environment.NewLine}{timerText}{Environment.NewLine}{defuse}", 0, 500, Color.WhiteSmoke);
    }
}