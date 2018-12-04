using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player {
    public enum Traits {
        [Description("Hatred of Goblins")]
        GOBLIN_SLAYER,
        [Description("Mystical Knowldege")]
        MYSTIC_KNOW,
        [Description("Ability to get where you don't belong")]
        SKULLDUGGERY,
        [Description("Keen observation")]
        OBSERVANT };
    public enum State { HAS_AMULET }
    public enum Clue { AMULET, AMULET_IN_ACTION, AMULET_DETAILS, ELDER_STUFF, ELDER_STUFF_STUDIED, ELDER_HOME, KNICK_OF_TIME, GOBBOWEED, ARCANE_RUNE, ELDER_WEAPON }
    private int xp = 0;
    public World.Weapon CurrentWeapon { get; set; }

    HashSet<Clue> clues = new HashSet<Clue>();
    HashSet<Traits> traits = new HashSet<Traits>();
    HashSet<State> states = new HashSet<State>();
    HashSet<World.Weapon> profectientWeapons = new HashSet<World.Weapon>();
    HashSet<World.Weapon> magicWeapons = new HashSet<World.Weapon>();

    public bool Knows(Clue clue) {
        return clues.Contains(clue);
    }

    public void Learn(Clue clue) {
        clues.Add(clue);
    }

    public Boolean HasEnoughClues() {
        return Knows(Clue.AMULET_IN_ACTION) && clues.Count >= 8;
    }

    public Boolean HasOneClueLeft() {
        return Knows(Clue.AMULET_IN_ACTION) && clues.Count >= 7;
    }

    public List<Clue> GetKnownClues() {
        return clues.ToList();
    }

    internal bool HasMagicWeapon() {
        return profectientWeapons.Intersect(magicWeapons).Count() > 0;
    }

    private List<World.Weapon> WeaponsCannotUse() {
        return magicWeapons.Except(profectientWeapons).ToList();
    }

    internal bool HasWeaponCannotUse() {
        return WeaponsCannotUse().Count > 0;
    }

    internal void GiveWeapon(World.Weapon weapon) {
        magicWeapons.Add(weapon);
        if (CanUse(weapon)) {
            CurrentWeapon = weapon;
        }
    }

    public World.Weapon ChooseWeaponToTake() {
        List<World.Weapon> possible = WeaponsCannotUse();
        World.Weapon w = possible[Random.Range(0, possible.Count)];
        return w;
    }

    public void TakeWeapon(World.Weapon w ) {
        magicWeapons.Remove(w);
    }

    public List<World.Weapon> TakeAllWeapons() {
        List<World.Weapon> toTake = new List<World.Weapon>(magicWeapons);
        magicWeapons.Clear();
        return toTake;
    }

    public bool Has(Traits trait) {
        return traits.Contains(trait);
    }

    public void Grant(Traits trait) {
        traits.Add(trait);
    }

    public bool CanUse(World.Weapon weapon) {
        return profectientWeapons.Contains(weapon);
    }

    public void GrantProfeciency(World.Weapon weapon) {
        profectientWeapons.Add(weapon);
        World.weaponsNotYetProfecient.Remove(weapon);
    }

    internal void XpUp() {
        xp++;
    }

    internal int Xp() {
        return xp;
    }


    public bool IsState(State state) {
        return states.Contains(state);
    }

    public void SetState(State state) {
        states.Add(state);
    }

    public void ClearState(State state) {
        states.Remove(state);
    }

    internal IEnumerable<World.Weapon> GetProfectientWeapons() {
        return profectientWeapons;
    }
}
