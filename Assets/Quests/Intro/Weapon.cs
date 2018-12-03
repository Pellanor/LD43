internal class Weapon : Quest {
    //todo: https://www.codementor.io/cerkit/giving-an-enum-a-string-value-using-the-description-attribute-6b4fwdle0
    public enum Weapons { Knife, Sword, BoringStuff}
    private Quest arrive = new ArriveInTown();

    public Option Left() {
        return new Option("Knife", () => World.player.GrantProfeciency("KNIFE"), arrive);
    }

    public Option Right() {
        return new Option("Sword", () => World.player.GrantProfeciency("SWORD"), arrive);
    }

    public string Text() {
        return "After days of travel you arrive at the remote town of Bracklewhyte only to find it under attack by goblins! You charge forth to save the day, hefting your trusty ...";
    }
}