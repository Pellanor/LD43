using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {
    private static bool tavernDestroyed = false;
    private static List<string> destroyedDwellings = new List<string>();
    private static int goblinsSlain = 0;

    private static HashSet<string> states = new HashSet<string>();
    public static Player player = new Player();

    private static List<Player> goblinAmbushCorpses = new List<Player>();
    private static List<Player> goblinCaptainCorpses = new List<Player>();
    public static int deathCount = 0;

    private static void Dead() {
        SetState("DEAD");
        deathCount++;
        player = new Player();
    }

    public static void DeadAtGoblinAmbush() {
        goblinAmbushCorpses.Add(player);
        Dead();
    }

    public static void DeadAtGoblinCaptain() {
        goblinCaptainCorpses.Add(player);
        Dead();
    }

    public static bool IsState(string state) {
        return states.Contains(state);
    }

    public static void SetState(string state) {
        states.Add(state);
    }

    public static void ClearState(string state) {
        states.Remove(state);
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
