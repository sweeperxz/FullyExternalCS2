namespace CS2Cheat.Core.Data;

public enum AimBotState
{
    // the hotkey is awaiting a press.
    Up,

    // hotkey pressed and suppressed.
    DownSuppressed,

    // hotkey down simulated (suppress released).
    Down
}