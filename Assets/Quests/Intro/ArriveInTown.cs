using System.Collections.Generic;
using UnityEngine;

internal class ArriveInTown : Quest {
    private List<string> homes = new List<string> { "Calderon residence", "Wagner house", "Snyder's home" };
    private string leftBuilding;
    private string rightBuilding;

    public ArriveInTown() {
        leftBuilding = getHome();
        if (World.IsBuilt("Tavern")) {
            rightBuilding = "Tavern";
        } else {
            rightBuilding = getHome();
        }
    }

    private string getHome() {
        int el = Random.Range(0, homes.Count);
        string h = homes[el];
        homes.Remove(h);
        return h;
    }

    public Option Left() {
        return new Option("Save the " + leftBuilding,
            Destroy(rightBuilding),
            new GreetElder(leftBuilding, rightBuilding));
    }

    public Option Right() {
        return new Option("Save the " + rightBuilding,
            Destroy(leftBuilding),
            new GreetElder(rightBuilding, leftBuilding));
    }

    private System.Action Destroy(string building) {
        return () => {
            World.Destroy(building);
            if (building != "Tavern") {
                World.SetState("CAPTIVE_TAKEN");
            }
        };
    }

    public string Text() {
        return "The green monsters are besiging the " + leftBuilding + " and the " + rightBuilding + "!";
    }
}