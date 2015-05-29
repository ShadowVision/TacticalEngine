using UnityEngine;
using System.Collections;

public class AliveAsset : GameAsset {
	[HideInInspector]
	public Orientation orientation;

	protected virtual void Awake(){
		orientation = gameObject.GetComponent<Orientation> ();
	}
}
