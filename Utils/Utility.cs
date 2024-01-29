using System.Diagnostics;
using System.Runtime.InteropServices;
using CS2Cheat.Core;
using CS2Cheat.Core.Data;
using Process.NET.Native.Types;
using SharpDX;
using WindowsInput.Native;
using static System.Diagnostics.Process;
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

    public static bool IsKeyDown(this VirtualKeyCode key)
    {
        return (User32.GetAsyncKeyState((int)key) & 0x8000) != 0;
    }


    public static void MouseMove(int x, int y)
    {
        var inputs = new INPUT[1];

        inputs[0] = new INPUT
        {
            type = InputType.Mouse,
            union = new InputUnion
            {
                mouse = new MOUSEINPUT
                {
                    deltaX = x,
                    deltaY = y,
                    flags = MouseFlags.Move
                }
            }
        };

        User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
    }


    public static void MouseLeftDown()
    {
        var inputs = new INPUT[1];

        inputs[0] = new INPUT
        {
            type = InputType.Mouse,
            union = new InputUnion
            {
                mouse = new MOUSEINPUT
                {
                    flags = MouseFlags.LeftDown
                }
            }
        };

        User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
    }
    
    
    public static void MouseLeftUp()
    {
        var inputs = new INPUT[1];

        inputs[0] = new INPUT
        {
            type = InputType.Mouse,
            union = new InputUnion
            {
                mouse = new MOUSEINPUT
                {
                    flags = MouseFlags.LeftUp
                }
            }
        };

        User32.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KEYBDINPUT
    {
        public ushort virtualKey;
        public ushort scanCode;
        public KeyboardFlags flags;
        public uint timeStamp;
        public IntPtr extraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOUSEINPUT
    {
        public int deltaX;
        public int deltaY;
        public int mouseData;
        public MouseFlags flags;
        public uint time;
        public IntPtr extraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HARDWAREINPUT
    {
        public uint message;
        public ushort wParamL;
        public ushort wParamH;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)] public MOUSEINPUT mouse;
        [FieldOffset(0)] public KEYBDINPUT keyboard;
        [FieldOffset(0)] public HARDWAREINPUT hardware;
    }

    public struct INPUT
    {
        public InputType type;
        public InputUnion union;
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