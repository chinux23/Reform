using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.BarterBehaviors;

namespace DefectionOverhaul
{
  [HarmonyPatch(typeof(DiplomaticBartersBehavior), "ConsiderClanLeaveKingdom")]
  public class ConsiderClanLeaveKingdom
  {
    public static bool Prefix(Clan clan)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleLeaveGlobal) {
        return false;
      }
      if (clan.Kingdom.RulingClan == Clan.PlayerClan ||
          clan.Kingdom.MapFaction.Leader == Hero.MainHero) {
        string condition = "Honor " + clan.Leader.GetTraitLevel(DefaultTraits.Honor).ToString();
        switch (clan.Leader.GetTraitLevel(DefaultTraits.Honor)) {
          case -2:
            if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveHonorMinus2) {
              return false;
            }
            break;
          case -1:
            if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveHonorMinus1) {
              return false;
            }
            break;
          case 1:
            if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveHonorPlus1) {
              return false;
            }
            break;
          case 2:
            if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveHonorPlus2) {
              return false;
            }
            break;
        }
        if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeave) {
          return false;
        }
        Helper.DebugLeave(clan, condition);
        return true;
      }
      return true;
    }
  }
}