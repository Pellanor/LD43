using System;

internal class RebuildHome : DailyQuestCandidate {
    private string dwelling;

    public bool IsAvailable() {
        return World.IsDwellingDestroyed();
    }

    public bool IsPriority() {
        return false;
    }

    private Action Rebuild() {
        return () => World.Rebuild(dwelling);
    }

    public Option Left() {
        if (World.IsBuilt("Tavern")) {
            return new Option("Celebrate with a Drink!", Rebuild(), new DrinkInTavern());
        }
        return new Option("Turn in early. You've got a busy day tomorrow.", Rebuild());
    }

    public string QuestText() {
        dwelling = World.GetDestroyedDwelling();
        return "Rebuild the " + dwelling;
    }

    public Option Right() {
        if (World.player.Has(Player.Traits.MysticalKnowledge)) {
            return new Option("You notice a small arcane rune in the wreckage...", Rebuild(), new ExamineArcaneRune());
        }
        return new Option("Chat the night away with the grateful family", Rebuild());
    }

    public string Text() {
        return "It's hard work but the whole town comes town comes together and soon the " + dwelling + " is restored. Luckily it wasn't that large, and the townsfolk are well versed at rebuilding.";
    }
}