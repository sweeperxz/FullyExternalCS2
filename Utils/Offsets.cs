using System.Dynamic;
using System.Net.Http;
using CS2Cheat.DTO.ClientDllDTO;
using CS2Cheat.Utils.DTO;
using Newtonsoft.Json;

namespace CS2Cheat.Utils;

public abstract class Offsets
{
    #region offsets

    public const float WeaponRecoilScale = 2f;
    public static int dwLocalPlayerPawn;
    public static int m_vOldOrigin;
    public static int m_vecViewOffset;
    public static int m_AimPunchAngle;
    public static int m_modelState;
    public static int m_pGameSceneNode;
    public static int m_fFlags;
    public static int m_iIDEntIndex;
    public static int m_lifeState;
    public static int m_iHealth;
    public static int m_iTeamNum;
    public static int dwEntityList;
    public static int m_bDormant;
    public static int m_iShotsFired;
    public static int m_hPawn;
    public static int dwLocalPlayerController;
    public static int dwViewMatrix;
    public static int dwViewAngles;
    public static int m_hObserverTarget;
    public static int m_entitySpottedState;
    public static int m_Item;
    public static int m_pClippingWeapon;
    public static int m_AttributeManager;
    public static int m_iItemDefinitionIndex;
    public static int m_bIsScoped;
    public static int m_flFlashDuration;
    public static int m_iszPlayerName;
    public static int dwPlantedC4;
    public static int dwGlobalVars;
    public static int m_nBombSite;
    public static int m_bBombDefused;
    public static int m_vecAbsVelocity;
    public static int m_flDefuseCountDown;
    public static int m_flC4Blow;
    public static int m_bBeingDefused;
    public const nint m_nCurrentTickThisFrame = 0x34;

    public static readonly Dictionary<string, int> Bones = new()
    {
        { "head", 6 }, { "neck_0", 5 }, { "spine_1", 4 }, { "spine_2", 2 }, { "pelvis", 0 },
        { "arm_upper_L", 8 }, { "arm_lower_L", 9 }, { "hand_L", 10 },
        { "arm_upper_R", 13 }, { "arm_lower_R", 14 }, { "hand_R", 15 },
        { "leg_upper_L", 22 }, { "leg_lower_L", 23 }, { "ankle_L", 24 },
        { "leg_upper_R", 25 }, { "leg_lower_R", 26 }, { "ankle_R", 27 }
    };

    public static async Task UpdateOffsets()
    {
        try
        {
            var sourceDataDw = JsonConvert.DeserializeObject<OffsetsDTO>(
                await FetchJson("https://raw.githubusercontent.com/a2x/cs2-dumper/main/output/offsets.json"));
            var sourceDataClient = JsonConvert.DeserializeObject<ClientDllDTO>(
                await FetchJson("https://raw.githubusercontent.com/a2x/cs2-dumper/main/output/client_dll.json"));

            dynamic destData = new ExpandoObject();

            // Offsets
            destData.dwBuildNumber = sourceDataDw?.engine2dll?.dwBuildNumber ?? 0;
            destData.dwLocalPlayerController = sourceDataDw?.clientdll?.dwLocalPlayerController ?? 0;
            destData.dwEntityList = sourceDataDw?.clientdll?.dwEntityList ?? 0;
            destData.dwViewMatrix = sourceDataDw?.clientdll?.dwViewMatrix ?? 0;
            destData.dwPlantedC4 = sourceDataDw?.clientdll?.dwPlantedC4 ?? 0;
            destData.dwLocalPlayerPawn = sourceDataDw?.clientdll?.dwLocalPlayerPawn ?? 0;
            destData.dwViewAngles = sourceDataDw?.clientdll?.dwViewAngles ?? 0;
            destData.dwGlobalVars = sourceDataDw?.clientdll?.dwGlobalVars ?? 0;

            // client.dll
            var classes = sourceDataClient?.clientdll?.classes;
            m_hObserverTarget = classes?.C_CSPlayerPawn.fields.m_hObserverTarget ?? 0;
            destData.m_fFlags = classes?.C_BaseEntity.fields.m_fFlags ?? 0;
            destData.m_vOldOrigin = classes?.C_BasePlayerPawn.fields.m_vOldOrigin ?? 0;
            destData.m_vecViewOffset = classes?.C_BaseModelEntity.fields.m_vecViewOffset ?? 0;
            destData.m_AimPunchAngle = classes?.C_CSPlayerPawn.fields.m_aimPunchAngle ?? 0;
            destData.m_modelState = classes?.CSkeletonInstance.fields.m_modelState ?? 0;
            destData.m_pGameSceneNode = classes?.C_BaseEntity.fields.m_pGameSceneNode ?? 0;
            destData.m_iIDEntIndex = classes?.C_CSPlayerPawnBase.fields.m_iIDEntIndex ?? 0;
            destData.m_lifeState = classes?.C_BaseEntity.fields.m_lifeState ?? 0;
            destData.m_iHealth = classes?.C_BaseEntity.fields.m_iHealth ?? 0;
            destData.m_iTeamNum = classes?.C_BaseEntity.fields.m_iTeamNum ?? 0;
            destData.m_bDormant = classes?.CGameSceneNode.fields.m_bDormant ?? 0;
            destData.m_iShotsFired = classes?.C_CSPlayerPawn.fields.m_iShotsFired ?? 0;
            destData.m_hPawn = classes?.CBasePlayerController.fields.m_hPawn ?? 0;
            destData.m_entitySpottedState = classes?.C_CSPlayerPawn.fields.m_entitySpottedState ?? 0;
            destData.m_Item = classes?.C_AttributeContainer.fields.m_Item ?? 0;
            destData.m_pClippingWeapon = classes?.C_CSPlayerPawnBase.fields.m_pClippingWeapon ?? 0;
            destData.m_AttributeManager = classes?.C_EconEntity.fields.m_AttributeManager ?? 0;
            destData.m_iItemDefinitionIndex = classes?.C_EconItemView.fields.m_iItemDefinitionIndex ?? 0;
            destData.m_bIsScoped = classes?.C_CSPlayerPawnBase.fields.m_bIsScoped ?? 0;
            destData.m_flFlashDuration = classes?.C_CSPlayerPawnBase.fields.m_flFlashDuration ?? 0;
            destData.m_iszPlayerName = classes?.CBasePlayerController.fields.m_iszPlayerName ?? 0;
            destData.m_nBombSite = classes?.C_PlantedC4.fields.m_nBombSite ?? 0;
            destData.m_bBombDefused = classes?.C_PlantedC4.fields.m_bBombDefused ?? 0;
            destData.m_vecAbsVelocity = classes?.C_BaseEntity.fields.m_vecAbsVelocity ?? 0;
            destData.m_flDefuseCountDown = classes?.C_PlantedC4.fields.m_flDefuseCountDown ?? 0;
            destData.m_flC4Blow = classes?.C_PlantedC4.fields.m_flC4Blow ?? 0;
            destData.m_bBeingDefused = classes?.C_PlantedC4.fields.m_bBeingDefused ?? 0;
            destData.m_hObserverTarget = classes?.C_CSPlayerPawn.fields.m_hObserverTarget ?? 0;

            UpdateStaticFields(destData);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[+] Offsets updated successfully.");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[!] Failed to update offsets: {ex.Message}");
            Console.ResetColor();
            throw;
        }
    }

    private static async Task<string> FetchJson(string url)
    {
        using var client = new HttpClient();
        return await client.GetStringAsync(url);
    }

    private static void UpdateStaticFields(dynamic data)
    {

        dwLocalPlayerPawn = data.dwLocalPlayerPawn;
        m_vOldOrigin = data.m_vOldOrigin;
        m_vecViewOffset = data.m_vecViewOffset;
        m_AimPunchAngle = data.m_AimPunchAngle;
        m_modelState = data.m_modelState;
        m_pGameSceneNode = data.m_pGameSceneNode;
        m_iIDEntIndex = data.m_iIDEntIndex;
        m_lifeState = data.m_lifeState;
        m_iHealth = data.m_iHealth;
        m_iTeamNum = data.m_iTeamNum;
        m_bDormant = data.m_bDormant;
        m_iShotsFired = data.m_iShotsFired;
        m_hPawn = data.m_hPawn;
        m_fFlags = data.m_fFlags;
        dwLocalPlayerController = data.dwLocalPlayerController;
        dwViewMatrix = data.dwViewMatrix;
        dwViewAngles = data.dwViewAngles;
        dwEntityList = data.dwEntityList;
        m_entitySpottedState = data.m_entitySpottedState;
        m_Item = data.m_Item;
        m_pClippingWeapon = data.m_pClippingWeapon;
        m_AttributeManager = data.m_AttributeManager;
        m_iItemDefinitionIndex = data.m_iItemDefinitionIndex;
        m_bIsScoped = data.m_bIsScoped;
        m_flFlashDuration = data.m_flFlashDuration;
        m_iszPlayerName = data.m_iszPlayerName;
        dwPlantedC4 = data.dwPlantedC4;
        dwGlobalVars = data.dwGlobalVars;
        m_nBombSite = data.m_nBombSite;
        m_bBombDefused = data.m_bBombDefused;
        m_vecAbsVelocity = data.m_vecAbsVelocity;
        m_flDefuseCountDown = data.m_flDefuseCountDown;
        m_flC4Blow = data.m_flC4Blow;
        m_bBeingDefused = data.m_bBeingDefused;
        m_hObserverTarget = data.m_hObserverTarget;

    }

    #endregion
}
