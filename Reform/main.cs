using HarmonyLib;

using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace Reform
{
	public class Main : MBSubModuleBase
	{
		protected override void OnSubModuleLoad()
		{
			base.OnSubModuleLoad();
			// FileLog.Log("Reform module loaded.");
		}

		protected override void OnBeforeInitialModuleScreenSetAsRoot()
		{
			var harmony = new Harmony("mod.bannerlord.reform");
			harmony.PatchAll();
			InformationManager
					.DisplayMessage(new InformationMessage("Loading reform."));
		}
	}
}
