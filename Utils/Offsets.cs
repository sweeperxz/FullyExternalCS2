using System.Dynamic;
using System.IO;
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


    public static void UpdateOffsets()
    {
        try
        {
            const string offsetsDw = "OffsetData/offsets.json";
            const string offsetsClient = "OffsetData/client.dll.json";
            const string destPath = "offsets.json";
            const string destDirectory = "OffsetData";


            if (!File.Exists(destPath) || !Directory.Exists(destDirectory)) Directory.CreateDirectory(destDirectory);
            File.Create(destPath).Dispose();


            var sourceDataDw = JsonConvert.DeserializeObject<OffsetsDTO>(FetchJson(offsetsDw));
            var sourceDataClient = JsonConvert.DeserializeObject<ClientDllDTO>(FetchJson(offsetsClient));


            var destJson = File.ReadAllText(destPath);
            dynamic destData = JsonConvert.DeserializeObject(destJson)!;

            if (destData != null && destData?.dwBuildNumber != 0 && destData?.dwBuildNumber != null &&
                sourceDataDw!.engine2dll.dwBuildNumber! == (int)destData?.dwBuildNumber!)
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
                m_bIsScoped = destData?.m_bIsScoped;
                m_flFlashDuration = destData?.m_flFlashDuration;
                m_iszPlayerName = destData?.m_iszPlayerName;
                dwPlantedC4 = destData?.dwPlantedC4;
                dwGlobalVars = destData?.dwGlobalVars;
                m_nBombSite = destData?.m_nBombSite;
                m_bBombDefused = destData?.m_bBombDefused;
                m_vecAbsVelocity = destData?.m_vecAbsVelocity;
                m_flDefuseCountDown = destData?.m_flDefuseCountDown;
                m_flC4Blow = destData?.m_flC4Blow;
                m_bBeingDefused = destData?.m_bBeingDefused;
                return;
            }

            if (destData == null) destData = new ExpandoObject();


            // offsets
            destData.dwBuildNumber = sourceDataDw.engine2dll.dwBuildNumber!;
            destData.dwLocalPlayerController = sourceDataDw.clientdll.dwLocalPlayerController!;
            destData.dwEntityList = sourceDataDw.clientdll.dwEntityList!;
            destData.dwViewMatrix = sourceDataDw.clientdll.dwViewMatrix!;
            destData.dwPlantedC4 = sourceDataDw.clientdll.dwPlantedC4!;
            destData.dwLocalPlayerPawn = sourceDataDw.clientdll.dwLocalPlayerPawn!;
            destData.dwViewAngles = sourceDataDw.clientdll.dwViewAngles!;
            destData.dwPlantedC4 = sourceDataDw.clientdll.dwPlantedC4!;
            destData.dwGlobalVars = sourceDataDw.clientdll.dwGlobalVars!;

            // client.dll
            destData.m_fFlags = sourceDataClient.clientdll.classes.C_BaseEntity.fields.m_fFlags!;
            destData.m_vOldOrigin = sourceDataClient.clientdll.classes.C_BasePlayerPawn.fields.m_vOldOrigin!;
            destData.m_vecViewOffset = sourceDataClient.clientdll.classes.C_BaseModelEntity.fields.m_vecViewOffset!;
            destData.m_aimPunchAngle = sourceDataClient.clientdll.classes.C_CSPlayerPawn.fields.m_aimPunchAngle!;
            destData.m_modelState = sourceDataClient.clientdll.classes.CSkeletonInstance.fields.m_modelState!;
            destData.m_pGameSceneNode = sourceDataClient.clientdll.classes.C_BaseEntity.fields.m_pGameSceneNode!;
            destData.m_iIDEntIndex = sourceDataClient.clientdll.classes.C_CSPlayerPawnBase.fields.m_iIDEntIndex!;
            destData.m_lifeState = sourceDataClient.clientdll.classes.C_BaseEntity.fields.m_lifeState!;
            destData.m_iHealth = sourceDataClient.clientdll.classes.C_BaseEntity.fields.m_iHealth!;
            destData.m_iTeamNum = sourceDataClient.clientdll.classes.C_BaseEntity.fields.m_iTeamNum!;
            destData.m_bDormant = sourceDataClient.clientdll.classes.CGameSceneNode.fields.m_bDormant!;
            destData.m_iShotsFired = sourceDataClient.clientdll.classes.C_CSPlayerPawnBase.fields.m_iShotsFired!;
            destData.m_hPawn = sourceDataClient.clientdll.classes.CBasePlayerController.fields.m_hPawn!;
            destData.m_entitySpottedState =
                sourceDataClient.clientdll.classes.C_CSPlayerPawnBase.fields.m_entitySpottedState!;
            destData.m_Item = sourceDataClient.clientdll.classes.C_AttributeContainer.fields.m_Item!;
            destData.m_pClippingWeapon =
                sourceDataClient.clientdll.classes.C_CSPlayerPawnBase.fields.m_pClippingWeapon!;
            destData.m_AttributeManager = sourceDataClient.clientdll.classes.C_EconEntity.fields.m_AttributeManager!;
            destData.m_iItemDefinitionIndex =
                sourceDataClient.clientdll.classes.C_EconItemView.fields.m_iItemDefinitionIndex!;
            destData.m_bIsScoped = sourceDataClient.clientdll.classes.C_CSPlayerPawnBase.fields.m_bIsScoped!;
            destData.m_flFlashDuration =
                sourceDataClient.clientdll.classes.C_CSPlayerPawnBase.fields.m_flFlashDuration!;
            destData.m_iszPlayerName = sourceDataClient.clientdll.classes.CBasePlayerController.fields.m_iszPlayerName!;
            destData.m_nBombSite = sourceDataClient.clientdll.classes.C_PlantedC4.fields.m_nBombSite!;
            destData.m_bBombDefused = sourceDataClient.clientdll.classes.C_PlantedC4.fields.m_bBombDefused!;
            destData.m_vecAbsVelocity = sourceDataClient.clientdll.classes.C_BaseEntity.fields.m_vecAbsVelocity!;
            destData.m_flDefuseCountDown = sourceDataClient.clientdll.classes.C_PlantedC4.fields.m_flDefuseCountDown!;
            destData.m_flC4Blow = sourceDataClient.clientdll.classes.C_PlantedC4.fields.m_flC4Blow!;
            destData.m_bBeingDefused = sourceDataClient.clientdll.classes.C_PlantedC4.fields.m_bBeingDefused!;


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
            m_bIsScoped = updatedDestData?.m_bIsScoped;
            m_flFlashDuration = updatedDestData?.m_flFlashDuration;
            m_iszPlayerName = updatedDestData?.m_iszPlayerName;
            dwPlantedC4 = updatedDestData?.dwPlantedC4;
            dwGlobalVars = updatedDestData?.dwGlobalVars;
            m_nBombSite = updatedDestData?.m_nBombSite;
            m_bBombDefused = updatedDestData?.m_bBombDefused;
            m_vecAbsVelocity = updatedDestData?.m_vecAbsVelocity;
            m_flDefuseCountDown = updatedDestData?.m_flDefuseCountDown;
            m_flC4Blow = updatedDestData?.m_flC4Blow;
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                "No files found in OffsetData folder, please add the files \"offsets.json\" and \"client.dll.json\" to the folder from \ngithub.com/a2x/cs2-dumper.");
            throw;
        }
        catch (NullReferenceException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(
                "Make sure that the files (client.dll.json and offsets.json) do not have empty fields.");
            throw;
        }
    }


    private static string FetchJson(string path)
    {
        return File.ReadAllText(path);
    }

    #endregion
}