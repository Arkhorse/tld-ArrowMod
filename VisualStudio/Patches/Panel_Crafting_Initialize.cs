using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTLD.Gear;

namespace ArrowMod
{
    //[HarmonyPatch(typeof(GameManager), "Awake")]
    [HarmonyPatch(typeof(Panel_Crafting), nameof(Panel_Crafting.Initialize))]
    public class InterfaceManager_Awake
    {
        public static void Postfix()
        {
            if (!InterfaceManager.GetPanel<Panel_Crafting>().enabled) return;

            if (Settings.Instance.arrowUseLine)
            {
                BlueprintData bpi = new()
                {
                    // Inputs
                    m_KeroseneLitersRequired = 0f,
                    m_GunpowderKGRequired = 0f,
                    m_RequiredTool = null,
                    m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                    // Outputs
                    m_CraftedResult = Utilities.GetGearItemPrefab("GEAR_Arrow"),
                    m_CraftedResultCount = 1,

                    // Process
                    m_Locked = false,
                    m_AppearsInStoryOnly = false,
                    m_RequiresLight = true,
                    m_RequiresLitFire = false,
                    m_RequiredCraftingLocation = CraftingLocation.Workbench,
                    m_DurationMinutes = Settings.Instance.arrowCraftTime, // whatever, we need to set this in ItemPassFilter
                    m_CraftingAudio = Utilities.MakeAudioEvent("PLAY_CRAFTINGARROWS"),

                    m_AppliedSkill = SkillType.None,
                    m_ImprovedSkill = SkillType.None,
                    m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(0) { }
                };

                bpi.m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                {
                    [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = Utilities.GetGearItemPrefab("GEAR_Line") },
                    [1] = new BlueprintData.RequiredGearItem() { m_Count = 3, m_Item = Utilities.GetGearItemPrefab("GEAR_CrowFeather") },
                    [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = Utilities.GetGearItemPrefab("GEAR_ArrowShaft") },
                    [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = Utilities.GetGearItemPrefab("GEAR_ArrowHead") }
                };
                InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi);

                if (Settings.Instance.craftFletchingFromBark)
                {
                    BlueprintData bpi2 = new()
                    {
                        // Inputs
                        m_KeroseneLitersRequired = 0f,
                        m_GunpowderKGRequired = 0f,
                        m_RequiredTool = Utilities.GetToolItemPrefab("GEAR_Knife"),
                        m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                        // Outputs
                        m_CraftedResult = Utilities.GetGearItemPrefab("GEAR_Arrow"),
                        m_CraftedResultCount = 1,

                        // Process
                        m_Locked = false,
                        m_AppearsInStoryOnly = false,
                        m_RequiresLight = true,
                        m_RequiresLitFire = false,
                        m_RequiredCraftingLocation = CraftingLocation.Workbench,
                        m_DurationMinutes = 2 * (Settings.Instance.arrowCraftTime + Settings.Instance.craftFletchingFromBarkTime), // whaever, we need to set this in ItemPassFilter
                        m_CraftingAudio = Utilities.MakeAudioEvent("PLAY_CRAFTINGARROWS"),
                        m_AppliedSkill = SkillType.None,
                        m_ImprovedSkill = SkillType.None,
                        m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(4)
                        {
                            [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = Utilities.GetGearItemPrefab("GEAR_Line") },
                            [1] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = Utilities.GetGearItemPrefab("GEAR_BarkTinder") },
                            [2] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = Utilities.GetGearItemPrefab("GEAR_ArrowShaft") },
                            [3] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = Utilities.GetGearItemPrefab("GEAR_ArrowHead") }
                        }
                    };
                    InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi2);
                }
            }
            if (Settings.Instance.craftArrowFromWood)
            {
                BlueprintData bpi3 = new()
                {
                    // Inputs
                    m_KeroseneLitersRequired = 0f,
                    m_GunpowderKGRequired = 0f,
                    m_RequiredTool = Utilities.GetToolItemPrefab("GEAR_Knife"),
                    m_OptionalTools = new Il2CppReferenceArray<ToolsItem>(0),

                    // Outputs
                    m_CraftedResult = Utilities.GetGearItemPrefab("GEAR_ArrowShaft"),
                    m_CraftedResultCount = 3,

                    // Process
                    m_Locked = false,
                    m_AppearsInStoryOnly = false,
                    m_RequiresLight = true,
                    m_RequiresLitFire = false,
                    m_RequiredCraftingLocation = CraftingLocation.Workbench,
                    m_DurationMinutes = 180, // with knife it will be 1/2 of this time; it will be much longer than from branch but it takes time to cut arrow from plank
                    m_CraftingAudio = Utilities.MakeAudioEvent("PLAY_CRAFTINGARROWS"),
                    m_AppliedSkill = SkillType.None,
                    m_ImprovedSkill = SkillType.None,
                    m_RequiredGear = new Il2CppReferenceArray<BlueprintData.RequiredGearItem>(1)
                    {
                        [0] = new BlueprintData.RequiredGearItem() { m_Count = 1, m_Item = Utilities.GetGearItemPrefab("GEAR_Hardwood") }
                    }
                };

                InterfaceManager.GetInstance().m_BlueprintManager.m_AllBlueprints.Add(bpi3);
            }
        }
    }
}