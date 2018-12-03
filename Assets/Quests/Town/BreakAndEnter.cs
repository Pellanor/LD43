using System;

internal class BreakAndEnter : DailyQuestCandidate {
    public bool IsAvailable() {
        return World.player.Has(Player.Traits.Skullduggery);
    }

    private Action Clue() {
        return () => World.player.Learn("ELDER_STUFF");
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        if (World.player.Has(Player.Traits.MysticalKnowledge)) {
            return new Option("Take some time to study his arcane tomes", Clue(), new StudyElderStuff());
        }
        return new Option("It's a shame you don't understand any of this", Clue());
    }

    public string QuestText() {
        return "Sneak into the Elder's Home";
    }

    public Option Right() {
        if (World.player.HasOneClueLeft()) {
            return new Option("He must be behind everything. Ambush him!", Clue(), new AmbushElder());
        }
        return new Option("It's a shame you don't understand any of this", Clue());
    }

    public string Text() {
        return "While visiting the Elder you were intrigued by his unusual collection. You wait until he's out, then sneak in to take a closer look. Magical tomes line his bookshelves, and ancient artifacts are scattered through his study.";
    }
}