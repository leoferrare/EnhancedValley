# EnhancedValley

Numerous mods to add small contents to the game.

## Included Mods

### 1. CustomChestSizeMod (C# SMAPI Framework Mod)
A framework mod that allows any mod to specify custom chest capacities using Content Patcher `CustomFields`.<br>
*Enormous Chest is a basic usage of this mod.*
- **How it works:** It uses Harmony to patch Stardew Valley's `Chest.GetActualCapacity` method. It looks up the custom field `"Darkiriq30.CustomChestSizeMod/Capacity"` inside `Data/BigCraftables` to dynamically override the chest size.
- **Usage for developers:** In your Content Patcher pack, add the following to your big craftable's `CustomFields` property, replacing `X` with any value you want.
  ```json
  "Darkiriq30.CustomChestSizeMod/Capacity": "X"
  ```

### 2. [CP] Enormous Chest (Content Patcher Mod)
A Content Patcher pack that adds the **Enormous Chest**, which serves as an upgrade to the vanilla Big Chest.<br>
*This mod is a basic example use of the CustomChestSizeMod.*
- **Capacity:** 120 slots (compared to vanilla Big Chest's 70 slots).
- **Crafting Ingredients:** 150 Wood, 20 Hardwood, 4 Iron Bars, and 10 Void Essence.
- **Obtaining:** The recipe can be purchased from Robin at the Carpenter's Shop for 10,000g.
- **Unlock Condition:** The recipe is gated behind player progression and will only appear in Robin's shop after you have purchased/learned the vanilla **Big Chest** recipe.

### 3. [CP] Better Equipments (Content Patcher Mod)
A Content Patcher pack that registers custom, high-tier combat equipment:
- **Prismatic Ring**: A custom ring radiating with prismatic energy, registered in `Data/Objects` (Type: `Ring`).
  - **Crafting Recipe:** 1 Prismatic Shard, 5 Iridium Bars, and 10 Refined Quartz (unlocks at **Combat Level 10**).
- **Prismatic Boots**: Custom boots forged from prismatic shards, registered in `Data/Boots` (stats: +6 Defense, +6 Immunity).
  - **Crafting Recipe:** 1 Prismatic Shard, 10 Iridium Bars, and 10 Cinder Shards (unlocks at **Combat Level 10**).

## Authors
- [**Darkiriq30**](https://github.com/leoferrare) - Mods
- [**YukiRubi**](https://github.com/YukiRubi) - Mods, Assets