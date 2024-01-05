namespace CS2Cheat.Utils;

public static class Offsets
{
    #region offsets

    public static float weapon_recoil_scale = 2.0f;
    public static int dwLocalPlayerPawn = 0x16C8F58;
    public static int dwViewAngels = 0x1880DC0;
    public static int m_vOldOrigin = 0x1224;
    public static int m_vecViewOffset = 0xC48;
    public static int m_AimPunchAngle = 0x171C;
    public static int m_iFOV = 0x210;
    public static int m_modelState = 0x160;
    public static int m_angEyeAngles = 0x1518;
    public static int m_pGameSceneNode = 0x310;
    public static int m_fFlags = 0x3C8;
    public static int m_pCameraServices = 0x10E0;
    public static int m_iFOVStart = 0x214;
    public static int m_iIDEntIndex = 0x1544;
    public static int m_lifeState = 0x330;
    public static int m_iHealth = 0x32C;
    public static int m_iTeamNum = 0x3BF;
    public static int dwEntityList = 0x17C1950;
    public static int m_bDormant = 0xE7;
    public static int m_hPlayerPawn = 0x7EC;
    public static int m_iszPlayerName = 0x640;
    public static int m_iShotsFired = 0x1420;

    public static readonly Dictionary<string, int> BONES = new()
    {
        { "head", 6 },
        { "neck_0", 5 },
        { "spine_1", 4 },
        { "spine_2", 2 },
        { "pelvis", 0 },
        { "arm_upper_L", 8 },
        { "arm_lower_L", 9 },
        { "hand_L", 10 },
        { "arm_upper_R", 13 },
        { "arm_lower_R", 14 },
        { "hand_R", 15 },
        { "leg_upper_L", 22 },
        { "leg_lower_L", 23 },
        { "ankle_L", 24 },
        { "leg_upper_R", 25 },
        { "leg_lower_R", 26 },
        { "ankle_R", 27 }
    };

    public static int m_hPawn = 0x60C;
    public static int dwLocalPlayerController = 0x1810F48;
    public static int dwViewMatrix = 0x1820150;
    public static int dwViewAngles = 0x1880DC0;

    #endregion
}