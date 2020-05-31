using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Reform
{
  [HarmonyPatch(typeof(Village), "HearthLevel")]
  internal class SettlementFoodStocksChange
  {
    public static void Postfix(
      ref int __result,
      Village __instance)
    {
      __result = (int)__instance.Hearth / 100;
    }
  }
}
