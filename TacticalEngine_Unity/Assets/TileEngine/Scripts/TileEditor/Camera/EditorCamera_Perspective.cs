using UnityEngine;
using System.Collections;

public class EditorCamera_Perspective : MonoBehaviour {
	public float rotationSpeed = 4;

	private Vector3 currentRot = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		if(Mathf.Abs(h) > 0.1f){
			currentRot.y += -h * Time.deltaTime * rotationSpeed;
			transform.localEulerAngles = currentRot;
		}
		if(Mathf.Abs(v) > 0.1f){
			currentRot.x += v * Time.deltaTime * rotationSpeed;
			transform.localEulerAngles = currentRot;
		}

	}
}
