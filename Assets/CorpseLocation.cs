using System.Collections.Generic;

public class CorpseLocation {
    private List<Player> corpses = new List<Player>();

    public void PlayerDied() {
        World.SetState(World.State.DEAD);
        World.deathCount++;
        corpses.Add(World.player);
    }

    public List<Player> Corpses() {
        return corpses;
    }

    public void RecoverCorpse(Player p) {
        corpses.Remove(p);
        World.SetAmulet(p);
    }
}