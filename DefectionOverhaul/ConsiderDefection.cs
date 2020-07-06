using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.BarterBehaviors;

namespace DefectionOverhaul
{
  [HarmonyPatch(typeof(DiplomaticBartersBehavior), "ConsiderDefection")]
  public class ConsiderDefection
  {
    public static bool Prefix(Clan clan1, Kingdom kingdom)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleDefectionGlobal) {
        return false;
      }
      if (clan1.Kingdom.RulingClan == Clan.PlayerClan || clan1.Kingdom.MapFaction.Leader == Hero.MainHero) {
        string condition = "Honor " + clan1.Leader.GetTraitLevel(DefaultTraits.Honor).ToString();
        switch (clan1.Leader.GetTraitLevel(DefaultTraits.Honor)) {
          case -2:
            if (clan1.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationDefectHonorMinus2) {
              return false;
            }
            break;
          case -1:
            if (clan1.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationDefectHonorMinus1) {
              return false;
            }
            break;
          case 1:
            if (clan1.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationDefectHonorPlus1) {
              return false;
            }
            break;
          case 2:
            if (clan1.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationDefectHonorPlus2) {
              return false;
            }
            break;
        }
        if (clan1.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationDefect) {
          return false;
        }
        Helper.DebugDefect(clan1, kingdom, condition);
        return true;
      }
      return true;
    }
  }
}
