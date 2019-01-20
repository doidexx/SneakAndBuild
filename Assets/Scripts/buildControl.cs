using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buildControl : MonoBehaviour {

    //buildint Time
    private float BT, BX;
    public static int aAmt;
    //Press E phisical object
    public GameObject pE, half, arcade, bar, hell;
    public Text ac;
	// Use this for initialization
	void Start () {
        // build time
        BT = 0;
        // bar X value (width)
        BX = 8;
        // exclamation point
        pE.SetActive(false);
        // bar
        bar.SetActive(false);
        // particle system
        hell.SetActive(false);
        aAmt = 29;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(BT);
        // If build time is between 4 and 8 half arcade pops up
        if (BT > 4 && BT < 8) {
            half.SetActive(true);
        } else {
            half.SetActive(false);
        }
        if (BT >= 8) {
            // If build time is 8 or grater desactivate the building zone and activate the arcade
            arcade.SetActive(true);
            gameObject.SetActive(false);
            aAmt--;
        } else {
            arcade.SetActive(false);
        }
        ac.text = "Arcades: " + aAmt;
        if (aAmt == 0) {
            SceneManager.LoadScene(4);
        }
	}

    void OnTriggerStay(Collider other) {
            if (other.CompareTag("player")) { 
                pE.SetActive(true);
                if (Input.GetKey(KeyCode.E) && BT < 8) {
                    BT += Time.fixedDeltaTime;
                    hell.SetActive(true);
                    bar.SetActive(true);
                    if (BT > 0) {
                        bar.transform.localScale = new Vector3(BX - BT, bar.transform.localScale.y, bar.transform.localScale.z);
                    }
                } else {
                    hell.SetActive(false);
                }
            
            if (Input.GetKeyUp(KeyCode.E)) {
                bar.SetActive(false);
            }
            if (other.CompareTag("half")) {
                half = other.gameObject;
            }
            if (other.CompareTag("full")) {
                arcade = other.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        pE.SetActive(false);
        bar.SetActive(false);
        hell.SetActive(false);
        BX = 8;
    }
}
