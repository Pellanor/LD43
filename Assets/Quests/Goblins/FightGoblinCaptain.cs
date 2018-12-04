using ExtensionMethods;
using System;
using System.Text;

internal class FightGoblinCaptain : DailyQuestCandidate {
    public bool IsAvailable() {
        return World.LocationOnMap(World.Location.GOBLIN_CAPTAIN) && !World.IsState(World.State.CAPTAIN_SLAIN);
    }

    public bool IsPriority() {
        return false;
    }

    private Action Victory() {
        return () => {
            World.player.GiveWeapon(World.goblinCaptainWeapon);
            World.SetState(World.State.CAPTAIN_SLAIN);
            World.SlayGoblins();
            World.player.XpUp();
        };
    }

    private Action Defeat() {
        return () => {
            World.goblinCaptain.PlayerDied();
        };
    }

    public Option Left() {
        if (Winning()) {
            return new Option(GoblinHunting.VictoryResponses[UnityEngine.Random.Range(0, GoblinHunting.VictoryResponses.Count)], Victory());
        }
        return new Option(GoblinHunting.DeathResponses[UnityEngine.Random.Range(0, GoblinHunting.DeathResponses.Count)], Defeat());
    }

    public Option Right() {
        if (Winning()) {
            return new Option(GoblinHunting.VictoryResponses[UnityEngine.Random.Range(0, GoblinHunting.VictoryResponses.Count)], Victory());
        }
        return new Option(GoblinHunting.DeathResponses[UnityEngine.Random.Range(0, GoblinHunting.DeathResponses.Count)], Defeat());
    }

    public string QuestText() {
        return "Challenge the Goblin Captain";
    }

    private bool Winning() {
        return World.player.Xp() >= 5 || World.player.HasMagicWeapon();
    }

    public string Text() {
        StringBuilder sb = new StringBuilder();
        if (World.IsState(World.State.CAPTAIN_WAIT)) {
            sb.Append("The captain is still patrolling the encampment. ");
        }
        sb.Append("You step out from the trees, challenging the captain to a duel! ");
        if (Winning()) {
            sb.Append("It is a close affair, but soon the goblin falls. His " + World.goblinCaptainWeapon.GetDescription() + " is now yours. ");
            if (!World.player.CanUse(World.goblinCaptainWeapon)) {
                sb.Append("It's a shame you don't know how to use it. ");
            } else {
                sb.Append("This will make you mutch stronger! ");
            }
            sb.Append("You return home victorious.");
        } else {
            sb.Append("While you're stronger that the goblin, it's quickly apparent that his mystic " + World.goblinCaptainWeapon.GetDescription() + " is giving him the edge. As his allies encircle you there's no where to flee. You are slain.");
        }
        return sb.ToString();
    }
}