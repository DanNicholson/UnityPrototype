using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashBehaviour : MonoBehaviour {

	public Rigidbody2D rb;
	public bool dashReady;
	public bool dashUsed;
	public float dashCounter = 5.0f;
	public float dashForce;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if (Input.GetKeyDown (KeyCode.LeftShift) && dashReady == true) {
			rb.AddForce (Vector2.right * dashForce);
		}
	}

	void Update () {

		Debug.Log ("dashCounter = " + dashCounter);
		if (dashUsed = true &&  dashCounter < 5.0f) {
			dashCounter += Time.deltaTime;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift) && dashReady == true) {
			dashReady = false;
			dashCounter = 0;
			dashUsed = true;

		}

		if (dashCounter == 5.0f || dashCounter > 5.0f) {
			dashCounter = 5.0f;
			dashUsed = false;
			dashReady = true;
		}
	}
}
