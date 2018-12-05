using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildControl : MonoBehaviour {

    //buildint Time
    private float BT;
    //Press E phisical object
    public GameObject pE, half, arcade;
	// Use this for initialization
	void Start () {
        BT = 0;
        pE.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(BT);
        if (BT > 4 && BT < 8) {
            half.SetActive(true);
        } else {
            half.SetActive(false);
        }
        if (BT >= 8) {
            arcade.SetActive(true);
            gameObject.SetActive(false);
        } else {
            arcade.SetActive(false);
        }
	}

    void OnTriggerStay(Collider other) {
            if (other.CompareTag("player")) { 
            pE.SetActive(true);
            if (Input.GetKey(KeyCode.E) && BT <= 8) {
                    BT += Time.fixedDeltaTime;
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
    }
}
