using UnityEngine;
using System.Collections;

public class PlayerCollision : PlayerObject {
	
	public Vector3 groundCheckDirection = new Vector3(0,-1f,0);
	public float groundCheckDistance = 1f;

	private RaycastHit groundHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Check to see if we are on ground
		if (Physics.Raycast (new Ray (player.worldPosition, groundCheckDirection), out groundHit, groundCheckDistance)) {
			player.enterState (PlayerController.PlayerState.GROUND);
		} else if (player.currentState == PlayerController.PlayerState.GROUND) {
			player.enterState(PlayerController.PlayerState.AIR);
		}
	}
	
	public void OnCollisionEnter(Collision collision) {
		// hit ground
		foreach(ContactPoint contact in collision.contacts){
			if (contact.normal.y < 0 && Mathf.Abs(contact.normal.y) > Mathf.Abs(contact.normal.x)) {
				player.enterState (PlayerController.PlayerState.GROUND);
			}
		}
	}
	public void OnCollisionExit(Collision collision) {

	}
	public void OnCollisionStay(Collision collision) {

	}
}
