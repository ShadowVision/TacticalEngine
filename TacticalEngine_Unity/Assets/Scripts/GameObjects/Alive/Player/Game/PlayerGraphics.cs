using UnityEngine;
using System.Collections;

public class PlayerGraphics : PlayerObject {
	public GameObject mesh;
	public GameObject body;
	
	private Lerp_Basic meshLerp;
	private Lerp_Basic bodyLerp;
	private Quaternion targetRotation;

	// Use this for initialization
	void Start () {
		meshLerp = mesh.AddComponent<Lerp_Basic> ();
		meshLerp.positionMod = 0;
		meshLerp.scaleMod = 0;
		meshLerp.rotationMod = 5;
		
		bodyLerp = body.AddComponent<Lerp_Basic> ();
		bodyLerp.positionMod = 0;
		bodyLerp.scaleMod = 0;
		bodyLerp.rotationMod = 2;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//targetRotation = mesh.transform.rotation;
		Vector3 vel = player.motor.velocity;
		vel.y = 0;
		if(player.isZLocked){
			//targetRotation.SetLookRotation(new Vector3(vel.x/15, 0, Mathf.Abs(vel.x/15)), Vector3.up);
			//bodyLerp.targetRotation = targetRotation;
		}if (player.currentState == PlayerController.PlayerState.WALL) {

		}else{
			bodyLerp.targetRotation = Quaternion.identity;
			if (vel.magnitude > .01f) {
				targetRotation.SetLookRotation (new Vector3 (vel.x, 0, vel.z), Vector3.up);
				meshLerp.targetRotation = targetRotation;
			}
		}
	}

	public void OnNewOrientation(Vector3 up){
		player.transform.up = up;
	}
}
