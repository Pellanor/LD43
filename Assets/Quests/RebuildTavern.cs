internal class RebuildTavern : DailyQuestCandidate {
    public bool IsAvailable() {
        return WorldState.IsDestroyed("Tavern");
    }

    public bool IsPriority() {
        throw new System.NotImplementedException();
    }

    public Option Left() {
        throw new System.NotImplementedException();
    }

    public string QuestText() {
        return "Rebuild the Tavern";
    }

    public Option Right() {
        throw new System.NotImplementedException();
    }

    public string Text() {
        throw new System.NotImplementedException();
    }
}