using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using CS2Cheat.Core;
using CS2Cheat.Core.Data;
using Process.NET.Native.Types;
using SharpDX;
using static System.Diagnostics.Process;
using Keys = Process.NET.Native.Types.Keys;
using Rectangle = System.Drawing.Rectangle;


namespace CS2Cheat.Utils;

public static class Utility
{
    public enum InputType
    {
        Mouse = 0,
        Keyboard = 1,
        Hardware = 2
    }

    [Flags]
    public enum MouseFlags : uint
    {
        Move = 0x0001,


        LeftDown = 0x0002,


        LeftUp = 0x0004,


        RightDown = 0x0008,


        RightUp = 0x0010,

        MiddleDown = 0x0020,


        MiddleUp = 0x0040,


        XDown = 0x0080,


        XUp = 0x0100,


        VerticalWheel = 0x0800,


        HorizontalWheel = 0x1000,


        VirtualDesk = 0x4000,


        Absolute = 0x8000
    }

    private const double PiOver180 = Math.PI / 180.0;

    public static double DegreeToRadian(this double degree)
    {
        return degree * PiOver180;
    }

    public static float DegreeToRadian(this float degree)
    {
        return (float)(degree * PiOver180);
    }


    public static Rectangle GetClientRectangle(IntPtr handle)
    {
        return User32.ClientToScreen(handle, out var point) && User32.GetClientRect(handle, out var rect)
            ? new Rectangle(point.X, point.Y, rect.Right - rect.Left, rect.Bottom - rect.Top)
            : default;
    }


    public static Module GetModule(this System.Diagnostics.Process process, string moduleName)
    {
        var processModule = process.GetProcessModule(moduleName);
        return processModule is null || processModule.BaseAddress == IntPtr.Zero
            ? default
            : new Module(process, processModule);
    }


    private static ProcessModule GetProcessModule(this System.Diagnostics.Process process,
        string moduleName)
    {
        return process?.Modules.OfType<ProcessModule>()
            .FirstOrDefault(a => string.Equals(a.ModuleName.ToLower(), moduleName.ToLower()));
    }


    public static bool IsRunning(this System.Diagnostics.Process process)
    {
        try
        {
            GetProcessById(process.Id);
        }
        catch (InvalidOperationException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        return true;
    }

    public static Team ToTeam(this int teamNum)
    {
        return teamNum switch
        {
            1 => Team.Spectator,
            2 => Team.Terrorists,
            3 => Team.CounterTerrorists,
            _ => Team.Unknown
        };
    }

    public static bool IsKeyDown(this Keys key)
    {
        return (User32.GetAsyncKeyState((int)key) & 0x8000) != 0;
    }


    public static void MouseMove(int x, int y)
    {
        var inputs = new Input[1];

        inputs[0] = new Input
        {
            Type = InputType.Mouse,
            Union = new InputUnion
            {
                mouse = new MouseInput
                {
                    deltaX = x,
                    deltaY = y,
                    flags = MouseFlags.Move
                }
            }
        };

        User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }


    public static void MouseLeftDown()
    {
        var inputs = new Input[1];

        inputs[0] = new Input
        {
            Type = InputType.Mouse,
            Union = new InputUnion
            {
                mouse = new MouseInput
                {
                    flags = MouseFlags.LeftDown
                }
            }
        };

        User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }


    public static void MouseLeftUp()
    {
        var inputs = new Input[1];

        inputs[0] = new Input
        {
            Type = InputType.Mouse,
            Union = new InputUnion
            {
                mouse = new MouseInput
                {
                    flags = MouseFlags.LeftUp
                }
            }
        };

        User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }

    public static void PressSpace()
    {
        var inputs = new Input[2];

        inputs[0] = new Input
        {
            Type = InputType.Keyboard,
            Union = new InputUnion
            {
                keyboard = new KeyboardInput
                {
                    virtualKey = (ushort)Keys.Right,
                    scanCode = 0,
                    flags = 0,
                    timeStamp = 0,
                    extraInfo = IntPtr.Zero
                }
            }
        };

        inputs[1] = new Input
        {
            Type = InputType.Keyboard,
            Union = new InputUnion
            {
                keyboard = new KeyboardInput
                {
                    virtualKey = (ushort)Keys.Right,
                    scanCode = 0,
                    flags = KeyboardFlags.KeyUp,
                    timeStamp = 0,
                    extraInfo = IntPtr.Zero
                }
            }
        };

        User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
        public ushort virtualKey;
        public ushort scanCode;
        public KeyboardFlags flags;
        public uint timeStamp;
        public IntPtr extraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        public int deltaX;
        public int deltaY;
        public int mouseData;
        public MouseFlags flags;
        public uint time;
        public IntPtr extraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HardwareInput
    {
        public uint message;
        public ushort wParamL;
        public ushort wParamH;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)] public MouseInput mouse;
        [FieldOffset(0)] public KeyboardInput keyboard;
        [FieldOffset(0)] public HardwareInput hardware;
    }

    public struct Input
    {
        public InputType Type;
        public InputUnion Union;
    }


    #region memory

    public static T Read<T>(this System.Diagnostics.Process process, IntPtr lpBaseAddress)
        where T : unmanaged
    {
        return Read<T>(process.Handle, lpBaseAddress);
    }


    public static T Read<T>(this Module module, int offset)
        where T : unmanaged
    {
        return Read<T>(module.Process.Handle, module.ProcessModule.BaseAddress + offset);
    }


    private static T Read<T>(IntPtr hProcess, IntPtr lpBaseAddress)
        where T : unmanaged
    {
        var size = Marshal.SizeOf<T>();
        var buffer = default(T) as object;
        Kernel32.ReadProcessMemory(hProcess, lpBaseAddress, buffer, size, out var lpNumberOfBytesRead);
        return lpNumberOfBytesRead == size ? (T)buffer : default;
    }

    public static string ReadString(this System.Diagnostics.Process process, IntPtr lpBaseAddress, int maxLength = 256)
    {
        var buffer = ReadBytes(process.Handle, lpBaseAddress, maxLength);
        var nullCharIndex = Array.IndexOf(buffer, (byte)'\0');
        return nullCharIndex >= 0
            ? Encoding.UTF8.GetString(buffer.AsSpan(0, nullCharIndex + 1)).Trim()
            : Encoding.UTF8.GetString(buffer).Trim();
    }

    private static byte[] ReadBytes(IntPtr hProcess, IntPtr lpBaseAddress, int maxLength)
    {
        var buffer = new byte[maxLength];
        Kernel32.ReadProcessMemory(hProcess, lpBaseAddress, buffer, maxLength, out _);
        return buffer;
    }


    public static Matrix GetMatrixViewport(Size screenSize)
    {
        return GetMatrixViewport(new Viewport
        {
            X = 0,
            Y = 0,
            Width = screenSize.Width,
            Height = screenSize.Height,
            MinDepth = 0,
            MaxDepth = 1
        });
    }

    private static Matrix GetMatrixViewport(in Viewport viewport)
    {
        return new Matrix
        {
            M11 = viewport.Width * 0.5f,
            M12 = 0,
            M13 = 0,
            M14 = 0,

            M21 = 0,
            M22 = -viewport.Height * 0.5f,
            M23 = 0,
            M24 = 0,

            M31 = 0,
            M32 = 0,
            M33 = viewport.MaxDepth - viewport.MinDepth,
            M34 = 0,

            M41 = viewport.X + viewport.Width * 0.5f,
            M42 = viewport.Y + viewport.Height * 0.5f,
            M43 = viewport.MinDepth,
            M44 = 1
        };
    }

    #endregion
}