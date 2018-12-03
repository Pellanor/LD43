internal class InvestigateCamp : DailyQuestCandidate {
    public bool IsAvailable() {
        return World.IsState("CAMP_FOUND")
            && !World.IsState("CAMP_CLEARED");
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return new Option("Slay them all!", new AttackCamp());
    }

    public string QuestText() {
        return "Investigate Goblin Camp";
    }

    public Option Right() {
        return new Option("Slay them all!", new AttackCamp());
    }

    public string Text() {
        return "A small number of goblins are cooking something over an open fire. It doesn't smell quite as bad as you expected. You see no sign of the captives.";
    }
}