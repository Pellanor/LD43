using ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;
using static Player.Traits;

public class Intro : Quest {
    private Quest next = new PickWeapon();
    private Player.Traits leftTrait;
    private Player.Traits rightTrait;

    public Intro() {
        if (World.deathCount == 0) {
            leftTrait = GOBLIN_SLAYER;
            List<Player.Traits> possible = new List<Player.Traits> { MYSTIC_KNOW, OBSERVANT, SKULLDUGGERY };
            rightTrait = possible[Random.Range(0, possible.Count)];
        } else {
            List<Player.Traits> possible = new List<Player.Traits> { GOBLIN_SLAYER, MYSTIC_KNOW, OBSERVANT, SKULLDUGGERY };
            rightTrait = possible[Random.Range(0, possible.Count)];
            possible.Remove(rightTrait);
            leftTrait = possible[Random.Range(0, possible.Count)];
        }
    }

    public string Text() {
        return World.deathCount == 0
            ? "You are the promised hero of legend! Renowned throughout the land for your ..."
            : "You are the TRUE promised hero of legend! Much better than that last smuck. Renowned throughout the land for your ...";
    }

    public Option Left() {
        return new Option(leftTrait.GetDescription(), () => World.player.Grant(leftTrait), next);
    }

    public Option Right() {
        return new Option(rightTrait.GetDescription(), () => World.player.Grant(rightTrait), next);
    }
}
