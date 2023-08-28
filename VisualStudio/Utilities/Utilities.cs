namespace ArrowMod
{
    internal class Utilities
    {
        // NOTE: These "Get" methods are volitile. Ensure it is always up to date as otherwise it can break anything tied to GearItem
        // This is used to load prefab info of a GearItem
        [return: NotNullIfNotNull(nameof(name))]
        public static GearItem GetGearItemPrefab(string name) => GearItem.LoadGearItemPrefab(name);
        [return: NotNullIfNotNull(nameof(name))]
        public static ToolsItem GetToolItemPrefab(string name) => GearItem.LoadGearItemPrefab(name).GetComponent<ToolsItem>();
        [return: NotNullIfNotNull(nameof(name))]
        public static ClothingItem GetClothingItemPrefab(string name) => GearItem.LoadGearItemPrefab(name).GetComponent<ClothingItem>();

        // use this to ensure that gear names are properly named
        [return: NotNullIfNotNull(nameof(name))]
        public static string? NormalizeName(string name)
        {
            if (name == null) return null;
            else return name.Replace("(Clone)", "").Trim();
        }

        // from CraftingRevisions by ds5678 and STBlade
        public static Il2CppAK.Wwise.Event? MakeAudioEvent(string eventName)
        {
            if (eventName == null)
            {
                return null;
            }
            uint eventId = AkSoundEngine.GetIDFromString(eventName);
            if (eventId <= 0 || eventId >= 4294967295)
            {
                return null;
            }

            Il2CppAK.Wwise.Event newEvent = new();
            newEvent.WwiseObjectReference = new WwiseEventReference();
            newEvent.WwiseObjectReference.objectName = eventName;
            newEvent.WwiseObjectReference.id = eventId;
            return newEvent;
        }
    }
}