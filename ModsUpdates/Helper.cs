using MCM.Abstractions.Settings.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace DefectionOverhaul
{
  public class Helper
  {
    public static void MessageHelper(string message)
    {
      InformationManager.DisplayMessage((InformationMessage)(object)new InformationMessage(message, Colors.Yellow));
    }

    public static void DebugDefect(Clan clan, Kingdom kingdom)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleDebugMessages) {
        InformationManager.DisplayMessage((InformationMessage)(object)new InformationMessage("The clan " + clan.Name.ToString() + " of your Kingdom considered defecting to the " + kingdom.Name.ToString() + " because their leader's relationship with you is " + clan.Leader.GetRelationWithPlayer().ToString() + "!", Colors.Yellow));
      }
    }

    public static void DebugDefect(Clan clan, Kingdom kingdom, string condition)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleDebugMessages) {
        InformationManager.DisplayMessage((InformationMessage)(object)new InformationMessage("The clan " + clan.Name.ToString() + " of your Kingdom considered defecting to the " + kingdom.Name.ToString() + " because their leader's relationship with you is " + clan.Leader.GetRelationWithPlayer().ToString() + "! (" + condition + ")", Colors.Yellow));
      }
    }

    public static void DebugLeave(Clan clan)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleDebugMessages) {
        InformationManager.DisplayMessage((InformationMessage)(object)new InformationMessage("The clan " + clan.Name.ToString() + " of your Kingdom considered leaving because their leader's relationship with you is " + clan.Leader.GetRelationWithPlayer().ToString() + "!", Colors.Yellow));
      }
    }

    public static void DebugLeave(Clan clan, string condition)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleDebugMessages) {
        InformationManager.DisplayMessage((InformationMessage)(object)new InformationMessage("The clan " + clan.Name.ToString() + " of your Kingdom considered leaving because their leader's relationship with you is " + clan.Leader.GetRelationWithPlayer().ToString() + "! (" + condition + ")", Colors.Yellow));
      }
    }

    public static void DebugLeaveMercenary(Clan clan)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleDebugMessages) {
        InformationManager.DisplayMessage((InformationMessage)(object)new InformationMessage("The mercenary clan " + (clan.Name)?.ToString() + " in your Kingdom's service considered breaking their contract because their leader's relationship with you is " + clan.Leader.GetRelationWithPlayer().ToString() + "!", Colors.Yellow));
      }
    }

    public static void DebugLeaveMercenary(Clan clan, string condition)
    {
      if (GlobalSettings<DefectionOverhaulSettings>.Instance.ToggleDebugMessages) {
        InformationManager.DisplayMessage((InformationMessage)(object)new InformationMessage("The mercenary clan " + (clan.Name)?.ToString() + " in your Kingdom's service considered breaking their contract because their leader's relationship with you is " + clan.Leader.GetRelationWithPlayer().ToString() + "! (" + condition + ")", Colors.Yellow));
      }
    }
  }
}
