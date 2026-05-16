using Dalamud.Game.Gui.PartyFinder.Types;
using Dalamud.Interface.Colors;
using Dalamud.Interface.Utility.Raii;
using Dalamud.Bindings.ImGui;

namespace BetterPartyFinder.Windows.Main;

public partial class MainWindow
{
    private bool Save;

    private void DrawRestrictionsTab(ConfigurationFilter filter)
    {
        using var table = ImRaii.Table("CategoryTable", 2, ImGuiTableFlags.BordersInnerV);
        if (!table.Success)
            return;

        Save = false;

        ImGui.TableSetupColumn("##Show");
        ImGui.TableSetupColumn("##Hide");

        ImGui.TableNextColumn();
        Helper.TextColored(ImGuiColors.HealerGreen, "Show:");
        ImGui.Separator();

        ImGui.TableNextColumn();
        Helper.TextColored(ImGuiColors.ParsedOrange, "Hide:");
        ImGui.Separator();

        filter[MirroredObjectiveFlags.None] = DrawRestrictionEntry("No Objective Set", filter[MirroredObjectiveFlags.None]);
        filter[MirroredObjectiveFlags.Practice] = DrawRestrictionEntry("Practice", filter[MirroredObjectiveFlags.Practice]);
        filter[MirroredObjectiveFlags.DutyCompletion] = DrawRestrictionEntry("Duty Completion", filter[MirroredObjectiveFlags.DutyCompletion]);
        filter[MirroredObjectiveFlags.Loot] = DrawRestrictionEntry("Loot", filter[MirroredObjectiveFlags.Loot]);

        DrawSeparator();

        filter[ConditionFlags.None] = DrawRestrictionEntry("No Completion Requirement", filter[ConditionFlags.None]);
        filter[ConditionFlags.DutyIncomplete] = DrawRestrictionEntry("Duty Incomplete", filter[ConditionFlags.DutyIncomplete]);
        filter[ConditionFlags.DutyComplete] = DrawRestrictionEntry("Duty Complete", filter[ConditionFlags.DutyComplete]);
        filter[ConditionFlags.DutyCompleteWeeklyUnclaimed] = DrawRestrictionEntry("Weekly Reward Unclaimed", filter[ConditionFlags.DutyCompleteWeeklyUnclaimed]);

        DrawSeparator();

        filter[DutyFinderSettingsFlags.UnrestrictedParty] = DrawRestrictionEntry("Undersized Party", filter[DutyFinderSettingsFlags.UnrestrictedParty]);
        filter[DutyFinderSettingsFlags.MinimumIL] = DrawRestrictionEntry("Minimum Item Level", filter[DutyFinderSettingsFlags.MinimumIL]);
        filter[DutyFinderSettingsFlags.SilenceEcho] = DrawRestrictionEntry("Silence Echo", filter[DutyFinderSettingsFlags.SilenceEcho]);

        DrawSeparator();

        filter[MirroredLootRuleFlags.GreedOnly] = DrawRestrictionEntry("Greed Only", filter[MirroredLootRuleFlags.GreedOnly]);
        filter[MirroredLootRuleFlags.Lootmaster] = DrawRestrictionEntry("Lootmaster", filter[MirroredLootRuleFlags.Lootmaster]);

        DrawSeparator();

        filter[SearchAreaFlags.DataCenter] = DrawRestrictionEntry("Data Centre Parties", filter[SearchAreaFlags.DataCenter]);
        filter[SearchAreaFlags.World] = DrawRestrictionEntry("World-Local Parties", filter[SearchAreaFlags.World]);
        filter[SearchAreaFlags.OnePlayerPerJob] = DrawRestrictionEntry("One Player Per Job", filter[SearchAreaFlags.OnePlayerPerJob]);

        if (Save)
            Plugin.Config.Save();
    }

    private bool DrawRestrictionEntry(string name, bool state)
    {
        ImGui.TableNextRow();
        ImGui.TableSetColumnIndex(state ? 0 : 1);

        if (ImGui.Selectable(name))
        {
            state = !state;
            Save = true;
        }

        return state;
    }

    private void DrawSeparator()
    {
        ImGui.TableNextRow();

        ImGui.TableNextColumn();
        ImGui.Separator();
        ImGui.TableNextColumn();
        ImGui.Separator();
    }
}