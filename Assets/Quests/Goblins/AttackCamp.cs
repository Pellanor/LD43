using System;

internal class AttackCamp : Quest {

    private Action Victory() {
        return () => {
            World.player.XpUp();
            World.SetState("CAMP_CLEARED");
        };
    }

    public Option Left() {
        return new Option("Great Victory!", Victory());
    }

    public Option Right() {
        return new Option("Successs!", Victory());
    }

    public string Text() {
        return "You make short work of the goblins. Searching the camp thouroughly you see no sign of humans being held here. The sun begins to set, so you turn home victorius";
    }
}