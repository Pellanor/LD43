using System.Collections.Generic;
using UnityEngine;

internal class DrinkInTavern : DailyQuestCandidate {
    private static List<TavernScene> scenes = new List<TavernScene> {
        new TavernScene("While enjoying a drink you hear some of the men boasting, despite the constant goblin raids the town has never fallen. They're always driven back before they even reach the Elder's home.",
            () => World.player.Learn("ELDER_HOME")),
        new TavernScene("Some of the village womenfolk offer to buy you a drink. They praise the good fortune that a heroe shows up in the knick of time whenever the goblins get too upity.",
            () => World.player.Learn("KNICK_OF_TIME"))
    };

    private List<string> responses = new List<string> {
        "You order another round then call it a night.",
        "...",
        "....."
    };

    private TavernScene currentScene;

    public DrinkInTavern() {
        currentScene = scenes[Random.Range(0, scenes.Count)];
    }

    public bool IsAvailable() {
        return World.IsBuilt("Tavern");
    }

    public bool IsPriority() {
        return false;
    }

   private string GetResponse() {
        string response = responses[Random.Range(0, responses.Count)];
        responses.Remove(response);
        return response;
    }

    public Option Left() {
        return new Option(GetResponse(), currentScene.Action());
    }

    public Option Right() {
        return new Option(GetResponse(), currentScene.Action());
    }

    public string QuestText() {
        return "Spend the day in the Tavern";
    }
 
    public string Text() {
        return currentScene.Text();
    }

    private class TavernScene {
        private string text;
        private System.Action action;
        public TavernScene(string text, System.Action action) {
            this.text = text;
            this.action = action;
        }

        public string Text() {
            return text;
        }

        public System.Action Action() {
            return action;
        }
    }
}