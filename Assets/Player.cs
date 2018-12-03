using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
    public enum Traits { GoblinSlayer, Trait, MysticalKnowledge, Skullduggery, Observant };
    private int xp = 0;

    HashSet<string> clues = new HashSet<string>();
    HashSet<Traits> traits = new HashSet<Traits>();
    HashSet<string> states = new HashSet<string>();

    public bool Knows(string state) {
        return clues.Contains(state);
    }

    public void Learn(string state) {
        clues.Add(state);
    }

    public Boolean HasEnoughClues() {
        return clues.Count >= 5;
    }

    public Boolean HasOneClueLeft() {
        return clues.Count >= 4;
    }

    public bool Has(Traits trait) {
        return traits.Contains(trait);
    }

    public void Grant(Traits trait) {
        traits.Add(trait);
    }

    public bool CanUse(string weapon) {
        return false;
    }

    public void GrantProfeciency(string weapon) {

    }

    internal void XpUp() {
        xp++;
    }
}
