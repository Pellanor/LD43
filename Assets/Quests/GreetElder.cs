internal class GreetElder : Quest {
    private string savedBuilding;
    private string destroyedBuilding;

    public GreetElder(string savedBuilding, string destroyedBuilding) {
        this.savedBuilding = savedBuilding;
        this.destroyedBuilding = destroyedBuilding;
    }

    public Option Left() {
        return new Option("Yo", (p) => { }, null);
    }

    public Option Right() {
        return new Option("Up Dog.", (p) => { }, null);
    }

    public string Text() {
        return "You slay the goblins at the " + savedBuilding + ", and the others are so demoralized they flee, but not before burning down the " + destroyedBuilding + ". The town elder, a wizened old man, thanks you for saving them, and offers you an Amulet of Protection in reward.";
    }
}