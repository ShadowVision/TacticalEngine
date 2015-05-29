using UnityEngine;
using System.Collections;

public class PlayerInput : PlayerObject {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = new Vector3(Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));

		player.motor.move (dir);

		if (Input.GetButtonDown ("Jump")) {
			player.motor.startJump ();
		} else if (Input.GetButton ("Jump")) {
			player.motor.holdJump();
		}

		if (Input.GetButtonDown ("zLock")) {
			player.setZLock(true);
		} else if (Input.GetButtonUp ("zLock")) {
			player.setZLock(false);
		}

	}
}
