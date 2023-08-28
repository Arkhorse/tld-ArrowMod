using Il2CppTLD.Gear;

namespace ArrowMod
{
    // based on better mending mod
    [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.RefreshSelectedBlueprint))]
    public class Panel_Crafting_RefreshSelectedBlueprint
    {
        public static void Postfix(Panel_Crafting __instance)
        {
            if (!InterfaceManager.GetPanel<Panel_Crafting>().enabled) return;

            //__instance.m_SelectedDescription.color = whiteColor;
            BlueprintData bpi = __instance.SelectedBPI;
            if (bpi)
            {
                __instance.m_SelectedDescription.color = Color.white;
                if (bpi.m_CraftedResult == Utilities.GetGearItemPrefab("GEAR_ArrowShaft") && bpi.m_RequiredGear[0].m_Item == Utilities.GetGearItemPrefab("GEAR_Hardwood"))
                {
                    int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                    int requiredArcherySkill = Settings.Instance.craftArrowFromWoodLevel;
                    if (currentArcherySkill < requiredArcherySkill)
                    {
                        __instance.m_SelectedDescription.text = "Required Archery skill " + requiredArcherySkill.ToString();
                        __instance.m_SelectedDescription.color = Color.red;
                    }
                }
                if (bpi.m_CraftedResult == Utilities.GetGearItemPrefab("GEAR_Arrow") && bpi.m_RequiredGear[1].m_Item == Utilities.GetGearItemPrefab("GEAR_BarkTinder"))
                {
                    int currentArcherySkill = GameManager.GetSkillArchery().GetCurrentTierNumber() + 1;
                    int requiredArcherySkill = Settings.Instance.craftFletchingFromBarkLevel;
                    if (currentArcherySkill < requiredArcherySkill)
                    {
                        __instance.m_SelectedDescription.text = "Required Archery skill " + requiredArcherySkill.ToString();
                        __instance.m_SelectedDescription.color = Color.red;
                    }
                }
            }
        }
    }
}