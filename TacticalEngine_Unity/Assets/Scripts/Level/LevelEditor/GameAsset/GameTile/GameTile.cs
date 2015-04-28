using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTile : GameAsset {

	[HideInInspector]
	public TilePosition position;

	// Use this for initialization
	void Awake () {
		data = gameObject.AddComponent<LevelTile_Data> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(LevelData.LevelTile_Options options){
		position = options.position;
		transform.position = new Vector3(options.position.x,options.position.y,options.position.z);
	}
}
