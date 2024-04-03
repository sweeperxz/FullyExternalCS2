using Newtonsoft.Json;

namespace CS2Cheat.Utils.DTO;

public class OffsetsDTO
{
    [JsonProperty("client.dll")] public ClientDll clientdll { get; set; }

    [JsonProperty("engine2.dll")] public Engine2Dll engine2dll { get; set; }

    [JsonProperty("inputsystem.dll")] public InputsystemDll inputsystemdll { get; set; }

    [JsonProperty("matchmaking.dll")] public MatchmakingDll matchmakingdll { get; set; }
}

public class ClientDll
{
    public int dwCSGOInput { get; set; }
    public int dwEntityList { get; set; }
    public int dwGameEntitySystem { get; set; }
    public int dwGameEntitySystem_getHighestEntityIndex { get; set; }
    public int dwGameRules { get; set; }
    public int dwGlobalVars { get; set; }
    public int dwGlowManager { get; set; }
    public int dwLocalPlayerController { get; set; }
    public int dwLocalPlayerPawn { get; set; }
    public int dwPlantedC4 { get; set; }
    public int dwPrediction { get; set; }
    public int dwSensitivity { get; set; }
    public int dwSensitivity_sensitivity { get; set; }
    public int dwViewAngles { get; set; }
    public int dwViewMatrix { get; set; }
    public int dwViewRender { get; set; }
}

public class Engine2Dll
{
    public int dwBuildNumber { get; set; }
    public int dwNetworkGameClient { get; set; }
    public int dwNetworkGameClient_deltaTick { get; set; }
    public int dwNetworkGameClient_getLocalPlayer { get; set; }
    public int dwNetworkGameClient_getMaxClients { get; set; }
    public int dwNetworkGameClient_signOnState { get; set; }
    public int dwWindowHeight { get; set; }
    public int dwWindowWidth { get; set; }
}

public class InputsystemDll
{
    public int dwInputSystem { get; set; }
}

public class MatchmakingDll
{
    public int dwGameTypes { get; set; }
    public int dwGameTypes_mapName { get; set; }
}