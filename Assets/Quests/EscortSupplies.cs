internal class EscortSupplies : DailyQuestCandidate {
    public bool IsAvailable() {
        return true;
    }

    public bool IsPriority() {
        throw new System.NotImplementedException();
    }

    public Option Left() {
        throw new System.NotImplementedException();
    }

    public string QuestText() {
        return "Escort a supply train";
    }

    public Option Right() {
        throw new System.NotImplementedException();
    }

    public string Text() {
        throw new System.NotImplementedException();
    }
}