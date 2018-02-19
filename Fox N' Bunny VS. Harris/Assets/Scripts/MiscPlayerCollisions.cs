using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscPlayerCollisions : MonoBehaviour {

    PlayerMovement player;

	// Use this for initialization
	void Start () {
        player = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Cloud")
        {
            if (player.velocity.y <= 0)
            {
                player.slowFall = true;
                player.isGrounded = true;
            }
        }
    }

    void OnTriggerLeave2D(Collider2D col)
    {
        if (col.gameObject.tag == "Cloud")
        {
            player.slowFall = false;
        }
    }
}
