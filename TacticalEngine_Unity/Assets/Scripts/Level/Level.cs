using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class Level : MonoBehaviour {
	private Light sun;
	private GameObject tileHolder;
	private Dictionary<TilePosition,LevelTile> tiles;

	public LevelTile tileTemplate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(LevelOptions options){
		//build sun
		GameObject go = new GameObject ("Sun");
		sun = go.AddComponent<Light> ();
		sun.type = LightType.Directional;
		sun.transform.position = new Vector3 (0, 10, 0);
		setSun (options.sunColor, options.sunBrightness, options.sunDirection);

		//build grid
		tiles = new Dictionary<TilePosition, LevelTile> ();
		tileHolder = new GameObject ("TileHolder");
		tileHolder.transform.parent = transform;
		foreach(TileOptions tileOptions in options.tiles){
			LevelTile tile = (LevelTile)Instantiate(tileTemplate);
			tile.name = ("Tile_"+tileOptions.position.x+","+tileOptions.position.y);
			tile.transform.parent = tileHolder.transform;
			tile.init(tileOptions);
			tiles.Add(tile.position, tile);
		}

	}
	public void setSun(Color color, float brightness, Vector3 direction){
		sun.color = color;
		sun.intensity = brightness;
		sun.transform.eulerAngles = direction;
	}
}

public class LevelOptions{
	//SUN	
	public Color sunColor;
	public float sunBrightness;
	public Vector3 sunDirection;

	//GRID
	public float maxTilesX = 100;
	public float maxTilesY = 100;
	public List<TileOptions> tiles;

}
