using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	private Transform player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player_fox").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
