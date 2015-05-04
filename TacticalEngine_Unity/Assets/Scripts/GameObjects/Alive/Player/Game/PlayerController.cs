using UnityEngine;
using System.Collections;

public class PlayerController : GameAsset {

	[HideInInspector]
	public PlayerMotor motor;
	[HideInInspector]
	public PlayerInput input;
	[HideInInspector]
	public PlayerCollision collision;

	public Camera playerCamera;

	public enum PlayerState{	
		NONE,
		GROUND,
		AIR
	}
	private PlayerState _currentState;
	private PlayerState _prevState;
	public PlayerState currentState{
		get{
			return _currentState;
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
