internal class BreakAndEnter : DailyQuestCandidate {
    public bool IsAvailable() {
        return WorldState.currentPlayer.Has(Player.Traits.Skullduggery);
    }

    public bool IsPriority() {
        throw new System.NotImplementedException();
    }

    public Option Left() {
        throw new System.NotImplementedException();
    }

    public string QuestText() {
        throw new System.NotImplementedException();
    }

    public Option Right() {
        throw new System.NotImplementedException();
    }

    public string Text() {
        throw new System.NotImplementedException();
    }
}