using UnityEngine;
using System.Collections;

public class ColliderAlert : MonoBehaviour {
	public GameAsset target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void OnCollisionEnter(Collision collision) {
		target.OnCollisionEnter (collision);
	}
	private void OnCollisionExit(Collision collision) {
		target.OnCollisionExit (collision);
	}
	private void OnCollisionStay(Collision collision) {
		target.OnCollisionStay (collision);
	}
}
