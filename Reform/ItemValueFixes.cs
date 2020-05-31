﻿using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace Reform
{
  [HarmonyPatch(typeof(DefaultItemValueModel), "CalculateTierMeleeWeapon")]
  internal class ItemValueFixes
  {
    public static void Postfix(WeaponComponent weaponComponent, ref float __result)
    {
      WeaponComponentData weaponComponentData = weaponComponent.PrimaryWeapon;
      if (weaponComponentData.WeaponClass == WeaponClass.Javelin) {
        if (__result > 0) {
          // Javelie price is extradinarily high with high smithing skills.
          // Use sqrt to smooth the curve.
          __result = (float)Math.Sqrt(__result);
        }
      }
    }
  }
}
