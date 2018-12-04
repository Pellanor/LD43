using ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;
using static World;

internal class PickWeapon : Quest {
    private Quest arrive = new ArriveInTown();
    private readonly List<Weapon> allWeapons = new List<Weapon> {Weapon.SCYTHE, Weapon.GLAIVE, Weapon.FLAIL, Weapon.METEOR_HAMMER, Weapon.LOCHABER_AXE, Weapon.FALCION, Weapon.RAPIER};
    private Weapon left;
    private Weapon right;

    public PickWeapon() {
        List<Weapon> possible = new List<Weapon>(weaponsNotYetProfecient);
        if (possible.Count == 0) {
            possible = new List<Weapon>(allWeapons);
        }
        left = possible[Random.Range(0, possible.Count)];
        if (possible.Count == 1) {
            possible = new List<Weapon>(allWeapons);
        }
        possible.Remove(left);
        right = possible[Random.Range(0, possible.Count)];
    }

    private System.Action ChooseWeapon(Weapon w) {
        return () => {
            player.GrantProfeciency(w);
            player.CurrentWeapon = w;
            player.WeaponSet = true;
            if (!goblinCaptainSpawned) {
                goblinCaptainWeapon = ChooseWeaponToSpawn();
                SpawnWeapon(goblinCaptainWeapon);
                goblinCaptainSpawned = true;
            }
        };
    }

    public Option Left() {
        return new Option(left.GetDescription(), ChooseWeapon(left), arrive);
    }

    public Option Right() {
        return new Option(right.GetDescription(), ChooseWeapon(right), arrive);
    }

    public string Text() {
        return "After days of travel you arrive at the remote town of Bracklewhyte only to find it under attack by goblins! You charge forth to save the day, hefting your trusty ...";
    }
}