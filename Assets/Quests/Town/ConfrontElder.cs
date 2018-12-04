using ExtensionMethods;
using System;
using System.Text;

internal class ConfrontElder : DailyQuestCandidate {
    public bool IsAvailable() {
        return World.player.HasEnoughClues();
    }

    public bool IsPriority() {
        return true;
    }

    private Action Victory() {
        return () => World.SetState(World.State.VICTORY);
    }

    private Action Defeat() {
        return () => {
            foreach (World.Weapon w in World.player.TakeAllWeapons()) {
                World.GiveElderWeapon(w);
            }
            World.goblinAmbush.PlayerDied();
        };
    }

    public Option Left() {
        if (World.player.Xp() >= World.elderPower && World.player.HasMagicWeapon()) {
            return new Option("Time to celebrate at the Tavern.", Victory(), new Victory("Congratulations!", "Thanks for Playing!"));
        }
        return new Option("He sure is strong for an old timer", Defeat());
    }

    public string QuestText() {
        return "Confront the Elder!";
    }

    public Option Right() {
        if (World.player.Xp() >= World.elderPower && World.player.HasMagicWeapon()) {
            return new Option("Search his home for clues to a future adventure.", Victory(), new Victory("Congratulations!", "Thanks for Playing!"));
        }
        return new Option("That sure ended well...", Defeat());
    }

    public string Text() {
        StringBuilder sb = new StringBuilder();
        sb.Append("You kick down the door to the elder's study and demand that he explains himself!\n");
        if (World.player.Xp() < World.elderPower) {
            sb.Append("You're answered with a blast of mystic energy. It catches you unaware, and your vision goes black.");
        } else if (!World.player.HasMagicWeapon()) {
            sb.Append("A blast of energy shoots down the hall, and you deftly roll to avoid it. You swing your " + World.player.CurrentWeapon.GetDescription() + " at the Elder, but it explodes in your hands! The shraplnel pierces your face and tears your torso. Your vision goes black.");
        } else {
            sb.Append("A blast of energy shoots down the hall, and you deftly roll to avoid it. You swing your " + World.player.CurrentWeapon.GetDescription() + " at the Elder and are pleased by the shocked look on his face when it pierces his mystic protection and strikes him down.\n" +
                    "You stand victorious.");
        }
        return sb.ToString();
    }
}