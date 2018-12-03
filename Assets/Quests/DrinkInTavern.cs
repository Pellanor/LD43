internal class DrinkInTavern : DailyQuestCandidate {
    public bool IsAvailable() {
        return WorldState.IsBuilt("Tavern");
    }

    public bool IsPriority() {
        throw new System.NotImplementedException();
    }

    public Option Left() {
        throw new System.NotImplementedException();
    }

    public string QuestText() {
        return "Spend the day in the Tavern";
    }

    public Option Right() {
        throw new System.NotImplementedException();
    }

    public string Text() {
        throw new System.NotImplementedException();
    }
}