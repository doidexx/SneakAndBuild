using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerS : MonoBehaviour {
    Rigidbody pbody;
    private float speed;
	// Use this for initialization
	void Start () {
        pbody = GetComponent<Rigidbody>();
        speed = 15f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.W)) {
            pbody.MovePosition(transform.position + Vector3.forward * Time.fixedDeltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A)) {
            pbody.MovePosition(transform.position + Vector3.left * Time.fixedDeltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D)) {
            pbody.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S)) {
            pbody.MovePosition(transform.position + Vector3.back * Time.fixedDeltaTime * speed);
        }
    }
}
