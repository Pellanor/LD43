using System;

internal class PathToTheMountains : DailyQuestCandidate {
    public bool IsAvailable() {
        return World.LocationOnMap(World.Location.GOBLIN_RUINS)
            && !World.LocationOnMap(World.Location.MAGIC_LANDS);
    }

    private Action Found() {
        return () => World.AddToMap(World.Location.MAGIC_LANDS);
    }

    public bool IsPriority() {
        return false;
    }

    public Option Left() {
        return new Option("Coninue to Explore", Found(), new ExploreMountains());
    }

    public string QuestText() {
        return "Exlpore the Distant Mountains";
    }

    public Option Right() {
        return new Option("Return to Town", Found());
    }

    public string Text() {
        return "You follow the path climbing into the mountains. The is a rough land, full of hard edges and sharp winds. Rounding a corner you're suprised to see a number of broken goblin bodies, which don't seem to have been here for long. While any dead goblin is a good goblin, your unsure what caused the death of these.";
    }
}