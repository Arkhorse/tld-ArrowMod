using Il2CppTLD.Gear;

namespace ArrowMod
{
    [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.ItemPassesFilter), new Type[] { typeof(BlueprintData) })]
    public static class Panel_Crafting_ItemPassesFilter
    {
        public static void Postfix(Panel_Crafting __instance, ref bool __result, BlueprintData bpi)
        {
            if (!InterfaceManager.GetPanel<Panel_Crafting>().enabled) return;

            if (bpi != null && bpi.m_CraftedResult != null)
            {
                if (bpi.m_CraftedResult.name == "GEAR_Arrow")
                {
                    if (Settings.Instance.arrowUseLine && bpi.m_RequiredGear.Count == 3)
                    {
                        __result = false;
                    }
                    if (bpi.m_RequiredGear[1].m_Item == Utilities.GetGearItemPrefab("GEAR_BarkTinder"))
                    {
                        bpi.m_DurationMinutes = (Settings.Instance.arrowCraftTime + Settings.Instance.craftFletchingFromBarkTime) * 2;
                    }
                    else
                    {
                        bpi.m_DurationMinutes = Settings.Instance.arrowCraftTime;
                    }
                }
                else if (bpi.m_CraftedResult.name == "GEAR_ArrowHead")
                {
                    // for mods that override result count, like ForgeBlueprintsMod
                    int resMulti = bpi.m_CraftedResultCount / 2;
                    bpi.m_DurationMinutes = Settings.Instance.arrowHeadCraftTime * resMulti;

                }
            }
        }
    }
}