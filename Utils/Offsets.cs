namespace CS2Cheat.Utils;

public static class Offsets
{
    #region offsets

    public const float WeaponRecoilScale = 2.0f;
    public static readonly int dwLocalPlayerPawn = 0x16D4F48;
    public static readonly int m_vOldOrigin = 0x1224;
    public static readonly int m_vecViewOffset = 0xC48;
    public static readonly int m_AimPunchAngle = 0x171C;
    public static readonly int m_modelState = 0x160;
    public static readonly int m_pGameSceneNode = 0x310;
    public static readonly int m_fFlags = 0x3C8;
    public static readonly int m_iIDEntIndex = 0x1544;
    public static readonly int m_lifeState = 0x330;
    public static readonly int m_iHealth = 0x32C;
    public static readonly int m_iTeamNum = 0x3BF;
    public static readonly int dwEntityList = 0x17CE6A0;
    public static readonly int m_bDormant = 0xE7;
    public static readonly int m_iShotsFired = 0x1420;
    public static readonly int m_hPawn = 0x60C;
    public static readonly int dwLocalPlayerController = 0x181DC98;
    public static readonly int dwViewMatrix = 0x182CEA0;
    public static readonly int dwViewAngles = 0x1890F30;
    public static readonly int m_nBombSite = 0xE84;
    public static readonly int m_bBeingDefused = 0xEBC;
    public static readonly int m_bBombDefused = 0xED4;
    public static readonly int dwPlantedC4 = 0x18257D8;


    public static readonly Dictionary<string, int> Bones = new()
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

    #endregion
}