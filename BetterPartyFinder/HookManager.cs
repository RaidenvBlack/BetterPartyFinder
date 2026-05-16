using System;
using Dalamud.Utility.Signatures;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace BetterPartyFinder;


public unsafe class HookManager
{
    [Signature("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 0F 10 81 ?? ?? ?? ?? 8B 99")]
    private readonly delegate* unmanaged<AgentLookingForGroup*, byte, byte> RequestPartyFinderListings = null!;

    public HookManager()
    {
        Plugin.GameInteropProvider.InitializeFromAttributes(this);
    }

    public void RefreshListings()
    {
        if (RequestPartyFinderListings == null)
            throw new InvalidOperationException("Could not find signature for Party Finder listings");

        var agent = AgentLookingForGroup.Instance();
        RequestPartyFinderListings(agent, agent->CategoryTab);
    }
}