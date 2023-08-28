namespace ArrowMod
{
    [HarmonyPatch(typeof(Panel_Crafting), "ItemPassesFilter")]
    private static class Panel_Crafting_ItemPassesFilter
    {
        private static void Postfix(Panel_Crafting __instance, ref bool __result, BlueprintData bpi)
        {
            if (bpi?.m_CraftedResult?.name == "GEAR_Arrow")
            {
                if (Settings.options.arrowUseLine && bpi.m_RequiredGear.Count == 3)
                {
                    __result = false;
                }
                if (bpi.m_RequiredGear[1].m_Item == GetGearItemPrefab("GEAR_BarkTinder"))
                {
                    bpi.m_DurationMinutes = (Settings.options.arrowCraftTime + Settings.options.craftFletchingFromBarkTime) * 2;
                }
                else
                {
                    bpi.m_DurationMinutes = Settings.options.arrowCraftTime;
                }
            }
            else if (bpi?.m_CraftedResult?.name == "GEAR_ArrowHead")
            {
                // for mods that override result count, like ForgeBlueprintsMod
                int resMulti = bpi.m_CraftedResultCount / 2;
                bpi.m_DurationMinutes = Settings.options.arrowHeadCraftTime * resMulti;

            }

        }
    }
}