using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using UnfriendlyTerritorySpeedFix;

namespace UnfriendlyTerritorySpeedFix
{
  public class Main : MBSubModuleBase
  {
    protected override void OnSubModuleLoad()
    {
      base.OnSubModuleLoad();
    }

    protected override void OnGameStart(Game game, IGameStarter starterObject)
    {
      starterObject.AddModel(new TerritorySpeedModel());
    }

    protected override void OnBeforeInitialModuleScreenSetAsRoot()
    {
      //new Harmony("mod.bannerlord.unfriendly.territory.seepdfix").PatchAll();
      InformationManager
          .DisplayMessage(new InformationMessage("UnfriendlyTerritorySpeedFix"));
    }
  }
}