internal class GoblinHunting : DailyQuestCandidate {
    public bool IsAvailable() {
        return true;
    }

    public bool IsPriority() {
        throw new System.NotImplementedException();
    }

    public Option Left() {
        throw new System.NotImplementedException();
    }

    public Option Right() {
        throw new System.NotImplementedException();
    }

    public string QuestText() {
        return "Hunt for more Goblins";
    }

    public string Text() {
        return "You kill more goblins";
    }
}