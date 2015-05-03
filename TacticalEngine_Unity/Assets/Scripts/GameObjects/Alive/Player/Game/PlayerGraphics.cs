using UnityEngine;
using System.Collections;

public class PlayerGraphics : PlayerObject {
	public GameObject mesh;
	
	private Lerp_Basic meshLerp;
	private Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		meshLerp = mesh.AddComponent<Lerp_Basic> ();
		meshLerp.positionMod = 0;
		meshLerp.scaleMod = 0;
		meshLerp.rotationMod = 5;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//targetRotation = mesh.transform.rotation;
		Vector3 vel = player.motor.velocity;
		vel.y = 0;
		targetRotation.SetLookRotation (new Vector3(vel.x,0,vel.z), Vector3.up);
		meshLerp.targetRotation = targetRotation;
	}
}
