using UnityEngine;
using System.Collections;

public class PlayerController : GameAsset {

	[HideInInspector]
	public PlayerMotor motor;
	[HideInInspector]
	public PlayerInput input;
	[HideInInspector]
	public PlayerCollision collision;

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
	public bool zLock{
		get{
			return zLocked;
		}set{
			if(value && !zLocked){
				Debug.Log("Locking");
				zLocked = true;
				playerCamera.zLock (true);
				currentZStatus = zStatus.LOCKING;
				Invoke("finishZLock", zLockTimeoutInSeconds);
			}else if (!value && zLocked){
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
		}
	}
	private void finishZLock(){
		if (currentZStatus == zStatus.UNLOCKME) {
			Debug.Log("Finished: Unlocking");
			currentZStatus = zStatus.FINISHED;
			zLock = false;
		} else {
			Debug.Log("Finished: Still Holding");
			currentZStatus = zStatus.FINISHED;
		}
	}

	// Use this for initialization
	void Awake () {
		motor = gameObject.GetComponent<PlayerMotor> ();
		input = gameObject.GetComponent<PlayerInput> ();
		collision = gameObject.GetComponent<PlayerCollision> ();
	}
	
	// Update is called once per frame
	void Update () {
	
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


}
