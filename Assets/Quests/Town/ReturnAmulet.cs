using System;

internal class ReturnAmulet : DailyQuestCandidate {
    public bool IsAvailable() {
        return World.player.IsState(Player.State.HAS_AMULET);
    }

    public bool IsPriority() {
        return true;
    }

    private Action TransferPower() {
        return () => {
            World.player.Learn(Player.Clue.AMULET_IN_ACTION);
            World.TransferPower();
        };
    }

    public Option Left() {
        return new Option("I know kung fu!", TransferPower());
    }

    public string QuestText() {
        return "Return the amulet to the Elder";
    }

    public Option Right() {
        return new Option("Such Knowledge! Much wow!", TransferPower());
    }

    public string Text() {
        return "The elder is waiting for you when you get to his home. He takes the amulet from you and holds a small blue gem up to it which begins to glow. He then presses the gem to the amulet you where, and you feel the knowledge of your predecessor pass to you. It leaves you feeling stronger, and a little suspicious of what's going on in town.";
    }
}