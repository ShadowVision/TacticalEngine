using UnityEngine;
using System.Collections;

public class PlayerMotor : PlayerObject {
	[HideInInspector]
	public Rigidbody rigid;
	
	public float gravityForce = 1f;
	public float wallRunGravityForce = 1f;
	public float terminalVelocity = 5f;
	public float groundFriction = .1f;
	public float airFriction = .1f;
	public float wallFriction = .1f;
	public float moveSpeedMin = 10;
	public float moveSpeedMax = 10;
	public float moveSpeedAcc = 1;
	public float jumpSpeed = 10;
	public float jumpCap = 5;
	public int numberOfJumps = 2;
	public float jumpMoveSpeedMod = 1;

	public Vector3 velocity {
		get {
			return vel;
		}
	}

	private float gravity = 0;
	private float jumpCounter = 0;
	private int jumpNum = 0;
	private bool jumping = false;
	private bool okToUpdateJump = false;
	private Vector3 vel; 
	private Vector3 savedMoveDir = Vector3.zero;
	private float currentMoveSpeed = 0;
	private float friction = 0;
	// Use this for initialization
	void Start () {
		rigid = gameObject.GetComponent<Rigidbody> ();
		gravity = gravityForce;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate	(){
		//rigid.AddForce (vel);
		//transform.position = transform.position + vel;	
		rigid.velocity = player.transform.localToWorldMatrix.MultiplyVector(vel);

		switch (player.currentState) {
		case PlayerController.PlayerState.GROUND:
			friction = groundFriction;
			break;
		case PlayerController.PlayerState.AIR:
			friction = airFriction;
			break;
		case PlayerController.PlayerState.WALL:
			friction = wallFriction;
			break;
		}
		vel.x *= 1-friction;
		vel.z *= 1-friction;
		if (player.currentState != PlayerController.PlayerState.GROUND) {
			okToUpdateJump = true;
			vel.y -= gravity * Time.deltaTime;
			vel.y = Mathf.Max (-terminalVelocity,vel.y);
		} else {
			vel.y = 0;
		}
	}

	public void move(Vector3 direction){
		if (player.currentState == PlayerController.PlayerState.WALL) {

		} else {
			if (player.isZLocked) {
				player.playerCamera.releaseInputLock ();
			} else {
				//lock direction change if moving. release if not
				if (direction.magnitude < .01f || Mathf.Abs (Vector3.Angle (savedMoveDir, direction)) > 15) {
					//if (direction.magnitude < .01f || Mathf.Abs(Vector3.Angle(previousMoveDir,direction)) < 30) {
					player.playerCamera.releaseInputLock ();
				} else {
					if (!player.playerCamera.inputLocked) {
						player.playerCamera.lockInput ();
						savedMoveDir = direction;
					}
				}
			}

			//Acceleration
			if (player.currentState == PlayerController.PlayerState.GROUND) {
				if (vel.magnitude > .01f) {
					currentMoveSpeed += moveSpeedAcc * Time.deltaTime;
				} else {
					currentMoveSpeed = moveSpeedMin;
				}
			}
			
			direction = player.playerCamera.inputTransform.TransformDirection (direction);
			vel += direction * currentMoveSpeed * Time.deltaTime;
		}

		if (currentMoveSpeed > moveSpeedMax) {
			currentMoveSpeed = moveSpeedMax;
		} else if (currentMoveSpeed < moveSpeedMin) {
			currentMoveSpeed = moveSpeedMin;
		}
	}
	public void startJump(){
		if (jumpNum < numberOfJumps) {
			endWallRun();
			jumpCounter = 0;
			jumpNum++;
			jumping = true;
			if(player.currentState == PlayerController.PlayerState.GROUND){
				vel*= jumpMoveSpeedMod;
				currentMoveSpeed*= jumpMoveSpeedMod;
			}
			vel.y = jumpSpeed;
			player.enterState (PlayerController.PlayerState.AIR);
		}
	}
	public void holdJump(){
		if(player.currentState == PlayerController.PlayerState.WALL){return;}

		if (okToUpdateJump && jumping && jumpCounter <= jumpCap) {
			vel.y += jumpSpeed;
			jumpCounter += jumpSpeed;
			okToUpdateJump = false;
		}
	}
	private void endJump(bool resetJumps = true){
		jumpCounter = 0;
		if (resetJumps) {
			jumpNum = 0;
		} 
		jumping = false;
	}
	public void hitGround(){
		endJump ();
		endWallRun ();
	}

	public void startWallRun(){
		gravity = wallRunGravityForce;
		vel.y *= .5f;
		endJump (false);
		if (jumpCounter >= jumpCap) {
			jumpCounter = jumpCap-1;
		}
	}
	public void endWallRun(){
		gravity = gravityForce;
	}
}
