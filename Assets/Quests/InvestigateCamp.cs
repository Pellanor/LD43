internal class InvestigateCamp : Quest {
    public Option Left() {
        return new Option("Slay them all!", (p) => { }, new AttackCamp());
    }

    public Option Right() {
        return new Option("Slay them all!", (p) => { }, new AttackCamp());
    }

    public string Text() {
        return "A small number of goblins are cooking something over an open fire. It doesn't smell quite as bad as you expected. You see no sign of the captives.";
    }
}