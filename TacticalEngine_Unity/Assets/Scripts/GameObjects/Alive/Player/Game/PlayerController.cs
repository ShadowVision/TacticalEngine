using UnityEngine;
using System.Collections;

public class PlayerController : AliveAsset {

	[HideInInspector]
	public PlayerMotor motor;
	[HideInInspector]
	public PlayerInput input;
	[HideInInspector]
	public PlayerCollision collision;
	[HideInInspector]
	public PlayerGraphics graphics;

	public ThirdPersonCam playerCamera;

	public enum PlayerState{	
		NONE,
		GROUND,
		AIR,
		WALL
	}
	private PlayerState _currentState;
	private PlayerState _prevState;
	public PlayerState currentState{
		get{
			return _currentState;
		}
	}
	
	private bool zLocked = false;
	private float zLockTimeoutInSeconds = .35f;
	private enum zStatus
	{
		UNLOCKED,
		LOCKING,
		UNLOCKME,
		FINISHED
	}
	private zStatus currentZStatus = zStatus.UNLOCKED;

	public bool isZLocked{
		get{
			return zLocked;
		}
	}

	// Use this for initialization
	override protected void Awake () {
		base.Awake ();
		motor = gameObject.GetComponent<PlayerMotor> ();
		input = gameObject.GetComponent<PlayerInput> ();
		collision = gameObject.GetComponent<PlayerCollision> ();
		graphics = gameObject.GetComponent<PlayerGraphics> ();
		orientation.OnNewOrientation = OnNewOrientation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnNewOrientation(Vector3 up){
		graphics.OnNewOrientation (up);
	}

	public void enterState(PlayerState newState){
		if (newState != _currentState) {
			//Debug.Log("entering state: " + newState);
			_prevState = _currentState;
			_currentState = newState;
			switch (newState) {
			case PlayerState.GROUND:
				motor.hitGround();
				break;
			case PlayerState.AIR:
				collision.pauseGroundCheck(.1f);
				break;
			case PlayerState.WALL: 
				motor.startWallRun();
				break;
			}
		}
	}

	public override void OnCollisionEnter (Collision collision)
	{
		this.collision.OnCollisionEnter (collision);
	}
	public override void OnCollisionExit (Collision collision)
	{
		this.collision.OnCollisionExit (collision);
	}
	public override void OnCollisionStay (Collision collision)
	{
		this.collision.OnCollisionStay (collision);
	}

	public void setZLock(bool zLock){
		if(zLock && !zLocked){
			startZLock();
		}else if (!zLock && zLocked){
			stopZLock ();
		}
	}	

	private void startZLock(){
		Debug.Log("Locking");
		zLocked = true;
		playerCamera.zLock (true);
		currentZStatus = zStatus.LOCKING;
		Invoke("finishZLock", zLockTimeoutInSeconds);
		if(currentState == PlayerState.WALL){
//			setGravityToWall();
		}
	}
	private void stopZLock(){
		if(currentZStatus == zStatus.FINISHED){
			Debug.Log("Unlocking: Finished");
			zLocked = false;
			currentZStatus = zStatus.UNLOCKED;
			playerCamera.zLock (false);
		}else{
			Debug.Log("Unlocking: Waiting to finish");
			currentZStatus = zStatus.UNLOCKME;
		}
	}
	private void finishZLock(){
		if (currentZStatus == zStatus.UNLOCKME) {
			Debug.Log("Finished: Unlocking");
			currentZStatus = zStatus.FINISHED;
			setZLock(false);
		} else {
			Debug.Log("Finished: Still Holding");
			currentZStatus = zStatus.FINISHED;
		}
	}


}
