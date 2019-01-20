using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tut : MonoBehaviour {
	public int inst;
	public Text instructions;
	public GameObject [] images;
	public GameObject bot, bot1;
	// Use this for initialization
	void Start () {
		inst = 0;
	}
	
	// Update is called once per frame
	void Update () {
        // Each states activates a different image and/or bottom
		if (inst == 0) {
			bot1.SetActive (false);
			images[0].SetActive(true);
            images[1].SetActive(false);
			instructions.text = "Use W A S D to move around the map to the Green Area. Once on the green area press and Hold E to summon the arcade machine.";
		}
        if (inst == 1) {
            bot1.SetActive(true);
            images[1].SetActive(true);
            images[0].SetActive(false);
			images[2].SetActive(false);
            instructions.text = "When summoning the arcade a bar will appear at the top, this will indicade how long it will take to completely summon the arcade";
        }
        if (inst == 2) {
            images[2].SetActive(true);
            images[1].SetActive(false);
            images[3].SetActive(false);
            instructions.text = "Half way through the summoning half arcade will appear.";
        }
        if (inst == 3) {
            images[3].SetActive(true);
            images[2].SetActive(false);
            images[4].SetActive(false);
            instructions.text = "Once the arcade is fully summon the green areas will desapear.";
        }
        if (inst == 4) {
            images[4].SetActive(true);
            images[3].SetActive(false);
            images[5].SetActive(false);
            instructions.text = "There will be security guards trying to prevent you from summoning the arcades. If they hear you around the building they will go to your location and try to kick you out of the place.";
        }
        if (inst == 5) {
            bot.SetActive(true);
            images[5].SetActive(true);
            images[4].SetActive(false);
            instructions.text = "If you get too close to the guards they will see you and follow you around until you get off their sigh.";
        }
		if (inst == 6) {
            bot.SetActive(false);
			images[5].SetActive(false);
            instructions.text = "That was everything I had to teach you... GOOD LUCK";
		}
	}
}
