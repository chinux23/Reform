using System;

using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace Reform
{
  public class Main : MBSubModuleBase
  {
    protected override void OnSubModuleLoad()
    {
      Module.CurrentModule.AddInitialStateOption(new InitialStateOption(
        "TestReformOption", new TextObject("Click Me", null), 9990, () =>
        {
          InformationManager.DisplayMessage(
            new InformationMessage("HelloWorld"));
        }, false));
    }
  }
}
