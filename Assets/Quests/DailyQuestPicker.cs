using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class DailyQuestPicker: Quest {
    private List<DailyQuestCandidate> quests = new List<DailyQuestCandidate> {
        new SearchForCaptive(),
        new GoblinHunting(),
        new FightGoblinCaptain(),
        new FindRuins(),
        new PathToTheMountains(),
        new ExploreMountains(),
        new TalkWithElder(),
        new BodyFromGoblinCaptain(),
        new ReturnAmulet(),
        new ShowWeapon(),
        new DrinkInTavern(),
        new RebuildTavern(),
        new RebuildHome(),
        new ConfrontElder(),
        new BreakAndEnter(),
        new EscortSupplies()
    };

    Option left;
    Option right;

    public DailyQuestPicker() {
        List<DailyQuestCandidate> available = quests.Where(q => q.IsAvailable()).ToList();
        List<DailyQuestCandidate> priority = available.Where(q => q.IsPriority()).ToList();
        DailyQuestCandidate lQuest;
        if (priority.Count > 0) {
            lQuest = priority[Random.Range(0, priority.Count)];
            priority.Remove(lQuest);
        } else {
            lQuest = available[Random.Range(0, available.Count)];
        }
        available.Remove(lQuest);
        left = new Option(lQuest.QuestText(), lQuest);

        DailyQuestCandidate rQuest;
        if (priority.Count > 0) {
            rQuest = priority[Random.Range(0, priority.Count)];
            priority.Remove(rQuest);
        } else {
            rQuest = available[Random.Range(0, available.Count)];
        }
        available.Remove(rQuest);
        right = new Option(rQuest.QuestText(), rQuest);
    }

    public Option Left() {
        return left;
    }

    public Option Right() {
        return right;
    }

    private List<string> texts = new List<string> {
        "Before you can even look look outside your window, you can hear birds singing, and the daily business of the town puttering forwards. Feeling the Suns warmth  through you window encourages you. Today will be a good day.",
        "The sound of thunder rocks you from your dreams. Normally the squire would have come to fetch you as a part of his morning routine; the storm must have delayed him. It can't delay you, however. No matter how much you might ache for the comfort of a few hours of rest.",
        "A Normal day, by all accounts. Maybe it's your imagination but it feels quiet. A little too quiet. You shrug it off and clear your head. You have to stay focused.",
        "You stretch and let out a well earned yawn to greet the morning!After getting dressed your next accomplishment Splashing water on your face before bolting out the door! Time to meet the challenges ahead; you can't wait to see the townspeoples smiles.",
        "You open the door to lodge, ready to meet the day, be it a blizzard or fire fog. Nothing is going to slow you down! The people depend on you afterall.",
        "The Elders always told you that the heroes journey is an easy one.  \"A heroes' path reveals itself before him,\" he told you, \"all you have to do is walk it\"  he said.  It's morning. You're the hero. You have absolutely no idea what to do next.",
        "You yawn and try to shake off the morning haze that comes a fitful sleep. It would have been ideal to have gotten a good nights sleep to start the morning right... except every cricket and thistle in the night has started to sound like another goblin raid...",
        "You spring into action! There's a thin layer of mist this morning, but you welcome it. This is your destiny! Give it time, because just as the sun will spread the mist, you will protect this town and drive back whatever threatens its people from those god forsaken lands to the east. It's what you were born for, afterall.",
        "It's windy this morning, but you might as well be sails for all it can do to dampen your resolve. A small chat with a servant over breakfast, and brief pleasantries with the lodge owner are all you allow yourself before setting foot outside your housing. It's time to make a decision. What need to be done first, and why?"
    };

    public string Text() {
        if (World.player.FirstDayInVillage) {
            World.player.FirstDayInVillage = false;
            return "After driving off the goblins, the townsfolk all look to their losses then turn in for the night.\n" +
                    "The next morning is bright: golden sunshine, blue sky, pleasant wind. A perfect day to";
        }
        return texts[Random.Range(0, texts.Count)];
    }
}