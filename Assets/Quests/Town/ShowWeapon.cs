using ExtensionMethods;
using System;

internal class ShowWeapon : DailyQuestCandidate {

    World.Weapon weapon;

    public ShowWeapon() {
        if (World.player.HasWeaponCannotUse()) {
            weapon = World.player.ChooseWeaponToTake();
        }
    }

    public bool IsAvailable() {
        return World.player.HasWeaponCannotUse();
    }

    public bool IsPriority() {
        return true;
    }

    private Action GiveWeapon() {
        return () => {
            World.player.TakeWeapon(weapon);
            World.GiveElderWeapon(weapon);
            World.player.Learn(Player.Clue.ELDER_WEAPON);
        };
    }

    public Option Left() {
        return new Option("Maybe that will keep him out of my hair", GiveWeapon());
    }

    public string QuestText() {
        return "Show the Magic Weapon to the Elder";
    }

    public Option Right() {
        return new Option("I better ge tthat back!", GiveWeapon());
    }

    public string Text() {
        return "The elder approaches you, curious to see the weapon that you found. He studies artifacts such as this in his free time. Since you're not profcecient with the " + weapon.GetDescription() + " anyway, you let him hang on to it for the time being.";
    }
}