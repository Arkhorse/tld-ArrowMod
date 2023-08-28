using Il2CppTLD.Gear;

namespace ArrowMod
{
    // based on better mending mod
    [HarmonyPatch(typeof(BlueprintData), nameof(BlueprintData.CanCraftBlueprint), new Type[] { typeof(Inventory), typeof(PlayerManager), typeof(CraftingLocation) })]
    public class BlueprintData_CanCraftBlueprint
    {
        public static void Postfix(ref bool __result, BlueprintData __instance)
        {
            if (__instance.m_CraftedResult == Utilities.GetGearItemPrefab("GEAR_ArrowShaft") && __instance.m_RequiredGear[0].m_Item == Utilities.GetGearItemPrefab("GEAR_Hardwood") && __result)
            {
                int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                int requiredArcherySkill = Settings.Instance.craftArrowFromWoodLevel;
                if (currentArcherySkill < requiredArcherySkill)
                {
                    __result = false;
                }
            }
            if (__instance.m_CraftedResult == Utilities.GetGearItemPrefab("GEAR_Arrow") && __instance.m_RequiredGear[1].m_Item == Utilities.GetGearItemPrefab("GEAR_BarkTinder") && __result)
            {
                int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                int requiredArcherySkill = Settings.Instance.craftFletchingFromBarkLevel;
                if (currentArcherySkill < requiredArcherySkill)
                {
                    __result = false;
                }
            }
        }
    }
}