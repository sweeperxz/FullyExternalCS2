using System.Numerics;
using ClickableTransparentOverlay;
using CS2Cheat.Core;
using CS2Cheat.Data.Game;
using CS2Cheat.Features;
using CS2Cheat.Utils;
using ImGuiNET;
using Keys = Process.NET.Native.Types.Keys;

namespace CS2Cheat.Graphics;

public class OverlayRenderer : Overlay
{
    private readonly GameProcess _gameProcess;
    private readonly GameData _gameData;
    private ConfigManager _config;
    private bool _showMenu, _menuKeyWasDown, _styleApplied;
    private int _activeTab;
    private string? _waitingForBind;
    private readonly BombTimer _bombTimer;
    private readonly VoteTeller _voteTeller;
    private readonly AimBot _aimBot;
    private readonly TriggerBot _triggerBot;
    private float _menuAlpha;

    static readonly Vector4 ColBg = new(0.10f, 0.11f, 0.14f, 0.97f);
    static readonly Vector4 ColSidebar = new(0.08f, 0.09f, 0.11f, 1f);
    static readonly Vector4 ColAccent = new(0f, 0.47f, 1f, 1f);
    static readonly Vector4 ColAccentDim = new(0f, 0.35f, 0.8f, 1f);
    static readonly Vector4 ColText = new(0.85f, 0.85f, 0.88f, 1f);
    static readonly Vector4 ColTextDim = new(0.45f, 0.47f, 0.52f, 1f);
    static readonly Vector4 ColItem = new(0.14f, 0.15f, 0.19f, 1f);
    static readonly Vector4 ColItemHover = new(0.18f, 0.19f, 0.24f, 1f);
    static readonly Vector4 ColItemActive = new(0.12f, 0.13f, 0.17f, 1f);
    static readonly Vector4 ColBorder = new(0.18f, 0.20f, 0.25f, 0.5f);

    static readonly string[] TabNames = { "\u2022 Aimbot", "\u2022 Visuals", "\u2022 Misc", "\u2022 Settings", "\u2022 Config" };

    public OverlayRenderer(GameProcess gp, GameData gd) : base(true)
    {
        _gameProcess = gp; _gameData = gd;
        _config = ConfigManager.Load();
        _bombTimer = new BombTimer(gp);
        _voteTeller = new VoteTeller(gp);
        _aimBot = new AimBot(gp, gd);
        _triggerBot = new TriggerBot(gp, gd);
    }

    protected override Task PostInitialized()
    {
        var h = this.window.Handle;
        var ex = User32.GetWindowLong(h, User32.GWL_EXSTYLE);
        User32.SetWindowLong(h, User32.GWL_EXSTYLE, ex | User32.WS_EX_NOACTIVATE | User32.WS_EX_TOOLWINDOW);
        UpdateOverlayGeometry();
        
        return Task.CompletedTask;
    }

    protected override void Render()
    {
        UpdateOverlayGeometry();
        if (!_gameProcess.IsValid) return;
        _config = ConfigManager.Load();

        var mk = _config.MenuToggleKey;
        var mkd = mk.IsKeyDown();
        if (mkd && !_menuKeyWasDown) _showMenu = !_showMenu;
        _menuKeyWasDown = mkd;

        _menuAlpha = _showMenu ? Math.Min(_menuAlpha + 0.08f, 1f) : Math.Max(_menuAlpha - 0.08f, 0f);

        if (_menuAlpha > 0.01f)
        {
            var io = ImGui.GetIO();
            ImGui.SetNextWindowPos(Vector2.Zero);
            ImGui.SetNextWindowSize(io.DisplaySize);
            ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, Vector2.Zero);
            ImGui.PushStyleColor(ImGuiCol.WindowBg, new Vector4(0, 0, 0, 0.01f));
            ImGui.Begin("##bd", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize |
                ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar |
                ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoFocusOnAppearing | ImGuiWindowFlags.NoNav);
            ImGui.End();
            ImGui.PopStyleColor();
            ImGui.PopStyleVar();
            RenderMenu();
        }

        var dl = ImGui.GetBackgroundDrawList();
        RenderVisuals(dl);
        dl.AddText(new Vector2(5, 5), Colors.White, $"{ImGui.GetIO().Framerate:0} FPS");
    }

    void ApplyStyle()
    {
        if (_styleApplied) return;
        ImGui.StyleColorsDark();
        var s = ImGui.GetStyle();
        s.WindowRounding = 4;
        s.FrameRounding = 3;
        s.GrabRounding = 3;
        _styleApplied = true;
    }

    void RenderMenu()
    {
        ApplyStyle();
        ImGui.PushStyleVar(ImGuiStyleVar.Alpha, _menuAlpha);

        var menuSize = new Vector2(520, 420);
        var io = ImGui.GetIO();
        var pos = (io.DisplaySize - menuSize) * 0.5f;
        ImGui.SetNextWindowPos(pos, ImGuiCond.Always);
        ImGui.SetNextWindowSize(menuSize, ImGuiCond.Always);
        ImGui.Begin("##main", ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoResize |
            ImGuiWindowFlags.NoMove | ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoCollapse);

        ImGui.PushStyleColor(ImGuiCol.ChildBg, ColSidebar);
        ImGui.BeginChild("##sidebar", new Vector2(150, 0), ImGuiChildFlags.None);
        ImGui.SetCursorPos(new Vector2(16, 16));
        ImGui.PushStyleColor(ImGuiCol.Text, ColAccent);
        ImGui.Text("CS2 EXTERNAL");
        ImGui.PopStyleColor();
        ImGui.SetCursorPosY(48);
        ImGui.Separator();
        ImGui.SetCursorPosY(58);

        for (int i = 0; i < TabNames.Length; i++)
        {
            ImGui.SetCursorPosX(8);
            bool sel = _activeTab == i;
            if (sel) ImGui.PushStyleColor(ImGuiCol.Text, ColAccent);
            ImGui.PushStyleVar(ImGuiStyleVar.FramePadding, new Vector2(8, 8));
            if (ImGui.Selectable(TabNames[i], sel, ImGuiSelectableFlags.None, new Vector2(134, 28)))
                _activeTab = i;
            ImGui.PopStyleVar();
            if (sel) ImGui.PopStyleColor();
        }

        ImGui.SetCursorPosY(ImGui.GetWindowHeight() - 50);
        ImGui.Separator();
        ImGui.SetCursorPosX(12);
        ImGui.TextColored(ColTextDim, $"{io.Framerate:0} fps");
        ImGui.SetCursorPosX(12);
        ImGui.TextColored(ColTextDim, $"{_gameProcess.WindowRectangleClient.Width}x{_gameProcess.WindowRectangleClient.Height}");

        ImGui.EndChild();
        ImGui.PopStyleColor();

        ImGui.SameLine();
        ImGui.PushStyleVar(ImGuiStyleVar.WindowPadding, new Vector2(20, 16));
        ImGui.BeginChild("##content", Vector2.Zero, ImGuiChildFlags.None);

        switch (_activeTab)
        {
            case 0: TabAimbot(); break;
            case 1: TabVisuals(); break;
            case 2: TabMisc(); break;
            case 3: TabSettings(); break;
            case 4: TabConfig(); break;
        }

        ImGui.EndChild();
        ImGui.PopStyleVar();
        ImGui.End();
        ImGui.PopStyleVar();
    }

    void TabAimbot()
    {
        SectionHeader("Aimbot");
        var aimBot = _config.AimBot;
        if (Toggle("Enabled", ref aimBot)) _config.AimBot = aimBot;

        var aimFovCircle = _config.AimFovCircle;
        if (Toggle("Show FOV Circle", ref aimFovCircle)) _config.AimFovCircle = aimFovCircle;

        ImGui.Spacing();
        var fov = _config.AimFov;
        if (ImGui.SliderFloat("FOV", ref fov, 1f, 60f, "%.1f°"))
        { _config.AimFov = fov; ConfigManager.UpdateCache(_config); }

        var smooth = _config.AimSmoothing;
        if (ImGui.SliderFloat("Smoothing", ref smooth, 1f, 20f, "%.1f"))
        { _config.AimSmoothing = smooth; ConfigManager.UpdateCache(_config); }

        var bone = _config.AimBoneIndex;
        if (ImGui.Combo("Target Bone", ref bone, ConfigManager.BoneDisplayNames, ConfigManager.BoneDisplayNames.Length))
        { _config.AimBoneIndex = bone; ConfigManager.UpdateCache(_config); }

        ImGui.Spacing();
        SectionHeader("Recoil Control (RCS)");
        var aimRcs = _config.AimRcs;
        if (Toggle("Enable RCS", ref aimRcs)) _config.AimRcs = aimRcs;
        if (aimRcs)
        {
            var rcsStrength = _config.AimRcsStrength;
            if (ImGui.SliderFloat("RCS Strength (%)", ref rcsStrength, 0f, 100f, "%.0f%%"))
            { _config.AimRcsStrength = rcsStrength; ConfigManager.UpdateCache(_config); }
        }

    }

    void TabVisuals()
    {
        SectionHeader("ESP");
        var espBox = _config.EspBox;
        if (Toggle("ESP Box", ref espBox)) { _config.EspBox = espBox; ConfigManager.UpdateCache(_config); }
        var espName = _config.EspName;
        if (Toggle("Name", ref espName)) { _config.EspName = espName; ConfigManager.UpdateCache(_config); }
        var espWeapon = _config.EspWeapon;
        if (Toggle("Weapon", ref espWeapon)) { _config.EspWeapon = espWeapon; ConfigManager.UpdateCache(_config); }
        var espFlags = _config.EspFlags;
        if (Toggle("Flags", ref espFlags)) { _config.EspFlags = espFlags; ConfigManager.UpdateCache(_config); }

        var boxColorVec = new Vector4(_config.EspBoxColor[0], _config.EspBoxColor[1], _config.EspBoxColor[2], _config.EspBoxColor[3]);
        if (ImGui.ColorEdit4("Box Color", ref boxColorVec))
        {
            _config.EspBoxColor[0] = boxColorVec.X;
            _config.EspBoxColor[1] = boxColorVec.Y;
            _config.EspBoxColor[2] = boxColorVec.Z;
            _config.EspBoxColor[3] = boxColorVec.W;
            ConfigManager.UpdateCache(_config);
        }

        var skeletonEsp = _config.SkeletonEsp;
        if (Toggle("Skeleton", ref skeletonEsp)) _config.SkeletonEsp = skeletonEsp;
        var espAimCrosshair = _config.EspAimCrosshair;
        if (Toggle("Aim Crosshair", ref espAimCrosshair)) _config.EspAimCrosshair = espAimCrosshair;

        ImGui.Spacing();
        SectionHeader("World");
        var bombTimer = _config.BombTimer;
        if (Toggle("Bomb Timer", ref bombTimer)) _config.BombTimer = bombTimer;
        var voteTeller = _config.VoteTeller;
        if (Toggle("Vote Teller", ref voteTeller)) _config.VoteTeller = voteTeller;
    }

    void TabMisc()
    {
        SectionHeader("Combat");
        var triggerBot = _config.TriggerBot;
        if (Toggle("TriggerBot", ref triggerBot)) _config.TriggerBot = triggerBot;

        ImGui.Spacing();
        SectionHeader("General");
        var teamCheck = _config.TeamCheck;
        if (Toggle("Team Check", ref teamCheck)) _config.TeamCheck = teamCheck;
    }

    void TabSettings()
    {
        SectionHeader("Key Binds");
        DrawKeyBind("AimBot", "AimBotKey", _config.AimBotKey);
        DrawKeyBind("Recoil Control", "AimRcsKey", _config.AimRcsKey);
        DrawKeyBind("TriggerBot", "TriggerBotKey", _config.TriggerBotKey);
        DrawKeyBind("Menu Toggle", "MenuToggleKey", _config.MenuToggleKey);
    }

    void TabConfig()
    {
        SectionHeader("Configuration");

        ImGui.PushStyleColor(ImGuiCol.Button, ColAccent);
        ImGui.PushStyleColor(ImGuiCol.ButtonHovered, ColAccentDim);
        if (ImGui.Button("Save Config", new Vector2(200, 32)))
            ConfigManager.Save(_config);
        ImGui.PopStyleColor(2);

        ImGui.Spacing();
        if (ImGui.Button("Reload Config", new Vector2(200, 32)))
        { ConfigManager.Reload(); _config = ConfigManager.Load(); }

        ImGui.Spacing();
        if (ImGui.Button("Reset Defaults", new Vector2(200, 32)))
        { _config = ConfigManager.Default(); ConfigManager.Save(_config); }

        ImGui.Spacing(); ImGui.Spacing();
        SectionHeader("Info");
        ImGui.TextColored(ColTextDim, "Version: 2.0 ImGui");
        ImGui.TextColored(ColTextDim, $"Game: {(_gameProcess.IsGameForeground ? "Active" : "Background")}");
    }

    void SectionHeader(string text)
    {
        ImGui.TextColored(ColAccent, text.ToUpper());
        ImGui.Spacing();
    }

    bool Toggle(string label, ref bool value)
    {
        if (ImGui.Checkbox(label, ref value))
        {
            ConfigManager.UpdateCache(_config);
            return true;
        }
        return false;
    }

    void DrawKeyBind(string label, string bindId, Keys currentKey)
    {
        ImGui.PushID(bindId);
        bool isWaiting = _waitingForBind == bindId;
        string btnText = isWaiting ? "[ ... ]" : $"[ {ConfigManager.GetKeyName(currentKey)} ]";

        ImGui.Text(label);
        ImGui.SameLine(200);

        if (isWaiting)
        {
            ImGui.PushStyleColor(ImGuiCol.Button, new Vector4(0.7f, 0.15f, 0.15f, 1f));
            ImGui.PushStyleColor(ImGuiCol.ButtonHovered, new Vector4(0.8f, 0.2f, 0.2f, 1f));
        }

        if (ImGui.Button(btnText, new Vector2(110, 0)))
            _waitingForBind = isWaiting ? null : bindId;

        if (isWaiting)
        {
            ImGui.PopStyleColor(2);
            var k = ScanKey();
            if (k != Keys.None)
            {
                if (k == Keys.Escape) { _waitingForBind = null; }
                else
                {
                    switch (bindId)
                    {
                        case "AimBotKey": _config.AimBotKey = k; break;
                        case "AimRcsKey": _config.AimRcsKey = k; break;
                        case "TriggerBotKey": _config.TriggerBotKey = k; break;
                        case "MenuToggleKey": _config.MenuToggleKey = k; break;
                    }
                    ConfigManager.UpdateCache(_config);
                    _waitingForBind = null;
                }
            }
        }
        ImGui.PopID();
    }

    static Keys ScanKey()
    {
        Keys[] keys = {
            Keys.LButton, Keys.RButton, Keys.MButton, Keys.XButton1, Keys.XButton2,
            Keys.LMenu, Keys.RMenu, Keys.LShiftKey, Keys.RShiftKey, Keys.LControlKey, Keys.RControlKey,
            Keys.Insert, Keys.Delete, Keys.Home, Keys.End, Keys.Capital, Keys.Tab, Keys.Space,
            Keys.F1,Keys.F2,Keys.F3,Keys.F4,Keys.F5,Keys.F6,Keys.F7,Keys.F8,Keys.F9,Keys.F10,Keys.F11,Keys.F12,
            Keys.Q,Keys.W,Keys.E,Keys.R,Keys.T,Keys.Y,Keys.U,Keys.I,Keys.O,Keys.P,
            Keys.A,Keys.S,Keys.D,Keys.F,Keys.G,Keys.H,Keys.J,Keys.K,Keys.L,
            Keys.Z,Keys.X,Keys.C,Keys.V,Keys.B,Keys.N,Keys.M,
            Keys.D0,Keys.D1,Keys.D2,Keys.D3,Keys.D4,Keys.D5,Keys.D6,Keys.D7,Keys.D8,Keys.D9,
            Keys.Escape
        };
        foreach (var k in keys) if (k.IsKeyDown()) return k;
        return Keys.None;
    }

    void UpdateOverlayGeometry()
    {
        var r = _gameProcess.WindowRectangleClient;
        if (r.Width <= 0 || r.Height <= 0) return;
        try
        {
            var ts = new System.Drawing.Size(r.Width, r.Height);
            var tp = new System.Drawing.Point(r.X, r.Y);
            if (this.Size != ts) this.Size = ts;
            if (this.Position != tp) this.Position = tp;
        }
        catch { }
    }

    void RenderVisuals(ImDrawListPtr dl)
    {
        if (_config.EspBox) EspBox.Draw(dl, _gameData);
        if (_config.SkeletonEsp) SkeletonEsp.Draw(dl, _gameData);
        if (_config.EspAimCrosshair) EspAimCrosshair.Draw(dl, _gameData, _gameProcess);
        if (_config.BombTimer) BombTimer.Draw(dl);
        if (_config.VoteTeller) VoteTeller.Draw(dl);

        if (_config.AimFovCircle)
        {
            var io = ImGui.GetIO();
            var center = new Vector2(io.DisplaySize.X / 2, io.DisplaySize.Y / 2);
            var radius = (float)(Math.Tan((_config.AimFov * Math.PI / 180.0) / 2.0) / Math.Tan((90.0 * Math.PI / 180.0) / 2.0) * (io.DisplaySize.X / 2.0));
            dl.AddCircle(center, radius, Colors.WhiteSmoke, 64, 1.0f);
        }
    }

    public void StartFeatures() { _bombTimer.Start(); _voteTeller.Start(); _triggerBot.Start(); _aimBot.Start(); }
    public void StopFeatures() { _bombTimer.Dispose(); _voteTeller.Dispose(); _triggerBot.Dispose(); _aimBot.Dispose(); }

    public static uint ToColor(byte r, byte g, byte b, byte a = 255) =>
        ImGui.ColorConvertFloat4ToU32(new Vector4(r/255f, g/255f, b/255f, a/255f));
    public static uint ToColor(Vector4 c) => ImGui.ColorConvertFloat4ToU32(c);

    public static class Colors
    {
        public static readonly uint White = ToColor(255,255,255);
        public static readonly uint Red = ToColor(255,0,0);
        public static readonly uint DarkRed = ToColor(139,0,0);
        public static readonly uint Green = ToColor(0,255,0);
        public static readonly uint LimeGreen = ToColor(50,205,50);
        public static readonly uint Blue = ToColor(0,0,255);
        public static readonly uint DarkBlue = ToColor(0,0,139);
        public static readonly uint Yellow = ToColor(255,255,0);
        public static readonly uint OrangeRed = ToColor(255,69,0);
        public static readonly uint DeepSkyBlue = ToColor(0,191,255);
        public static readonly uint WhiteSmoke = ToColor(245,245,245);
        public static readonly uint Black = ToColor(0,0,0);
        public static readonly uint DarkGray = ToColor(169,169,169);
    }
}
