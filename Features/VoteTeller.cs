using System.Numerics;
using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using ImGuiNET;

namespace CS2Cheat.Features;

internal class VoteTeller : ThreadedServiceBase
{
    private const int EntityListEntryOffset = 16;
    private const int EntityListStride = 112;
    private const int VoteControllerStartIndex = 64;
    private const int VoteControllerMaxIndex = 8192;

    private readonly GameProcess _gameProcess;

    private static bool _isVoting;
    private static int _votingTeam;
    private static int _yesVotes;
    private static int _noVotes;
    private static int _activeIssue;

    public VoteTeller(GameProcess gameProcess)
    {
        _gameProcess = gameProcess;
    }

    protected override void FrameAction()
    {
        if (!_gameProcess.IsValid || _gameProcess.ModuleClient == null || _gameProcess.Process == null)
        {
            ResetVote();
            return;
        }

        var entityList = _gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList);
        if (entityList == IntPtr.Zero)
        {
            ResetVote();
            return;
        }

        var voteController = FindVoteController(entityList);
        if (voteController == IntPtr.Zero)
        {
            ResetVote();
            return;
        }

        _activeIssue = _gameProcess.Process.Read<int>(voteController + 1552);
        _votingTeam = _gameProcess.Process.Read<int>(voteController + 1556);
        _yesVotes = _gameProcess.Process.Read<int>(voteController + 1560);
        _noVotes = _gameProcess.Process.Read<int>(voteController + 1564);
        _isVoting = _activeIssue > 0;
    }

    private IntPtr FindVoteController(IntPtr entityList)
    {
        if (_gameProcess.Process == null) return IntPtr.Zero;

        for (var i = VoteControllerStartIndex; i < VoteControllerMaxIndex; i++)
        {
            var listEntry = _gameProcess.Process.Read<IntPtr>(entityList + 8 * (i >> 9) + EntityListEntryOffset);
            if (listEntry == IntPtr.Zero) continue;

            var entity = _gameProcess.Process.Read<IntPtr>(listEntry + EntityListStride * (i & 0x1FF));
            if (entity == IntPtr.Zero) continue;

            var entityIdentity = _gameProcess.Process.Read<IntPtr>(entity + 0x10);
            if (entityIdentity == IntPtr.Zero) continue;

            var designerNamePtr = _gameProcess.Process.Read<IntPtr>(entityIdentity + 0x20);
            if (designerNamePtr == IntPtr.Zero) continue;

            var designerName = _gameProcess.Process.ReadString(designerNamePtr, 64);
            if (designerName == "vote_controller") return entity;
        }

        return IntPtr.Zero;
    }

    private static void ResetVote()
    {
        _isVoting = false;
        _votingTeam = 0;
        _yesVotes = 0;
        _noVotes = 0;
        _activeIssue = 0;
    }

    public static void Draw(ImDrawListPtr drawList)
    {
        if (!_isVoting) return;

        var teamName = _votingTeam == 2 ? "TERRORISTS" : _votingTeam == 3 ? "COUNTER-TERRORISTS" : "ALL";
        var color = _votingTeam == 2 ? OverlayRenderer.Colors.OrangeRed : OverlayRenderer.Colors.DeepSkyBlue;
        var text = $"Vote: {teamName}\nIssue ID: {_activeIssue}\nYes: {_yesVotes} | No: {_noVotes}";

        var font = ImGui.GetFont();
        var fontSize = ImGui.GetFontSize() * 1.4f;
        var position = new Vector2(10, 350);

        drawList.AddText(font, fontSize, position + new Vector2(1, 1), OverlayRenderer.Colors.Black, text);
        drawList.AddText(font, fontSize, position, color, text);
    }
}
