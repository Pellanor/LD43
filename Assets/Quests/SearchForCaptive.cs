internal class SearchForCaptive : DailyQuestCandidate {
    public bool IsAvailable() {
        return WorldState.IsState("CAPTIVE_TAKEN")
            && !WorldState.IsState("FOUND_CAMP");
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return new Option("Investigate the camp", (p) => WorldState.SetState("FOUND_CAMP"), new InvestigateCamp());
    }

    public Option Right() {
        if (WorldState.currentPlayer.Has(Player.Traits.GoblinSlayer)) {
            new Option("Slay Goblins!!!", (p) => WorldState.SetState("FOUND_CAMP"), new AttackCamp());
        }
        return new Option("Follow the path towards the mountains", (p) => WorldState.SetState("FOUND_CAMP"), new FindRuins());
    }

    public string QuestText() {
        return "Search for Captives";
    }

    public string Text() {
        return "You pick up the trail just outside of town and venture into the woods. After a few hours hike you notice the path diverge. Down the left path you see smoke rising from cookfires. The right path looks less traveled and continues deeper into the woods, towards the mountains.";
    }
}