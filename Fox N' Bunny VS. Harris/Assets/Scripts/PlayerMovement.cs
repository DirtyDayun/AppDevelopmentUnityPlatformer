using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Vector2 velocity; // This Vector2 is used to change the Rigidbody2D's velocity easily
    public float jumpSpeed;
	public float gravity;
	public float speed;
	public string keyUp;
	public string keyDown;
	public string keyLeft;
	public string keyRight;
    public bool slowFall;
    public bool isGrounded;

    private Rigidbody2D rb;
    private Animator animation;
    private bool animPlaying;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
        animation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        // The Movment and Gravity methods are called everytime the Update method is called
		Movement ();
		Gravity ();
	}

    // The Movement method deals with player input and controls the Rigidbody2D component
	void Movement() {
		rb.velocity = velocity;

		if (Input.GetKey (keyLeft)) {
			velocity.x = -speed; // -speed (or speed * -1) is set to the x velocity to make the player go left
            transform.localScale = new Vector3(-4, 4, 1);

            if (isGrounded && !animPlaying && velocity.y <= 0)
            {
                animation.Play("Walk");
            }
		} else if (Input.GetKey (keyRight)) {
			velocity.x = speed; // speed is set to the x velocity to make the player go right
            transform.localScale = new Vector3(4, 4, 1);

            if (isGrounded && !animPlaying && velocity.y <= 0)
            {
                animation.Play("Walk");
            }
        } else {
			velocity.x = 0; // If the left/right keys aren't pressed, the player stops moving horizontally

            if (isGrounded && velocity.y <= 0)
            {
                animation.Play("Stand");
                animPlaying = false;
            }
        }

		if (Input.GetKey (keyUp) && isGrounded) {
			Jump (); // The Jump method is called which controls jumping, wow!
            animation.Play("Jump");
            animPlaying = false;
        }
	}

    // The Gravity method deals with... well... gravity
	void Gravity() {
		if (velocity.y > -15 && !slowFall) {
			velocity.y -= gravity;
		}

        if (slowFall)
        {
            velocity.y = -0.35f;
        }

        // These raycasts are cast downwards on both sides of the player to detect if the player is standing on ground
		RaycastHit2D ray1 = Physics2D.Raycast(transform.position - new Vector3(0.5f, 0.25f), Vector2.down, 0.5f);
		RaycastHit2D ray2 = Physics2D.Raycast(transform.position - new Vector3(-0.5f, 0.25f), Vector2.down, 0.5f);
		if (ray1.transform || ray2.transform) {
			isGrounded = true; // If either of the rays are touching ground, the player is grounded
		} else if (!ray1.transform && !ray2.transform) {
			isGrounded = false; // If both of the rays aren't touching ground, the player is not grounded
		}

		// print (isGrounded);
	}

    // The Jump method
	void Jump() {
		velocity.y = jumpSpeed; // The y velocity is set to jumpSpeed to make the player... jump!
                                // gravity constantly removes from the y velocity so the player
                                // eventually falls back down
        slowFall = false;
	}

    public void Animation()
    {
        animPlaying = true;
    }
}
