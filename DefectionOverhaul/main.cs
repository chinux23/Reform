using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace DefectionOverhaul
{
  public class Main : MBSubModuleBase
  {
    protected override void OnSubModuleLoad()
    {
      base.OnSubModuleLoad();
    }

    protected override void OnBeforeInitialModuleScreenSetAsRoot()
    {
      new Harmony("mod.bannerlord.defection.overhaul").PatchAll();
      InformationManager
          .DisplayMessage(new InformationMessage("Defection Overhaul loaded."));
    }

  }
}