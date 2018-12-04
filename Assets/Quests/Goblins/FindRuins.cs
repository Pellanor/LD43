using System;

internal class FindRuins : DailyQuestCandidate {
    public bool IsAvailable() {
        return (World.LocationOnMap(World.Location.GOBLIN_CAMP) || World.GoblinsSlain() >= 5)
            && !World.LocationOnMap(World.Location.GOBLIN_RUINS);
    }

    private Action FoundRuins() {
        return () => World.AddToMap(World.Location.GOBLIN_RUINS);
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return new Option("Continue down the path", FoundRuins(), new PathToTheMountains());
    }

    public string QuestText() {
        return "Explore Goblin Ruins";
    }

    public Option Right() {
        return new Option("Return to Hunting Goblins", FoundRuins(), new GoblinHunting());
    }

    public string Text() {
        return "Your exploration takes you closer to the mountains you come across a ruined stronghold. Investigating further it appears to be of goblin make?! When were goblins ever organized enough to build strongholds, and what caused the ruin of this one. You see a path continuing towards the mountains.";
    }
}