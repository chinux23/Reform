This is updated Defection Overhaul for Bannerlord with MCMv3 as of July 5th, 2020.

Original Mod: https://www.nexusmods.com/mountandblade2bannerlord/mods/705


The goal of this mod is to prevent clans from defecting from or leaving the player's kingdom, unless the leader's relationship with the player is low (threshold is configurable). I got tired of clan leaders I had a positive relationship with, or had given fiefs to etc, still defecting from my Kingdom.

This is achieved with a Harmony Prefix patch of the following methods found in ﻿TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors.BarterBehaviors.DiplomaticBartersBehavior:

ConsiderDefection(Clan, Kingdom)
ConsiderClanLeaveKingdom(Clan)
ConsiderClanLeaveAsMercenary(Clan)

The Harmony patch applies logic that prevents these methods from running for a clan that is in a Kingdom where the ruling clan is the player's clan, with a leader whose relationship is above a configurable threshold with the player. How Honorable the clan leader is affects the threshold. Otherwise, the methods run as normal and the clan may leave the Kingdom. The minimum required relationship with the player is adjustable in the Mod Options menu. There is also three global toggles for whether all clans are allowed to defect from/leave/leave as mercenary. This applies to clans in every Kingdom, not just the player's, and overrides any other settings set in the mod - this is Disabled by default.

Known Compatibility Issues
The Community Patch﻿ currently must be placed at the bottom of your load order, as it performs a main menu cleanup which breaks mods using MBOptionScreen - the Community Patch team is implementing a fix in their next version. The game will crash at the main menu if you do not follow this instruction.
Defection Overhaul has been tested on version e1.3.0 and Beta e1.4.0.

Potential Future Features
Open for suggestions

Tools Used
Harmony Library - https://github.com/pardeike/Harmony
Mod Configuration Menu (MBOptionScreen) v3 - https://github.com/Aragas/Bannerlord.MBOptionScreen
