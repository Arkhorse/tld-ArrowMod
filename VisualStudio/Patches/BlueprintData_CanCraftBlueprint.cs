namespace ArrowMod
{
    // based on better mending mod
    [HarmonyPatch(typeof(BlueprintData), "CanCraftBlueprint")]
    private class BlueprintData_CanCraftBlueprint
    {

        private static void Postfix(ref bool __result, BlueprintData __instance)
        {
            if (__instance.m_CraftedResult == GetGearItemPrefab("GEAR_ArrowShaft") && __instance.m_RequiredGear[0].m_Item == GetGearItemPrefab("GEAR_Hardwood") && __result)
            {
                int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                int requiredArcherySkill = Settings.options.craftArrowFromWoodLevel;
                if (currentArcherySkill < requiredArcherySkill)
                {
                    __result = false;
                }
            }
            if (__instance.m_CraftedResult == GetGearItemPrefab("GEAR_Arrow") && __instance.m_RequiredGear[1].m_Item == GetGearItemPrefab("GEAR_BarkTinder") && __result)
            {
                int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                int requiredArcherySkill = Settings.options.craftFletchingFromBarkLevel;
                if (currentArcherySkill < requiredArcherySkill)
                {
                    __result = false;
                }
            }
        }
    }
}