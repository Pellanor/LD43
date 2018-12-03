using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class DailyQuestPicker: Quest {
    private List<DailyQuestCandidate> quests = new List<DailyQuestCandidate> {
        new SearchForCaptive(),
        new GoblinHunting(),
        new FightGoblinCaptain(),
        new PathToTheMountains(),
        new TalkWithElder(),
        new BodyFromGoblinCaptain(),
        new BodyFromGoblinAmbush(),
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
            lQuest = priority[Random.Range(0, available.Count)];
            priority.Remove(lQuest);
        } else {
            lQuest = available[Random.Range(0, available.Count)];
        }
        available.Remove(lQuest);
        left = new Option(lQuest.QuestText(), lQuest);

        DailyQuestCandidate rQuest;
        if (priority.Count > 0) {
            rQuest = priority[Random.Range(0, available.Count)];
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

    public string Text() {
        return "After driving off the goblins, the townsfolk all look to their losses then turn in for the night.\n" +
                "The next morning is bright: golden sunshine, blue sky, pleasant wind. A perfect day to";
    }
}