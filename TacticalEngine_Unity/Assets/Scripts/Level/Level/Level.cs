using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Level : SaveableObject {
	private Light sun;
	private GameObject tileHolder;
	private Dictionary<TilePosition,GameTile> tiles;

	public Data_Level levelData;

	public GameTile tileTemplate;
	// Use this for initialization
	void Start () {
		data = levelData;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(Data_Level options){
		//build sun
		GameObject go = new GameObject ("Sun");
		sun = go.AddComponent<Light> ();
		sun.type = LightType.Directional;
		sun.transform.position = new Vector3 (0, 10, 0);
		setSun (options.sunColor, options.sunBrightness, options.sunDirection);

		//build grid
		tiles = new Dictionary<TilePosition, GameTile> ();
		tileHolder = new GameObject ("TileHolder");
		tileHolder.transform.parent = transform;
		foreach(Data_GameTile tileOptions in options.tiles){
			GameTile tile = (GameTile)Instantiate(tileTemplate);
			tile.name = ("Tile_"+tileOptions.position.x+","+tileOptions.position.y);
			tile.transform.parent = tileHolder.transform;
			tile.myData.loadData(tileOptions.saveData());
			tiles.Add(tile.myData.position, tile);
		}

	}
	public void setSun(Color color, float brightness, Vector3 direction){
		sun.color = color;
		sun.intensity = brightness;
		sun.transform.eulerAngles = direction;
	}
}

public class LevelOptions{

}
