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

	public Vector3 velocity {
		get {
			return vel;
		}
	}

	private float jumpCounter;
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
			vel.y -= gravityForce;
			vel.y = Mathf.Max (-terminalVelocity,vel.y);
		} else {
			vel.y = 0;
		}
	}

	public void move(Vector3 direction){
		vel += direction * moveSpeed * Time.deltaTime;
	}
	public void jump(){
		if (jumpCounter <= jumpCap) {
			if(jumpCounter == 0){
				//first jump tick
			}
			float force = jumpSpeed * Time.deltaTime;
			vel += Vector3.up * force;
			jumpCounter += force;
			player.enterState(PlayerController.PlayerState.AIR);
		}
	}
	private void endJump(){
		jumpCounter = 0;
	}
	public void hitGround(){
		endJump ();
	}
}
