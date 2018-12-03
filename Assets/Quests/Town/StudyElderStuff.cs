using System;

internal class StudyElderStuff : Quest {
    private Action Clue() {
        return () => World.player.Learn("ELDER_STUFF_STUDIED");
    }

    public Option Left() {
        return new Option("Jump out the Window", Clue());
    }

    public Option Right() {
        if (World.player.HasOneClueLeft()) {
            return new Option("Confront the Elder", Clue(), new ConfrontElder());
        }
        return new Option("Slip out the Side Door", Clue());
    }

    public string Text() {
        return "You risk taking a bit more time to learn what you can. As you begin to red through his texts you realize most of them are far beyond you. Suddenly you hear the front door opening!";
    }
}