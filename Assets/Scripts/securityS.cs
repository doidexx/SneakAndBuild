using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class securityS : MonoBehaviour {

	NavMeshAgent myNav;
	private Vector3[] patrolP;
	private Vector3 targetLP;
	private Material [] myMat;
	private MeshRenderer myMR;
	public GameObject eP, dEP, target;
	private bool looking, looking1, looking2;
    private int j;
	private float stopLT, stopLT1;
	// Use this for initialization
	void Start () {
		stopLT = 0;
		stopLT1 = 0;
		patrolP = new Vector3[6];
		myNav = GetComponent<NavMeshAgent>();
		eP.SetActive(false);
		myMat = GetComponent<Renderer>().materials;
		myMR = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//patroling behavior positions
        patrolP[0] = new Vector3(-27, transform.position.y, -27);
        patrolP[1] = new Vector3(-27, transform.position.y, 27);
        patrolP[2] = new Vector3(27, transform.position.y, 27);
        patrolP[3] = new Vector3(20, transform.position.y, -27);
        patrolP[4] = new Vector3(0, transform.position.y, -18);
        patrolP[5] = new Vector3(0, transform.position.y, 9);
		// exclamation point if the player is heard
		eP.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z + 2);
        dEP.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z + 2);
		//moving from one point to the other.
		for (int i =0; i < 6; i++) {
			if (transform.position == patrolP[i]) {
				j = i + 1;
				if (j == 6) {
					j = 0;
				}
				myNav.destination = patrolP[j];
			}
		}
		//following the player
		if (looking) {
            myNav.destination = target.transform.position;
			looking1 = false;
			dEP.SetActive(true);
            myMR.material = myMat[1];
		}
        //if the player is not withing the range, go back to patrol.
        if (!looking && !looking1) {
            myNav.destination = patrolP[j];
			eP.SetActive(false);
			dEP.SetActive(false);
			myMR.material = myMat[0];
        }
		//looking for the sound.
		if (looking1) {
            myNav.destination = targetLP;
            eP.SetActive(true);
            myMR.material = myMat[1];
		}
		//back to patrol if dont find the player.
		if (transform.position == targetLP) {
			looking2 = true;
		}
		if (looking2) {
            stopLT1 += Time.fixedDeltaTime;
		}
		//counter to stop looking at that location.
		if (stopLT1 >= 5) {
			looking1 = false;
            looking2 = false;
			stopLT1 = 0;
		}
		//if the player is close enought, follow it.
		if (Vector3.Distance(transform.position, target.transform.position) < 10f) {
			looking = true;
		}
		//counter to stop following after the player is off security sight
		if (Vector3.Distance(transform.position, target.transform.position) > 10f) {
			stopLT += Time.fixedDeltaTime;
			if (stopLT > 5) {
				looking = false;
				stopLT = 0;
			}
		}
	}

	void OnTriggerStay(Collider other) {
		//if the player is "talking" withing the range, follow it.
		if (Input.GetKey(KeyCode.E)) {
			if (other.gameObject == target) {
				targetLP = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
				looking1 = true;
			}
        }
	}

	void OnCollisionEnter(Collision other) {
		//catch the player.
		if (other.gameObject == target) {
			Debug.Log("Catched");
		}
	}
}

