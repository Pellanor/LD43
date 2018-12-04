using System;

internal class WarnElder : Quest {

    private Action Defeat() {
        return () => {
            foreach (World.Weapon w in World.player.TakeAllWeapons()) {
                World.GiveElderWeapon(w);
            }
            World.goblinAmbush.PlayerDied();
        };
    }

    public Option Left() {
        return new Option("You must have been very tired!", Defeat());
    }

    public Option Right() {
        return new Option("Was there something in the Tea?", Defeat());
    }

    public string Text() {
        return "The elder takes you inside for tea. He's very concerned about the rune you found. Despite the importance of the news, you have a hard time keeping your eyes open. Your vision goes black.";
    }
}