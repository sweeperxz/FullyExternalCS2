using System.Dynamic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;

namespace CS2Cheat.Utils;

public class Offsets
{
    #region offsets

    private static readonly HttpClient HttpClient = new();
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
    public static int m_entitySpottedState;
    public static int m_Item;
    public static int m_pClippingWeapon;
    public static int m_AttributeManager;
    public static int m_iItemDefinitionIndex;
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


    public void UpdateOffsets()
    {
        const string offsetsDw = "https://github.com/a2x/cs2-dumper/raw/main/generated/offsets.json";
        const string offsetsClient = "https://github.com/a2x/cs2-dumper/raw/main/generated/client.dll.json";
        const string destPath = "offsets.json";

        if (!File.Exists(destPath)) File.Create(destPath).Dispose();

        var sourceDataDw = FetchJsonAndDeserialize(offsetsDw);
        var sourceDataClient = FetchJsonAndDeserialize(offsetsClient);


        var destJson = File.ReadAllText(destPath);
        dynamic destData = JsonConvert.DeserializeObject(destJson)!;

        if (destData != null && destData?.dwBuildNumber != 0 && destData?.dwBuildNumber != null &&
            sourceDataDw.engine2_dll?.data?.dwBuildNumber?.value! == destData?.dwBuildNumber)
        {
            dwLocalPlayerPawn = destData?.dwLocalPlayerPawn;
            m_vOldOrigin = destData?.m_vOldOrigin;
            m_vecViewOffset = destData?.m_vecViewOffset;
            m_AimPunchAngle = destData?.m_aimPunchAngle;
            m_modelState = destData?.m_modelState;
            m_pGameSceneNode = destData?.m_pGameSceneNode;
            m_iIDEntIndex = destData?.m_iIDEntIndex;
            m_lifeState = destData?.m_lifeState;
            m_iHealth = destData?.m_iHealth;
            m_iTeamNum = destData?.m_iTeamNum;
            m_bDormant = destData?.m_bDormant;
            m_iShotsFired = destData?.m_iShotsFired;
            m_hPawn = destData?.m_hPawn;
            m_fFlags = destData?.m_fFlags;
            dwLocalPlayerController = destData?.dwLocalPlayerController;
            dwViewMatrix = destData?.dwViewMatrix;
            dwViewAngles = destData?.dwViewAngles;
            dwEntityList = destData?.dwEntityList;
            m_entitySpottedState = destData?.m_entitySpottedState;
            m_Item = destData?.m_Item;
            m_pClippingWeapon = destData?.m_pClippingWeapon;
            m_AttributeManager = destData?.m_AttributeManager;
            m_iItemDefinitionIndex = destData?.m_iItemDefinitionIndex;
            return;
        }

        if (destData == null) destData = new ExpandoObject();


        // offsets
        destData.dwBuildNumber = sourceDataDw.engine2_dll?.data?.dwBuildNumber?.value!;
        destData.dwLocalPlayerController = sourceDataDw.client_dll?.data?.dwLocalPlayerController?.value!;
        destData.dwEntityList = sourceDataDw.client_dll?.data?.dwEntityList?.value!;
        destData.dwViewMatrix = sourceDataDw.client_dll?.data?.dwViewMatrix?.value!;
        destData.dwPlantedC4 = sourceDataDw.client_dll?.data?.dwPlantedC4?.value!;
        destData.dwLocalPlayerPawn = sourceDataDw.client_dll?.data?.dwLocalPlayerPawn?.value!;
        destData.dwViewAngles = sourceDataDw.client_dll?.data?.dwViewAngles?.value!;

        // client.dll
        destData.m_fFlags = sourceDataClient.C_BaseEntity?.data?.m_fFlags?.value!;
        destData.m_vOldOrigin = sourceDataClient.C_BasePlayerPawn?.data?.m_vOldOrigin?.value!;
        destData.m_vecViewOffset = sourceDataClient.C_BaseModelEntity?.data?.m_vecViewOffset?.value!;
        destData.m_aimPunchAngle = sourceDataClient.C_CSPlayerPawn?.data?.m_aimPunchAngle?.value!;
        destData.m_modelState = sourceDataClient.CSkeletonInstance?.data?.m_modelState?.value!;
        destData.m_pGameSceneNode = sourceDataClient.C_BaseEntity?.data?.m_pGameSceneNode?.value!;
        destData.m_iIDEntIndex = sourceDataClient.C_CSPlayerPawnBase?.data?.m_iIDEntIndex?.value!;
        destData.m_lifeState = sourceDataClient.C_BaseEntity?.data?.m_lifeState?.value!;
        destData.m_iHealth = sourceDataClient.C_BaseEntity?.data?.m_iHealth?.value!;
        destData.m_iTeamNum = sourceDataClient.C_BaseEntity?.data?.m_iTeamNum?.value!;
        destData.m_bDormant = sourceDataClient.CGameSceneNode?.data?.m_bDormant?.value!;
        destData.m_iShotsFired = sourceDataClient.C_CSPlayerPawnBase?.data?.m_iShotsFired?.value!;
        destData.m_hPawn = sourceDataClient.CBasePlayerController?.data?.m_hPawn?.value!;
        destData.m_entitySpottedState = sourceDataClient.C_CSPlayerPawnBase?.data?.m_entitySpottedState?.value!;
        destData.m_Item = sourceDataClient.C_AttributeContainer?.data?.m_Item?.value!;
        destData.m_pClippingWeapon = sourceDataClient.C_CSPlayerPawnBase.data?.m_pClippingWeapon.value!;
        destData.m_AttributeManager = sourceDataClient.C_EconEntity.data?.m_AttributeManager.value!;
        destData.m_iItemDefinitionIndex = sourceDataClient.C_EconItemView.data?.m_iItemDefinitionIndex.value!;


        // Write updated destination JSON
        string updatedDestJson = JsonConvert.SerializeObject(destData, Formatting.Indented);
        File.WriteAllText(destPath, updatedDestJson);

        Console.WriteLine("Offsets updated in the local file.");


        var jsonContent = File.ReadAllText(destPath);

        dynamic updatedDestData = JsonConvert.DeserializeObject(jsonContent)!;


        dwLocalPlayerPawn = updatedDestData?.dwLocalPlayerPawn;
        m_vOldOrigin = updatedDestData?.m_vOldOrigin;
        m_vecViewOffset = updatedDestData?.m_vecViewOffset;
        m_AimPunchAngle = updatedDestData?.m_aimPunchAngle;
        m_modelState = updatedDestData?.m_modelState;
        m_pGameSceneNode = updatedDestData?.m_pGameSceneNode;
        m_iIDEntIndex = updatedDestData?.m_iIDEntIndex;
        m_lifeState = updatedDestData?.m_lifeState;
        m_iHealth = updatedDestData?.m_iHealth;
        m_iTeamNum = updatedDestData?.m_iTeamNum;
        m_bDormant = updatedDestData?.m_bDormant;
        m_iShotsFired = updatedDestData?.m_iShotsFired;
        m_hPawn = updatedDestData?.m_hPawn;
        m_fFlags = updatedDestData?.m_fFlags;
        dwLocalPlayerController = updatedDestData?.dwLocalPlayerController;
        dwViewMatrix = updatedDestData?.dwViewMatrix;
        dwViewAngles = updatedDestData?.dwViewAngles;
        dwEntityList = updatedDestData?.dwEntityList;
        m_entitySpottedState = updatedDestData?.m_entitySpottedState;
        m_Item = updatedDestData?.m_Item;
        m_pClippingWeapon = updatedDestData?.m_pClippingWeapon;
        m_AttributeManager = updatedDestData?.m_AttributeManager;
        m_iItemDefinitionIndex = updatedDestData?.m_iItemDefinitionIndex;
    }

    private static dynamic FetchJsonAndDeserialize(string url)
    {
        var sourceJson = HttpClient.GetStringAsync(url).Result;
        return JsonConvert.DeserializeObject(sourceJson)!;
    }

    #endregion
}