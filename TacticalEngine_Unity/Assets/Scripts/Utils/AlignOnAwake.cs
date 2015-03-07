using UnityEngine;
using System.Collections;

public class AlignOnAwake : MonoBehaviour {
	public int roundDecimals = 2;
	// Use this for initialization
	void Start () {
		Transform[] transforms = FindObjectsOfType<Transform> ();
		foreach(Transform t in transforms){
			Vector3 newPosition = t.position;
			newPosition.x = Libonati.round(newPosition.x, roundDecimals);
			newPosition.y = Libonati.round(newPosition.y, roundDecimals);
			newPosition.z = Libonati.round(newPosition.z, roundDecimals);
			t.position = newPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
