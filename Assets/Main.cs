﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Text questText;
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
        o.DoAction(currentPlayer);
        if (o.Next() != null) {
            SetQuest(o.Next());
        } else {
            SetQuest(new DailyQuestPicker());
        }
    }

    void SetQuest(Quest newQuest) {
        currentQuest = newQuest;
        questText.text = currentQuest.Text();
        swipeLeft.GetComponentInChildren<Text>().text = currentQuest.Left().Text();
        swipeRight.GetComponentInChildren<Text>().text = currentQuest.Right().Text();
    }
}
