using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildControl : MonoBehaviour {

    //buildint Time
    private float BT;
    //Press E phisical object
    public GameObject pE;
	// Use this for initialization
	void Start () {
        BT = 0;
        pE.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(BT);
	}

    void OnTriggerStay(Collider other) {
            if (other.CompareTag("player")) { 
            pE.SetActive(true);
            if (Input.GetKey(KeyCode.E) && BT <= 8) {
                    BT += Time.fixedDeltaTime;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        pE.SetActive(false);
    }
}
