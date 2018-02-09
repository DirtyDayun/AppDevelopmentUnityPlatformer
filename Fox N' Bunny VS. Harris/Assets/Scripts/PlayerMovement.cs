using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float jumpSpeed;
	public float gravity;
	public float speed;
	public string keyUp;
	public string keyDown;
	public string keyLeft;
	public string keyRight;

	private Rigidbody2D rb;
	private Vector2 velocity;
	private bool isGrounded;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Gravity ();
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

		if (Input.GetKey (keyUp) && isGrounded) {
			Jump ();
		}
	}

	void Gravity() {
		if (velocity.y > -15) {
			velocity.y -= gravity;
		}

		RaycastHit2D ray1 = Physics2D.Raycast(transform.position - new Vector3(0.5f, 0.25f), Vector2.down, 0.5f);
		RaycastHit2D ray2 = Physics2D.Raycast(transform.position - new Vector3(-0.5f, 0.25f), Vector2.down, 0.5f);
		if (ray1.transform || ray2.transform) {
			isGrounded = true;
		} else if (!ray1.transform && !ray2.transform) {
			isGrounded = false;
		}

		print (isGrounded);
	}

	void Jump() {
		velocity.y = jumpSpeed;
	}
}
