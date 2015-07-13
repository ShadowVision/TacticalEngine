using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Data_Level : DataNode {
	//SUN	
	public Color sunColor;
	public float sunBrightness;
	public Vector3 sunDirection;
	
	//GRID
	public float maxTilesX = 100;
	public float maxTilesY = 100;
	public List<Data_GameTile> tiles;
}
