﻿using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;


namespace DifficultMelee
{
  class AgentAi
  {
    [HarmonyPatch(typeof(AgentStatCalculateModel))]
    [HarmonyPatch("SetAiRelatedProperties")]
    class OverrideSetAiRelatedProperties
    {
      static void Postfix(Agent agent, ref AgentDrivenProperties agentDrivenProperties, WeaponComponentData equippedItem, WeaponComponentData secondaryItem)
      {
        int meleeSkill = GetMeleeSkill(agent, equippedItem, secondaryItem);
        SkillObject skill = (equippedItem == null) ? DefaultSkills.Athletics : equippedItem.RelevantSkill;
        int effectiveSkill = GetEffectiveSkill(agent.Character, agent.Origin, agent.Formation, skill);
        float meleeLevel = CalculateAILevel(agent, meleeSkill);                 //num
        float effectiveSkillLevel = CalculateAILevel(agent, effectiveSkill);    //num2
        float meleeDefensivness = meleeLevel + agent.Defensiveness;             //num3

        agentDrivenProperties.AiChargeHorsebackTargetDistFactor = 4f;
        agentDrivenProperties.AIBlockOnDecideAbility = MBMath.ClampFloat(meleeLevel * 0.5f, 0.15f, 0.45f);
        agentDrivenProperties.AIParryOnDecideAbility = MBMath.ClampFloat((meleeLevel * 0.25f) + 0.15f, 0.1f, 0.45f);
        agentDrivenProperties.AIRealizeBlockingFromIncorrectSideAbility = MBMath.ClampFloat(meleeLevel + 0.1f, 0f, 0.95f);
        agentDrivenProperties.AIDecideOnAttackChance = MBMath.ClampFloat(meleeLevel + 0.1f, 0f, 0.95f);
        agentDrivenProperties.AIDecideOnRealizeEnemyBlockingAttackAbility = MBMath.ClampFloat(meleeLevel + 0.1f, 0f, 0.95f);

        agentDrivenProperties.AiRangedHorsebackMissileRange = 0.7f;
        agentDrivenProperties.AiUseShieldAgainstEnemyMissileProbability = 0.95f;
        agentDrivenProperties.AiFlyingMissileCheckRadius = 250f;
      }

      static float GetCombatAIDifficultyMultiplier()
      {
        switch (CampaignOptions.CombatAIDifficulty) {
          case CampaignOptions.Difficulty.VeryEasy:
            return 0.70f;
          case CampaignOptions.Difficulty.Easy:
            return 0.80f;
          case CampaignOptions.Difficulty.Realistic:
            return 0.90f;
          default:
            return 1.0f;
        }
      }

      static protected float CalculateAILevel(Agent agent, int relevantSkillLevel)
      {
        float difficultyModifier = GetCombatAIDifficultyMultiplier();
        //float difficultyModifier = 1.0f; // v enhanced battle test je difficulty very easy
        return MBMath.ClampFloat((float)relevantSkillLevel / 250f * difficultyModifier, 0f, 1f);
      }

      static protected int GetMeleeSkill(Agent agent, WeaponComponentData equippedItem, WeaponComponentData secondaryItem)
      {
        SkillObject skill = DefaultSkills.Athletics;
        if (equippedItem != null) {
          SkillObject relevantSkill = equippedItem.RelevantSkill;
          skill = ((relevantSkill == DefaultSkills.OneHanded || relevantSkill == DefaultSkills.Polearm) ? relevantSkill : ((relevantSkill != DefaultSkills.TwoHanded) ? DefaultSkills.OneHanded : ((secondaryItem == null) ? DefaultSkills.TwoHanded : DefaultSkills.OneHanded)));
        }
        return GetEffectiveSkill(agent.Character, agent.Origin, agent.Formation, skill);
      }

      static protected int GetEffectiveSkill(BasicCharacterObject agentCharacter, IAgentOriginBase agentOrigin, Formation agentFormation, SkillObject skill)
      {
        return agentCharacter.GetSkillValue(skill);
      }
    }
  }
}