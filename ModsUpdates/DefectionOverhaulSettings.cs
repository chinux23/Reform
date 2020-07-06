using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;
namespace DefectionOverhaul
{
  public class DefectionOverhaulSettings : AttributeGlobalSettings<DefectionOverhaulSettings>
  {
    public override string DisplayName => "Defection Overhaul";
    public override string Id => "defection.overhaul";
    public override string FolderName => "DefectionOverhaul";
    public override string Format => "xml";

    [SettingPropertyInteger("Defection", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationDefect {
      get;
      set;
    } = 10;

    [SettingPropertyInteger("Deceitful (Honor -2)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationDefectHonorMinus2 {
      get;
      set;
    } = 30;

    [SettingPropertyInteger("Devious (Honor -1)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationDefectHonorMinus1 {
      get;
      set;
    } = 20;


    [SettingPropertyInteger("Honest (Honor 1)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationDefectHonorPlus1 {
      get;
      set;
    } = 0;


    [SettingPropertyInteger("Honorable (Honor 2)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationDefectHonorPlus2 {
      get;
      set;
    } = -10;


    [SettingPropertyInteger("Leave", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeave {
      get;
      set;
    } = 10;


    [SettingPropertyInteger("Leave - Deceitful (Honor -2)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveHonorMinus2 {
      get;
      set;
    } = 30;

    [SettingPropertyInteger("Leave - Devious (Honor -1)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveHonorMinus1 {
      get;
      set;
    } = 20;


    [SettingPropertyInteger("Leave - Honest (Honor 1)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveHonorPlus1 {
      get;
      set;
    } = 0;


    [SettingPropertyInteger("Leave - Honorable (Honor 2)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveHonorPlus2 {
      get;
      set;
    } = -10;


    [SettingPropertyInteger("Leave as Mercenary", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveMercenary {
      get;
      set;
    } = 50;


    [SettingPropertyInteger("Leave as Mercenary - Deceitful (Honor -2)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveMercenaryHonorMinus2 {
      get;
      set;
    } = 50;


    [SettingPropertyInteger("Leave as Mercenary - Devious (Honor -1)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveMercenaryHonorMinus1 {
      get;
      set;
    } = 50;


    [SettingPropertyInteger("Leave as Mercenary - Honest (Honor 1)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveMercenaryHonorPlus1 {
      get;
      set;
    } = 50;


    [SettingPropertyInteger("Leave as Mercenary - Honorable (Honor 2)", -100, 100)]
    [SettingPropertyGroup("Player's Kingdom - Minimum Relation Required for Never Leave")]
    public int MinLeaderRelationLeaveMercenaryHonorPlus2 {
      get;
      set;
    } = 50;


    [SettingPropertyBool("Defection - Global")]
    [SettingPropertyGroup("Global")]
    public bool ToggleDefectionGlobal {
      get;
      set;
    } = false;

    [SettingPropertyBool("Leave - Global")]
    [SettingPropertyGroup("Global")]
    public bool ToggleLeaveGlobal {
      get;
      set;
    } = false;

    [SettingPropertyBool("Leave as Mercenary - Global")]
    [SettingPropertyGroup("Global")]
    public bool ToggleLeaveMercenaryGlobal {
      get;
      set;
    } = false;

    [SettingPropertyBool("Enable Debug Messages")]
    [SettingPropertyGroup("Debug")]
    public bool ToggleDebugMessages {
      get;
      set;
    } = false;
  }
}
