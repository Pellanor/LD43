internal class StudyAmulet : Quest {
    public Option Left() {
        return new Option("Huh", () => World.player.Learn(Player.Clue.AMULET_DETAILS));
    }

    public Option Right() {
        return new Option("Unusual", () => World.player.Learn(Player.Clue.AMULET_DETAILS));
    }

    public string Text() {
        return "The arcane symbols on your amulet seem like runes of protection at first glance, but upon closer examination they're actually runes of preservation with a hint soul magic. Much more powerful than you would expect to find in such a small town.";
    }
}