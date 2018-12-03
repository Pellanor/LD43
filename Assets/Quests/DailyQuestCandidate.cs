public interface DailyQuestCandidate : Quest {
    bool IsAvailable();
    bool IsPriority();
    string QuestText();
}