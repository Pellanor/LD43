
using ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

public class ExploreMountains : DailyQuestCandidate {
    public static readonly List<string> DeathResponses = new List<string> {
        "Boo",
        "Omnia mors æquat",
        "Death makes sad stories of us all"
    };

    private List<MountainScene> scenes = new List<MountainScene> {
         new MountainScene("The scree gives out from under you! You slip and fall off a cliff.", Death(), DeathResponses),
         new MountainScene("A Boulder comes from the sky and crushes your legs. As you lay on the ground you see a Runned Giant walking by.", Death(), DeathResponses)
    };

    private static System.Action Death() {
        return () => World.mountains.PlayerDied();
    }

    private static System.Action Weapon(World.Weapon weapon) {
        return () => {
            World.SpawnWeapon(weapon);
            World.player.GiveWeapon(weapon);
        };
    }

    private MountainScene currentScene;

    public ExploreMountains() {
        if (World.player.Knows(Player.Clue.AMULET) && !World.player.IsState(Player.State.HAS_AMULET)) {
            foreach (Player corpse in World.mountains.Corpses()) {
                scenes.Add(new MountainScene("As you scramble over some rocks, you notice a boot sticking out of a crevace. Looking closer it appears to be a fallen hero. You quickly retrieve the amulet and return home.",
                    new Option("Taking extra care of your footing", () => World.mountains.RecoverCorpse(corpse)),
                    new Option("Keeping an eye out for foes", () => World.mountains.RecoverCorpse(corpse))));
            }
        }
        if (!World.player.HasWeaponCannotUse() && !World.player.HasMagicWeapon() && World.CanSpawnWeapon()) {
            World.Weapon weapon = World.ChooseWeaponToSpawn();
            scenes.Add(new MountainScene("As you scramble over some rocks, you notice something metallic sticking out of a crevace. Looking closer it appears to be a " + weapon.GetDescription() + ". You quickly retrieve the weapon and return home.",
                new Option("Sweet Loot!", Weapon(weapon)),
                new Option("Why don't I ever find something I can use?", Weapon(weapon))));
        }
        currentScene = scenes[Random.Range(0, scenes.Count)];
    }

    public bool IsAvailable() {
        return World.LocationOnMap(World.Location.MAGIC_LANDS);
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return currentScene.GetLeft();
    }

    public Option Right() {
        return currentScene.GetRight();
    }

    public string QuestText() {
        return "Explore the Mountains";
    }

    public string Text() {
        return currentScene.Text();
    }

    private class MountainScene {
        private string text;
        private Option left;
        private Option right;

        public MountainScene(string text, System.Action action, List<string> responses) {
            this.text = text;
            List<string> usableResponsese = new List<string>(responses);
            string leftText = usableResponsese[Random.Range(0, usableResponsese.Count)];
            left = new Option(leftText, action);
            usableResponsese.Remove(leftText);
            right = new Option(usableResponsese[Random.Range(0, usableResponsese.Count)], action);
        }

        public MountainScene(string text, Option left, Option right) {
            this.text = text;
            this.left = left;
            this.right = right;
        }

        public string Text() {
            return text;
        }

        public Option GetLeft() {
            return left;
        }

        public Option GetRight() {
            return right;
        }
    }
}
