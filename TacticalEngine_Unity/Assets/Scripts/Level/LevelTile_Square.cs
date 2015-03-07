using UnityEngine;
using System.Collections;

public class LevelTile_Square : MonoBehaviour {
	[HideInInspector]
	public LevelTile tile;

	void OnMouseDown(){
		tile.setFocus ();
	}
}
