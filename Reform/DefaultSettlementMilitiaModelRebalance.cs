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
  [HarmonyPatch(typeof(DefaultSettlementMilitiaModel), "CalculateMilitiaChange")]
  internal class MilitiaChangeRebalance
  {
    // This is quite hacky.
    // TODO: Revise this mechanism here used to adjust daily militia change.
    //const int kProsperityIndex = 1;
    const float town_castle_multiplier = 2f;
    const float village_multiplier = 10f;

    public static void Postfix(
      ref float __result,
      Settlement settlement,
      StatExplainer explanation,
      DefaultSettlementMilitiaModel __instance,
      ref TextObject ____baseText,
      ref TextObject ____retiredText,
      ref TextObject ____fromHearthsText,
      ref TextObject ____fromProsperityText,
      ref TextObject ____cultureText,
      ref TextObject ____militiaFromMarketText,
      ref TextObject ____foodShortageText
      )
    {
      float mutliplier = 1;
      float old_mulitia_change_due_to_prosperity = 0;
      if (settlement.IsVillage) {
        mutliplier = village_multiplier;
        old_mulitia_change_due_to_prosperity = settlement.Village.Hearth / 500f;
      } else if (settlement.IsFortification) {
        mutliplier = town_castle_multiplier;
        old_mulitia_change_due_to_prosperity = settlement.Town.Prosperity / (settlement.IsCastle ? 500f : 1000f);
      }
      float reform_adjustment = (mutliplier - 1) * old_mulitia_change_due_to_prosperity;

      // Change adjustment;
      __result += reform_adjustment;

      if (explanation != null) {
        foreach (StatExplainer.ExplanationLine line in explanation.Lines) {
          if (line.Name == ____fromProsperityText.ToString()) {
            line.Number += reform_adjustment;
          } else if (line.Name == ____fromHearthsText.ToString()) {
            line.Number += reform_adjustment;
          }
          //explanation.AddLine("Reformed", reform_adjustment);
          // explanation.Lines[kProsperityIndex].Number = old_mulitia_change_due_to_prosperity * mutliplier;
        }
      }
    }
  }
}
