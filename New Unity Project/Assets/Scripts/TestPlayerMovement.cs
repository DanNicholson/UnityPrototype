using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerMovement : MonoBehaviour {

	public float playerSpeed = 10;
	public float jumpHeight = 15;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.D)){
			GetComponent<Rigidbody2D>().transform.position += Vector3.right * playerSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)){
			GetComponent<Rigidbody2D>().transform.position += Vector3.left * playerSpeed * Time.deltaTime;
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			Jump();
		}

	}

	void Jump(){
		//GetComponent<Rigidbody2D>().transform.position += Vector3.up * jumpHeight * Time.deltaTime;
		GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
