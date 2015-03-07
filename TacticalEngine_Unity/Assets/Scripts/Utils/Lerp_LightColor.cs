using UnityEngine;
using System.Collections;

public class Lerp_LightColor : MonoBehaviour {
	public Light targetLight;
	public Color targetColor;
	public float lerpSpeedMod = 1;

	// Use this for initialization
	void Awake () {
		if(GetComponent<Light>() != null){
			targetColor = targetLight.color;
		}else{
			targetLight = gameObject.GetComponent<Light>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		targetLight.color = Color.Lerp (targetLight.color, targetColor, Time.deltaTime * lerpSpeedMod);
	}
}
