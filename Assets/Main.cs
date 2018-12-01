using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Text questText;

	void Start () {
	}
	
	void Update () {
		
	}

    public void SwipeRight() {
        questText.text = "You swiped right!";
    }

    public void SwipeLeft()
    {
        questText.text = "You swiped left!";
    }
}
