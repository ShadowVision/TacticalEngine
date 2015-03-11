using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTile : GameAsset {

	[HideInInspector]
	public TilePosition position;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(TileOptions options){
		position = options.position;
		transform.position = new Vector3(options.position.x,options.position.y,options.position.z);
	}
}

public class TileOptions{
	public TilePosition position;
}
public class TilePosition{
	public int x=0;
	public int y=0;
	public int z=0;
	public TilePosition(int X, int Y, int Z){
		x = X;
		y = Y;
		z = Z;
	}
}