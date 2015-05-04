using UnityEngine;
using System.Collections;

public class PlayerMotor : PlayerObject {
	[HideInInspector]
	public Rigidbody rigid;

	public float gravityForce = 1f;
	public float terminalVelocity = 5f;
	public float linearFriction = .1f;
	public float moveSpeed = 10;
	public float jumpSpeed = 10;
	public float jumpCap = 5;
	public int numberOfJumps = 2;

	public Vector3 velocity {
		get {
			return vel;
		}
	}

	private float jumpCounter = 0;
	private int jumpNum = 0;
	private bool jumping = false;
	private Vector3 vel; 
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void LateUpdate(){
		//rigid.AddForce (vel);
		rigid.velocity = vel;
		vel.x *= 1-linearFriction;
		vel.z *= 1-linearFriction;
		if (player.currentState != PlayerController.PlayerState.GROUND) {
			vel.y -= gravityForce * Time.deltaTime;
			vel.y = Mathf.Max (-terminalVelocity,vel.y);
		} else {
			vel.y = 0;
		}
	}

	public void move(Vector3 direction){
		//TODO Take direction and modify it to be relative to either camera direction or player direction; 
		vel += direction * moveSpeed * Time.deltaTime;
	}
	public void startJump(){
		if (jumpNum < numberOfJumps) {
			jumpCounter = 0;
			jumpNum++;
			jumping = true;
			vel.y = jumpSpeed;
			player.enterState (PlayerController.PlayerState.AIR);
		}
	}
	public void holdJump(){
		if (jumping && jumpCounter <= jumpCap) {
			vel.y += jumpSpeed;
			jumpCounter += jumpSpeed;
		}
	}
	private void endJump(){
		jumpCounter = 0;
		jumpNum = 0;
		jumping = false;
	}
	public void hitGround(){
		endJump ();
	}
}
