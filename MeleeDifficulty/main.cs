using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace DifficultMelee
{
  public class Main : MBSubModuleBase
  {
    protected override void OnSubModuleLoad()
    {
      base.OnSubModuleLoad();
    }

    protected override void OnBeforeInitialModuleScreenSetAsRoot()
    {
      new Harmony("mod.bannerlord.difficult.melee").PatchAll();
      InformationManager
          .DisplayMessage(new InformationMessage("difficult melee Loaded."));
    }

  }
}