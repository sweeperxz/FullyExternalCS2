using Newtonsoft.Json;

namespace CS2Cheat.DTO.ClientDllDTO;

public class ClientDllDTO
{
    [JsonProperty("client.dll")] public ClientDll clientdll { get; set; }
}

public class ClientDll
{
    public Classes classes { get; set; }
    public Enums enums { get; set; }
}

public class ActiveModelConfigT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class AudioparamsT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CAnimGraphNetworkedVariables
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CAttributeContainer
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CAttributeList
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CAttributeManager
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBarnLight
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseAnimGraph
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseAnimGraphController
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBaseButton
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBaseClientUIEntity
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseCombatCharacter
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseCombatCharacterWaterWakeModeT
{
    public int alignment { get; set; }
    public Members members { get; set; }
    public string type { get; set; }
}

public class CBaseCSGrenade
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseCSGrenadeProjectile
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseDoor
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBaseEntity
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseEntityAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBaseFire
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseFlex
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseGrenade
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseModelEntity
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBasePlayerController
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBasePlayerControllerAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBasePlayerPawn
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBasePlayerVData
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBasePlayerWeapon
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBasePlayerWeaponVData
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBasePropDoor
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBaseTrigger
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBaseViewModel
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBeam
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBodyComponentBaseAnimGraph
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBodyComponentPoint
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBodyComponentSkeletonInstance
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CBombTarget
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CBreakableProp
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CC4
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CChicken
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CClientPointEntityAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCollisionProperty
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CColorCorrection
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CColorCorrectionVolume
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCompositeMaterialEditorDoc
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSArmsRaceScript
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSDeathmatchScript
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSGameModeRulesArmsRace
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSGameModeRulesDeathmatch
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSGameModeScript
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSGameRules
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSGameRulesProxy
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSGOTeamPreviewCharacterPosition
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSGOViewModel
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSObserverPawn
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSObserverPawnAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerActionTrackingServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerBaseCameraServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSPlayerBulletServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerBuyServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerController
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSPlayerControllerActionTrackingServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerControllerAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerControllerDamageServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerControllerInGameMoneyServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerControllerInventoryServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerHostageServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerItemServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerMovementServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSPlayerPawn
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSPlayerPawnAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerPawnBase
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSPlayerPingServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerResource
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSPlayerViewModelServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSPlayerWeaponServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSTakeDamageInfoAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSTeam
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSWeaponBase
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSWeaponBaseAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CCSWeaponBaseGun
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSWeaponBaseVData
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CCSWeaponBaseVDataAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CDamageRecord
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CDecoyProjectile
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CDynamicLight
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CDynamicProp
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CDynamicPropAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CEconEntity
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEconItemAttribute
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CEconItemView
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CEffectData
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CEntityDissolve
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEntityFlame
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEntityIdentity
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CEntityInstance
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CEnvCombinedLightProbeVolume
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvCubemap
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvCubemapFog
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvDecal
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvDetailController
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvLightProbeVolume
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvParticleGlow
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvScreenOverlay
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CEnvSky
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvVolumetricFogController
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvVolumetricFogVolume
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvWind
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvWindClientside
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CEnvWindShared
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CFireSmoke
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CFish
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CFists
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CFogController
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CFogplayerparamsT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CFootstepControl
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CFuncConveyor
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CFuncElectrifiedVolume
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CFuncLadder
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CFuncMonitor
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CFuncMoveLinear
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CFuncRotating
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CGameSceneNode
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CGameSceneNodeHandle
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CGlowProperty
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CGradientFog
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CHandleTest
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CHitboxComponent
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CHostage
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CInferno
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CInfoOffscreenPanoramaTexture
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CInfoVisibilityBox
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CInfoWorldLayer
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CItem
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CItemDogtags
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class Classes
{
    public ActiveModelConfigT ActiveModelConfig_t { get; set; }
    public CAnimGraphNetworkedVariables CAnimGraphNetworkedVariables { get; set; }
    public CAttributeList CAttributeList { get; set; }
    public CAttributeManager CAttributeManager { get; set; }
    public CBaseAnimGraph CBaseAnimGraph { get; set; }
    public CBaseAnimGraphController CBaseAnimGraphController { get; set; }
    public CBasePlayerController CBasePlayerController { get; set; }
    public CBasePlayerControllerAPI CBasePlayerControllerAPI { get; set; }
    public CBasePlayerVData CBasePlayerVData { get; set; }
    public CBasePlayerWeaponVData CBasePlayerWeaponVData { get; set; }
    public CBodyComponentBaseAnimGraph CBodyComponentBaseAnimGraph { get; set; }
    public CBodyComponentPoint CBodyComponentPoint { get; set; }
    public CBodyComponentSkeletonInstance CBodyComponentSkeletonInstance { get; set; }
    public CBombTarget CBombTarget { get; set; }
    public CCSArmsRaceScript CCSArmsRaceScript { get; set; }
    public CCSDeathmatchScript CCSDeathmatchScript { get; set; }
    public CCSGameModeRulesArmsRace CCSGameModeRules_ArmsRace { get; set; }
    public CCSGameModeRulesDeathmatch CCSGameModeRules_Deathmatch { get; set; }
    public CCSGameModeScript CCSGameModeScript { get; set; }
    public CCSPlayerBaseCameraServices CCSPlayerBase_CameraServices { get; set; }
    public CCSPlayerController CCSPlayerController { get; set; }
    public CCSPlayerControllerAPI CCSPlayerControllerAPI { get; set; }
    public CCSPlayerControllerActionTrackingServices CCSPlayerController_ActionTrackingServices { get; set; }
    public CCSPlayerControllerDamageServices CCSPlayerController_DamageServices { get; set; }
    public CCSPlayerControllerInGameMoneyServices CCSPlayerController_InGameMoneyServices { get; set; }
    public CCSPlayerControllerInventoryServices CCSPlayerController_InventoryServices { get; set; }
    public CCSPlayerActionTrackingServices CCSPlayer_ActionTrackingServices { get; set; }
    public CCSPlayerBulletServices CCSPlayer_BulletServices { get; set; }
    public CCSPlayerBuyServices CCSPlayer_BuyServices { get; set; }
    public CCSPlayerHostageServices CCSPlayer_HostageServices { get; set; }
    public CCSPlayerItemServices CCSPlayer_ItemServices { get; set; }
    public CCSPlayerMovementServices CCSPlayer_MovementServices { get; set; }
    public CCSPlayerPingServices CCSPlayer_PingServices { get; set; }
    public CCSPlayerViewModelServices CCSPlayer_ViewModelServices { get; set; }
    public CCSPlayerWeaponServices CCSPlayer_WeaponServices { get; set; }
    public CCSTakeDamageInfoAPI CCSTakeDamageInfoAPI { get; set; }
    public CCSWeaponBaseAPI CCSWeaponBaseAPI { get; set; }
    public CCSWeaponBaseVData CCSWeaponBaseVData { get; set; }
    public CCSWeaponBaseVDataAPI CCSWeaponBaseVDataAPI { get; set; }
    public CClientPointEntityAPI CClientPointEntityAPI { get; set; }
    public CCollisionProperty CCollisionProperty { get; set; }
    public CCompositeMaterialEditorDoc CCompositeMaterialEditorDoc { get; set; }
    public CDamageRecord CDamageRecord { get; set; }
    public CDynamicPropAPI CDynamicPropAPI { get; set; }
    public CEconItemAttribute CEconItemAttribute { get; set; }
    public CEffectData CEffectData { get; set; }
    public CEntityIdentity CEntityIdentity { get; set; }
    public CEntityInstance CEntityInstance { get; set; }
    public CGameSceneNode CGameSceneNode { get; set; }
    public CGameSceneNodeHandle CGameSceneNodeHandle { get; set; }
    public CGlowProperty CGlowProperty { get; set; }
    public CHitboxComponent CHitboxComponent { get; set; }
    public CInfoOffscreenPanoramaTexture CInfoOffscreenPanoramaTexture { get; set; }
    public CInfoWorldLayer CInfoWorldLayer { get; set; }
    public CLightComponent CLightComponent { get; set; }
    public CModelState CModelState { get; set; }
    public CNetworkedSequenceOperation CNetworkedSequenceOperation { get; set; }
    public CPlayerCameraServices CPlayer_CameraServices { get; set; }
    public CPlayerMovementServices CPlayer_MovementServices { get; set; }
    public CPlayerMovementServicesHumanoid CPlayer_MovementServices_Humanoid { get; set; }
    public CPlayerObserverServices CPlayer_ObserverServices { get; set; }
    public CPlayerWeaponServices CPlayer_WeaponServices { get; set; }
    public CPrecipitationVData CPrecipitationVData { get; set; }
    public CProjectedTextureBase CProjectedTextureBase { get; set; }
    public CPulseGraphInstanceClientEntity CPulseGraphInstance_ClientEntity { get; set; }
    public CSMatchStatsT CSMatchStats_t { get; set; }
    public CSPerRoundStatsT CSPerRoundStats_t { get; set; }
    public CSkeletonInstance CSkeletonInstance { get; set; }
    public CTakeDamageInfoAPI CTakeDamageInfoAPI { get; set; }
    public CTimeline CTimeline { get; set; }
    public CAttributeContainer C_AttributeContainer { get; set; }
    public CBarnLight C_BarnLight { get; set; }
    public CBaseButton C_BaseButton { get; set; }
    public CBaseCSGrenade C_BaseCSGrenade { get; set; }
    public CBaseCSGrenadeProjectile C_BaseCSGrenadeProjectile { get; set; }
    public CBaseClientUIEntity C_BaseClientUIEntity { get; set; }
    public CBaseCombatCharacter C_BaseCombatCharacter { get; set; }
    public CBaseDoor C_BaseDoor { get; set; }
    public CBaseEntity C_BaseEntity { get; set; }
    public CBaseEntityAPI C_BaseEntityAPI { get; set; }
    public CBaseFire C_BaseFire { get; set; }
    public CBaseFlex C_BaseFlex { get; set; }
    public CBaseGrenade C_BaseGrenade { get; set; }
    public CBaseModelEntity C_BaseModelEntity { get; set; }
    public CBasePlayerPawn C_BasePlayerPawn { get; set; }
    public CBasePlayerWeapon C_BasePlayerWeapon { get; set; }
    public CBasePropDoor C_BasePropDoor { get; set; }
    public CBaseTrigger C_BaseTrigger { get; set; }
    public CBaseViewModel C_BaseViewModel { get; set; }
    public CBeam C_Beam { get; set; }
    public CBreakableProp C_BreakableProp { get; set; }
    public CC4 C_C4 { get; set; }
    public CCSGOViewModel C_CSGOViewModel { get; set; }
    public CCSGOTeamPreviewCharacterPosition C_CSGO_TeamPreviewCharacterPosition { get; set; }
    public CCSGameRules C_CSGameRules { get; set; }
    public CCSGameRulesProxy C_CSGameRulesProxy { get; set; }
    public CCSObserverPawn C_CSObserverPawn { get; set; }
    public CCSObserverPawnAPI C_CSObserverPawnAPI { get; set; }
    public CCSPlayerPawn C_CSPlayerPawn { get; set; }
    public CCSPlayerPawnAPI C_CSPlayerPawnAPI { get; set; }
    public CCSPlayerPawnBase C_CSPlayerPawnBase { get; set; }
    public CCSPlayerResource C_CSPlayerResource { get; set; }
    public CCSTeam C_CSTeam { get; set; }
    public CCSWeaponBase C_CSWeaponBase { get; set; }
    public CCSWeaponBaseGun C_CSWeaponBaseGun { get; set; }
    public CChicken C_Chicken { get; set; }
    public CColorCorrection C_ColorCorrection { get; set; }
    public CColorCorrectionVolume C_ColorCorrectionVolume { get; set; }
    public CDecoyProjectile C_DecoyProjectile { get; set; }
    public CDynamicLight C_DynamicLight { get; set; }
    public CDynamicProp C_DynamicProp { get; set; }
    public CEconEntity C_EconEntity { get; set; }
    public CEconItemView C_EconItemView { get; set; }
    public CEntityDissolve C_EntityDissolve { get; set; }
    public CEntityFlame C_EntityFlame { get; set; }
    public CEnvCombinedLightProbeVolume C_EnvCombinedLightProbeVolume { get; set; }
    public CEnvCubemap C_EnvCubemap { get; set; }
    public CEnvCubemapFog C_EnvCubemapFog { get; set; }
    public CEnvDecal C_EnvDecal { get; set; }
    public CEnvDetailController C_EnvDetailController { get; set; }
    public CEnvLightProbeVolume C_EnvLightProbeVolume { get; set; }
    public CEnvParticleGlow C_EnvParticleGlow { get; set; }
    public CEnvScreenOverlay C_EnvScreenOverlay { get; set; }
    public CEnvSky C_EnvSky { get; set; }
    public CEnvVolumetricFogController C_EnvVolumetricFogController { get; set; }
    public CEnvVolumetricFogVolume C_EnvVolumetricFogVolume { get; set; }
    public CEnvWind C_EnvWind { get; set; }
    public CEnvWindClientside C_EnvWindClientside { get; set; }
    public CEnvWindShared C_EnvWindShared { get; set; }
    public CFireSmoke C_FireSmoke { get; set; }
    public CFish C_Fish { get; set; }
    public CFists C_Fists { get; set; }
    public CFogController C_FogController { get; set; }
    public CFootstepControl C_FootstepControl { get; set; }
    public CFuncConveyor C_FuncConveyor { get; set; }
    public CFuncElectrifiedVolume C_FuncElectrifiedVolume { get; set; }
    public CFuncLadder C_FuncLadder { get; set; }
    public CFuncMonitor C_FuncMonitor { get; set; }
    public CFuncMoveLinear C_FuncMoveLinear { get; set; }
    public CFuncRotating C_FuncRotating { get; set; }
    public CGradientFog C_GradientFog { get; set; }
    public CHandleTest C_HandleTest { get; set; }
    public CHostage C_Hostage { get; set; }
    public CInferno C_Inferno { get; set; }
    public CInfoVisibilityBox C_InfoVisibilityBox { get; set; }
    public CItem C_Item { get; set; }
    public CItemDogtags C_ItemDogtags { get; set; }
    public CLightEntity C_LightEntity { get; set; }
    public CLightGlow C_LightGlow { get; set; }
    public CMapVetoPickController C_MapVetoPickController { get; set; }
    public CMolotovProjectile C_MolotovProjectile { get; set; }
    public COmniLight C_OmniLight { get; set; }
    public CParticleSystem C_ParticleSystem { get; set; }
    public CPathParticleRope C_PathParticleRope { get; set; }
    public CPhysicsProp C_PhysicsProp { get; set; }
    public CPlantedC4 C_PlantedC4 { get; set; }
    public CPlayerPing C_PlayerPing { get; set; }
    public CPlayerSprayDecal C_PlayerSprayDecal { get; set; }
    public CPlayerVisibility C_PlayerVisibility { get; set; }
    public CPointCamera C_PointCamera { get; set; }
    public CPointClientUIDialog C_PointClientUIDialog { get; set; }
    public CPointClientUIHUD C_PointClientUIHUD { get; set; }
    public CPointClientUIWorldPanel C_PointClientUIWorldPanel { get; set; }
    public CPointClientUIWorldTextPanel C_PointClientUIWorldTextPanel { get; set; }
    public CPointCommentaryNode C_PointCommentaryNode { get; set; }
    public CPointValueRemapper C_PointValueRemapper { get; set; }
    public CPointWorldText C_PointWorldText { get; set; }
    public CPostProcessingVolume C_PostProcessingVolume { get; set; }
    public CRagdollManager C_RagdollManager { get; set; }
    public CRagdollProp C_RagdollProp { get; set; }
    public CRagdollPropAttached C_RagdollPropAttached { get; set; }
    public CRectLight C_RectLight { get; set; }
    public CRetakeGameRules C_RetakeGameRules { get; set; }
    public CRopeKeyframe C_RopeKeyframe { get; set; }
    public CSceneEntity C_SceneEntity { get; set; }
    public CShatterGlassShardPhysics C_ShatterGlassShardPhysics { get; set; }
    public CSkyCamera C_SkyCamera { get; set; }
    public CSmokeGrenadeProjectile C_SmokeGrenadeProjectile { get; set; }
    public CSoundAreaEntityBase C_SoundAreaEntityBase { get; set; }
    public CSoundAreaEntityOrientedBox C_SoundAreaEntityOrientedBox { get; set; }
    public CSoundAreaEntitySphere C_SoundAreaEntitySphere { get; set; }
    public CSoundOpvarSetPointBase C_SoundOpvarSetPointBase { get; set; }
    public CSpotlightEnd C_SpotlightEnd { get; set; }
    public CSprite C_Sprite { get; set; }
    public CSun C_Sun { get; set; }
    public CTeam C_Team { get; set; }
    public CTeamRoundTimer C_TeamRoundTimer { get; set; }
    public CTextureBasedAnimatable C_TextureBasedAnimatable { get; set; }
    public CTonemapController2 C_TonemapController2 { get; set; }
    public CTriggerBuoyancy C_TriggerBuoyancy { get; set; }
    public CTriggerPhysics C_TriggerPhysics { get; set; }
    public CVoteController C_VoteController { get; set; }
    public CWeaponBaseItem C_WeaponBaseItem { get; set; }
    public CWeaponShield C_WeaponShield { get; set; }
    public CWeaponTaser C_WeaponTaser { get; set; }
    public CFogplayerparamsT C_fogplayerparams_t { get; set; }
    public CompMatMutatorConditionT CompMatMutatorCondition_t { get; set; }
    public CompMatPropertyMutatorT CompMatPropertyMutator_t { get; set; }
    public CompositeMaterialAssemblyProcedureT CompositeMaterialAssemblyProcedure_t { get; set; }
    public CompositeMaterialEditorPointT CompositeMaterialEditorPoint_t { get; set; }
    public CompositeMaterialInputContainerT CompositeMaterialInputContainer_t { get; set; }
    public CompositeMaterialInputLooseVariableT CompositeMaterialInputLooseVariable_t { get; set; }
    public CompositeMaterialMatchFilterT CompositeMaterialMatchFilter_t { get; set; }
    public CompositeMaterialT CompositeMaterial_t { get; set; }
    public CountdownTimer CountdownTimer { get; set; }
    public EngineCountdownTimer EngineCountdownTimer { get; set; }
    public EntityRenderAttributeT EntityRenderAttribute_t { get; set; }
    public EntitySpottedStateT EntitySpottedState_t { get; set; }
    public GeneratedTextureHandleT GeneratedTextureHandle_t { get; set; }
    public IntervalTimer IntervalTimer { get; set; }
    public PhysicsRagdollPoseT PhysicsRagdollPose_t { get; set; }
    public SellbackPurchaseEntryT SellbackPurchaseEntry_t { get; set; }
    public VPhysicsCollisionAttributeT VPhysicsCollisionAttribute_t { get; set; }
    public ViewAngleServerChangeT ViewAngleServerChange_t { get; set; }
    public WeaponPurchaseCountT WeaponPurchaseCount_t { get; set; }
    public WeaponPurchaseTrackerT WeaponPurchaseTracker_t { get; set; }
    public AudioparamsT audioparams_t { get; set; }
    public FogparamsT fogparams_t { get; set; }
    public ShardModelDescT shard_model_desc_t { get; set; }
    public Sky3dparamsT sky3dparams_t { get; set; }
}

public class CLightComponent
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CLightEntity
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CLightGlow
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CMapVetoPickController
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CModelState
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CMolotovProjectile
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CNetworkedSequenceOperation
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class COmniLight
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CompMatMutatorConditionT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CompMatPropertyMutatorConditionTypeT
{
    public int alignment { get; set; }
    public Members members { get; set; }
    public string type { get; set; }
}

public class CompMatPropertyMutatorT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CompMatPropertyMutatorTypeT
{
    public int alignment { get; set; }
    public Members members { get; set; }
    public string type { get; set; }
}

public class CompositeMaterialAssemblyProcedureT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CompositeMaterialEditorPointT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CompositeMaterialInputContainerSourceTypeT
{
    public int alignment { get; set; }
    public Members members { get; set; }
    public string type { get; set; }
}

public class CompositeMaterialInputContainerT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CompositeMaterialInputLooseVariableT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CompositeMaterialInputLooseVariableTypeT
{
    public int alignment { get; set; }
    public Members members { get; set; }
    public string type { get; set; }
}

public class CompositeMaterialInputTextureTypeT
{
    public int alignment { get; set; }
    public Members members { get; set; }
    public string type { get; set; }
}

public class CompositeMaterialMatchFilterT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CompositeMaterialMatchFilterTypeT
{
    public int alignment { get; set; }
    public Members members { get; set; }
    public string type { get; set; }
}

public class CompositeMaterialT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CompositeMaterialVarSystemVarT
{
    public int alignment { get; set; }
    public Members members { get; set; }
    public string type { get; set; }
}

public class CountdownTimer
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CParticleSystem
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPathParticleRope
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPhysicsProp
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPlantedC4
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPlayerCameraServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CPlayerMovementServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CPlayerMovementServicesHumanoid
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPlayerObserverServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CPlayerPing
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPlayerSprayDecal
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CPlayerVisibility
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPlayerWeaponServices
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CPointCamera
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPointClientUIDialog
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPointClientUIHUD
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPointClientUIWorldPanel
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPointClientUIWorldTextPanel
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPointCommentaryNode
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPointValueRemapper
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPointWorldText
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CPostProcessingVolume
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CPrecipitationVData
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CProjectedTextureBase
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CPulseGraphInstanceClientEntity
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CRagdollManager
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CRagdollProp
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CRagdollPropAttached
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CRectLight
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CRetakeGameRules
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CRopeKeyframe
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSceneEntity
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CShatterGlassShardPhysics
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSkeletonInstance
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSkyCamera
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSMatchStatsT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSmokeGrenadeProjectile
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSoundAreaEntityBase
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSoundAreaEntityOrientedBox
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSoundAreaEntitySphere
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSoundOpvarSetPointBase
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSPerRoundStatsT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CSpotlightEnd
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSprite
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CSun
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CTakeDamageInfoAPI
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class CTeam
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CTeamRoundTimer
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CTextureBasedAnimatable
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CTimeline
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CTonemapController2
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CTriggerBuoyancy
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CTriggerPhysics
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CVoteController
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CWeaponBaseItem
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CWeaponShield
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class CWeaponTaser
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public string parent { get; set; }
}

public class EngineCountdownTimer
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class EntityRenderAttributeT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class EntitySpottedStateT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class Enums
{
    public CBaseCombatCharacterWaterWakeModeT C_BaseCombatCharacter__WaterWakeMode_t { get; set; }
    public CompMatPropertyMutatorConditionTypeT CompMatPropertyMutatorConditionType_t { get; set; }
    public CompMatPropertyMutatorTypeT CompMatPropertyMutatorType_t { get; set; }
    public CompositeMaterialInputContainerSourceTypeT CompositeMaterialInputContainerSourceType_t { get; set; }
    public CompositeMaterialInputLooseVariableTypeT CompositeMaterialInputLooseVariableType_t { get; set; }
    public CompositeMaterialInputTextureTypeT CompositeMaterialInputTextureType_t { get; set; }
    public CompositeMaterialMatchFilterTypeT CompositeMaterialMatchFilterType_t { get; set; }
    public CompositeMaterialVarSystemVarT CompositeMaterialVarSystemVar_t { get; set; }
}

public class Fields
{
    public int m_AssociatedEntities { get; set; }
    public int m_AssociatedEntityNames { get; set; }
    public int m_Handle { get; set; }
    public int m_Name { get; set; }
    public int m_aShootSounds { get; set; }
    public int m_bAllowFlipping { get; set; }
    public int m_bAutoSwitchFrom { get; set; }
    public int m_bAutoSwitchTo { get; set; }
    public int m_bBuiltRightHanded { get; set; }
    public int m_bLinkedCooldowns { get; set; }
    public int m_iDefaultClip1 { get; set; }
    public int m_iDefaultClip2 { get; set; }
    public int m_iFlags { get; set; }
    public int m_iMaxClip1 { get; set; }
    public int m_iMaxClip2 { get; set; }
    public int m_iPosition { get; set; }
    public int m_iRumbleEffect { get; set; }
    public int m_iSlot { get; set; }
    public int m_iWeight { get; set; }
    public int m_nPrimaryAmmoType { get; set; }
    public int m_nSecondaryAmmoType { get; set; }
    public int m_sMuzzleAttachment { get; set; }
    public int m_szMuzzleFlashParticle { get; set; }
    public int m_szWorldModel { get; set; }
    public int m_ArmorValue { get; set; }
    public int m_GunGameImmunityColor { get; set; }
    public int m_angEyeAngles { get; set; }
    public int m_angLastMuzzleFlashAngle { get; set; }
    public int m_angShootAngleHistory { get; set; }
    public int m_angStashedShootAngles { get; set; }
    public int m_bCachedPlaneIsValid { get; set; }
    public int m_bCanMoveDuringFreezePeriod { get; set; }
    public int m_bClipHitStaticWorld { get; set; }
    public int m_bDeferStartMusicOnWarmup { get; set; }
    public int m_bFlashBuildUp { get; set; }
    public int m_bFlashDspHasBeenCleared { get; set; }
    public int m_bFlashScreenshotHasBeenGrabbed { get; set; }
    public int m_bGrenadeParametersStashed { get; set; }
    public int m_bGuardianShouldSprayCustomXMark { get; set; }
    public int m_bGunGameImmunity { get; set; }
    public int m_bHasDeathInfo { get; set; }
    public int m_bHasMovedSinceSpawn { get; set; }
    public int m_bHasNightVision { get; set; }
    public int m_bHideTargetID { get; set; }
    public int m_bHud_MiniScoreHidden { get; set; }
    public int m_bHud_RadarHidden { get; set; }
    public int m_bInNoDefuseArea { get; set; }
    public int m_bIsDefusing { get; set; }
    public int m_bIsGrabbingHostage { get; set; }
    public int m_bIsRescuing { get; set; }
    public int m_bIsScoped { get; set; }
    public int m_bIsWalking { get; set; }
    public int m_bKilledByHeadshot { get; set; }
    public int m_bKilledByTaser { get; set; }
    public int m_bNightVisionOn { get; set; }
    public int m_bOldIsScoped { get; set; }
    public int m_bResumeZoom { get; set; }
    public int m_bScreenTearFrameCaptured { get; set; }
    public int m_bShouldAutobuyDMWeapons { get; set; }
    public int m_bShouldAutobuyNow { get; set; }
    public int m_bStrafing { get; set; }
    public int m_bSuppressGuardianTooFarWarningAudio { get; set; }
    public int m_bWaitForNoAttack { get; set; }
    public int m_cycleLatch { get; set; }
    public int m_delayTargetIDTimer { get; set; }
    public int m_entitySpottedState { get; set; }
    public int m_fImmuneToGunGameDamageTime { get; set; }
    public int m_fImmuneToGunGameDamageTimeLast { get; set; }
    public int m_fMolotovDamageTime { get; set; }
    public int m_fMolotovUseTime { get; set; }
    public int m_fNextThinkPushAway { get; set; }
    public int m_fRenderingClipPlane { get; set; }
    public int m_flClientDeathTime { get; set; }
    public int m_flCurrentMusicStartTime { get; set; }
    public int m_flDeathCCWeight { get; set; }
    public int m_flDeathInfoTime { get; set; }
    public int m_flDetectedByEnemySensorTime { get; set; }
    public int m_flEmitSoundTime { get; set; }
    public int m_flFlashBangTime { get; set; }
    public int m_flFlashDuration { get; set; }
    public int m_flFlashMaxAlpha { get; set; }
    public int m_flFlashOverlayAlpha { get; set; }
    public int m_flFlashScreenshotAlpha { get; set; }
    public int m_flGuardianTooFarDistFrac { get; set; }
    public int m_flHealthFadeAlpha { get; set; }
    public int m_flHealthFadeValue { get; set; }
    public int m_flHitHeading { get; set; }
    public int m_flLastCollisionCeiling { get; set; }
    public int m_flLastCollisionCeilingChangeTime { get; set; }
    public int m_flLastSmokeAge { get; set; }
    public int m_flLastSmokeOverlayAlpha { get; set; }
    public int m_flLastSpawnTimeIndex { get; set; }
    public int m_flLowerBodyYawTarget { get; set; }
    public int m_flMusicRoundStartTime { get; set; }
    public int m_flNextGuardianTooFarWarning { get; set; }
    public int m_flNextMagDropTime { get; set; }
    public int m_flNightVisionAlpha { get; set; }
    public int m_flPrevMatchEndTime { get; set; }
    public int m_flPrevRoundEndTime { get; set; }
    public int m_flProgressBarStartTime { get; set; }
    public int m_flSlopeDropHeight { get; set; }
    public int m_flSlopeDropOffset { get; set; }
    public int m_flVelocityModifier { get; set; }
    public int m_grenadeParameterStashTime { get; set; }
    public int m_hMuzzleFlashShape { get; set; }
    public int m_hOriginalController { get; set; }
    public int m_holdTargetIDTimer { get; set; }
    public int m_iAddonBits { get; set; }
    public int m_iBlockingUseActionInProgress { get; set; }
    public int m_iDirection { get; set; }
    public int m_iHealthBarRenderMaskIndex { get; set; }
    public int m_iIDEntIndex { get; set; }
    public int m_iMoveState { get; set; }
    public int m_iOldIDEntIndex { get; set; }
    public int m_iPlayerState { get; set; }
    public int m_iPrimaryAddon { get; set; }
    public int m_iProgressBarDuration { get; set; }
    public int m_iSecondaryAddon { get; set; }
    public int m_iShotsFired { get; set; }
    public int m_iStartAccount { get; set; }
    public int m_iTargetedWeaponEntIndex { get; set; }
    public int m_iThrowGrenadeCounter { get; set; }
    public int m_ignoreLadderJumpTime { get; set; }
    public int m_ladderSurpressionTimer { get; set; }
    public int m_lastLadderNormal { get; set; }
    public int m_lastLadderPos { get; set; }
    public int m_lastStandingPos { get; set; }
    public int m_nDeathCamMusic { get; set; }
    public int m_nHeavyAssaultSuitCooldownRemaining { get; set; }
    public int m_nHitBodyPart { get; set; }
    public int m_nLastClipPlaneSetupFrame { get; set; }
    public int m_nLastConcurrentKilled { get; set; }
    public int m_nLastKillerIndex { get; set; }
    public int m_nLastMagDropAttachmentIndex { get; set; }
    public int m_nMyCollisionGroup { get; set; }
    public int m_nPlayerInfernoBodyFx { get; set; }
    public int m_nPlayerInfernoFootFx { get; set; }
    public int m_nPlayerSmokedFx { get; set; }
    public int m_nSurvivalTeamNumber { get; set; }
    public int m_nWhichBombZone { get; set; }
    public int m_pClippingWeapon { get; set; }
    public int m_pPingServices { get; set; }
    public int m_pViewModelServices { get; set; }
    public int m_previousPlayerState { get; set; }
    public int m_serverIntendedCycle { get; set; }
    public int m_thirdPersonHeading { get; set; }
    public int m_unCurrentEquipmentValue { get; set; }
    public int m_unFreezetimeEndEquipmentValue { get; set; }
    public int m_unRoundStartEquipmentValue { get; set; }
    public int m_vHeadConstraintOffset { get; set; }
    public int m_vLastSmokeOverlayColor { get; set; }
    public int m_vecBulletHitModels { get; set; }
    public int m_vecDeathInfoOrigin { get; set; }
    public int m_vecIntroStartEyePosition { get; set; }
    public int m_vecIntroStartPlayerForward { get; set; }
    public int m_vecLastAliveLocalVelocity { get; set; }
    public int m_vecLastClipCameraForward { get; set; }
    public int m_vecLastClipCameraPos { get; set; }
    public int m_vecLastMuzzleFlashPos { get; set; }
    public int m_vecPickupModelSlerpers { get; set; }
    public int m_vecPlayerPatchEconIndices { get; set; }
    public int m_vecStashedGrenadeThrowPosition { get; set; }
    public int m_vecStashedVelocity { get; set; }
    public int m_vecThirdPersonViewPositionOverride { get; set; }
    public int m_vecThrowPositionHistory { get; set; }
    public int m_vecVelocityHistory { get; set; }
    public int m_bEndMatchNextMapAllVoted { get; set; }
    public int m_bHostageAlive { get; set; }
    public int m_bombsiteCenterA { get; set; }
    public int m_bombsiteCenterB { get; set; }
    public int m_foundGoalPositions { get; set; }
    public int m_hostageRescueX { get; set; }
    public int m_hostageRescueY { get; set; }
    public int m_hostageRescueZ { get; set; }
    public int m_iHostageEntityIDs { get; set; }
    public int m_isHostageFollowingSomeone { get; set; }
    public int m_bSurrendered { get; set; }
    public int m_iClanID { get; set; }
    public int m_numMapVictories { get; set; }
    public int m_scoreFirstHalf { get; set; }
    public int m_scoreOvertime { get; set; }
    public int m_scoreSecondHalf { get; set; }
    public int m_szClanTeamname { get; set; }
    public int m_szTeamFlagImage { get; set; }
    public int m_szTeamLogoImage { get; set; }
    public int m_szTeamMatchStat { get; set; }
    public int m_ClientPreviousWeaponState { get; set; }
    public int m_IronSightController { get; set; }
    public int m_OnPlayerPickup { get; set; }
    public int m_bBurstMode { get; set; }
    public int m_bFireOnEmpty { get; set; }
    public int m_bGlowForPing { get; set; }
    public int m_bInReload { get; set; }
    public int m_bIsHauledBack { get; set; }
    public int m_bOldFirstPersonSpectatedState { get; set; }
    public int m_bReloadVisuallyComplete { get; set; }
    public int m_bReloadsWithClips { get; set; }
    public int m_bSilencerOn { get; set; }
    public int m_bUIWeapon { get; set; }
    public int m_bVisualsDataSet { get; set; }
    public int m_bWasOwnedByCT { get; set; }
    public int m_bWasOwnedByTerrorist { get; set; }
    public int m_donated { get; set; }
    public int m_ePlayerFireEvent { get; set; }
    public int m_ePlayerFireEventAttackType { get; set; }
    public int m_fAccuracyPenalty { get; set; }
    public int m_fAccuracySmoothedForZoom { get; set; }
    public int m_fLastShotTime { get; set; }
    public int m_fScopeZoomEndTime { get; set; }
    public int m_flCrosshairDistance { get; set; }
    public int m_flDroppedAtTime { get; set; }
    public int m_flFireSequenceStartTime { get; set; }
    public int m_flGunAccuracyPositionDeprecated { get; set; }
    public int m_flLastAccuracyUpdateTime { get; set; }
    public int m_flLastLOSTraceFailureTime { get; set; }
    public int m_flLastMagDropRequestTime { get; set; }
    public int m_flNextAttackRenderTimeOffset { get; set; }
    public int m_flNextClientFireBulletTime { get; set; }
    public int m_flNextClientFireBulletTime_Repredict { get; set; }
    public int m_flPostponeFireReadyFrac { get; set; }
    public int m_flRecoilIndex { get; set; }
    public int m_flTimeSilencerSwitchComplete { get; set; }
    public int m_flTimeWeaponIdle { get; set; }
    public int m_flTurningInaccuracy { get; set; }
    public int m_flTurningInaccuracyDelta { get; set; }
    public int m_flWatTickOffset { get; set; }
    public int m_gunHeat { get; set; }
    public int m_hCurrentThirdPersonSequence { get; set; }
    public int m_hOurPing { get; set; }
    public int m_hPrevOwner { get; set; }
    public int m_iAlpha { get; set; }
    public int m_iAmmoLastCheck { get; set; }
    public int m_iCrosshairTextureID { get; set; }
    public int m_iIronSightMode { get; set; }
    public int m_iNumEmptyAttacks { get; set; }
    public int m_iOriginalTeamNumber { get; set; }
    public int m_iRecoilIndex { get; set; }
    public int m_iScopeTextureID { get; set; }
    public int m_iState { get; set; }
    public int m_lastSmokeTime { get; set; }
    public int m_nDropTick { get; set; }
    public int m_nFireSequenceStartTimeAck { get; set; }
    public int m_nFireSequenceStartTimeChange { get; set; }
    public int m_nLastEmptySoundCmdNum { get; set; }
    public int m_nOurPingIndex { get; set; }
    public int m_nPostponeFireReadyTicks { get; set; }
    public int m_nSilencerBoneIndex { get; set; }
    public int m_nViewModelIndex { get; set; }
    public int m_seqFirePrimary { get; set; }
    public int m_seqFireSecondary { get; set; }
    public int m_seqIdle { get; set; }
    public int m_smokeAttachments { get; set; }
    public int m_thirdPersonFireSequences { get; set; }
    public int m_thirdPersonSequences { get; set; }
    public int m_vecOurPingPos { get; set; }
    public int m_vecTurningInaccuracyEyeDirLast { get; set; }
    public int m_weaponMode { get; set; }
    public int m_bNeedsBoltAction { get; set; }
    public int m_iBurstShotsRemaining { get; set; }
    public int m_iSilencerBodygroup { get; set; }
    public int m_inPrecache { get; set; }
    public int m_silencedModelIndex { get; set; }
    public int m_zoomLevel { get; set; }
    public int m_AttributeManager { get; set; }
    public int m_OriginalOwnerXuidHigh { get; set; }
    public int m_OriginalOwnerXuidLow { get; set; }
    public int m_bAttributesInitialized { get; set; }
    public int m_hHolidayHatAddon { get; set; }
    public int m_hWaterWakeParticles { get; set; }
    public int m_jumpedThisFrame { get; set; }
    public int m_leader { get; set; }
    public int m_MaxFalloff { get; set; }
    public int m_MinFalloff { get; set; }
    public int m_bClientSide { get; set; }
    public int m_bEnabled { get; set; }
    public int m_bEnabledOnClient { get; set; }
    public int m_bExclusive { get; set; }
    public int m_bFadingIn { get; set; }
    public int m_bMaster { get; set; }
    public int m_flCurWeight { get; set; }
    public int m_flCurWeightOnClient { get; set; }
    public int m_flFadeDuration { get; set; }
    public int m_flFadeInDuration { get; set; }
    public int m_flFadeOutDuration { get; set; }
    public int m_flFadeStartTime { get; set; }
    public int m_flFadeStartWeight { get; set; }
    public int m_flMaxWeight { get; set; }
    public int m_netlookupFilename { get; set; }
    public int m_vecOrigin { get; set; }
    public int m_FadeDuration { get; set; }
    public int m_LastEnterTime { get; set; }
    public int m_LastEnterWeight { get; set; }
    public int m_LastExitTime { get; set; }
    public int m_LastExitWeight { get; set; }
    public int m_MaxWeight { get; set; }
    public int m_Weight { get; set; }
    public int m_lookupFilename { get; set; }
    public int m_flTimeParticleEffectSpawn { get; set; }
    public int m_nClientLastKnownDecoyShotTick { get; set; }
    public int m_nDecoyShotTick { get; set; }
    public int __m_pChainEntity { get; set; }
    public int m_animationController { get; set; }
    public int m_Exponent { get; set; }
    public int m_Flags { get; set; }
    public int m_InnerAngle { get; set; }
    public int m_LightStyle { get; set; }
    public int m_OuterAngle { get; set; }
    public int m_Radius { get; set; }
    public int m_SpotRadius { get; set; }
    public int m_OnAnimReachedEnd { get; set; }
    public int m_OnAnimReachedStart { get; set; }
    public int m_bCreateNonSolid { get; set; }
    public int m_bFiredStartEndOutput { get; set; }
    public int m_bForceNpcExclude { get; set; }
    public int m_bIsOverrideProp { get; set; }
    public int m_bRandomizeCycle { get; set; }
    public int m_bStartDisabled { get; set; }
    public int m_bUseAnimGraph { get; set; }
    public int m_bUseHitboxesForRenderBox { get; set; }
    public int m_glowColor { get; set; }
    public int m_iCachedFrameCount { get; set; }
    public int m_iInitialGlowState { get; set; }
    public int m_iszIdleAnim { get; set; }
    public int m_nGlowRange { get; set; }
    public int m_nGlowRangeMin { get; set; }
    public int m_nGlowTeam { get; set; }
    public int m_nIdleAnimLoopMode { get; set; }
    public int m_pOutputAnimBegun { get; set; }
    public int m_pOutputAnimLoopCycleOver { get; set; }
    public int m_pOutputAnimOver { get; set; }
    public int m_vecCachedRenderMaxs { get; set; }
    public int m_vecCachedRenderMins { get; set; }
    public int m_bAttachmentDirty { get; set; }
    public int m_bClientside { get; set; }
    public int m_bParticleSystemsCreated { get; set; }
    public int m_flFallbackWear { get; set; }
    public int m_flFlexDelayTime { get; set; }
    public int m_flFlexDelayedWeight { get; set; }
    public int m_hOldProvidee { get; set; }
    public int m_hViewmodelAttachment { get; set; }
    public int m_iNumOwnerValidationRetries { get; set; }
    public int m_iOldTeam { get; set; }
    public int m_nFallbackPaintKit { get; set; }
    public int m_nFallbackSeed { get; set; }
    public int m_nFallbackStatTrak { get; set; }
    public int m_nUnloadedModelIndex { get; set; }
    public int m_vecAttachedModels { get; set; }
    public int m_vecAttachedParticles { get; set; }
    public int m_AttributeList { get; set; }
    public int m_NetworkedDynamicAttributes { get; set; }
    public int m_bDisallowSOC { get; set; }
    public int m_bInitialized { get; set; }
    public int m_bInitializedTags { get; set; }
    public int m_bInventoryImageRgbaRequested { get; set; }
    public int m_bInventoryImageTriedCache { get; set; }
    public int m_bIsStoreItem { get; set; }
    public int m_bIsTradeItem { get; set; }
    public int m_bRestoreCustomMaterialAfterPrecache { get; set; }
    public int m_iAccountID { get; set; }
    public int m_iEntityLevel { get; set; }
    public int m_iEntityQuality { get; set; }
    public int m_iEntityQuantity { get; set; }
    public int m_iInventoryPosition { get; set; }
    public int m_iItemDefinitionIndex { get; set; }
    public int m_iItemID { get; set; }
    public int m_iItemIDHigh { get; set; }
    public int m_iItemIDLow { get; set; }
    public int m_iQualityOverride { get; set; }
    public int m_iRarityOverride { get; set; }
    public int m_nInventoryImageRgbaHeight { get; set; }
    public int m_nInventoryImageRgbaWidth { get; set; }
    public int m_szCurrentLoadCachedFileName { get; set; }
    public int m_szCustomName { get; set; }
    public int m_szCustomNameOverride { get; set; }
    public int m_unClientFlags { get; set; }
    public int m_unOverrideStyle { get; set; }
    public int m_bCoreExplode { get; set; }
    public int m_bLinkedToServerEnt { get; set; }
    public int m_flFadeInLength { get; set; }
    public int m_flFadeInStart { get; set; }
    public int m_flFadeOutLength { get; set; }
    public int m_flFadeOutModelLength { get; set; }
    public int m_flFadeOutModelStart { get; set; }
    public int m_flFadeOutStart { get; set; }
    public int m_flNextSparkTime { get; set; }
    public int m_flStartTime { get; set; }
    public int m_nDissolveType { get; set; }
    public int m_nMagnitude { get; set; }
    public int m_vDissolverOrigin { get; set; }
    public int m_bCheapEffect { get; set; }
    public int m_hEntAttached { get; set; }
    public int m_hOldAttached { get; set; }
    public int m_Color { get; set; }
    public int m_bCustomCubemapTexture { get; set; }
    public int m_bMoveable { get; set; }
    public int m_flBrightness { get; set; }
    public int m_flEdgeFadeDist { get; set; }
    public int m_hCubemapTexture { get; set; }
    public int m_hLightProbeDirectLightIndicesTexture { get; set; }
    public int m_hLightProbeDirectLightScalarsTexture { get; set; }
    public int m_hLightProbeDirectLightShadowsTexture { get; set; }
    public int m_hLightProbeTexture { get; set; }
    public int m_nEnvCubeMapArrayIndex { get; set; }
    public int m_nHandshake { get; set; }
    public int m_nLightProbeAtlasX { get; set; }
    public int m_nLightProbeAtlasY { get; set; }
    public int m_nLightProbeAtlasZ { get; set; }
    public int m_nLightProbeSizeX { get; set; }
    public int m_nLightProbeSizeY { get; set; }
    public int m_nLightProbeSizeZ { get; set; }
    public int m_nPriority { get; set; }
    public int m_vBoxMaxs { get; set; }
    public int m_vBoxMins { get; set; }
    public int m_vEdgeFadeDists { get; set; }
    public int m_bCopyDiffuseFromDefaultCubemap { get; set; }
    public int m_bDefaultEnvMap { get; set; }
    public int m_bDefaultSpecEnvMap { get; set; }
    public int m_bIndoorCubeMap { get; set; }
    public int m_flDiffuseScale { get; set; }
    public int m_flInfluenceRadius { get; set; }
    public int m_vBoxProjectMaxs { get; set; }
    public int m_vBoxProjectMins { get; set; }
    public int m_bActive { get; set; }
    public int m_bFirstTime { get; set; }
    public int m_bHasHeightFogEnd { get; set; }
    public int m_bHeightFogEnabled { get; set; }
    public int m_flEndDistance { get; set; }
    public int m_flFogFalloffExponent { get; set; }
    public int m_flFogHeightEnd { get; set; }
    public int m_flFogHeightExponent { get; set; }
    public int m_flFogHeightStart { get; set; }
    public int m_flFogHeightWidth { get; set; }
    public int m_flFogMaxOpacity { get; set; }
    public int m_flLODBias { get; set; }
    public int m_flStartDistance { get; set; }
    public int m_hFogCubemapTexture { get; set; }
    public int m_hSkyMaterial { get; set; }
    public int m_iszSkyEntity { get; set; }
    public int m_nCubemapSourceType { get; set; }
    public int m_bProjectOnCharacters { get; set; }
    public int m_bProjectOnWater { get; set; }
    public int m_bProjectOnWorld { get; set; }
    public int m_flDepth { get; set; }
    public int m_flDepthSortBias { get; set; }
    public int m_flHeight { get; set; }
    public int m_flWidth { get; set; }
    public int m_hDecalMaterial { get; set; }
    public int m_nRenderOrder { get; set; }
    public int m_sceneNode { get; set; }
    public int m_flFadeEndDist { get; set; }
    public int m_flFadeStartDist { get; set; }
    public int m_ColorTint { get; set; }
    public int m_flAlphaScale { get; set; }
    public int m_flRadiusScale { get; set; }
    public int m_flSelfIllumScale { get; set; }
    public int m_hTextureOverride { get; set; }
    public int m_bIsActive { get; set; }
    public int m_bWasActive { get; set; }
    public int m_flCurrentOverlayTime { get; set; }
    public int m_flOverlayTimes { get; set; }
    public int m_iCachedDesiredOverlay { get; set; }
    public int m_iCurrentOverlay { get; set; }
    public int m_iDesiredOverlay { get; set; }
    public int m_iszOverlayNames { get; set; }
    public int m_flBrightnessScale { get; set; }
    public int m_flFogMaxEnd { get; set; }
    public int m_flFogMaxStart { get; set; }
    public int m_flFogMinEnd { get; set; }
    public int m_flFogMinStart { get; set; }
    public int m_hSkyMaterialLightingOnly { get; set; }
    public int m_nFogType { get; set; }
    public int m_vTintColor { get; set; }
    public int m_vTintColorLightingOnly { get; set; }
    public int m_bEnableIndirect { get; set; }
    public int m_bIsMaster { get; set; }
    public int m_flAnisotropy { get; set; }
    public int m_flDefaultAnisotropy { get; set; }
    public int m_flDefaultDrawDistance { get; set; }
    public int m_flDefaultScattering { get; set; }
    public int m_flDrawDistance { get; set; }
    public int m_flFadeInEnd { get; set; }
    public int m_flFadeSpeed { get; set; }
    public int m_flIndirectStrength { get; set; }
    public int m_flScattering { get; set; }
    public int m_flStartAnisoTime { get; set; }
    public int m_flStartAnisotropy { get; set; }
    public int m_flStartDrawDistance { get; set; }
    public int m_flStartDrawDistanceTime { get; set; }
    public int m_flStartScatterTime { get; set; }
    public int m_flStartScattering { get; set; }
    public int m_hFogIndirectTexture { get; set; }
    public int m_nForceRefreshCount { get; set; }
    public int m_nIndirectTextureDimX { get; set; }
    public int m_nIndirectTextureDimY { get; set; }
    public int m_nIndirectTextureDimZ { get; set; }
    public int m_flFalloffExponent { get; set; }
    public int m_flStrength { get; set; }
    public int m_nFalloffShape { get; set; }
    public int m_EnvWindShared { get; set; }
    public int m_CurrentSwayVector { get; set; }
    public int m_PrevSwayVector { get; set; }
    public int m_bGusting { get; set; }
    public int m_currentWindVector { get; set; }
    public int m_flAveWindSpeed { get; set; }
    public int m_flGustDuration { get; set; }
    public int m_flInitialWindSpeed { get; set; }
    public int m_flMaxGustDelay { get; set; }
    public int m_flMinGustDelay { get; set; }
    public int m_flSimTime { get; set; }
    public int m_flSwayTime { get; set; }
    public int m_flSwitchTime { get; set; }
    public int m_flVariationTime { get; set; }
    public int m_flWindAngleVariation { get; set; }
    public int m_flWindSpeed { get; set; }
    public int m_flWindSpeedVariation { get; set; }
    public int m_iEntIndex { get; set; }
    public int m_iGustDirChange { get; set; }
    public int m_iInitialWindDir { get; set; }
    public int m_iMaxGust { get; set; }
    public int m_iMaxWind { get; set; }
    public int m_iMinGust { get; set; }
    public int m_iMinWind { get; set; }
    public int m_iWindDir { get; set; }
    public int m_iWindSeed { get; set; }
    public int m_iszGustSound { get; set; }
    public int m_location { get; set; }
    public int m_windRadius { get; set; }
    public int m_skeletonInstance { get; set; }
    public int m_bClipTested { get; set; }
    public int m_bFadingOut { get; set; }
    public int m_flChildFlameSpread { get; set; }
    public int m_flClipPerc { get; set; }
    public int m_flScaleEnd { get; set; }
    public int m_flScaleRegister { get; set; }
    public int m_flScaleStart { get; set; }
    public int m_flScaleTimeEnd { get; set; }
    public int m_flScaleTimeStart { get; set; }
    public int m_nFlameFromAboveModelIndex { get; set; }
    public int m_nFlameModelIndex { get; set; }
    public int m_pFireOverlay { get; set; }
    public int m_tParticleSpawn { get; set; }
    public int m_actualAngles { get; set; }
    public int m_actualPos { get; set; }
    public int m_angle { get; set; }
    public int m_angles { get; set; }
    public int m_averageError { get; set; }
    public int m_buoyancy { get; set; }
    public int m_deathAngle { get; set; }
    public int m_deathDepth { get; set; }
    public int m_errorHistory { get; set; }
    public int m_errorHistoryCount { get; set; }
    public int m_errorHistoryIndex { get; set; }
    public int m_gotUpdate { get; set; }
    public int m_localLifeState { get; set; }
    public int m_poolOrigin { get; set; }
    public int m_pos { get; set; }
    public int m_vel { get; set; }
    public int m_waterLevel { get; set; }
    public int m_wigglePhase { get; set; }
    public int m_wiggleRate { get; set; }
    public int m_wiggleTimer { get; set; }
    public int m_x { get; set; }
    public int m_y { get; set; }
    public int m_z { get; set; }
    public int m_bPlayingUninterruptableAct { get; set; }
    public int m_nUninterruptableActivity { get; set; }
    public int m_bUseAngles { get; set; }
    public int m_fog { get; set; }
    public int m_iChangedVariables { get; set; }
    public int m_destination { get; set; }
    public int m_source { get; set; }
    public int m_flCurrentConveyorOffset { get; set; }
    public int m_flCurrentConveyorSpeed { get; set; }
    public int m_flTargetSpeed { get; set; }
    public int m_flTransitionStartSpeed { get; set; }
    public int m_hConveyorModels { get; set; }
    public int m_nTransitionDurationTicks { get; set; }
    public int m_nTransitionStartTick { get; set; }
    public int m_vecMoveDirEntitySpace { get; set; }
    public int m_EffectName { get; set; }
    public int m_bState { get; set; }
    public int m_nAmbientEffect { get; set; }
    public int m_Dismounts { get; set; }
    public int m_bDisabled { get; set; }
    public int m_bFakeLadder { get; set; }
    public int m_bHasSlack { get; set; }
    public int m_flAutoRideSpeed { get; set; }
    public int m_vecLadderDir { get; set; }
    public int m_vecLocalTop { get; set; }
    public int m_vecPlayerMountPositionBottom { get; set; }
    public int m_vecPlayerMountPositionTop { get; set; }
    public int m_bDraw3DSkybox { get; set; }
    public int m_bRenderShadows { get; set; }
    public int m_bUseUniqueColorTarget { get; set; }
    public int m_brushModelName { get; set; }
    public int m_hTargetCamera { get; set; }
    public int m_nResolutionEnum { get; set; }
    public int m_targetCamera { get; set; }
    public int m_bBombPlantedHere { get; set; }
    public int m_bGradientFogNeedsTextures { get; set; }
    public int m_bIsEnabled { get; set; }
    public int m_flFadeTime { get; set; }
    public int m_flFarZ { get; set; }
    public int m_flFogEndDistance { get; set; }
    public int m_flFogEndHeight { get; set; }
    public int m_flFogStartDistance { get; set; }
    public int m_flFogStartHeight { get; set; }
    public int m_flFogStrength { get; set; }
    public int m_flFogVerticalExponent { get; set; }
    public int m_fogColor { get; set; }
    public int m_hGradientFogTexture { get; set; }
    public int m_bSendHandle { get; set; }
    public int m_bHandsHaveBeenCut { get; set; }
    public int m_blinkTimer { get; set; }
    public int m_chestAttachment { get; set; }
    public int m_eyeAttachment { get; set; }
    public int m_fLastGrabTime { get; set; }
    public int m_fNewestAlphaThinkTime { get; set; }
    public int m_flDeadOrRescuedTime { get; set; }
    public int m_flDropStartTime { get; set; }
    public int m_flGrabSuccessTime { get; set; }
    public int m_flRescueStartTime { get; set; }
    public int m_hHostageGrabber { get; set; }
    public int m_isInit { get; set; }
    public int m_isRescued { get; set; }
    public int m_lookAroundTimer { get; set; }
    public int m_lookAt { get; set; }
    public int m_nHostageState { get; set; }
    public int m_pPredictionOwner { get; set; }
    public int m_reuseTimer { get; set; }
    public int m_vecGrabbedPos { get; set; }
    public int m_BurnNormal { get; set; }
    public int m_bFireIsBurning { get; set; }
    public int m_bInPostEffectTime { get; set; }
    public int m_blosCheck { get; set; }
    public int m_drawableCount { get; set; }
    public int m_fireCount { get; set; }
    public int m_fireParentPositions { get; set; }
    public int m_firePositions { get; set; }
    public int m_flLastGrassBurnThink { get; set; }
    public int m_lastFireCount { get; set; }
    public int m_maxBounds { get; set; }
    public int m_maxFireHalfWidth { get; set; }
    public int m_maxFireHeight { get; set; }
    public int m_minBounds { get; set; }
    public int m_nFireEffectTickBegin { get; set; }
    public int m_nFireLifetime { get; set; }
    public int m_nInfernoType { get; set; }
    public int m_nfxFireDamageEffect { get; set; }
    public int m_nlosperiod { get; set; }
    public int m_nMode { get; set; }
    public int m_vBoxSize { get; set; }
    public int m_bShouldGlow { get; set; }
    public int m_pReticleHintTextName { get; set; }
    public int m_KillingPlayer { get; set; }
    public int m_OwningPlayer { get; set; }
    public int m_CLightComponent { get; set; }
    public int m_Glow { get; set; }
    public int m_flGlowProxySize { get; set; }
    public int m_flHDRColorScale { get; set; }
    public int m_nHorizontalSize { get; set; }
    public int m_nMaxDist { get; set; }
    public int m_nMinDist { get; set; }
    public int m_nOuterMaxDist { get; set; }
    public int m_nVerticalSize { get; set; }
    public int m_pOuter { get; set; }
    public int m_bDisabledHud { get; set; }
    public int m_nAccountIDs { get; set; }
    public int m_nCurrentPhase { get; set; }
    public int m_nDraftType { get; set; }
    public int m_nMapId0 { get; set; }
    public int m_nMapId1 { get; set; }
    public int m_nMapId2 { get; set; }
    public int m_nMapId3 { get; set; }
    public int m_nMapId4 { get; set; }
    public int m_nMapId5 { get; set; }
    public int m_nPhaseDurationTicks { get; set; }
    public int m_nPhaseStartTick { get; set; }
    public int m_nPostDataUpdateTick { get; set; }
    public int m_nStartingSide0 { get; set; }
    public int m_nTeamWinningCoinToss { get; set; }
    public int m_nTeamWithFirstChoice { get; set; }
    public int m_nVoteMapIdsList { get; set; }
    public int m_bIsIncGrenade { get; set; }
    public int m_bShowLight { get; set; }
    public int m_flInnerAngle { get; set; }
    public int m_flOuterAngle { get; set; }
    public int m_bAnimateDuringGameplayPause { get; set; }
    public int m_bFrozen { get; set; }
    public int m_bNoFreeze { get; set; }
    public int m_bNoRamp { get; set; }
    public int m_bNoSave { get; set; }
    public int m_bOldActive { get; set; }
    public int m_bOldFrozen { get; set; }
    public int m_bStartActive { get; set; }
    public int m_clrTint { get; set; }
    public int m_flFreezeTransitionDuration { get; set; }
    public int m_flPreSimTime { get; set; }
    public int m_hControlPointEnts { get; set; }
    public int m_iEffectIndex { get; set; }
    public int m_iServerControlPointAssignments { get; set; }
    public int m_iszControlPointNames { get; set; }
    public int m_iszEffectName { get; set; }
    public int m_nDataCP { get; set; }
    public int m_nStopType { get; set; }
    public int m_nTintCP { get; set; }
    public int m_szSnapshotFileName { get; set; }
    public int m_vServerControlPoints { get; set; }
    public int m_vecDataCPValue { get; set; }
    public int m_PathNodes_Color { get; set; }
    public int m_PathNodes_Name { get; set; }
    public int m_PathNodes_PinEnabled { get; set; }
    public int m_PathNodes_Position { get; set; }
    public int m_PathNodes_RadiusScale { get; set; }
    public int m_PathNodes_TangentIn { get; set; }
    public int m_PathNodes_TangentOut { get; set; }
    public int m_flMaxSimulationTime { get; set; }
    public int m_flParticleSpacing { get; set; }
    public int m_flRadius { get; set; }
    public int m_flSlack { get; set; }
    public int m_nEffectState { get; set; }
    public int m_bAwake { get; set; }
    public int m_bBeingDefused { get; set; }
    public int m_bBombDefused { get; set; }
    public int m_bBombTicking { get; set; }
    public int m_bC4Activated { get; set; }
    public int m_bCannotBeDefused { get; set; }
    public int m_bExplodeWarning { get; set; }
    public int m_bHasExploded { get; set; }
    public int m_bRadarFlash { get; set; }
    public int m_bTenSecWarning { get; set; }
    public int m_bTriggerWarning { get; set; }
    public int m_fLastDefuseTime { get; set; }
    public int m_flC4Blow { get; set; }
    public int m_flC4ExplodeSpectateDuration { get; set; }
    public int m_flDefuseCountDown { get; set; }
    public int m_flDefuseLength { get; set; }
    public int m_flNextBeep { get; set; }
    public int m_flNextGlow { get; set; }
    public int m_flNextRadarFlashTime { get; set; }
    public int m_flTimerLength { get; set; }
    public int m_hBombDefuser { get; set; }
    public int m_hControlPanel { get; set; }
    public int m_hDefuserMultimeter { get; set; }
    public int m_nBombSite { get; set; }
    public int m_nSourceSoundscapeHash { get; set; }
    public int m_pBombDefuser { get; set; }
    public int m_vecC4ExplodeSpectateAng { get; set; }
    public int m_vecC4ExplodeSpectatePos { get; set; }
    public int m_bUrgent { get; set; }
    public int m_hPingedEntity { get; set; }
    public int m_hPlayer { get; set; }
    public int m_iType { get; set; }
    public int m_szPlaceName { get; set; }
    public int m_SprayRenderHelper { get; set; }
    public int m_flCreationTime { get; set; }
    public int m_nEntity { get; set; }
    public int m_nHitbox { get; set; }
    public int m_nPlayer { get; set; }
    public int m_nTintID { get; set; }
    public int m_nUniqueID { get; set; }
    public int m_nVersion { get; set; }
    public int m_rtGcTime { get; set; }
    public int m_ubSignature { get; set; }
    public int m_unAccountID { get; set; }
    public int m_unTraceID { get; set; }
    public int m_vecEndPos { get; set; }
    public int m_vecLeft { get; set; }
    public int m_vecNormal { get; set; }
    public int m_vecStart { get; set; }
    public int m_flFogDistanceMultiplier { get; set; }
    public int m_flFogMaxDensityMultiplier { get; set; }
    public int m_flVisibilityStrength { get; set; }
    public int m_DegreesPerSecond { get; set; }
    public int m_FOV { get; set; }
    public int m_FogColor { get; set; }
    public int m_Resolution { get; set; }
    public int m_TargetFOV { get; set; }
    public int m_bCanHLTVUse { get; set; }
    public int m_bDofEnabled { get; set; }
    public int m_bFogEnable { get; set; }
    public int m_bIsOn { get; set; }
    public int m_bNoSky { get; set; }
    public int m_bUseScreenAspectRatio { get; set; }
    public int m_fBrightness { get; set; }
    public int m_flAspectRatio { get; set; }
    public int m_flDofFarBlurry { get; set; }
    public int m_flDofFarCrisp { get; set; }
    public int m_flDofNearBlurry { get; set; }
    public int m_flDofNearCrisp { get; set; }
    public int m_flDofTiltToGround { get; set; }
    public int m_flFogEnd { get; set; }
    public int m_flFogMaxDensity { get; set; }
    public int m_flFogStart { get; set; }
    public int m_flZFar { get; set; }
    public int m_flZNear { get; set; }
    public int m_pNext { get; set; }
    public int m_bStartEnabled { get; set; }
    public int m_hActivator { get; set; }
    public int m_bAllowInteractionFromAllSceneWorlds { get; set; }
    public int m_bCheckCSSClasses { get; set; }
    public int m_bIgnoreInput { get; set; }
    public int m_flDPI { get; set; }
    public int m_flDepthOffset { get; set; }
    public int m_flInteractDistance { get; set; }
    public int m_unHorizontalAlign { get; set; }
    public int m_unOrientation { get; set; }
    public int m_unOwnerContext { get; set; }
    public int m_unVerticalAlign { get; set; }
    public int m_vecCSSClasses { get; set; }
    public int m_anchorDeltaTransform { get; set; }
    public int m_bDisableMipGen { get; set; }
    public int m_bExcludeFromSaveGames { get; set; }
    public int m_bFollowPlayerAcrossTeleport { get; set; }
    public int m_bForceRecreateNextUpdate { get; set; }
    public int m_bGrabbable { get; set; }
    public int m_bLit { get; set; }
    public int m_bMoveViewToPlayerNextThink { get; set; }
    public int m_bNoDepth { get; set; }
    public int m_bOnlyRenderToTexture { get; set; }
    public int m_bOpaque { get; set; }
    public int m_bRenderBackface { get; set; }
    public int m_bUseOffScreenIndicator { get; set; }
    public int m_nExplicitImageLayout { get; set; }
    public int m_pOffScreenIndicator { get; set; }
    public int m_messageText { get; set; }
    public int m_bListenedTo { get; set; }
    public int m_bRestartAfterRestore { get; set; }
    public int m_flEndTime { get; set; }
    public int m_flStartTimeInCommentary { get; set; }
    public int m_hViewPosition { get; set; }
    public int m_iNodeNumber { get; set; }
    public int m_iNodeNumberMax { get; set; }
    public int m_iszCommentaryFile { get; set; }
    public int m_iszSpeakers { get; set; }
    public int m_iszTitle { get; set; }
    public int m_bDisabledOld { get; set; }
    public int m_bEngaged { get; set; }
    public int m_bFirstUpdate { get; set; }
    public int m_bRequiresUseKey { get; set; }
    public int m_bUpdateOnClient { get; set; }
    public int m_flCurrentMomentum { get; set; }
    public int m_flDisengageDistance { get; set; }
    public int m_flEngageDistance { get; set; }
    public int m_flInputOffset { get; set; }
    public int m_flMaximumChangePerSecond { get; set; }
    public int m_flMomentumModifier { get; set; }
    public int m_flPreviousUpdateTickTime { get; set; }
    public int m_flPreviousValue { get; set; }
    public int m_flRatchetOffset { get; set; }
    public int m_flSnapValue { get; set; }
    public int m_hOutputEntities { get; set; }
    public int m_hRemapLineEnd { get; set; }
    public int m_hRemapLineStart { get; set; }
    public int m_nHapticsType { get; set; }
    public int m_nInputType { get; set; }
    public int m_nMomentumType { get; set; }
    public int m_nOutputType { get; set; }
    public int m_nRatchetType { get; set; }
    public int m_vecPreviousTestPoint { get; set; }
    public int m_FontName { get; set; }
    public int m_bFullbright { get; set; }
    public int m_flFontSize { get; set; }
    public int m_flWorldUnitsPerPx { get; set; }
    public int m_nJustifyHorizontal { get; set; }
    public int m_nJustifyVertical { get; set; }
    public int m_nReorientMode { get; set; }
    public int m_bExposureControl { get; set; }
    public int m_flExposureCompensation { get; set; }
    public int m_flExposureFadeSpeedDown { get; set; }
    public int m_flExposureFadeSpeedUp { get; set; }
    public int m_flMaxExposure { get; set; }
    public int m_flMaxLogExposure { get; set; }
    public int m_flMinExposure { get; set; }
    public int m_flMinLogExposure { get; set; }
    public int m_flRate { get; set; }
    public int m_flTonemapEVSmoothingRange { get; set; }
    public int m_flTonemapMinAvgLum { get; set; }
    public int m_flTonemapPercentBrightPixels { get; set; }
    public int m_flTonemapPercentTarget { get; set; }
    public int m_hPostSettings { get; set; }
    public int m_iCurrentMaxRagdollCount { get; set; }
    public int m_WeaponSequence { get; set; }
    public int m_flBlendWeight { get; set; }
    public int m_flBlendWeightCurrent { get; set; }
    public int m_hRagdollSource { get; set; }
    public int m_iEyeAttachment { get; set; }
    public int m_parentPhysicsBoneIndices { get; set; }
    public int m_ragAngles { get; set; }
    public int m_ragPos { get; set; }
    public int m_worldSpaceBoneComputationOrder { get; set; }
    public int m_attachmentPointBoneSpace { get; set; }
    public int m_attachmentPointRagdollSpace { get; set; }
    public int m_bHasParent { get; set; }
    public int m_boneIndexAttached { get; set; }
    public int m_parentTime { get; set; }
    public int m_ragdollAttachedObjectIndex { get; set; }
    public int m_vecOffset { get; set; }
    public int m_bBlockersPresent { get; set; }
    public int m_bRoundInProgress { get; set; }
    public int m_iBombSite { get; set; }
    public int m_iFirstSecondHalfRound { get; set; }
    public int m_nMatchSeed { get; set; }
    public int m_LightValues { get; set; }
    public int m_LinksTouchingSomething { get; set; }
    public int m_PhysicsDelegate { get; set; }
    public int m_RopeFlags { get; set; }
    public int m_RopeLength { get; set; }
    public int m_Slack { get; set; }
    public int m_Subdiv { get; set; }
    public int m_TextureHeight { get; set; }
    public int m_TextureScale { get; set; }
    public int m_Width { get; set; }
    public int m_bApplyWind { get; set; }
    public int m_bConstrainBetweenEndpoints { get; set; }
    public int m_bEndPointAttachmentAnglesDirty { get; set; }
    public int m_bEndPointAttachmentPositionsDirty { get; set; }
    public int m_bNewDataThisFrame { get; set; }
    public int m_bPhysicsInitted { get; set; }
    public int m_bPrevEndPointPos { get; set; }
    public int m_fLockedPoints { get; set; }
    public int m_fPrevLockedPoints { get; set; }
    public int m_flCurScroll { get; set; }
    public int m_flCurrentGustLifetime { get; set; }
    public int m_flCurrentGustTimer { get; set; }
    public int m_flScrollSpeed { get; set; }
    public int m_flTimeToNextGust { get; set; }
    public int m_hEndPoint { get; set; }
    public int m_hMaterial { get; set; }
    public int m_hStartPoint { get; set; }
    public int m_iEndAttachment { get; set; }
    public int m_iForcePointMoveCounter { get; set; }
    public int m_iRopeMaterialModelIndex { get; set; }
    public int m_iStartAttachment { get; set; }
    public int m_nChangeCount { get; set; }
    public int m_nLinksTouchingSomething { get; set; }
    public int m_nSegments { get; set; }
    public int m_vCachedEndPointAttachmentAngle { get; set; }
    public int m_vCachedEndPointAttachmentPos { get; set; }
    public int m_vColorMod { get; set; }
    public int m_vPrevEndPointPos { get; set; }
    public int m_vWindDir { get; set; }
    public int m_vecImpulse { get; set; }
    public int m_vecPreviousImpulse { get; set; }
    public int m_QueuedEvents { get; set; }
    public int m_bAutogenerated { get; set; }
    public int m_bClientOnly { get; set; }
    public int m_bIsPlayingBack { get; set; }
    public int m_bMultiplayer { get; set; }
    public int m_bPaused { get; set; }
    public int m_bWasPlaying { get; set; }
    public int m_flCurrentTime { get; set; }
    public int m_flForceClientTime { get; set; }
    public int m_hActorList { get; set; }
    public int m_hOwner { get; set; }
    public int m_nSceneStringIndex { get; set; }
    public int m_ShardDesc { get; set; }
    public int m_skyboxData { get; set; }
    public int m_skyboxSlotToken { get; set; }
    public int m_VoxelFrameData { get; set; }
    public int m_bDidSmokeEffect { get; set; }
    public int m_bSmokeEffectSpawned { get; set; }
    public int m_bSmokeVolumeDataReceived { get; set; }
    public int m_nRandomSeed { get; set; }
    public int m_nSmokeEffectTickBegin { get; set; }
    public int m_vSmokeColor { get; set; }
    public int m_vSmokeDetonationPos { get; set; }
    public int m_bWasEnabled { get; set; }
    public int m_iszSoundAreaType { get; set; }
    public int m_vPos { get; set; }
    public int m_flDMBonusStartTime { get; set; }
    public int m_flDMBonusTimeLength { get; set; }
    public int m_nDMBonusWeaponLoadoutSlot { get; set; }
    public int m_vMax { get; set; }
    public int m_vMin { get; set; }
    public int m_bUseAutoCompare { get; set; }
    public int m_iOpvarIndex { get; set; }
    public int m_iszOperatorName { get; set; }
    public int m_iszOpvarName { get; set; }
    public int m_iszStackName { get; set; }
    public int m_flLightScale { get; set; }
    public int m_bWorldSpaceScale { get; set; }
    public int m_flBrightnessDuration { get; set; }
    public int m_flBrightnessTimeStart { get; set; }
    public int m_flDestScale { get; set; }
    public int m_flDieTime { get; set; }
    public int m_flFrame { get; set; }
    public int m_flLastTime { get; set; }
    public int m_flMaxFrame { get; set; }
    public int m_flScaleDuration { get; set; }
    public int m_flSpriteFramerate { get; set; }
    public int m_flSpriteScale { get; set; }
    public int m_flStartScale { get; set; }
    public int m_hAttachedToEntity { get; set; }
    public int m_hOldSpriteMaterial { get; set; }
    public int m_hSpriteMaterial { get; set; }
    public int m_nAttachment { get; set; }
    public int m_nBrightness { get; set; }
    public int m_nDestBrightness { get; set; }
    public int m_nSpriteHeight { get; set; }
    public int m_nSpriteWidth { get; set; }
    public int m_nStartBrightness { get; set; }
    public int m_bOn { get; set; }
    public int m_bmaxColor { get; set; }
    public int m_clrOverlay { get; set; }
    public int m_fdistNormalize { get; set; }
    public int m_flAlphaHaze { get; set; }
    public int m_flAlphaHdr { get; set; }
    public int m_flFarZScale { get; set; }
    public int m_flHazeScale { get; set; }
    public int m_flRotation { get; set; }
    public int m_flSize { get; set; }
    public int m_fxSSSunFlareEffectIndex { get; set; }
    public int m_fxSunFlareEffectIndex { get; set; }
    public int m_iszSSEffectName { get; set; }
    public int m_vDirection { get; set; }
    public int m_vSunPos { get; set; }
    public int m_aPlayerControllers { get; set; }
    public int m_aPlayers { get; set; }
    public int m_iScore { get; set; }
    public int m_szTeamname { get; set; }
    public int m_bAutoCountdown { get; set; }
    public int m_bFire10SecRemain { get; set; }
    public int m_bFire1MinRemain { get; set; }
    public int m_bFire1SecRemain { get; set; }
    public int m_bFire2MinRemain { get; set; }
    public int m_bFire2SecRemain { get; set; }
    public int m_bFire30SecRemain { get; set; }
    public int m_bFire3MinRemain { get; set; }
    public int m_bFire3SecRemain { get; set; }
    public int m_bFire4MinRemain { get; set; }
    public int m_bFire4SecRemain { get; set; }
    public int m_bFire5MinRemain { get; set; }
    public int m_bFire5SecRemain { get; set; }
    public int m_bFireFinished { get; set; }
    public int m_bInCaptureWatchState { get; set; }
    public int m_bIsDisabled { get; set; }
    public int m_bShowInHUD { get; set; }
    public int m_bStartPaused { get; set; }
    public int m_bStopWatchTimer { get; set; }
    public int m_bTimerPaused { get; set; }
    public int m_flTimeRemaining { get; set; }
    public int m_flTimerEndTime { get; set; }
    public int m_flTotalTime { get; set; }
    public int m_nOldTimerLength { get; set; }
    public int m_nOldTimerState { get; set; }
    public int m_nSetupTimeLength { get; set; }
    public int m_nState { get; set; }
    public int m_nTimerInitialLength { get; set; }
    public int m_nTimerLength { get; set; }
    public int m_nTimerMaxLength { get; set; }
    public int m_bLoop { get; set; }
    public int m_flFPS { get; set; }
    public int m_flStartFrame { get; set; }
    public int m_hPositionKeys { get; set; }
    public int m_hRotationKeys { get; set; }
    public int m_vAnimationBoundsMax { get; set; }
    public int m_vAnimationBoundsMin { get; set; }
    public int m_flAutoExposureMax { get; set; }
    public int m_flAutoExposureMin { get; set; }
    public int m_flExposureAdaptationSpeedDown { get; set; }
    public int m_flExposureAdaptationSpeedUp { get; set; }
    public int m_BuoyancyHelper { get; set; }
    public int m_flFluidDensity { get; set; }
    public int m_angularDamping { get; set; }
    public int m_angularLimit { get; set; }
    public int m_bCollapseToForcePoint { get; set; }
    public int m_bConvertToDebrisWhenPossible { get; set; }
    public int m_flDampingRatio { get; set; }
    public int m_flFrequency { get; set; }
    public int m_gravityScale { get; set; }
    public int m_linearDamping { get; set; }
    public int m_linearForce { get; set; }
    public int m_linearLimit { get; set; }
    public int m_vecLinearForceDirection { get; set; }
    public int m_vecLinearForcePointAt { get; set; }
    public int m_vecLinearForcePointAtWorld { get; set; }
    public int m_bIsYesNoVote { get; set; }
    public int m_bTypeDirty { get; set; }
    public int m_bVotesDirty { get; set; }
    public int m_iActiveIssueIndex { get; set; }
    public int m_iOnlyTeamToVote { get; set; }
    public int m_nPotentialVotes { get; set; }
    public int m_nVoteOptionCount { get; set; }
    public int m_SequenceCompleteTimer { get; set; }
    public int m_bRedraw { get; set; }
    public int m_flDisplayHealth { get; set; }
    public int m_fFireTime { get; set; }
    public int m_NewColor { get; set; }
    public int m_OldColor { get; set; }
    public int m_flNewEnd { get; set; }
    public int m_flNewFarZ { get; set; }
    public int m_flNewHDRColorScale { get; set; }
    public int m_flNewMaxDensity { get; set; }
    public int m_flNewStart { get; set; }
    public int m_flOldEnd { get; set; }
    public int m_flOldFarZ { get; set; }
    public int m_flOldHDRColorScale { get; set; }
    public int m_flOldMaxDensity { get; set; }
    public int m_flOldStart { get; set; }
    public int m_flTransitionTime { get; set; }
    public int m_hCtrl { get; set; }
    public int m_bPassWhenTrue { get; set; }
    public int m_nMutatorCondition { get; set; }
    public int m_strMutatorConditionContainerName { get; set; }
    public int m_strMutatorConditionContainerVarName { get; set; }
    public int m_strMutatorConditionContainerVarValue { get; set; }
    public int m_bCaptureInRenderDoc { get; set; }
    public int m_bIsScratchTarget { get; set; }
    public int m_bSplatDebugInfo { get; set; }
    public int m_colDrawText_Color { get; set; }
    public int m_nMutatorCommandType { get; set; }
    public int m_nResolution { get; set; }
    public int m_nSetValue_Value { get; set; }
    public int m_strCopyKeysWithSuffix_FindSuffix { get; set; }
    public int m_strCopyKeysWithSuffix_InputContainerSrc { get; set; }
    public int m_strCopyKeysWithSuffix_ReplaceSuffix { get; set; }
    public int m_strCopyMatchingKeys_InputContainerSrc { get; set; }
    public int m_strCopyProperty_InputContainerProperty { get; set; }
    public int m_strCopyProperty_InputContainerSrc { get; set; }
    public int m_strCopyProperty_TargetProperty { get; set; }
    public int m_strDrawText_Font { get; set; }
    public int m_strDrawText_InputContainerProperty { get; set; }
    public int m_strDrawText_InputContainerSrc { get; set; }
    public int m_strGenerateTexture_InitialContainer { get; set; }
    public int m_strGenerateTexture_TargetParam { get; set; }
    public int m_strInitWith_Container { get; set; }
    public int m_strPopInputQueue_Container { get; set; }
    public int m_strRandomRollInputVars_SeedInputVar { get; set; }
    public int m_vecConditionalMutators { get; set; }
    public int m_vecConditions { get; set; }
    public int m_vecDrawText_Position { get; set; }
    public int m_vecRandomRollInputVars_InputVarsToRoll { get; set; }
    public int m_vecTexGenInstructions { get; set; }
    public int m_vecCompMatIncludes { get; set; }
    public int m_vecCompositeInputContainers { get; set; }
    public int m_vecMatchFilters { get; set; }
    public int m_vecPropertyMutators { get; set; }
    public int m_OwnerOnlyPredNetBoolVariables { get; set; }
    public int m_OwnerOnlyPredNetByteVariables { get; set; }
    public int m_OwnerOnlyPredNetFloatVariables { get; set; }
    public int m_OwnerOnlyPredNetGlobalSymbolVariables { get; set; }
    public int m_OwnerOnlyPredNetIntVariables { get; set; }
    public int m_OwnerOnlyPredNetQuaternionVariables { get; set; }
    public int m_OwnerOnlyPredNetUInt16Variables { get; set; }
    public int m_OwnerOnlyPredNetUInt32Variables { get; set; }
    public int m_OwnerOnlyPredNetUInt64Variables { get; set; }
    public int m_OwnerOnlyPredNetVectorVariables { get; set; }
    public int m_PredNetBoolVariables { get; set; }
    public int m_PredNetByteVariables { get; set; }
    public int m_PredNetFloatVariables { get; set; }
    public int m_PredNetGlobalSymbolVariables { get; set; }
    public int m_PredNetIntVariables { get; set; }
    public int m_PredNetQuaternionVariables { get; set; }
    public int m_PredNetUInt16Variables { get; set; }
    public int m_PredNetUInt32Variables { get; set; }
    public int m_PredNetUInt64Variables { get; set; }
    public int m_PredNetVectorVariables { get; set; }
    public int m_flLastTeleportTime { get; set; }
    public int m_nBoolVariablesCount { get; set; }
    public int m_nOwnerOnlyBoolVariablesCount { get; set; }
    public int m_nRandomSeedOffset { get; set; }
    public int m_flFOVRate { get; set; }
    public int m_flFOVTime { get; set; }
    public int m_flLastShotFOV { get; set; }
    public int m_hZoomOwner { get; set; }
    public int m_iFOV { get; set; }
    public int m_iFOVStart { get; set; }
    public int m_ChildModelName { get; set; }
    public int m_KVModelStateChoices { get; set; }
    public int m_ModelName { get; set; }
    public int m_bEnableChildModel { get; set; }
    public int m_flCycle { get; set; }
    public int m_nSequenceIndex { get; set; }
    public int m_vecCompositeMaterialAssemblyProcedures { get; set; }
    public int m_vecCompositeMaterials { get; set; }
    public int m_bExposeExternally { get; set; }
    public int m_nCompositeMaterialInputContainerSourceType { get; set; }
    public int m_strAlias { get; set; }
    public int m_strAttrName { get; set; }
    public int m_strAttrNameForVar { get; set; }
    public int m_strSpecificContainerMaterial { get; set; }
    public int m_vecLooseVariables { get; set; }
    public int m_bExposedVariableIsFixedRange { get; set; }
    public int m_bHasFloatBounds { get; set; }
    public int m_bValueBoolean { get; set; }
    public int m_cValueColor4 { get; set; }
    public int m_flValueFloatW { get; set; }
    public int m_flValueFloatW_Max { get; set; }
    public int m_flValueFloatW_Min { get; set; }
    public int m_flValueFloatX { get; set; }
    public int m_flValueFloatX_Max { get; set; }
    public int m_flValueFloatX_Min { get; set; }
    public int m_flValueFloatY { get; set; }
    public int m_flValueFloatY_Max { get; set; }
    public int m_flValueFloatY_Min { get; set; }
    public int m_flValueFloatZ { get; set; }
    public int m_flValueFloatZ_Max { get; set; }
    public int m_flValueFloatZ_Min { get; set; }
    public int m_nTextureType { get; set; }
    public int m_nValueIntW { get; set; }
    public int m_nValueIntX { get; set; }
    public int m_nValueIntY { get; set; }
    public int m_nValueIntZ { get; set; }
    public int m_nValueSystemVar { get; set; }
    public int m_nVariableType { get; set; }
    public int m_strExposedFriendlyGroupName { get; set; }
    public int m_strExposedFriendlyName { get; set; }
    public int m_strExposedHiddenWhenTrue { get; set; }
    public int m_strExposedVisibleWhenTrue { get; set; }
    public int m_strName { get; set; }
    public int m_strResourceMaterial { get; set; }
    public int m_strString { get; set; }
    public int m_strTextureCompilationVtexTemplate { get; set; }
    public int m_strTextureContentAssetPath { get; set; }
    public int m_strTextureRuntimeResourcePath { get; set; }
    public int m_nCompositeMaterialMatchFilterType { get; set; }
    public int m_strMatchFilter { get; set; }
    public int m_strMatchValue { get; set; }
    public int m_FinalKVs { get; set; }
    public int m_PreGenerationKVs { get; set; }
    public int m_TargetKVs { get; set; }
    public int m_vecGeneratedTextures { get; set; }
    public int m_duration { get; set; }
    public int m_nWorldGroupId { get; set; }
    public int m_timescale { get; set; }
    public int m_timestamp { get; set; }
    public int m_ID { get; set; }
    public int m_Values { get; set; }
    public int m_bSpotted { get; set; }
    public int m_bSpottedByMask { get; set; }
    public int m_strBitmapName { get; set; }
    public int m_bAbandonAllowsSurrender { get; set; }
    public int m_bAbandonOffersInstantSurrender { get; set; }
    public int m_bCanControlObservedBot { get; set; }
    public int m_bCannotBeKicked { get; set; }
    public int m_bControllingBot { get; set; }
    public int m_bDisconnection1MinWarningPrinted { get; set; }
    public int m_bEverFullyConnected { get; set; }
    public int m_bEverPlayedOnTeam { get; set; }
    public int m_bHasBeenControlledByPlayerThisRound { get; set; }
    public int m_bHasCommunicationAbuseMute { get; set; }
    public int m_bHasControlledBotThisRound { get; set; }
    public int m_bIsPlayerNameDirty { get; set; }
    public int m_bMvpNoMusic { get; set; }
    public int m_bPawnHasDefuser { get; set; }
    public int m_bPawnHasHelmet { get; set; }
    public int m_bPawnIsAlive { get; set; }
    public int m_bScoreReported { get; set; }
    public int m_eMvpReason { get; set; }
    public int m_flForceTeamTime { get; set; }
    public int m_flPreviousForceJoinTeamTime { get; set; }
    public int m_hObserverPawn { get; set; }
    public int m_hOriginalControllerOfCurrentPawn { get; set; }
    public int m_hPlayerPawn { get; set; }
    public int m_iCoachingTeam { get; set; }
    public int m_iCompTeammateColor { get; set; }
    public int m_iCompetitiveRankType { get; set; }
    public int m_iCompetitiveRanking { get; set; }
    public int m_iCompetitiveRankingPredicted_Loss { get; set; }
    public int m_iCompetitiveRankingPredicted_Tie { get; set; }
    public int m_iCompetitiveRankingPredicted_Win { get; set; }
    public int m_iCompetitiveWins { get; set; }
    public int m_iDraftIndex { get; set; }
    public int m_iMVPs { get; set; }
    public int m_iMusicKitID { get; set; }
    public int m_iMusicKitMVPs { get; set; }
    public int m_iPawnArmor { get; set; }
    public int m_iPawnBotDifficulty { get; set; }
    public int m_iPawnHealth { get; set; }
    public int m_iPawnLifetimeEnd { get; set; }
    public int m_iPawnLifetimeStart { get; set; }
    public int m_iPendingTeamNum { get; set; }
    public int m_iPing { get; set; }
    public int m_msQueuedModeDisconnectionTimestamp { get; set; }
    public int m_nBotsControlledThisRound { get; set; }
    public int m_nDisconnectionTick { get; set; }
    public int m_nEndMatchNextMapVote { get; set; }
    public int m_nPawnCharacterDefIndex { get; set; }
    public int m_nPlayerDominated { get; set; }
    public int m_nPlayerDominatingMe { get; set; }
    public int m_nQuestProgressReason { get; set; }
    public int m_pActionTrackingServices { get; set; }
    public int m_pDamageServices { get; set; }
    public int m_pInGameMoneyServices { get; set; }
    public int m_pInventoryServices { get; set; }
    public int m_sSanitizedPlayerName { get; set; }
    public int m_szClan { get; set; }
    public int m_szCrosshairCodes { get; set; }
    public int m_uiAbandonRecordedReason { get; set; }
    public int m_unActiveQuestId { get; set; }
    public int m_unPlayerTvControlFlags { get; set; }
    public int m_vecKills { get; set; }
    public int m_Transforms { get; set; }
    public int m_bDirty { get; set; }
    public int m_bPrevHelmet { get; set; }
    public int m_hItem { get; set; }
    public int m_nCost { get; set; }
    public int m_nPrevArmor { get; set; }
    public int m_unDefIdx { get; set; }
    public int m_nCollisionFunctionMask { get; set; }
    public int m_nCollisionGroup { get; set; }
    public int m_nEntityId { get; set; }
    public int m_nHierarchyId { get; set; }
    public int m_nInteractsAs { get; set; }
    public int m_nInteractsExclude { get; set; }
    public int m_nInteractsWith { get; set; }
    public int m_nOwnerId { get; set; }
    public int nIndex { get; set; }
    public int nType { get; set; }
    public int qAngle { get; set; }
    public int m_nCount { get; set; }
    public int m_nItemDefIndex { get; set; }
    public int m_weaponPurchases { get; set; }
    public int localBits { get; set; }
    public int localSound { get; set; }
    public int soundEventHash { get; set; }
    public int soundscapeEntityListIndex { get; set; }
    public int soundscapeIndex { get; set; }
    public int HDRColorScale { get; set; }
    public int blend { get; set; }
    public int blendtobackground { get; set; }
    public int colorPrimary { get; set; }
    public int colorPrimaryLerpTo { get; set; }
    public int colorSecondary { get; set; }
    public int colorSecondaryLerpTo { get; set; }
    public int dirPrimary { get; set; }
    public int duration { get; set; }
    public int enable { get; set; }
    public int end { get; set; }
    public int endLerpTo { get; set; }
    public int exponent { get; set; }
    public int farz { get; set; }
    public int lerptime { get; set; }
    public int locallightscale { get; set; }
    public int m_bNoReflectionFog { get; set; }
    public int m_bPadding { get; set; }
    public int maxdensity { get; set; }
    public int maxdensityLerpTo { get; set; }
    public int scattering { get; set; }
    public int skyboxFogFactor { get; set; }
    public int skyboxFogFactorLerpTo { get; set; }
    public int start { get; set; }
    public int startLerpTo { get; set; }
    public int m_ShatterPanelMode { get; set; }
    public int m_SurfacePropStringToken { get; set; }
    public int m_bParentFrozen { get; set; }
    public int m_flGlassHalfThickness { get; set; }
    public int m_nModelID { get; set; }
    public int m_solid { get; set; }
    public int m_vecPanelSize { get; set; }
    public int m_vecPanelVertices { get; set; }
    public int m_vecStressPositionA { get; set; }
    public int m_vecStressPositionB { get; set; }
    public int bClip3DSkyBoxNearToWorldFar { get; set; }
    public int flClip3DSkyBoxNearToWorldFarOffset { get; set; }
    public int fog { get; set; }
    public int m_nWorldGroupID { get; set; }
    public int origin { get; set; }
    public int scale { get; set; }
    public int m_iNumRoundKills { get; set; }
    public int m_iNumRoundKillsHeadshots { get; set; }
    public int m_matchStats { get; set; }
    public int m_perRoundStats { get; set; }
    public int m_unTotalRoundDamageDealt { get; set; }
    public int m_DamageList { get; set; }
    public int m_nSendUpdate { get; set; }
    public int m_iAccount { get; set; }
    public int m_iCashSpentThisRound { get; set; }
    public int m_iTotalCashSpent { get; set; }
    public int m_nPreviousAccount { get; set; }
    public int m_nPersonaDataPublicCommendsFriendly { get; set; }
    public int m_nPersonaDataPublicCommendsLeader { get; set; }
    public int m_nPersonaDataPublicCommendsTeacher { get; set; }
    public int m_nPersonaDataPublicLevel { get; set; }
    public int m_nPersonaDataXpTrailLevel { get; set; }
    public int m_rank { get; set; }
    public int m_unMusicID { get; set; }
    public int m_vecServerAuthoritativeWeaponSlots { get; set; }
    public int m_hLastWeaponBeforeC4AutoSwitch { get; set; }
    public int m_weaponPurchasesThisMatch { get; set; }
    public int m_weaponPurchasesThisRound { get; set; }
    public int m_totalHitsOnServer { get; set; }
    public int m_vecSellbackPurchaseEntries { get; set; }
    public int m_Attributes { get; set; }
    public int m_pManager { get; set; }
    public int m_hCarriedHostage { get; set; }
    public int m_hCarriedHostageProp { get; set; }
    public int m_bHasDefuser { get; set; }
    public int m_bHasHeavyArmor { get; set; }
    public int m_bHasHelmet { get; set; }
    public int m_StuckLast { get; set; }
    public int m_bDesiresDuck { get; set; }
    public int m_bDuckOverride { get; set; }
    public int m_bHasWalkMovedSinceLastJump { get; set; }
    public int m_bInStuckTest { get; set; }
    public int m_bOldJumpPressed { get; set; }
    public int m_bSpeedCropped { get; set; }
    public int m_duckUntilOnGround { get; set; }
    public int m_fStashGrenadeParameterWhen { get; set; }
    public int m_flDuckAmount { get; set; }
    public int m_flDuckOffset { get; set; }
    public int m_flDuckSpeed { get; set; }
    public int m_flHeightAtJumpStart { get; set; }
    public int m_flJumpPressedTime { get; set; }
    public int m_flJumpUntil { get; set; }
    public int m_flJumpVel { get; set; }
    public int m_flLastDuckTime { get; set; }
    public int m_flMaxFallVelocity { get; set; }
    public int m_flMaxJumpHeightThisJump { get; set; }
    public int m_flOffsetTickCompleteTime { get; set; }
    public int m_flOffsetTickStashedSpeed { get; set; }
    public int m_flStamina { get; set; }
    public int m_flStuckCheckTime { get; set; }
    public int m_flWaterEntryTime { get; set; }
    public int m_nButtonDownMaskPrev { get; set; }
    public int m_nDuckJumpTimeMsecs { get; set; }
    public int m_nDuckTimeMsecs { get; set; }
    public int m_nGameCodeHasMovedPlayerAfterCommand { get; set; }
    public int m_nJumpTimeMsecs { get; set; }
    public int m_nLadderSurfacePropIndex { get; set; }
    public int m_nOldWaterLevel { get; set; }
    public int m_nTraceCount { get; set; }
    public int m_vecForward { get; set; }
    public int m_vecLadderNormal { get; set; }
    public int m_vecLastPositionAtFullCrouchSpeed { get; set; }
    public int m_vecUp { get; set; }
    public int m_hPlayerPing { get; set; }
    public int m_hViewModel { get; set; }
    public int m_bIsHoldingLookAtWeapon { get; set; }
    public int m_bIsLookingAtWeapon { get; set; }
    public int m_flNextAttack { get; set; }
    public int m_nOldInputHistoryCount { get; set; }
    public int m_nOldShootPositionHistoryCount { get; set; }
    public int m_DefaultLoadoutSlot { get; set; }
    public int m_GearSlot { get; set; }
    public int m_GearSlotPosition { get; set; }
    public int m_WeaponCategory { get; set; }
    public int m_WeaponType { get; set; }
    public int m_angPivotAngle { get; set; }
    public int m_bCannotShootUnderwater { get; set; }
    public int m_bHasBurstMode { get; set; }
    public int m_bHideViewModelWhenZoomed { get; set; }
    public int m_bIsFullAuto { get; set; }
    public int m_bIsRevolver { get; set; }
    public int m_bMeleeWeapon { get; set; }
    public int m_bUnzoomsAfterShot { get; set; }
    public int m_eSilencerType { get; set; }
    public int m_flArmorRatio { get; set; }
    public int m_flAttackMovespeedFactor { get; set; }
    public int m_flBotAudibleRange { get; set; }
    public int m_flCycleTime { get; set; }
    public int m_flFlinchVelocityModifierLarge { get; set; }
    public int m_flFlinchVelocityModifierSmall { get; set; }
    public int m_flHeadshotMultiplier { get; set; }
    public int m_flHeatPerShot { get; set; }
    public int m_flIdleInterval { get; set; }
    public int m_flInaccuracyAltSoundThreshold { get; set; }
    public int m_flInaccuracyCrouch { get; set; }
    public int m_flInaccuracyFire { get; set; }
    public int m_flInaccuracyJump { get; set; }
    public int m_flInaccuracyJumpApex { get; set; }
    public int m_flInaccuracyJumpInitial { get; set; }
    public int m_flInaccuracyLadder { get; set; }
    public int m_flInaccuracyLand { get; set; }
    public int m_flInaccuracyMove { get; set; }
    public int m_flInaccuracyPitchShift { get; set; }
    public int m_flInaccuracyReload { get; set; }
    public int m_flInaccuracyStand { get; set; }
    public int m_flIronSightFOV { get; set; }
    public int m_flIronSightLooseness { get; set; }
    public int m_flIronSightPivotForward { get; set; }
    public int m_flIronSightPullUpSpeed { get; set; }
    public int m_flIronSightPutDownSpeed { get; set; }
    public int m_flMaxSpeed { get; set; }
    public int m_flPenetration { get; set; }
    public int m_flRange { get; set; }
    public int m_flRangeModifier { get; set; }
    public int m_flRecoilAngle { get; set; }
    public int m_flRecoilAngleVariance { get; set; }
    public int m_flRecoilMagnitude { get; set; }
    public int m_flRecoilMagnitudeVariance { get; set; }
    public int m_flRecoveryTimeCrouch { get; set; }
    public int m_flRecoveryTimeCrouchFinal { get; set; }
    public int m_flRecoveryTimeStand { get; set; }
    public int m_flRecoveryTimeStandFinal { get; set; }
    public int m_flSpread { get; set; }
    public int m_flThrowVelocity { get; set; }
    public int m_flTimeToIdleAfterFire { get; set; }
    public int m_flZoomTime0 { get; set; }
    public int m_flZoomTime1 { get; set; }
    public int m_flZoomTime2 { get; set; }
    public int m_nCrosshairDeltaDistance { get; set; }
    public int m_nCrosshairMinDistance { get; set; }
    public int m_nDamage { get; set; }
    public int m_nKillAward { get; set; }
    public int m_nNumBullets { get; set; }
    public int m_nPrice { get; set; }
    public int m_nPrimaryReserveAmmoMax { get; set; }
    public int m_nRecoilSeed { get; set; }
    public int m_nRecoveryTransitionEndBullet { get; set; }
    public int m_nRecoveryTransitionStartBullet { get; set; }
    public int m_nSecondaryReserveAmmoMax { get; set; }
    public int m_nSpreadSeed { get; set; }
    public int m_nTracerFrequency { get; set; }
    public int m_nZoomFOV1 { get; set; }
    public int m_nZoomFOV2 { get; set; }
    public int m_nZoomLevels { get; set; }
    public int m_sWrongTeamMsg { get; set; }
    public int m_szAimsightLensMaskModel { get; set; }
    public int m_szAnimClass { get; set; }
    public int m_szAnimExtension { get; set; }
    public int m_szEjectBrassEffect { get; set; }
    public int m_szHeatEffect { get; set; }
    public int m_szMagazineModel { get; set; }
    public int m_szMuzzleFlashParticleAlt { get; set; }
    public int m_szMuzzleFlashThirdPersonParticle { get; set; }
    public int m_szMuzzleFlashThirdPersonParticleAlt { get; set; }
    public int m_szName { get; set; }
    public int m_szPlayerModel { get; set; }
    public int m_szTracerParticle { get; set; }
    public int m_szUseRadioSubtitle { get; set; }
    public int m_szViewModel { get; set; }
    public int m_szWorldDroppedModel { get; set; }
    public int m_vecIronSightEyePos { get; set; }
    public int m_CachedResults { get; set; }
    public int m_ProviderType { get; set; }
    public int m_Providers { get; set; }
    public int m_bPreventLoopback { get; set; }
    public int m_hOuter { get; set; }
    public int m_iReapplyProvisionParity { get; set; }
    public int m_CollisionGroup { get; set; }
    public int m_collisionAttribute { get; set; }
    public int m_flBoundingRadius { get; set; }
    public int m_flCapsuleRadius { get; set; }
    public int m_nEnablePhysics { get; set; }
    public int m_nSolidType { get; set; }
    public int m_nSurroundType { get; set; }
    public int m_triggerBloat { get; set; }
    public int m_usSolidFlags { get; set; }
    public int m_vCapsuleCenter1 { get; set; }
    public int m_vCapsuleCenter2 { get; set; }
    public int m_vecMaxs { get; set; }
    public int m_vecMins { get; set; }
    public int m_vecSpecifiedSurroundingMaxs { get; set; }
    public int m_vecSpecifiedSurroundingMins { get; set; }
    public int m_vecSurroundingMaxs { get; set; }
    public int m_vecSurroundingMins { get; set; }
    public int m_KVthumbnail { get; set; }
    public int m_Points { get; set; }
    public int m_DamagerXuid { get; set; }
    public int m_PlayerDamager { get; set; }
    public int m_PlayerRecipient { get; set; }
    public int m_RecipientXuid { get; set; }
    public int m_bIsOtherEnemy { get; set; }
    public int m_hPlayerControllerDamager { get; set; }
    public int m_hPlayerControllerRecipient { get; set; }
    public int m_iActualHealthRemoved { get; set; }
    public int m_iDamage { get; set; }
    public int m_iLastBulletUpdate { get; set; }
    public int m_iNumHits { get; set; }
    public int m_killType { get; set; }
    public int m_szPlayerDamagerName { get; set; }
    public int m_szPlayerRecipientName { get; set; }
    public int m_bSetBonus { get; set; }
    public int m_flInitialValue { get; set; }
    public int m_flValue { get; set; }
    public int m_iAttributeDefinitionIndex { get; set; }
    public int m_nRefundableCurrency { get; set; }
    public int m_fFlags { get; set; }
    public int m_flMagnitude { get; set; }
    public int m_flScale { get; set; }
    public int m_hEntity { get; set; }
    public int m_hOtherEntity { get; set; }
    public int m_iEffectName { get; set; }
    public int m_nAttachmentIndex { get; set; }
    public int m_nAttachmentName { get; set; }
    public int m_nColor { get; set; }
    public int m_nDamageType { get; set; }
    public int m_nEffectIndex { get; set; }
    public int m_nExplosionType { get; set; }
    public int m_nHitBox { get; set; }
    public int m_nMaterial { get; set; }
    public int m_nPenetrate { get; set; }
    public int m_nSurfaceProp { get; set; }
    public int m_vAngles { get; set; }
    public int m_vNormal { get; set; }
    public int m_vOrigin { get; set; }
    public int m_vStart { get; set; }
    public int m_PathIndex { get; set; }
    public int m_designerName { get; set; }
    public int m_fDataObjectTypes { get; set; }
    public int m_flags { get; set; }
    public int m_name { get; set; }
    public int m_nameStringableIndex { get; set; }
    public int m_pNextByClass { get; set; }
    public int m_pPrev { get; set; }
    public int m_pPrevByClass { get; set; }
    public int m_worldGroupId { get; set; }
    public int m_CScriptComponent { get; set; }
    public int m_bVisibleinPVS { get; set; }
    public int m_iszPrivateVScripts { get; set; }
    public int m_pEntity { get; set; }
    public int m_angAbsRotation { get; set; }
    public int m_angRotation { get; set; }
    public int m_bBoneMergeFlex { get; set; }
    public int m_bDebugAbsOriginChanges { get; set; }
    public int m_bDirtyBoneMergeBoneToRoot { get; set; }
    public int m_bDirtyBoneMergeInfo { get; set; }
    public int m_bDirtyHierarchy { get; set; }
    public int m_bDormant { get; set; }
    public int m_bForceParentToBeNetworked { get; set; }
    public int m_bNetworkedAnglesChanged { get; set; }
    public int m_bNetworkedPositionChanged { get; set; }
    public int m_bNetworkedScaleChanged { get; set; }
    public int m_bWillBeCallingPostDataUpdate { get; set; }
    public int m_flAbsScale { get; set; }
    public int m_flZOffset { get; set; }
    public int m_hParent { get; set; }
    public int m_hierarchyAttachName { get; set; }
    public int m_nDoNotSetAnimTimeInInvalidatePhysicsCount { get; set; }
    public int m_nHierarchicalDepth { get; set; }
    public int m_nHierarchyType { get; set; }
    public int m_nLatchAbsOrigin { get; set; }
    public int m_nParentAttachmentOrBone { get; set; }
    public int m_nodeToWorld { get; set; }
    public int m_pChild { get; set; }
    public int m_pNextSibling { get; set; }
    public int m_pOwner { get; set; }
    public int m_pParent { get; set; }
    public int m_vRenderOrigin { get; set; }
    public int m_vecAbsOrigin { get; set; }
    public int m_bAnimGraphUpdateEnabled { get; set; }
    public int m_bAnimationUpdateScheduled { get; set; }
    public int m_bBuiltRagdoll { get; set; }
    public int m_bClientRagdoll { get; set; }
    public int m_bHasAnimatedMaterialAttributes { get; set; }
    public int m_bInitiallyPopulateInterpHistory { get; set; }
    public int m_bSuppressAnimEventSounds { get; set; }
    public int m_flMaxSlopeDistance { get; set; }
    public int m_nForceBone { get; set; }
    public int m_pClientsideRagdoll { get; set; }
    public int m_pRagdollPose { get; set; }
    public int m_vLastSlopeCheckPos { get; set; }
    public int m_vecForce { get; set; }
    public int m_bEligibleForScreenHighlight { get; set; }
    public int m_bFlashing { get; set; }
    public int m_bGlowing { get; set; }
    public int m_fGlowColor { get; set; }
    public int m_flGlowStartTime { get; set; }
    public int m_flGlowTime { get; set; }
    public int m_glowColorOverride { get; set; }
    public int m_iGlowTeam { get; set; }
    public int m_iGlowType { get; set; }
    public int m_bvDisabledHitGroups { get; set; }
    public int m_RenderAttrName { get; set; }
    public int m_TargetEntities { get; set; }
    public int m_nResolutionX { get; set; }
    public int m_nResolutionY { get; set; }
    public int m_nTargetChangeCount { get; set; }
    public int m_szLayoutFileName { get; set; }
    public int m_bCreateAsChildSpawnGroup { get; set; }
    public int m_bEntitiesSpawned { get; set; }
    public int m_bWorldLayerActuallyVisible { get; set; }
    public int m_bWorldLayerVisible { get; set; }
    public int m_hLayerSpawnGroup { get; set; }
    public int m_layerName { get; set; }
    public int m_pOutputOnEntitiesSpawned { get; set; }
    public int m_worldName { get; set; }
    public int m_Pattern { get; set; }
    public int m_SecondaryColor { get; set; }
    public int m_SkyAmbientBounce { get; set; }
    public int m_SkyColor { get; set; }
    public int m_bFlicker { get; set; }
    public int m_bMixedShadows { get; set; }
    public int m_bPrecomputedFieldsValid { get; set; }
    public int m_bRenderDiffuse { get; set; }
    public int m_bRenderToCubemaps { get; set; }
    public int m_bRenderTransmissive { get; set; }
    public int m_bUseSecondaryColor { get; set; }
    public int m_bUsesBakedShadowing { get; set; }
    public int m_flAttenuation0 { get; set; }
    public int m_flAttenuation1 { get; set; }
    public int m_flAttenuation2 { get; set; }
    public int m_flBrightnessMult { get; set; }
    public int m_flCapsuleLength { get; set; }
    public int m_flFadeMaxDist { get; set; }
    public int m_flFadeMinDist { get; set; }
    public int m_flFalloff { get; set; }
    public int m_flFogContributionStength { get; set; }
    public int m_flLightStyleStartTime { get; set; }
    public int m_flMinRoughness { get; set; }
    public int m_flNearClipPlane { get; set; }
    public int m_flOrthoLightHeight { get; set; }
    public int m_flOrthoLightWidth { get; set; }
    public int m_flPhi { get; set; }
    public int m_flPrecomputedMaxRange { get; set; }
    public int m_flShadowCascadeCrossFade { get; set; }
    public int m_flShadowCascadeDistance0 { get; set; }
    public int m_flShadowCascadeDistance1 { get; set; }
    public int m_flShadowCascadeDistance2 { get; set; }
    public int m_flShadowCascadeDistance3 { get; set; }
    public int m_flShadowCascadeDistanceFade { get; set; }
    public int m_flShadowFadeMaxDist { get; set; }
    public int m_flShadowFadeMinDist { get; set; }
    public int m_flSkyIntensity { get; set; }
    public int m_flTheta { get; set; }
    public int m_hLightCookie { get; set; }
    public int m_nBakedShadowIndex { get; set; }
    public int m_nCascadeRenderStaticObjects { get; set; }
    public int m_nCascades { get; set; }
    public int m_nCastShadows { get; set; }
    public int m_nDirectLight { get; set; }
    public int m_nFogLightingMode { get; set; }
    public int m_nIndirectLight { get; set; }
    public int m_nRenderSpecular { get; set; }
    public int m_nShadowCascadeResolution0 { get; set; }
    public int m_nShadowCascadeResolution1 { get; set; }
    public int m_nShadowCascadeResolution2 { get; set; }
    public int m_nShadowCascadeResolution3 { get; set; }
    public int m_nShadowHeight { get; set; }
    public int m_nShadowPriority { get; set; }
    public int m_nShadowWidth { get; set; }
    public int m_nStyle { get; set; }
    public int m_vPrecomputedBoundsMaxs { get; set; }
    public int m_vPrecomputedBoundsMins { get; set; }
    public int m_vPrecomputedOBBAngles { get; set; }
    public int m_vPrecomputedOBBExtent { get; set; }
    public int m_vPrecomputedOBBOrigin { get; set; }
    public int m_MeshGroupMask { get; set; }
    public int m_bClientClothCreationSuppressed { get; set; }
    public int m_hModel { get; set; }
    public int m_nClothUpdateFlags { get; set; }
    public int m_nForceLOD { get; set; }
    public int m_nIdealMotionType { get; set; }
    public int m_bDiscontinuity { get; set; }
    public int m_bSequenceChangeNetworked { get; set; }
    public int m_flPrevCycle { get; set; }
    public int m_flPrevCycleForAnimEventDetection { get; set; }
    public int m_flPrevCycleFromDiscontinuity { get; set; }
    public int m_flWeight { get; set; }
    public int m_hSequence { get; set; }
    public int m_CurrentFog { get; set; }
    public int m_OverrideFogColor { get; set; }
    public int m_PlayerFog { get; set; }
    public int m_PostProcessingVolumes { get; set; }
    public int m_angDemoViewAngles { get; set; }
    public int m_audio { get; set; }
    public int m_bOverrideFogColor { get; set; }
    public int m_bOverrideFogStartEnd { get; set; }
    public int m_fOverrideFogEnd { get; set; }
    public int m_fOverrideFogStart { get; set; }
    public int m_flCsViewPunchAngleTickRatio { get; set; }
    public int m_flOldPlayerViewOffsetZ { get; set; }
    public int m_flOldPlayerZ { get; set; }
    public int m_hActivePostProcessingVolume { get; set; }
    public int m_hColorCorrectionCtrl { get; set; }
    public int m_hOldFogController { get; set; }
    public int m_hTonemapController { get; set; }
    public int m_hViewEntity { get; set; }
    public int m_nCsViewPunchAngleTick { get; set; }
    public int m_vecCsViewPunchAngle { get; set; }
    public int m_arrForceSubtickMoveWhen { get; set; }
    public int m_flForwardMove { get; set; }
    public int m_flLeftMove { get; set; }
    public int m_flMaxspeed { get; set; }
    public int m_flUpMove { get; set; }
    public int m_nButtonDoublePressed { get; set; }
    public int m_nButtons { get; set; }
    public int m_nImpulse { get; set; }
    public int m_nLastCommandNumberProcessed { get; set; }
    public int m_nQueuedButtonChangeMask { get; set; }
    public int m_nQueuedButtonDownMask { get; set; }
    public int m_nToggleButtonDownMask { get; set; }
    public int m_pButtonPressedCmdNumber { get; set; }
    public int m_vecLastMovementImpulses { get; set; }
    public int m_vecOldViewAngles { get; set; }
    public int m_animGraphNetworkedVars { get; set; }
    public int m_bLastUpdateSkipped { get; set; }
    public int m_bNetworkedAnimationInputsChanged { get; set; }
    public int m_bNetworkedSequenceChanged { get; set; }
    public int m_bSequenceFinished { get; set; }
    public int m_flPlaybackRate { get; set; }
    public int m_flPrevAnimUpdateTime { get; set; }
    public int m_flSeqFixedCycle { get; set; }
    public int m_flSeqStartTime { get; set; }
    public int m_flSoundSyncTime { get; set; }
    public int m_nAnimLoopMode { get; set; }
    public int m_nNotifyState { get; set; }
    public int m_bDucked { get; set; }
    public int m_bDucking { get; set; }
    public int m_bInCrouch { get; set; }
    public int m_bInDuckJump { get; set; }
    public int m_flCrouchTransitionStartTime { get; set; }
    public int m_flFallVelocity { get; set; }
    public int m_flStepSoundTime { get; set; }
    public int m_flSurfaceFriction { get; set; }
    public int m_groundNormal { get; set; }
    public int m_nCrouchState { get; set; }
    public int m_nStepside { get; set; }
    public int m_surfaceProps { get; set; }
    public int m_bForcedObserverMode { get; set; }
    public int m_flObserverChaseDistance { get; set; }
    public int m_flObserverChaseDistanceCalcTime { get; set; }
    public int m_hObserverTarget { get; set; }
    public int m_iObserverLastMode { get; set; }
    public int m_iObserverMode { get; set; }
    public int m_hActiveWeapon { get; set; }
    public int m_hLastWeapon { get; set; }
    public int m_hMyWeapons { get; set; }
    public int m_iAmmo { get; set; }
    public int m_bBatchSameVolumeType { get; set; }
    public int m_flInnerDistance { get; set; }
    public int m_nAttachType { get; set; }
    public int m_nRTEnvCP { get; set; }
    public int m_nRTEnvCPComponent { get; set; }
    public int m_szModifier { get; set; }
    public int m_szParticlePrecipitationEffect { get; set; }
    public int m_LightColor { get; set; }
    public int m_SpotlightTextureName { get; set; }
    public int m_bAlwaysUpdate { get; set; }
    public int m_bCameraSpace { get; set; }
    public int m_bEnableShadows { get; set; }
    public int m_bFlipHorizontal { get; set; }
    public int m_bLightOnlyTarget { get; set; }
    public int m_bLightWorld { get; set; }
    public int m_bSimpleProjection { get; set; }
    public int m_bVolumetric { get; set; }
    public int m_flAmbient { get; set; }
    public int m_flColorTransitionTime { get; set; }
    public int m_flFlashlightTime { get; set; }
    public int m_flIntensity { get; set; }
    public int m_flLightFOV { get; set; }
    public int m_flLinearAttenuation { get; set; }
    public int m_flNearZ { get; set; }
    public int m_flNoiseStrength { get; set; }
    public int m_flPlaneOffset { get; set; }
    public int m_flProjectionSize { get; set; }
    public int m_flQuadraticAttenuation { get; set; }
    public int m_flVolumetricIntensity { get; set; }
    public int m_hTargetEntity { get; set; }
    public int m_nNumPlanes { get; set; }
    public int m_nShadowQuality { get; set; }
    public int m_nSpotlightTextureFrame { get; set; }
    public int m_iEnemy3Ks { get; set; }
    public int m_iEnemy4Ks { get; set; }
    public int m_iEnemy5Ks { get; set; }
    public int m_iEnemyKnifeKills { get; set; }
    public int m_iEnemyTaserKills { get; set; }
    public int m_iAssists { get; set; }
    public int m_iCashEarned { get; set; }
    public int m_iDeaths { get; set; }
    public int m_iEnemiesFlashed { get; set; }
    public int m_iEquipmentValue { get; set; }
    public int m_iHeadShotKills { get; set; }
    public int m_iKillReward { get; set; }
    public int m_iKills { get; set; }
    public int m_iLiveTime { get; set; }
    public int m_iMoneySaved { get; set; }
    public int m_iObjective { get; set; }
    public int m_iUtilityDamage { get; set; }
    public int m_bDirtyMotionType { get; set; }
    public int m_bDisableSolidCollisionsForHierarchy { get; set; }
    public int m_bIsAnimationEnabled { get; set; }
    public int m_bIsGeneratingLatchedParentSpaceState { get; set; }
    public int m_bUseParentRenderBounds { get; set; }
    public int m_materialGroup { get; set; }
    public int m_modelState { get; set; }
    public int m_nHitboxSet { get; set; }
    public int m_CommandContext { get; set; }
    public int m_bIsHLTV { get; set; }
    public int m_bIsLocalPlayerController { get; set; }
    public int m_hPawn { get; set; }
    public int m_hPredictedPawn { get; set; }
    public int m_hSplitOwner { get; set; }
    public int m_hSplitScreenPlayers { get; set; }
    public int m_iConnected { get; set; }
    public int m_iDesiredFOV { get; set; }
    public int m_iszPlayerName { get; set; }
    public int m_nFinalPredictedTick { get; set; }
    public int m_nInButtonsWhichAreToggles { get; set; }
    public int m_nSplitScreenSlot { get; set; }
    public int m_nTickBase { get; set; }
    public int m_steamID { get; set; }
    public int m_bStopped { get; set; }
    public int m_flFinalValue { get; set; }
    public int m_flInterval { get; set; }
    public int m_flValues { get; set; }
    public int m_nBucketCount { get; set; }
    public int m_nCompressionType { get; set; }
    public int m_nValueCounts { get; set; }
    public int m_Item { get; set; }
    public int m_iExternalItemProviderRegisteredToken { get; set; }
    public int m_ullRegisteredAsItemID { get; set; }
    public int m_LightStyleEvents { get; set; }
    public int m_LightStyleString { get; set; }
    public int m_LightStyleTargets { get; set; }
    public int m_QueuedLightStyleStrings { get; set; }
    public int m_StyleEvent { get; set; }
    public int m_bContactShadow { get; set; }
    public int m_fAlternateColorBrightness { get; set; }
    public int m_flBounceScale { get; set; }
    public int m_flColorTemperature { get; set; }
    public int m_flFadeSizeEnd { get; set; }
    public int m_flFadeSizeStart { get; set; }
    public int m_flFogScale { get; set; }
    public int m_flLuminaireAnisotropy { get; set; }
    public int m_flLuminaireSize { get; set; }
    public int m_flShadowFadeSizeEnd { get; set; }
    public int m_flShadowFadeSizeStart { get; set; }
    public int m_flShape { get; set; }
    public int m_flSkirt { get; set; }
    public int m_flSkirtNear { get; set; }
    public int m_flSoftX { get; set; }
    public int m_flSoftY { get; set; }
    public int m_nBakeSpecularToCubemaps { get; set; }
    public int m_nBounceLight { get; set; }
    public int m_nColorMode { get; set; }
    public int m_nFog { get; set; }
    public int m_nFogShadows { get; set; }
    public int m_nLuminaireShape { get; set; }
    public int m_nShadowMapSize { get; set; }
    public int m_vAlternateColor { get; set; }
    public int m_vBakeSpecularToCubemapsSize { get; set; }
    public int m_vShear { get; set; }
    public int m_vSizeParams { get; set; }
    public int m_glowEntity { get; set; }
    public int m_szDisplayText { get; set; }
    public int m_usable { get; set; }
    public int m_bClientPredictDelete { get; set; }
    public int m_bIsHeldByPlayer { get; set; }
    public int m_bJumpThrow { get; set; }
    public int m_bJustPulledPin { get; set; }
    public int m_bPinPulled { get; set; }
    public int m_bThrowAnimating { get; set; }
    public int m_fDropTime { get; set; }
    public int m_fThrowTime { get; set; }
    public int m_flNextHoldFrac { get; set; }
    public int m_flThrowStrength { get; set; }
    public int m_flThrowStrengthApproach { get; set; }
    public int m_hSwitchToWeaponAfterThrow { get; set; }
    public int m_nNextHoldTick { get; set; }
    public int flNextTrailLineTime { get; set; }
    public int m_arrTrajectoryTrailPointCreationTimes { get; set; }
    public int m_arrTrajectoryTrailPoints { get; set; }
    public int m_bCanCreateGrenadeTrail { get; set; }
    public int m_bExplodeEffectBegan { get; set; }
    public int m_flSpawnTime { get; set; }
    public int m_flTrajectoryTrailEffectCreationTime { get; set; }
    public int m_hSnapshotTrajectoryParticleSnapshot { get; set; }
    public int m_nBounces { get; set; }
    public int m_nExplodeEffectIndex { get; set; }
    public int m_nExplodeEffectTickBegin { get; set; }
    public int m_nSnapshotTrajectoryEffectIndex { get; set; }
    public int m_vInitialPosition { get; set; }
    public int m_vInitialVelocity { get; set; }
    public int m_vecExplodeEffectOrigin { get; set; }
    public int vecLastTrailLinePos { get; set; }
    public int m_DialogXMLName { get; set; }
    public int m_PanelClassName { get; set; }
    public int m_PanelID { get; set; }
    public int m_bloodColor { get; set; }
    public int m_flFieldOfView { get; set; }
    public int m_flWaterNextTraceTime { get; set; }
    public int m_flWaterWorldZ { get; set; }
    public int m_hMyWearables { get; set; }
    public int m_leftFootAttachment { get; set; }
    public int m_nWaterWakeMode { get; set; }
    public int m_rightFootAttachment { get; set; }
    public int m_bIsUsable { get; set; }
    public int m_CBodyComponent { get; set; }
    public int m_DataChangeEventRef { get; set; }
    public int m_EntClientFlags { get; set; }
    public int m_ListEntry { get; set; }
    public int m_MoveCollide { get; set; }
    public int m_MoveType { get; set; }
    public int m_NetworkTransmitComponent { get; set; }
    public int m_Particles { get; set; }
    public int m_aThinkFunctions { get; set; }
    public int m_bAnimTimeChanged { get; set; }
    public int m_bAnimatedEveryTick { get; set; }
    public int m_bApplyLayerMatchIDToModel { get; set; }
    public int m_bClientSideRagdoll { get; set; }
    public int m_bHasAddedVarsToInterpolation { get; set; }
    public int m_bHasSuccessfullyInterpolated { get; set; }
    public int m_bInterpolateEvenWithNoModel { get; set; }
    public int m_bIsPlatform { get; set; }
    public int m_bPredictable { get; set; }
    public int m_bPredictionEligible { get; set; }
    public int m_bRenderEvenWhenNotSuccessfullyInterpolated { get; set; }
    public int m_bRenderWithViewModels { get; set; }
    public int m_bSimulationTimeChanged { get; set; }
    public int m_bTakesDamage { get; set; }
    public int m_dependencies { get; set; }
    public int m_fBBoxVisFlags { get; set; }
    public int m_fEffects { get; set; }
    public int m_flAnimTime { get; set; }
    public int m_flCreateTime { get; set; }
    public int m_flElasticity { get; set; }
    public int m_flFriction { get; set; }
    public int m_flGravityScale { get; set; }
    public int m_flNavIgnoreUntilTime { get; set; }
    public int m_flProxyRandomValue { get; set; }
    public int m_flSimulationTime { get; set; }
    public int m_flSpeed { get; set; }
    public int m_flTimeScale { get; set; }
    public int m_flWaterLevel { get; set; }
    public int m_hEffectEntity { get; set; }
    public int m_hGroundEntity { get; set; }
    public int m_hOldMoveParent { get; set; }
    public int m_hOwnerEntity { get; set; }
    public int m_hSceneObjectController { get; set; }
    public int m_hThink { get; set; }
    public int m_iCurrentThinkContext { get; set; }
    public int m_iEFlags { get; set; }
    public int m_iHealth { get; set; }
    public int m_iMaxHealth { get; set; }
    public int m_iTeamNum { get; set; }
    public int m_lifeState { get; set; }
    public int m_nActualMoveType { get; set; }
    public int m_nCreationTick { get; set; }
    public int m_nDisableContextThinkStartTick { get; set; }
    public int m_nFirstPredictableCommand { get; set; }
    public int m_nInterpolationLatchDirtyFlags { get; set; }
    public int m_nLastPredictableCommand { get; set; }
    public int m_nLastThinkTick { get; set; }
    public int m_nNextScriptVarRecordID { get; set; }
    public int m_nNextThinkTick { get; set; }
    public int m_nNoInterpolationTick { get; set; }
    public int m_nSceneObjectOverrideFlags { get; set; }
    public int m_nSimulationTick { get; set; }
    public int m_nSplitUserPlayerPredictionSlot { get; set; }
    public int m_nSubclassID { get; set; }
    public int m_nTakeDamageFlags { get; set; }
    public int m_nVisibilityNoInterpolationTick { get; set; }
    public int m_nWaterType { get; set; }
    public int m_pCollision { get; set; }
    public int m_pGameSceneNode { get; set; }
    public int m_pRenderComponent { get; set; }
    public int m_sUniqueHammerID { get; set; }
    public int m_spawnflags { get; set; }
    public int m_tokLayerMatchID { get; set; }
    public int m_ubInterpolationFrame { get; set; }
    public int m_vecAbsVelocity { get; set; }
    public int m_vecAngVelocity { get; set; }
    public int m_vecBaseVelocity { get; set; }
    public int m_vecPredictedScriptFloatIDs { get; set; }
    public int m_vecPredictedScriptFloats { get; set; }
    public int m_vecVelocity { get; set; }
    public int m_flScaleTime { get; set; }
    public int m_nFlags { get; set; }
    public int m_CachedViewTarget { get; set; }
    public int m_PhonemeClasses { get; set; }
    public int m_bResetFlexWeightsOnModelChange { get; set; }
    public int m_blinktime { get; set; }
    public int m_blinktoggle { get; set; }
    public int m_flBlinkAmount { get; set; }
    public int m_flJawOpenAmount { get; set; }
    public int m_flexWeight { get; set; }
    public int m_iBlink { get; set; }
    public int m_iJawOpen { get; set; }
    public int m_iMouthAttachment { get; set; }
    public int m_mEyeOcclusionRendererCameraToBoneTransform { get; set; }
    public int m_nEyeOcclusionRendererBone { get; set; }
    public int m_nLastFlexUpdateFrameCount { get; set; }
    public int m_nNextSceneEventId { get; set; }
    public int m_prevblinktoggle { get; set; }
    public int m_vEyeOcclusionRendererHalfExtent { get; set; }
    public int m_vLookTargetPosition { get; set; }
    public int m_DmgRadius { get; set; }
    public int m_ExplosionSound { get; set; }
    public int m_bHasWarnedAI { get; set; }
    public int m_bIsLive { get; set; }
    public int m_bIsSmokeGrenade { get; set; }
    public int m_flDamage { get; set; }
    public int m_flDetonateTime { get; set; }
    public int m_flWarnAITime { get; set; }
    public int m_hOriginalThrower { get; set; }
    public int m_hThrower { get; set; }
    public int m_iszBounceSound { get; set; }
    public int m_CHitboxComponent { get; set; }
    public int m_CRenderComponent { get; set; }
    public int m_ClientOverrideTint { get; set; }
    public int m_Collision { get; set; }
    public int m_ConfigEntitiesToPropagateMaterialDecalsTo { get; set; }
    public int m_bAllowFadeInView { get; set; }
    public int m_bInitModelEffects { get; set; }
    public int m_bIsStaticProp { get; set; }
    public int m_bUseClientOverrideTint { get; set; }
    public int m_clrRender { get; set; }
    public int m_fadeMaxDist { get; set; }
    public int m_fadeMinDist { get; set; }
    public int m_flDecalHealBloodRate { get; set; }
    public int m_flDecalHealHeightRate { get; set; }
    public int m_flFadeScale { get; set; }
    public int m_flGlowBackfaceMult { get; set; }
    public int m_flShadowStrength { get; set; }
    public int m_iOldHealth { get; set; }
    public int m_nAddDecal { get; set; }
    public int m_nDecalsAdded { get; set; }
    public int m_nLastAddDecal { get; set; }
    public int m_nObjectCulling { get; set; }
    public int m_nRenderFX { get; set; }
    public int m_nRenderMode { get; set; }
    public int m_pClientAlphaProperty { get; set; }
    public int m_vDecalForwardAxis { get; set; }
    public int m_vDecalPosition { get; set; }
    public int m_vecRenderAttributes { get; set; }
    public int m_vecViewOffset { get; set; }
    public int m_ServerViewAngleChanges { get; set; }
    public int m_bIsSwappingToPredictableController { get; set; }
    public int m_flDeathTime { get; set; }
    public int m_flFOVSensitivityAdjust { get; set; }
    public int m_flLastCameraSetupTime { get; set; }
    public int m_flMouseSensitivity { get; set; }
    public int m_flOldSimulationTime { get; set; }
    public int m_flPredictionErrorTime { get; set; }
    public int m_hController { get; set; }
    public int m_iHideHUD { get; set; }
    public int m_nHighestConsumedServerViewAngleChangeIndex { get; set; }
    public int m_nLastExecutedCommandNumber { get; set; }
    public int m_nLastExecutedCommandTick { get; set; }
    public int m_pAutoaimServices { get; set; }
    public int m_pCameraServices { get; set; }
    public int m_pFlashlightServices { get; set; }
    public int m_pItemServices { get; set; }
    public int m_pMovementServices { get; set; }
    public int m_pObserverServices { get; set; }
    public int m_pUseServices { get; set; }
    public int m_pWaterServices { get; set; }
    public int m_pWeaponServices { get; set; }
    public int m_skybox3d { get; set; }
    public int m_vOldOrigin { get; set; }
    public int m_vecLastCameraSetupLocalOrigin { get; set; }
    public int m_vecPredictionError { get; set; }
    public int v_angle { get; set; }
    public int v_anglePrevious { get; set; }
    public int m_flNextPrimaryAttackTickRatio { get; set; }
    public int m_flNextSecondaryAttackTickRatio { get; set; }
    public int m_iClip1 { get; set; }
    public int m_iClip2 { get; set; }
    public int m_nNextPrimaryAttackTick { get; set; }
    public int m_nNextSecondaryAttackTick { get; set; }
    public int m_pReserveAmmo { get; set; }
    public int m_bLocked { get; set; }
    public int m_closedAngles { get; set; }
    public int m_closedPosition { get; set; }
    public int m_eDoorState { get; set; }
    public int m_hMaster { get; set; }
    public int m_modelChanged { get; set; }
    public int m_vWhereToSetLightingOrigin { get; set; }
    public int m_bClientSidePredicted { get; set; }
    public int m_flAnimationStartTime { get; set; }
    public int m_hOldLayerSequence { get; set; }
    public int m_hWeapon { get; set; }
    public int m_hWeaponModel { get; set; }
    public int m_iCameraAttachment { get; set; }
    public int m_nAnimationParity { get; set; }
    public int m_nOldAnimationParity { get; set; }
    public int m_oldLayer { get; set; }
    public int m_oldLayerStartTime { get; set; }
    public int m_previousCycle { get; set; }
    public int m_previousElapsedDuration { get; set; }
    public int m_sAnimationPrefix { get; set; }
    public int m_sVMName { get; set; }
    public int m_vecLastCameraAngles { get; set; }
    public int m_vecLastFacing { get; set; }
    public int m_flArmDamageMultiplier { get; set; }
    public int m_flChestDamageMultiplier { get; set; }
    public int m_flCrouchTime { get; set; }
    public int m_flDrowningDamageInterval { get; set; }
    public int m_flHeadDamageMultiplier { get; set; }
    public int m_flHoldBreathTime { get; set; }
    public int m_flLegDamageMultiplier { get; set; }
    public int m_flStomachDamageMultiplier { get; set; }
    public int m_flUseAngleTolerance { get; set; }
    public int m_flUseRange { get; set; }
    public int m_nDrowningDamageInitial { get; set; }
    public int m_nDrowningDamageMax { get; set; }
    public int m_nWaterSpeed { get; set; }
    public int m_sModelName { get; set; }
    public int m_bTurnedOff { get; set; }
    public int m_fAmplitude { get; set; }
    public int m_fEndWidth { get; set; }
    public int m_fFadeLength { get; set; }
    public int m_fHaloScale { get; set; }
    public int m_fSpeed { get; set; }
    public int m_fStartFrame { get; set; }
    public int m_fWidth { get; set; }
    public int m_flFireTime { get; set; }
    public int m_flFrameRate { get; set; }
    public int m_hAttachEntity { get; set; }
    public int m_hBaseMaterial { get; set; }
    public int m_hEndEntity { get; set; }
    public int m_nAttachIndex { get; set; }
    public int m_nBeamFlags { get; set; }
    public int m_nBeamType { get; set; }
    public int m_nClipStyle { get; set; }
    public int m_nHaloIndex { get; set; }
    public int m_nNumBeamEnts { get; set; }
    public int m_queryHandleHalo { get; set; }
    public int m_OnBreak { get; set; }
    public int m_OnHealthChanged { get; set; }
    public int m_OnTakeDamage { get; set; }
    public int m_PerformanceMode { get; set; }
    public int m_bHasBreakPiecesOrCommands { get; set; }
    public int m_explodeDamage { get; set; }
    public int m_explodeRadius { get; set; }
    public int m_explosionBuildupSound { get; set; }
    public int m_explosionCustomEffect { get; set; }
    public int m_explosionCustomSound { get; set; }
    public int m_explosionDelay { get; set; }
    public int m_explosionModifier { get; set; }
    public int m_flDefaultFadeScale { get; set; }
    public int m_flDmgModBullet { get; set; }
    public int m_flDmgModClub { get; set; }
    public int m_flDmgModExplosive { get; set; }
    public int m_flDmgModFire { get; set; }
    public int m_flLastPhysicsInfluenceTime { get; set; }
    public int m_flPressureDelay { get; set; }
    public int m_flPreventDamageBeforeTime { get; set; }
    public int m_hBreaker { get; set; }
    public int m_hFlareEnt { get; set; }
    public int m_hLastAttacker { get; set; }
    public int m_hPhysicsAttacker { get; set; }
    public int m_iInteractions { get; set; }
    public int m_iMinHealthDmg { get; set; }
    public int m_impactEnergyScale { get; set; }
    public int m_iszBasePropData { get; set; }
    public int m_iszPhysicsDamageTableName { get; set; }
    public int m_noGhostCollision { get; set; }
    public int m_activeLightParticleIndex { get; set; }
    public int m_bBombPlacedAnimation { get; set; }
    public int m_bBombPlanted { get; set; }
    public int m_bIsPlantingViaUse { get; set; }
    public int m_bPlayedArmingBeeps { get; set; }
    public int m_bStartedArming { get; set; }
    public int m_eActiveLightEffect { get; set; }
    public int m_fArmedTime { get; set; }
    public int m_nSpotRules { get; set; }
    public int m_szScreenText { get; set; }
    public int m_bNeedToQueueHighResComposite { get; set; }
    public int m_bShouldIgnoreOffsetAndAccuracy { get; set; }
    public int m_nLastKnownAssociatedWeaponEntIndex { get; set; }
    public int m_nOldWeaponParity { get; set; }
    public int m_nWeaponParity { get; set; }
    public int m_vLoweredWeaponOffset { get; set; }
    public int m_agentItem { get; set; }
    public int m_glovesItem { get; set; }
    public int m_nOrdinal { get; set; }
    public int m_nRandom { get; set; }
    public int m_nVariant { get; set; }
    public int m_sWeaponName { get; set; }
    public int m_weaponItem { get; set; }
    public int m_xuid { get; set; }
    public int m_MatchDevice { get; set; }
    public int m_MinimapVerticalSectionHeights { get; set; }
    public int m_RetakeRules { get; set; }
    public int m_TeamRespawnWaveTimes { get; set; }
    public int m_arrFeaturedGiftersAccounts { get; set; }
    public int m_arrFeaturedGiftersGifts { get; set; }
    public int m_arrProhibitedItemIndices { get; set; }
    public int m_arrTournamentActiveCasterAccounts { get; set; }
    public int m_bAnyHostageReached { get; set; }
    public int m_bBombDropped { get; set; }
    public int m_bCTCantBuy { get; set; }
    public int m_bCTTimeOutActive { get; set; }
    public int m_bDontIncrementCoopWave { get; set; }
    public int m_bFreezePeriod { get; set; }
    public int m_bGamePaused { get; set; }
    public int m_bGameRestart { get; set; }
    public int m_bHasMatchStarted { get; set; }
    public int m_bHasTriggeredCoopSpawnReset { get; set; }
    public int m_bHasTriggeredRoundStartMusic { get; set; }
    public int m_bIsDroppingItems { get; set; }
    public int m_bIsHltvActive { get; set; }
    public int m_bIsQuestEligible { get; set; }
    public int m_bIsQueuedMatchmaking { get; set; }
    public int m_bIsValveDS { get; set; }
    public int m_bLogoMap { get; set; }
    public int m_bMapHasBombTarget { get; set; }
    public int m_bMapHasBuyZone { get; set; }
    public int m_bMapHasRescueZone { get; set; }
    public int m_bMarkClientStopRecordAtRoundEnd { get; set; }
    public int m_bMatchWaitingForResume { get; set; }
    public int m_bPlayAllStepSoundsOnServer { get; set; }
    public int m_bRoundEndNoMusic { get; set; }
    public int m_bRoundEndShowTimerDefend { get; set; }
    public int m_bServerPaused { get; set; }
    public int m_bSpawnedTerrorHuntHeavy { get; set; }
    public int m_bSwitchingTeamsAtRoundReset { get; set; }
    public int m_bTCantBuy { get; set; }
    public int m_bTeamIntroPeriod { get; set; }
    public int m_bTechnicalTimeOut { get; set; }
    public int m_bTerroristTimeOutActive { get; set; }
    public int m_bWarmupPeriod { get; set; }
    public int m_eRoundEndReason { get; set; }
    public int m_eRoundWinReason { get; set; }
    public int m_fMatchStartTime { get; set; }
    public int m_fRoundStartTime { get; set; }
    public int m_fWarmupPeriodEnd { get; set; }
    public int m_fWarmupPeriodStart { get; set; }
    public int m_flCMMItemDropRevealEndTime { get; set; }
    public int m_flCMMItemDropRevealStartTime { get; set; }
    public int m_flCTTimeOutRemaining { get; set; }
    public int m_flGameStartTime { get; set; }
    public int m_flGuardianBuyUntilTime { get; set; }
    public int m_flLastPerfSampleTime { get; set; }
    public int m_flNextRespawnWave { get; set; }
    public int m_flRestartRoundTime { get; set; }
    public int m_flTerroristTimeOutRemaining { get; set; }
    public int m_gamePhase { get; set; }
    public int m_iHostagesRemaining { get; set; }
    public int m_iMatchStats_PlayersAlive_CT { get; set; }
    public int m_iMatchStats_PlayersAlive_T { get; set; }
    public int m_iMatchStats_RoundResults { get; set; }
    public int m_iNumConsecutiveCTLoses { get; set; }
    public int m_iNumConsecutiveTerroristLoses { get; set; }
    public int m_iRoundEndFunFactData1 { get; set; }
    public int m_iRoundEndFunFactData2 { get; set; }
    public int m_iRoundEndFunFactData3 { get; set; }
    public int m_iRoundEndFunFactPlayerSlot { get; set; }
    public int m_iRoundEndLegacy { get; set; }
    public int m_iRoundEndPlayerCount { get; set; }
    public int m_iRoundEndTimerTime { get; set; }
    public int m_iRoundEndWinnerTeam { get; set; }
    public int m_iRoundStartRoundNumber { get; set; }
    public int m_iRoundTime { get; set; }
    public int m_iRoundWinStatus { get; set; }
    public int m_iSpectatorSlotCount { get; set; }
    public int m_nCTTeamIntroVariant { get; set; }
    public int m_nCTTimeOuts { get; set; }
    public int m_nEndMatchMapGroupVoteOptions { get; set; }
    public int m_nEndMatchMapGroupVoteTypes { get; set; }
    public int m_nEndMatchMapVoteWinner { get; set; }
    public int m_nGuardianGrenadesToGiveBots { get; set; }
    public int m_nGuardianModeSpecialKillsRemaining { get; set; }
    public int m_nGuardianModeSpecialWeaponNeeded { get; set; }
    public int m_nGuardianModeWaveNumber { get; set; }
    public int m_nHalloweenMaskListSeed { get; set; }
    public int m_nMatchAbortedEarlyReason { get; set; }
    public int m_nMatchEndCount { get; set; }
    public int m_nNextMapInMapgroup { get; set; }
    public int m_nNumHeaviesToSpawn { get; set; }
    public int m_nOvertimePlaying { get; set; }
    public int m_nPauseStartTick { get; set; }
    public int m_nQueuedMatchmakingMode { get; set; }
    public int m_nRoundEndCount { get; set; }
    public int m_nRoundStartCount { get; set; }
    public int m_nRoundsPlayedThisPhase { get; set; }
    public int m_nServerQuestID { get; set; }
    public int m_nTTeamIntroVariant { get; set; }
    public int m_nTerroristTimeOuts { get; set; }
    public int m_nTotalPausedTicks { get; set; }
    public int m_nTournamentPredictionsPct { get; set; }
    public int m_numBestOfMaps { get; set; }
    public int m_numGlobalGifters { get; set; }
    public int m_numGlobalGiftsGiven { get; set; }
    public int m_numGlobalGiftsPeriodSeconds { get; set; }
    public int m_pGameModeRules { get; set; }
    public int m_sRoundEndFunFactToken { get; set; }
    public int m_sRoundEndMessage { get; set; }
    public int m_szMatchStatTxt { get; set; }
    public int m_szTournamentEventName { get; set; }
    public int m_szTournamentEventStage { get; set; }
    public int m_szTournamentPredictionsTxt { get; set; }
    public int m_timeUntilNextPhaseStarts { get; set; }
    public int m_totalRoundsPlayed { get; set; }
    public int m_vMinimapMaxs { get; set; }
    public int m_vMinimapMins { get; set; }
    public int m_pGameRules { get; set; }
    public int m_hDetectParentChange { get; set; }
    public int m_EconGloves { get; set; }
    public int m_RetakesMVPBoostExtraUtility { get; set; }
    public int m_aimPunchAngle { get; set; }
    public int m_aimPunchAngleVel { get; set; }
    public int m_aimPunchCache { get; set; }
    public int m_aimPunchTickBase { get; set; }
    public int m_aimPunchTickFraction { get; set; }
    public int m_bHasFemaleVoice { get; set; }
    public int m_bInBombZone { get; set; }
    public int m_bInBuyZone { get; set; }
    public int m_bInHostageRescueZone { get; set; }
    public int m_bInLanding { get; set; }
    public int m_bIsBuyMenuOpen { get; set; }
    public int m_bLastHeadBoneTransformIsValid { get; set; }
    public int m_bMustSyncRagdollState { get; set; }
    public int m_bNeedToReApplyGloves { get; set; }
    public int m_bOnGroundLastTick { get; set; }
    public int m_bPrevDefuser { get; set; }
    public int m_bPreviouslyInBuyZone { get; set; }
    public int m_bRagdollDamageHeadshot { get; set; }
    public int m_bRetakesHasDefuseKit { get; set; }
    public int m_bRetakesMVPLastRound { get; set; }
    public int m_bSkipOneHeadConstraintUpdate { get; set; }
    public int m_flHealthShotBoostExpirationTime { get; set; }
    public int m_flLandingTime { get; set; }
    public int m_flLandseconds { get; set; }
    public int m_flLastFiredWeaponTime { get; set; }
    public int m_flNextSprayDecalTime { get; set; }
    public int m_flOldFallVelocity { get; set; }
    public int m_flTimeOfLastInjury { get; set; }
    public int m_iRetakesMVPBoostItem { get; set; }
    public int m_iRetakesOffering { get; set; }
    public int m_iRetakesOfferingCard { get; set; }
    public int m_lastLandTime { get; set; }
    public int m_nEconGlovesChanged { get; set; }
    public int m_nPrevArmorVal { get; set; }
    public int m_nPrevGrenadeAmmoCount { get; set; }
    public int m_nRagdollDamageBone { get; set; }
    public int m_pBulletServices { get; set; }
    public int m_pBuyServices { get; set; }
    public int m_pGlowServices { get; set; }
    public int m_pHostageServices { get; set; }
    public int m_qDeathEyeAngles { get; set; }
    public int m_szLastPlaceName { get; set; }
    public int m_szRagdollDamageWeaponName { get; set; }
    public int m_unPreviousWeaponHash { get; set; }
    public int m_unWeaponHash { get; set; }
    public int m_vRagdollDamageForce { get; set; }
    public int m_vRagdollDamagePosition { get; set; }
    public int m_vRagdollServerOrigin { get; set; }
}

public class FogparamsT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class GeneratedTextureHandleT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class IntervalTimer
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class Members
{
    public int WATER_WAKE_IDLE { get; set; }
    public int WATER_WAKE_NONE { get; set; }
    public int WATER_WAKE_RUNNING { get; set; }
    public int WATER_WAKE_WALKING { get; set; }
    public int WATER_WAKE_WATER_OVERHEAD { get; set; }
    public int COMP_MAT_MUTATOR_CONDITION_INPUT_CONTAINER_EXISTS { get; set; }
    public int COMP_MAT_MUTATOR_CONDITION_INPUT_CONTAINER_VALUE_EQUALS { get; set; }
    public int COMP_MAT_MUTATOR_CONDITION_INPUT_CONTAINER_VALUE_EXISTS { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_CONDITIONAL_MUTATORS { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_COPY_KEYS_WITH_SUFFIX { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_COPY_MATCHING_KEYS { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_COPY_PROPERTY { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_DRAW_TEXT { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_GENERATE_TEXTURE { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_INIT { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_POP_INPUT_QUEUE { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_RANDOM_ROLL_INPUT_VARIABLES { get; set; }
    public int COMP_MAT_PROPERTY_MUTATOR_SET_VALUE { get; set; }
    public int CONTAINER_SOURCE_TYPE_LOOSE_VARIABLES { get; set; }
    public int CONTAINER_SOURCE_TYPE_MATERIAL_FROM_TARGET_ATTR { get; set; }
    public int CONTAINER_SOURCE_TYPE_SPECIFIC_MATERIAL { get; set; }
    public int CONTAINER_SOURCE_TYPE_TARGET_INSTANCE_MATERIAL { get; set; }
    public int CONTAINER_SOURCE_TYPE_TARGET_MATERIAL { get; set; }
    public int CONTAINER_SOURCE_TYPE_VARIABLE_FROM_TARGET_ATTR { get; set; }
    public int LOOSE_VARIABLE_TYPE_BOOLEAN { get; set; }
    public int LOOSE_VARIABLE_TYPE_COLOR4 { get; set; }
    public int LOOSE_VARIABLE_TYPE_FLOAT1 { get; set; }
    public int LOOSE_VARIABLE_TYPE_FLOAT2 { get; set; }
    public int LOOSE_VARIABLE_TYPE_FLOAT3 { get; set; }
    public int LOOSE_VARIABLE_TYPE_FLOAT4 { get; set; }
    public int LOOSE_VARIABLE_TYPE_INTEGER1 { get; set; }
    public int LOOSE_VARIABLE_TYPE_INTEGER2 { get; set; }
    public int LOOSE_VARIABLE_TYPE_INTEGER3 { get; set; }
    public int LOOSE_VARIABLE_TYPE_INTEGER4 { get; set; }
    public int LOOSE_VARIABLE_TYPE_RESOURCE_MATERIAL { get; set; }
    public int LOOSE_VARIABLE_TYPE_RESOURCE_TEXTURE { get; set; }
    public int LOOSE_VARIABLE_TYPE_STRING { get; set; }
    public int LOOSE_VARIABLE_TYPE_SYSTEMVAR { get; set; }
    public int INPUT_TEXTURE_TYPE_AO { get; set; }
    public int INPUT_TEXTURE_TYPE_COLOR { get; set; }
    public int INPUT_TEXTURE_TYPE_DEFAULT { get; set; }
    public int INPUT_TEXTURE_TYPE_MASKS { get; set; }
    public int INPUT_TEXTURE_TYPE_NORMALMAP { get; set; }
    public int INPUT_TEXTURE_TYPE_PEARLESCENCE_MASK { get; set; }
    public int INPUT_TEXTURE_TYPE_ROUGHNESS { get; set; }
    public int MATCH_FILTER_MATERIAL_ATTRIBUTE_EQUALS { get; set; }
    public int MATCH_FILTER_MATERIAL_ATTRIBUTE_EXISTS { get; set; }
    public int MATCH_FILTER_MATERIAL_NAME_SUBSTR { get; set; }
    public int MATCH_FILTER_MATERIAL_PROPERTY_EQUALS { get; set; }
    public int MATCH_FILTER_MATERIAL_PROPERTY_EXISTS { get; set; }
    public int MATCH_FILTER_MATERIAL_SHADER { get; set; }
    public int COMPMATSYSVAR_COMPOSITETIME { get; set; }
    public int COMPMATSYSVAR_EMPTY_RESOURCE_SPACER { get; set; }
}

public class Metadata
{
    public string name { get; set; }
    public string ty { get; set; }
    public string type { get; set; }
}

public class PhysicsRagdollPoseT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class SellbackPurchaseEntryT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class ShardModelDescT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class Sky3dparamsT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class ViewAngleServerChangeT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class VPhysicsCollisionAttributeT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class WeaponPurchaseCountT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}

public class WeaponPurchaseTrackerT
{
    public Fields fields { get; set; }
    public List<Metadata> metadata { get; set; }
    public object parent { get; set; }
}