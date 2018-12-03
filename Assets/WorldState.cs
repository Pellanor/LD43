using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldState {
    private static bool tavernDestroyed = false;
    private static List<string> destroyedDwellings = new List<string>();
    private static HashSet<string> states = new HashSet<string>();
    public static Random rnd = new Random();
    public static Player currentPlayer = new Player();
	
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
        return (building == "tavern" && tavernDestroyed)
            || (building != "Tavern" && destroyedDwellings.Contains(building));
    }

    public static bool IsBuilt(string building) {
        return !IsDestroyed(building);
    }

    public static bool IsDwellingDestroyed() {
        return destroyedDwellings.Count > 0;
    }

    public static string GetDestroyedDwelling() {
        return destroyedDwellings[Random.Range(0,destroyedDwellings.Count)];
    }
}
