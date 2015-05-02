using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[HideInInspector]
	public PlayerMotor motor;
	[HideInInspector]
	public PlayerInput input;

	// Use this for initialization
	void Awake () {
		motor = gameObject.GetComponent<PlayerMotor> ();
		input = gameObject.GetComponent<PlayerInput> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
