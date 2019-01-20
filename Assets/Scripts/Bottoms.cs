using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bottoms : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// Created different method for each bottom to use.
	public void St () {
		 SceneManager.LoadScene(1);
	}
    public void tut() {
        SceneManager.LoadScene(2);
    }
    public void done () {
        Application.Quit();
    }

	public void next () {
		GetComponent<tut>().inst++;
	}

	public void previous () {
		if (GetComponent<tut>().inst > 0) {
        	GetComponent<tut>().inst--;
		}
	}

	public void backBack() {
		SceneManager.LoadScene(0);
	}
}
