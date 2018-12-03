internal class RebuildHome : DailyQuestCandidate {
    private string dwelling;

    public bool IsAvailable() {
        return WorldState.IsDwellingDestroyed();
    }

    public bool IsPriority() {
        throw new System.NotImplementedException();
    }

    public Option Left() {
        throw new System.NotImplementedException();
    }

    public string QuestText() {
        dwelling = WorldState.GetDestroyedDwelling();
        return "Rebuild the " + dwelling;
    }

    public Option Right() {
        throw new System.NotImplementedException();
    }

    public string Text() {
        throw new System.NotImplementedException();
    }
}