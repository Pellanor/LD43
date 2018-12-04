using System;

internal class RebuildTavern : DailyQuestCandidate {
    public bool IsAvailable() {
        return World.IsDestroyed("Tavern");
    }

    public bool IsPriority() {
        return false;
    }

    private Action Rebuild() {
        return () => World.Rebuild("Tavern");
    }

    public Option Left() {
        return new Option("Celebrate with a Drink!", Rebuild(), new DrinkInTavern());
    }

    public Option Right() {
        if (World.player.Has(Player.Traits.MYSTIC_KNOW)) {
            return new Option("You notice a small arcane rune in the wreckage...", Rebuild(), new ExamineArcaneRune());
        }
        return new Option("Turn in early. You've got a busy day tomorrow.", Rebuild());
    }

    public string QuestText() {
        return "Rebuild the Tavern";
    }

    public string Text() {
        return "It's hard work but the whole town comes town comes together and soon the tavern is restored. Luckily it wasn't that large, and the townsfolk are well versed at rebuilding.";
    }
}