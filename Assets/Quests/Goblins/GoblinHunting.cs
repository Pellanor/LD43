using ExtensionMethods;
using System.Collections.Generic;
using UnityEngine;

internal class GoblinHunting : DailyQuestCandidate {
    public static readonly List<string> VictoryResponses = new List<string> {
        "yay",
        "Whoop Whoop",
        "Are there any more goblins?",
        "I'mma whoop some goblin ass.",
        "Continue the Onslaught... Destroy. Them. All."
    };

    public static readonly List<string> DeathResponses = new List<string> {
        "Boo",
        "Omnia mors æquat",
        "Death makes sad stories of us all"
    };

    private List<GoblinScene> scenes = new List<GoblinScene> {
        new GoblinScene(World.player.Has(Player.Traits.OBSERVANT)
            ? "You notice a few goblins waiting in ambush around the bend. You wonder how they know somebody would be coming this way. Either way, they haven't noticed you yet, so you sneak around and take them out from behind."
            : "You feel a sharp pain in your back. You turn around to see a goblin with a bow. The strength leaves your legs and you fall to your knees as three others take aim and fire. You are slain.",
            World.player.Has(Player.Traits.OBSERVANT) ? SlayGoblins() : Death(),
            World.player.Has(Player.Traits.OBSERVANT) ? VictoryResponses : DeathResponses),
         new GoblinScene("PLACEHOLD_GOBLIN_ENCOUNTER_1", SlayGoblins(), VictoryResponses),
         new GoblinScene("PLACEHOLD_GOBLIN_ENCOUNTER_2", SlayGoblins(), VictoryResponses),
         new GoblinScene("PLACEHOLD_GOBLIN_ENCOUNTER_3", SlayGoblins(), VictoryResponses),
         new GoblinScene("PLACEHOLD_GOBLIN_ENCOUNTER_4", SlayGoblins(), VictoryResponses)
    };

    private static System.Action SlayGoblins() {
        return () => {
            World.SlayGoblins();
            World.player.XpUp();
        };
    }

    private static System.Action Death() {
        return () => World.goblinAmbush.PlayerDied();
    }

    private GoblinScene currentScene;

    public GoblinHunting() {
        if (World.GoblinsSlain() >= 3 && !World.LocationOnMap(World.Location.GOBLIN_CAPTAIN)) {
            currentScene = new GoblinScene("You come accross another goblin encampment, this one a bit larger than the first. As you're looking around you spot a particularily imposing goblin with a glowing " + World.goblinCaptainWeapon.GetDescription() + "!.",
                    new Option("Kill the goblin captain and take his stuff!", () => World.AddToMap(World.Location.GOBLIN_CAPTAIN), new FightGoblinCaptain()),
                    new Option("Fall back to town, and return when you're better prepared.", () => World.AddToMap(World.Location.GOBLIN_CAPTAIN)));
        } else {
            if (World.player.Knows(Player.Clue.AMULET) && !World.player.IsState(Player.State.HAS_AMULET)) {
                foreach (Player corpse in World.goblinAmbush.Corpses()) {
                    scenes.Add(new GoblinScene("As you search through the woods you almost trip over your predecessor's corpse. It lays where it fell, pincussioned by arrows. You quickly retrive the amulet and turn home.",
                        new Option("Taking your time alert for any ambushes", () => World.goblinAmbush.RecoverCorpse(corpse)),
                        new Option("As fast as possble", () => World.goblinAmbush.RecoverCorpse(corpse))));
                }
            }
            currentScene = scenes[Random.Range(0, scenes.Count)];
        }
    }

    public bool IsAvailable() {
        return true;
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
        return "Go Goblin Hunting";
    }

    public string Text() {
        return currentScene.Text();
    }

    private class GoblinScene {
        private string text;
        private Option left;
        private Option right;

        public GoblinScene(string text, System.Action action, List<string> responses) {
            this.text = text;
            List<string> usableResponsese = new List<string>(responses);
            string leftText = usableResponsese[Random.Range(0, usableResponsese.Count)];
            left = new Option(leftText, action);
            usableResponsese.Remove(leftText);
            right = new Option(usableResponsese[Random.Range(0, usableResponsese.Count)], action);
        }

        public GoblinScene(string text, Option left, Option right) {
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