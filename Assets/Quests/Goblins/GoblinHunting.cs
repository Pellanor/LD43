using System.Collections.Generic;
using UnityEngine;

internal class GoblinHunting : DailyQuestCandidate {
    private static List<string> victoryResponses = new List<string> {
        "yay",
        "Whoop Whoop",
        "Are there any more goblins?",
        "I'mma whoop some goblin ass.",
        "Continue the Onslaught... Destroy. Them. All."
    };

    private static List<string> deathResponses = new List<string> {
        "Boo",
        "Omnia mors æquat",
        "Death makes sad stories of us all"
    };

    private List<GoblinScene> scenes = new List<GoblinScene> {
        new GoblinScene(World.player.Has(Player.Traits.Observant)
            ? "You notice a few goblins waiting in ambush around the bend. You wonder how they know somebody would be coming this way. Either way, they haven't noticed you yet, so you sneak around and take them out from behind."
            : "You feel a sharp pain in your back. You turn around to see a goblin with a bow. The strength leaves your legs and you fall to your knees as three others take aim and fire. You are slain.",
            World.player.Has(Player.Traits.Observant) ? SlayGoblins() : Death(),
            World.player.Has(Player.Traits.Observant) ? victoryResponses : deathResponses)
    };

    private static System.Action SlayGoblins() {
        return () => {
            World.SlayGoblins();
            World.player.XpUp();
        };
    }

    private static System.Action Death() {
        return () => {
            //todo: how to die
        };
    }
    private GoblinScene currentScene;

    public GoblinHunting() {
        currentScene = scenes[Random.Range(0, scenes.Count)];
    }

    public bool IsAvailable() {
        return true;
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return new Option(currentScene.GetResponse(), currentScene.Action());
    }

    public Option Right() {
        return new Option(currentScene.GetResponse(), currentScene.Action());
    }

    public string QuestText() {
        return "Go Goblin Hunting";
    }

    public string Text() {
        return currentScene.Text();
    }

    private class GoblinScene {
        private string text;
        private System.Action action;
        private List<string> responses;

        public GoblinScene(string text, System.Action action, List<string> responses) {
            this.text = text;
            this.action = action;
            this.responses = new List<string>(responses);
        }

        public string Text() {
            return text;
        }

        public System.Action Action() {
            return action;
        }

        public string GetResponse() {
            string response = responses[Random.Range(0, responses.Count)];
            responses.Remove(response);
            return response;
        }
    }
}