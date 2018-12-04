using UnityEngine;

internal class BodyFromGoblinCaptain : DailyQuestCandidate {

    Player corpse;

    public BodyFromGoblinCaptain() {
        if (World.goblinCaptain.Corpses().Count > 0) {
            corpse = World.goblinCaptain.Corpses()[Random.Range(0, World.goblinCaptain.Corpses().Count)];
        }
    }

    public bool IsAvailable() {
        return corpse != null
            && World.player.Knows(Player.Clue.AMULET)
            && !World.player.IsState(Player.State.HAS_AMULET);
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return new Option("Have a Bath", () => World.goblinCaptain.RecoverCorpse(corpse));
    }

    public string QuestText() {
        return "Search for the hero slain by the Goblin Captain";
    }

    public Option Right() {
        if (World.IsBuilt("Tavern")) {
            return new Option("Have a drink", () => World.goblinCaptain.RecoverCorpse(corpse));
        }
        return new Option("Try to sleep", () => World.goblinCaptain.RecoverCorpse(corpse));
    }

    public string Text() {
        return "You find the last hereo's body in a shallow grave not far from the encampment. It's unpleasent work, but you're able to recover the amulet. Not wanting to risk losing it you return to town.";
    }
}