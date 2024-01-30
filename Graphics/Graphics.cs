using System.Windows.Threading;
using CS2Cheat.Core.Data;
using CS2Cheat.Data.Game;
using CS2Cheat.Features;
using CS2Cheat.Utils;
using SharpDX;
using SharpDX.Direct3D9;
using static System.Windows.Application;
using Color = SharpDX.Color;
using Font = SharpDX.Direct3D9.Font;
using FontWeight = SharpDX.Direct3D9.FontWeight;

namespace CS2Cheat.Graphics;

public class Graphics : ThreadedServiceBase
{
    private static readonly VertexElement[] VertexElements =
    {
        new(0, 0, DeclarationType.Float4, DeclarationMethod.Default, DeclarationUsage.PositionTransformed, 0),
        new(0, 16, DeclarationType.Color, DeclarationMethod.Default, DeclarationUsage.Color, 0),
        VertexElement.VertexDeclarationEnd
    };


    public Graphics(GameProcess gameProcess, GameData gameData, WindowOverlay windowOverlay)
    {
        WindowOverlay = windowOverlay;
        OldRes = new Vector2(WindowOverlay.Window.Width, WindowOverlay.Window.Height);
        GameProcess = gameProcess;
        GameData = gameData;

        InitDevice();
    }

    protected override string ThreadName => nameof(Graphics);

    private WindowOverlay WindowOverlay { get; set; }
    private Vector2 OldRes { get; set; }
    public GameProcess GameProcess { get; private set; }
    public GameData GameData { get; private set; }
    private Device Device { get; set; }
    private Font FontAzonix64 { get; set; }
    public Font FontConsolas32 { get; set; }
    private List<Vertex> Vertices { get; } = [];


    public override void Dispose()
    {
        base.Dispose();

        FontAzonix64.Dispose();
        FontAzonix64 = default;
        FontConsolas32.Dispose();
        FontConsolas32 = default;
        Device.Dispose();
        Device = default;

        GameData = default;
        GameProcess = default;
        WindowOverlay = default;
    }

    private void InitDevice()
    {
        var parameters = new PresentParameters
        {
            Windowed = true,
            SwapEffect = SwapEffect.Discard,
            DeviceWindowHandle = WindowOverlay.Window.Handle,
            MultiSampleQuality = 0,
            BackBufferFormat = Format.A8R8G8B8,
            BackBufferWidth = WindowOverlay.Window.Width,
            BackBufferHeight = WindowOverlay.Window.Height,
            EnableAutoDepthStencil = true,
            AutoDepthStencilFormat = Format.D16,
            PresentationInterval = PresentInterval.Immediate,
            MultiSampleType = MultisampleType.TwoSamples
        };

        Device = new Device(new Direct3D(), 0, DeviceType.Hardware, WindowOverlay.Window.Handle,
            CreateFlags.HardwareVertexProcessing, parameters);

        var azonix64 = new FontDescription
        {
            Height = 64,
            Italic = false,
            CharacterSet = FontCharacterSet.Ansi,
            FaceName = "Tahoma",
            MipLevels = 0,
            OutputPrecision = FontPrecision.TrueType,
            PitchAndFamily = FontPitchAndFamily.Default,
            Quality = FontQuality.ClearType,
            Weight = FontWeight.Regular
        };
        FontAzonix64 = new Font(Device, azonix64);

        var consolas32 = new FontDescription
        {
            Height = 14,
            Italic = false,
            CharacterSet = FontCharacterSet.Ansi,
            FaceName = "Verdana",
            MipLevels = 0,
            OutputPrecision = FontPrecision.TrueType,
            PitchAndFamily = FontPitchAndFamily.Default,
            Quality = FontQuality.ClearType,
            Weight = FontWeight.Regular
        };
        FontConsolas32 = new Font(Device, consolas32);
    }

    protected override void FrameAction()
    {
        if (!GameProcess.IsValid) return;

        var newRes = new Vector2(WindowOverlay.Window.Width, WindowOverlay.Window.Height);
        if (!Equals(OldRes, newRes))
            Current.Dispatcher.Invoke(() =>
            {
                Device.Dispose();
                FontAzonix64.Dispose();
                FontConsolas32.Dispose();
                Vertices.Clear();
                InitDevice();
            }, DispatcherPriority.Render);

        OldRes = newRes;

        Current.Dispatcher.Invoke(() =>
        {
            Device.SetRenderState(RenderState.AlphaBlendEnable, true);
            Device.SetRenderState(RenderState.AlphaTestEnable, false);
            Device.SetRenderState(RenderState.SourceBlend, Blend.SourceAlpha);
            Device.SetRenderState(RenderState.DestinationBlend, Blend.InverseSourceAlpha);
            Device.SetRenderState(RenderState.Lighting, false);
            Device.SetRenderState(RenderState.CullMode, Cull.None);
            Device.SetRenderState(RenderState.ZEnable, true);
            Device.SetRenderState(RenderState.ZFunc, Compare.Always);

            Device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.FromAbgr(0), 1, 0);

            Device.BeginScene();
            Render();
            Device.EndScene();

            Device.Present();
        }, DispatcherPriority.Normal);
    }


    private void Render()
    {
        Vertices.Clear();

        Draw();

        var count = Vertices.Count;
        var vertices = new VertexBuffer(Device, count * 20, Usage.WriteOnly, VertexFormat.None, Pool.Managed);
        vertices.Lock(0, 0, LockFlags.None)
            .WriteRange(Vertices.ToArray());
        vertices.Unlock();

        Device.SetStreamSource(0, vertices, 0, 20);
        var vertexDecl = new VertexDeclaration(Device, VertexElements);
        Device.VertexDeclaration = vertexDecl;
        Device.DrawPrimitives(PrimitiveType.LineList, 0, count / 2);

        vertices.Dispose();
        vertexDecl.Dispose();
    }

    private void Draw()
    {
        // draw here
        EspAimCrosshair.Draw(this);
        WindowOverlay.Draw(GameProcess, this);
        SkeletonEsp.Draw(this);
        EspBox.Draw(this);
    }


    public void DrawLine(Color color, params Vector2[] verts)
    {
        if (verts.Length < 2 || verts.Length % 2 != 0) return;

        foreach (var vertex in verts)
            Vertices.Add(new Vertex { Color = color, Position = new Vector4(vertex.X, vertex.Y, 0.5f, 1.0f) });
    }

    public void DrawLineWorld(Color color, params Vector3[] verticesWorld)
    {
        var verticesScreen = verticesWorld
            .Select(v => GameData.Player.MatrixViewProjectionViewport.Transform(v))
            .Where(v => v.Z < 1)
            .Select(v => new Vector2(v.X, v.Y)).ToArray();
        DrawLine(color, verticesScreen);
    }

    public void DrawRectangle(Color color, Vector2 topLeft, Vector2 bottomRight)
    {
        var verts = new Vector2[]
        {
            new(topLeft.X, topLeft.Y),
            new(bottomRight.X, topLeft.Y),
            new(bottomRight.X, bottomRight.Y),
            new(topLeft.X, bottomRight.Y),
            new(topLeft.X, topLeft.Y)
        };

        for (var i = 0; i < verts.Length - 1; i++) DrawLine(color, verts[i], verts[i + 1]);
    }
}