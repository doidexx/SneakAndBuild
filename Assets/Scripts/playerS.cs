using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerS : MonoBehaviour {
    Rigidbody pbody;
    NavMeshAgent myNav;
    private AudioSource myA;
    private Animator MyAni;
    private float speed, lives;
    public Text livesC;
    public GameObject pE;
    public Transform target;

    public Quaternion rot;
    private bool w,a,s,d;
	// Use this for initialization
	void Start () {
        // Geting some components from the player
        pbody = GetComponent<Rigidbody>();
        myNav = GetComponent<NavMeshAgent>();
        myA = GetComponent<AudioSource>();
        MyAni = GetComponent<Animator>();
        // Setting up a specific ammount of lives and speed
        speed = 0.3f;
        lives = 3;
	}

    void Update() {
        // Keyboard input
        if (Input.GetKey(KeyCode.W)) {
            w = true;
            // Animatioin control
            MyAni.SetInteger("state", 1);
        }
        if (Input.GetKey(KeyCode.A)) {
            a = true;
            MyAni.SetInteger("state", 1);
        }
        if (Input.GetKey(KeyCode.S)) {
            s = true;
            MyAni.SetInteger("state", 1);
        }
        if (Input.GetKey(KeyCode.D)) {
            d =true;
            MyAni.SetInteger("state", 1);
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
        // Go back to idle if no keys are being pressed
        if (!d && !w && !a && !s) {
            MyAni.SetInteger("state", 0);
        }
        // Start "Summoning" the arcade from hell when E is being pressed
        // Audio Control
        if (Input.GetKey(KeyCode.E)) {
            // Just play if the sound is not playing already to avoid overlapping sound
            if (!myA.isPlaying) {
                myA.Play();
            }
        }
        // Stop audio when E is released
        if (Input.GetKeyUp(KeyCode.E)) {
            myA.Stop();
        }
        //Pause
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale == 1) {
                Time.timeScale = 0;
            } else {
                Time.timeScale = 1;
            }
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // Make the letter E move with the player
        pE.transform.position = new Vector3(transform.position.x, transform.position.y + 4, transform.position.z + 2);
        // myNav.SetDestination(new Vector3(target.position.x, transform.position.y, target.position.z));
        // Movement 
        if (w) {
            myNav.Move(Vector3.forward * 0.3f);
            rot = Quaternion.AngleAxis(0, Vector3.up);
            //myNav.SetDestination(transform.position + Vector3.forward * speed);
            //transform.Translate(Vector3.forward * speed);
        }
        if (a) {
            myNav.Move(Vector3.left * 0.3f);
            rot = Quaternion.AngleAxis(-90f, Vector3.up);
            //myNav.SetDestination(transform.position + (Vector3.left * speed));
            //transform.Translate(Vector3.left * speed);
        }
        if (d) {
            myNav.Move(Vector3.right * 0.3f);
            rot = Quaternion.AngleAxis(90f, Vector3.up);
            //myNav.SetDestination(transform.position + (Vector3.right * speed));
            // transform.Translate(Vector3.right * speed);
        }
        if (s) {
            myNav.Move(Vector3.back * 0.3f);
            rot = Quaternion.AngleAxis(180f, Vector3.up);
            //myNav.SetDestination(transform.position + (Vector3.back * speed));
            // transform.Translate(Vector3.back * speed);
        }
        // if (!w || !a || !s || !d) {
        //     transform.position = transform.position;
        // }
        // if the player have no more lives load a new scene (losing scene)
        if (lives == 0) {
            SceneManager.LoadScene(3);
        }
        // printing lives into the screen
        livesC.text = "Lives: " + lives;
        //combined direction angles
        if (a && w) {
            rot = Quaternion.AngleAxis(-45f, Vector3.up);
        }
        if (d && w) {
            rot = Quaternion.AngleAxis(45f, Vector3.up);
        }
        if (a && s) {
            rot = Quaternion.AngleAxis(-135f, Vector3.up);
        }
        if (d && s) {
            rot = Quaternion.AngleAxis(135f, Vector3.up);
        }
        //control the rotation of the main character.
        transform.rotation = Quaternion.Lerp( transform.rotation, rot, 0.125f);
    }

    void OnCollisionEnter(Collision other) {
        // taking out lives if the player touches the security guards
        if (other.gameObject.CompareTag ("security")) {
            lives--;
        }
    }
}
