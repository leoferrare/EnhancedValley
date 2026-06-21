using HarmonyLib;
using StardewModdingAPI;
using StardewValley.Objects;

namespace CustomChestSizeMod
{
    /// <summary>
    /// The entry point for the CustomChestSizeMod SMAPI mod.
    /// This mod dynamically overrides chest storage capacities based on Content Patcher CustomFields.
    /// </summary>
    public class ModEntry : Mod
    {
        /// <summary>
        /// Initializes the mod and registers the Harmony patches.
        /// </summary>
        /// <param name="helper">The SMAPI mod helper API.</param>
        public override void Entry(IModHelper helper)
        {
            // Create a new Harmony instance for modifying game methods at runtime.
            var harmony = new Harmony(this.ModManifest.UniqueID);

            // Apply a Postfix patch to the vanilla Chest.GetActualCapacity method.
            // This allows us to modify the return value of that method after it runs.
            harmony.Patch(
                original: AccessTools.Method(typeof(Chest), nameof(Chest.GetActualCapacity)),
                postfix: new HarmonyMethod(typeof(ModEntry), nameof(ModEntry.Chest_GetActualCapacity_Postfix))
            );
        }

        /// <summary>
        /// Harmony postfix patch that intercepts and overrides a chest's capacity.
        /// </summary>
        /// <param name="__instance">The actual Chest instance that was queried.</param>
        /// <param name="__result">The return value (capacity) of the GetActualCapacity method, passed by reference so we can modify it.</param>
        private static void Chest_GetActualCapacity_Postfix(Chest __instance, ref int __result)
        {
            // 1. Ensure the big craftable item database is loaded and contains data.
            // 2. Check if this chest's ItemId exists in the game's big craftable data asset.
            if (StardewValley.Game1.bigCraftableData != null && 
                StardewValley.Game1.bigCraftableData.TryGetValue(__instance.ItemId, out var data))
            {
                // 3. Verify that the big craftable has CustomFields defined.
                // 4. Try to retrieve our custom capacity field: "Darkiriq30.CustomChestSizeMod/Capacity".
                // 5. Safely parse the capacity value string into a valid integer.
                if (data.CustomFields != null && 
                    data.CustomFields.TryGetValue("Darkiriq30.CustomChestSizeMod/Capacity", out string rawCapacity) && 
                    int.TryParse(rawCapacity, out int capacity))
                {
                    // Override the chest capacity return value with our parsed custom capacity.
                    __result = capacity;
                }
            }
        }
    }
}
