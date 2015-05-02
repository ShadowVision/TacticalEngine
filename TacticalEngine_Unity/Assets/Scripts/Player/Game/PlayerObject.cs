using UnityEngine;
using System.Collections;

public class PlayerObject : MonoBehaviour {
	protected PlayerController player;

	// Use this for initialization
	protected void Awake () {
		player = gameObject.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
