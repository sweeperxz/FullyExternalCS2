namespace CS2Cheat.Core.Data;

/// <summary>
/// Aim bot state.
/// </summary>
public enum AimBotState
{
    /// <summary>
    /// Hot key is up, waiting for it to be pressed.
    /// </summary>
    Up,

    /// <summary>
    /// Hot key was pressed and suppressed.
    /// </summary>
    DownSuppressed,

    /// <summary>
    /// Hot key down simulated (suppress released).
    /// </summary>
    Down
}