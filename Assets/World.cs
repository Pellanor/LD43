using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

public class World {
    public enum State {DEAD, CAMP_CLEARED, CAPTIVE_TAKEN, HAS_SUPPLIES, CAPTAIN_WAIT, CAPTAIN_SLAIN, VICTORY }
    public enum Location { GOBLIN_CAMP, GOBLIN_RUINS, MAGIC_LANDS, GOBLIN_CAPTAIN }

    public enum Weapon {
        [Description("Scythe")]
        SCYTHE,
        [Description("Glaive")]
        GLAIVE,
        [Description("Flail")]
        FLAIL,
        [Description("Meteor Hammer")]
        METEOR_HAMMER,
        [Description("Lochaber Axe")]
        LOCHABER_AXE,
        [Description("Falcion")]
        FALCION,
        [Description("Rapier")]
        RAPIER
    }
    private static List<Weapon> weaponsCanBeSpawned = new List<Weapon> { Weapon.SCYTHE, Weapon.GLAIVE, Weapon.FLAIL, Weapon.METEOR_HAMMER, Weapon.LOCHABER_AXE, Weapon.FALCION, Weapon.RAPIER };
    public static List<Weapon> weaponsNotYetProfecient = new List<Weapon> { Weapon.SCYTHE, Weapon.GLAIVE, Weapon.FLAIL, Weapon.METEOR_HAMMER, Weapon.LOCHABER_AXE, Weapon.FALCION, Weapon.RAPIER };
    private static List<string> destroyedDwellings = new List<string>();
    private static bool tavernDestroyed = false;
    private static int goblinsSlain = 0;
    public static Weapon goblinCaptainWeapon;
    public static bool goblinGaptainSpawned = false;

    private static HashSet<State> states = new HashSet<State>();
    private static HashSet<Location> map = new HashSet<Location>();
    public static Player player = new Player();
    private static Player amulet;

    public static CorpseLocation goblinAmbush = new CorpseLocation();
    public static CorpseLocation goblinCaptain = new CorpseLocation();
    public static CorpseLocation mountains = new CorpseLocation();
    public static int deathCount = 0;
    public static int elderPower = 3;

    private static List<Weapon> eldersWeapons = new List<Weapon>();

    public static bool ElderHasWeaponPlayerCanUse() {
        return eldersWeapons.Where(weapon => player.CanUse(weapon)).ToList().Count > 0;
    }

    public static void GiveElderWeapon(Weapon w) {
        eldersWeapons.Add(w);
    }

    public static Weapon ChooseWeaponFromElder() {
        List<Weapon> possible = eldersWeapons.Where(weapon => player.CanUse(weapon)).ToList();
        return possible[UnityEngine.Random.Range(0, possible.Count)];
    }

    public static Weapon TakeWeaponFromElder(Weapon w) {
        eldersWeapons.Remove(w);
        return w;
    }

    public static Weapon ChooseWeaponToSpawn() {
        List<Weapon> possible = new List<Weapon>(weaponsNotYetProfecient);
        possible.RemoveAll(weapon => player.CanUse(weapon));
        Weapon w = possible[UnityEngine.Random.Range(0, possible.Count)];
        return w;
    }

    public static void SpawnWeapon(Weapon w) {
        weaponsCanBeSpawned.Remove(w);
    }

    internal static void SetAmulet(Player p) {
        player.SetState(Player.State.HAS_AMULET);
        amulet = p;
    }

    internal static void TransferPower() {
        player.ClearState(Player.State.HAS_AMULET);
        foreach(Player.Clue c in amulet.GetKnownClues()) {
            player.Learn(c);
        }
        foreach (World.Weapon w in amulet.GetProfectientWeapons()) {
            player.GrantProfeciency(w);
        }
        for(int i = 0; i < amulet.Xp(); i+=2) {
            player.XpUp();
        }
        elderPower++;
        amulet = null;
    }


    public static bool IsState(State state) {
        return states.Contains(state);
    }

    public static void SetState(State state) {
        states.Add(state);
    }

    public static void ClearState(State state) {
        states.Remove(state);
    }

    public static void AddToMap(Location l) {
        map.Add(l);
    }

    public static Boolean LocationOnMap(Location l) {
        return map.Contains(l);
    }

    public static void Destroy(string building) {
        if (building == "Tavern") {
            tavernDestroyed = true;
        } else {
            destroyedDwellings.Add(building);
        }
    }

    public static void Rebuild(string building) {
        if (building == "Tavern") {
            tavernDestroyed = false;
        } else {
            destroyedDwellings.Remove(building);
        }
    }

    public static bool IsDestroyed(string building) {
        return (building == "Tavern" && tavernDestroyed)
            || (building != "Tavern" && destroyedDwellings.Contains(building));
    }

    public static bool IsBuilt(string building) {
        return !IsDestroyed(building);
    }

    public static bool IsDwellingDestroyed() {
        return destroyedDwellings.Count > 0;
    }

    public static string GetDestroyedDwelling() {
        return destroyedDwellings[UnityEngine.Random.Range(0,destroyedDwellings.Count)];
    }

    internal static int GoblinsSlain() {
        return goblinsSlain;
    }

    internal static void SlayGoblins() {
        goblinsSlain++;
    }
}
