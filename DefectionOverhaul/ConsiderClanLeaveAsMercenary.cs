using HarmonyLib;
using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.BarterBehaviors;

namespace DefectionOverhaul
{
  [HarmonyPatch(typeof(DiplomaticBartersBehavior), "ConsiderClanLeaveAsMercenary")]
  public class ConsiderClanLeaveAsMercenary
  {
    public static bool Prefix(Clan clan)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleLeaveMercenaryGlobal) {
        return false;
      }
      if (clan.Kingdom.RulingClan == Clan.PlayerClan ||
          clan.Kingdom.MapFaction.Leader == Hero.MainHero) {
        string condition = "Honor " + clan.Leader.GetTraitLevel(DefaultTraits.Honor).ToString();
        switch (clan.Leader.GetTraitLevel(DefaultTraits.Honor)) {
          case -2:
            if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveMercenaryHonorMinus2) {
              return false;
            }
            break;
          case -1:
            if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveMercenaryHonorMinus1) {
              return false;
            }
            break;
          case 1:
            if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveMercenaryHonorPlus1) {
              return false;
            }
            break;
          case 2:
            if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveMercenaryHonorPlus2) {
              return false;
            }
            break;
        }
        if (clan.Leader.GetRelationWithPlayer() >= GlobalSettings<DefectionOverhaulSettings>.Instance.MinLeaderRelationLeaveMercenary) {
          return false;
        }
        Helper.DebugLeaveMercenary(clan, condition);
        return true;
      }
      return true;
    }
  }
}
