using System;

internal class EscortSupplies : DailyQuestCandidate {
    public bool IsAvailable() {
        return !World.IsState(World.State.HAS_SUPPLIES);
    }

    private Action Clue() {
        return () => {
            World.SetState(World.State.HAS_SUPPLIES);
            World.player.Learn(Player.Clue.GOBBOWEED);
            World.player.XpUp();
        };
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return new Option("¯\\_(ツ)_/¯ Must be for goblin traps", Clue());
    }

    public string QuestText() {
        return "Escort a Supply Train";
    }

    public Option Right() {
        if (World.player.HasOneClueLeft()) {
            return new Option("The elder is up to something. Confront him!", Clue(), new ConfrontElder());
        }
        return new Option("Maybe the crazy brewster is experimenting again?", Clue());
    }

    public string Text() {
        return "The elder tells you about a supply caravan coming in from the south. You agree to ride out and meet them in case of goblin ambush. It's a good thing you do, as sure enough a small band try to ambush the caravan. You drive them off easily enough, though one crate is damage. You look inside to see a bunch of gobboweed. Why would anybody in town want that?";
    }
}