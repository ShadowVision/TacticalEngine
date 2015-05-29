using UnityEngine;
using System.Collections;

public class PlayerCollision : PlayerObject {
	
	private Vector3 groundCheckDirection{
		get{
			return player.orientation.down;
		}
	}
	private Vector3 wallCheckDirection{
		get{
			return player.orientation.wallDir;
		}
	}
	public float groundCheckDistance = 1f;
	public float minWallRunSize = 1f;

	private RaycastHit groundHit;
	private bool checkGround = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		hitTestGround ();

		if (player.currentState == PlayerController.PlayerState.WALL) {
			if(Physics.Raycast(new Ray(player.worldPosition, wallCheckDirection), out groundHit, groundCheckDistance)){

			}else{
				player.enterState(PlayerController.PlayerState.AIR);
			}
		}
	}
	public void pauseGroundCheck(float seconds){
		checkGround = false;
		CancelInvoke ("resetGroundCheck");
		Invoke ("resetGroundCheck", seconds);
	}
	private void resetGroundCheck(){
		CancelInvoke ("resetGroundCheck");
		checkGround = true;
	}

	public void OnCollisionEnter(Collision collision) {
		Vector3 normal = Vector3.zero;

		// hit ground
		foreach(ContactPoint contact in collision.contacts){
			Vector3 n = player.transform.worldToLocalMatrix.MultiplyVector(contact.normal);
			normal += n;
			if (n.y < 0 && Mathf.Abs(n.y) > Mathf.Abs(n.x)) {
				//Debug.Log("Wall Normal: " + n);
				//player.enterState (PlayerController.PlayerState.GROUND);
				//return;
			}
		}
		normal /= collision.contacts.Length;

		if (player.currentState == PlayerController.PlayerState.AIR && collision.collider.bounds.size.magnitude > minWallRunSize) {
			//hit wall that we can run on
			Debug.Log("Wall Normal: " + normal);
			player.enterState(PlayerController.PlayerState.WALL);
		}
	}
	public void OnCollisionExit(Collision collision) {

	}
	public void OnCollisionStay(Collision collision) {

	}
	public bool hitTestGround(){
		//Check to see if we are on ground
		if (checkGround) {
			if (Physics.Raycast (new Ray (player.worldPosition, groundCheckDirection), out groundHit, groundCheckDistance)) {
				player.enterState (PlayerController.PlayerState.GROUND);
				player.orientation.setGround(groundHit.normal);
				return true;
			} else if (player.currentState == PlayerController.PlayerState.GROUND) {
				player.enterState (PlayerController.PlayerState.AIR);
				return false;
			}
		}
		return false;
	}

}
