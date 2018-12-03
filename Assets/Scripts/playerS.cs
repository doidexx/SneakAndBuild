using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerS : MonoBehaviour {
    Rigidbody pbody;
    NavMeshAgent myNav;
    private float speed;
    public GameObject pE;
    public Transform target;
    private bool w,a,s,d;
	// Use this for initialization
	void Start () {
        pbody = GetComponent<Rigidbody>();
        myNav = GetComponent<NavMeshAgent>();
        speed = 0.3f;
	}

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            w = true;
        }
        if (Input.GetKey(KeyCode.A)) {
            a = true;
        }
        if (Input.GetKey(KeyCode.S)) {
            s = true;
        }
        if (Input.GetKey(KeyCode.D)) {
            d =true;
        }
        if (Input.GetKeyUp(KeyCode.W)) {
            w = false;   
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            a = false;
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            s = false;
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            d = false;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        pE.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z + 2);
        //myNav.SetDestination(new Vector3(target.position.x, transform.position.y, target.position.z));
        if (w) {
            //myNav.Move(Vector3.forward);
            //myNav.SetDestination(transform.position + Vector3.forward * speed);
            transform.Translate(Vector3.forward * speed);    
        }
        if (a) {
            //myNav.Move(Vector3.left);
            //myNav.SetDestination(transform.position + (Vector3.left * speed));
            transform.Translate(Vector3.left * speed);
        }
        if (d) {
            //myNav.Move(Vector3.right);
            //myNav.SetDestination(transform.position + (Vector3.right * speed));
            transform.Translate(Vector3.right * speed);
        }
        if (s) {
            //myNav.Move(Vector3.back);
            //myNav.SetDestination(transform.position + (Vector3.back * speed));
            transform.Translate(Vector3.back * speed);
        }
        if (!w || !a || !s || !d) {
            transform.position = transform.position;
        }
    }
}
