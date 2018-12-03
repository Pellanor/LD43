internal class SearchForCaptive : DailyQuestCandidate {
    public bool IsAvailable() {
        return World.IsState("CAPTIVE_TAKEN")
            && !World.IsState("FOUND_CAMP");
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return new Option("Investigate the camp", () => World.SetState("FOUND_CAMP"), new InvestigateCamp());
    }

    public Option Right() {
        if (World.player.Has(Player.Traits.GoblinSlayer)) {
            return new Option("Slay Goblins!!!", () => World.SetState("FOUND_CAMP"), new AttackCamp());
        }
        return new Option("Follow the path towards the mountains", () => World.SetState("FOUND_CAMP"), new FindRuins());
    }

    public string QuestText() {
        return "Search for Captives";
    }

    public string Text() {
        return "You pick up the trail just outside of town and venture into the woods. After a few hours hike you notice the path diverge. Down the left path you see smoke rising from cookfires. The right path looks less traveled and continues deeper into the woods, towards the mountains.";
    }
}