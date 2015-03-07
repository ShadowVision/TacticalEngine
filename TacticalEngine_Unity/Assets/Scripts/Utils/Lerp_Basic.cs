using UnityEngine;
using System.Collections;

public class Lerp_Basic : MonoBehaviour {
	public Vector3 targetPosition;
	public Vector3 targetScale;
	public Quaternion targetRotation;

	public float positionMod = 1;
	public float scaleMod = 1;
	public float rotationMod = 1;

	public Transform targetTransform;


	// Use this for initialization
	void Awake () {
		if(targetTransform == null){
			targetTransform = gameObject.transform;
		}
		targetPosition = targetTransform.localPosition;
		targetScale = targetTransform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(targetTransform.localPosition != targetPosition){
			targetTransform.localPosition = Vector3.Lerp(targetTransform.localPosition,targetPosition, Time.deltaTime * positionMod);
			if(Vector3.Distance(targetTransform.localPosition, targetPosition) < .01f){
				targetTransform.localPosition = targetPosition;
			}
		}
		if(targetTransform.localScale != targetScale){
			targetTransform.localScale = Vector3.Lerp(targetTransform.localScale,targetScale, Time.deltaTime * scaleMod);
			if(Vector3.Distance(targetTransform.localScale, targetScale) < .01f){
				targetTransform.localScale = targetScale;
			}
		}
		if(targetTransform.localRotation != targetRotation){
			targetTransform.localRotation = Quaternion.Lerp(targetTransform.localRotation, targetRotation, Time.deltaTime * rotationMod);
		}
	}
}
