using UnityEngine;
using System.Collections;

public class PlayerMotor : PlayerObject {
	[HideInInspector]
	public Rigidbody rididbody;

	public float moveSpeed;
	// Use this for initialization
	void Start () {
		rididbody = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void move(Vector3 direction){
		rididbody.AddForce (direction * moveSpeed * Time.deltaTime);
	}
}
