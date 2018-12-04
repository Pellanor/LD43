internal class GreetElder : Quest {
    private string savedBuilding;
    private string destroyedBuilding;

    public GreetElder(string savedBuilding, string destroyedBuilding) {
        this.savedBuilding = savedBuilding;
        this.destroyedBuilding = destroyedBuilding;
    }

    public Option Left() {
        if (World.player.Has(Player.Traits.GOBLIN_SLAYER)) {
            return new Option("You got any more of those goblins to slay?");
        }
        return new Option("Happy to help");
    }

    public Option Right() {
        if (World.player.Has(Player.Traits.GOBLIN_SLAYER)) {
            return new Option("I did it for the joy of the slaughter");
        }
        return new Option("It's what anybody would have done");
    }

    public string Text() {
        return "You slay the goblins at the " + savedBuilding + ", and the others are so demoralized they flee, but not before burning down the " + destroyedBuilding + ". The town elder, a wizened old man, thanks you for saving them, and offers you an Amulet of Protection in reward.";
    }
}