using System;
using Dalamud.Game.Gui.PartyFinder.Types;

namespace BetterPartyFinder;

[Flags]
public enum MirroredLootRuleFlags : byte
{
    Normal = 1 << LootRuleFlags.Normal,
    GreedOnly = 1 << LootRuleFlags.GreedOnly,
    Lootmaster = 1 << LootRuleFlags.Lootmaster,
}

[Flags]
public enum MirroredObjectiveFlags : byte
{
    None = 1 << 0,
    DutyCompletion = 1 << 1,
    Practice = 1 << 2,
    Loot = 1 << 3,
}