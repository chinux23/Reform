using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.Core;
using TaleWorlds.Localization;


/* Patch party speed based on culture and friendiness.
 * 
 * When party is in a unfriendly territory such as near enemy castle, party suffers movement penalty. 
 * The penalty gets worse if the cultures are different, for example invasion.
 * The penalty is lessened if the culture is the same, for example retake lost territory.
 * 
 * Same logic applies when party is in friendly territory. Friendly territory gives party a movement bonus.
 * Same culture boost bonus.
 * Different culture reduces the bonus.
 * 
 * If the party is in enemy territory and the culture is different than party's leader, speed penalty is 1.0.
 * If the party is in enemy territory and party leader's culture is same with current territory, speed penalty is 0.
 * If the party is in friendly territory, speed bonus is 0.5
 */
namespace UnfriendlyTerritorySpeedFix
{

  internal class TerritorySpeedModel : DefaultPartySpeedCalculatingModel
  {

    public void PatchSpeedDueToFriendiness(ref MobileParty mobileParty, ref ExplainedNumber bonuses, ref Settlement closest_settlement)
    {
      if (closest_settlement.MapFaction == null) {
        // Training field.
        return;
      }

      if (mobileParty.MapFaction == null) {
        InformationManager.DisplayMessage(new InformationMessage("mobile party faction is null"));
        return;
      }

      if (mobileParty.MapFaction.IsAtWarWith(closest_settlement.MapFaction)) {
        bonuses.Add(-0.5f, new TextObject("Unfriendly Territory"));
        PatchSpeedDueToCulture(ref mobileParty, ref bonuses, ref closest_settlement);
      }
      if (mobileParty.MapFaction.StringId == closest_settlement.MapFaction.StringId) {
        bonuses.Add(0.5f, new TextObject("Friendly Territory"));
        PatchSpeedDueToCulture(ref mobileParty, ref bonuses, ref closest_settlement);
      }
    }

    public void PatchSpeedDueToCulture(ref MobileParty mobileParty, ref ExplainedNumber bonuses, ref Settlement closest_settlement)
    {
      if (closest_settlement.Culture == null) {
        // Training field.
        return;
      }

      if (mobileParty.LeaderHero == null) {
        return;
      }

      if (mobileParty.LeaderHero.Culture == null) {
        InformationManager.DisplayMessage(new InformationMessage("mobile party faction is null"));
        return;
      }

      if (closest_settlement.Culture == mobileParty.Leader.Culture) {
        bonuses.Add(0.5f, new TextObject("Friendly Culture"));
      } else {
        bonuses.Add(-0.5f, new TextObject("Unfriendly Culture"));
      }
    }

    public override ExplainedNumber CalculateFinalSpeed(MobileParty mobileParty, ExplainedNumber finalSpeed)
    {
      ExplainedNumber result = base.CalculateFinalSpeed(mobileParty, finalSpeed);

      if (!IsAffectedParty(mobileParty)) {
        return result;
      }

      Settlement closest_settlement = FindClosetSettlement(mobileParty);
      if (closest_settlement == null) {
        InformationManager.DisplayMessage(new InformationMessage("Unable to find closest settlement."));
        return result;
      }

      PatchSpeedDueToFriendiness(ref mobileParty, ref result, ref closest_settlement);

      result.LimitMin(1f);
      return result;
    }

    public static Dictionary<(int, int), string> pos_settlement_cache = new Dictionary<(int, int), string>();

    public Settlement FindClosetSettlement(MobileParty mobileParty)
    {
      string closest_settlement_id;

      (int, int) pos = ((int)mobileParty.Position2D.X, (int)mobileParty.Position2D.Y);
      if (pos_settlement_cache.ContainsKey(pos)) {
        closest_settlement_id = pos_settlement_cache[pos];
      } else {
        closest_settlement_id = Helpers.SettlementHelper.FindNearestSettlementToPoint(mobileParty.Position2D).StringId;
        pos_settlement_cache[pos] = closest_settlement_id;
      }
      return Settlement.Find(closest_settlement_id);
    }

    public bool IsAffectedParty(MobileParty party)
    {
      if (party.IsLeaderless) {
        return false;
      }

      if (party.IsLordParty) {
        return true;
      }

      if (party.IsMainParty) {
        return true;
      }

      return false;
    }
  }
}

