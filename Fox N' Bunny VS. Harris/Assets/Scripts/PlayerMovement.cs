using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	public string keyUp;
	public string keyDown;
	public string keyLeft;
	public string keyRight;

	private Rigidbody2D rb;
	private Vector2 velocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement() {
		rb.velocity = velocity;

		if (Input.GetKey (keyLeft)) {
			velocity.x = -speed;
		} else if (Input.GetKey (keyRight)) {
			velocity.x = speed;
		} else {
			velocity.x = 0;
		}
	}
}
