public class Intro : Quest {
    private Option left;
    private Option right;
    private Quest next = new Weapon();

    public string Text() {
        return "You are the promised hero of legend! Renowned throughout the land for your ...";
    }

    public Option Left() {
        return new Option("Hatred of Goblins", () => World.player.Grant(Player.Traits.GoblinSlayer), next);
    }

    public Option Right() {
        return new Option("Random Trait", () => World.player.Grant(Player.Traits.Trait), next);
    }
}
