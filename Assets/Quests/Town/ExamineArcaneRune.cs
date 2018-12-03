using System;

internal class ExamineArcaneRune : Quest {
    private Action Clue() {
        return () => World.player.Learn("ARCANE_RUNE");
    }

    public Option Left() {
        return new Option("Keep quite and investigate further", Clue());
    }

    public Option Right() {
        if (World.player.HasEnoughClues() || (World.player.HasOneClueLeft() && !World.player.Knows("ARCANE_RUNE"))) {
            return new Option("It must be the elder! Confront him.", Clue(), new ConfrontElder());
        }
        return new Option("Warn the Elder!", Clue(), new WarnElder());
    }

    public string Text() {
        if (World.player.Knows("ARCANE_RUNE")) {
            return "This rune appears to be the same type you found before. Somebody is luring goblins into town.";
        }
        return "The rune was damaged in the destruction, but you're prtty sure it attracted the goblins here! Who could have placed it?";
    }
}