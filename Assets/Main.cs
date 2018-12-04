using ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Text questText;
    public Text level;
    public Text weapon;
    public Button swipeRight;
    public Button swipeLeft;
    public Quest currentQuest;
    public Player currentPlayer;

	void Start () {
        currentPlayer = new Player();
        SetQuest(new Intro());
    }
	
	void Update () {
	}

    public void SwipeRight() {
        DoOption(currentQuest.Right());
    }

    public void SwipeLeft() {
        DoOption(currentQuest.Left());
    }

    private void DoOption(Option o) {
        o.DoAction();

        if (o.Next() != null) {
            SetQuest(o.Next());
        } else if (World.IsState(World.State.DEAD)) {
            World.player = new Player();
            World.ClearState(World.State.DEAD);
            SetQuest(new Intro());
        } else {
            SetQuest(new DailyQuestPicker());
        }
        level.text = "Level " + World.player.Xp();
        if (World.player.WeaponSet) {
            weapon.text = World.player.CurrentWeapon.GetDescription();
        } else {
            weapon.text = "Unarmed";
        }
    }

    void SetQuest(Quest newQuest) {
        currentQuest = newQuest;
        if (questText != null) {
            questText.text = currentQuest.Text();
            swipeLeft.GetComponentInChildren<Text>().text = currentQuest.Left().Text();
            swipeRight.GetComponentInChildren<Text>().text = currentQuest.Right().Text();
        }
    }
}
