using ExtensionMethods;
using System;
using System.Text;

internal class TalkWithElder : DailyQuestCandidate {

    private World.Weapon weapon;

    public TalkWithElder() {
        if (World.ElderHasWeaponPlayerCanUse()) {
            weapon = World.ChooseWeaponFromElder();
        }
    }

    public bool IsAvailable() {
        return World.deathCount > 0
            && !World.player.Knows(Player.Clue.AMULET);
    }

    public bool IsPriority() {
        return true;
    }

    private Action Stuff() {
        return () => {
            World.player.Learn(Player.Clue.AMULET);
            if (World.ElderHasWeaponPlayerCanUse()) {
                World.player.GiveWeapon(weapon);
                World.TakeWeaponFromElder(weapon);
            }
        };
    }

    public Option Left() {
        if (World.player.Has(Player.Traits.MYSTIC_KNOW)) {
            return new Option("Study your amulet", Stuff(), new StudyAmulet());
        }
        return new Option("I'll keep an eye out for it", Stuff());
    }

    public string QuestText() {
        return "Village Elder Wants to Talk";
    }

    public Option Right() {
        if (World.ElderHasWeaponPlayerCanUse()) {
            return new Option("You thank hime for the mighty weapon", Stuff());
        }
        return new Option("That's a bit morbid", Stuff());
    }

    public string Text() {
        StringBuilder sb = new StringBuilder();
        sb.Append("The elder greets you as you leave your room.");
        if (World.ElderHasWeaponPlayerCanUse()) {
            sb.Append("He hands you a glowing " + weapon.GetDescription() + ". It seems the last hero found it on his journey. ");
        }
        sb.Append("He ");
        if (World.ElderHasWeaponPlayerCanUse()) {
            sb.Append("also ");
        }
        sb.Append("informs you that the previous hero wore a special amulet not unlike the one you now where. If you're able to retrive it will grant you a portion of their power!");

        return sb.ToString();
    }
}