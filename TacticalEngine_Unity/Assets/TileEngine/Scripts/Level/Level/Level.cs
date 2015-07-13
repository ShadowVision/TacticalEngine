using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Level : SaveableObject {
	public static Level instance;

	private Light sun;
	private GameObject tileHolder;
	private Dictionary<TilePosition,GameTile> tiles;

	public Data_Level levelData;

	public GameTile tileTemplate;
	// Use this for initialization
	void Awake(){
		instance = (Level)this;
	}
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
			addTile(tileTemplate, tileOptions);
		}

	}
	public void addTile(TilePosition tilePosition){
		Data_GameTile tile = new Data_GameTile ();
		tile.position = tilePosition;
		addTile (tileTemplate, tile);
	}
	public void addTile(Data_GameTile tileOptions){
		addTile (tileTemplate, tileOptions);
	}
	public void addTile(GameTile tileTemplate, Data_GameTile tileOptions){
		GameTile tile = (GameTile)Instantiate(tileTemplate);
		tile.name = ("Tile_"+tileOptions.position.x+","+tileOptions.position.y+","+tileOptions.position.z);
		tile.transform.parent = tileHolder.transform;
		tile.myData.loadData(tileOptions.saveData());
		tiles.Add(tile.myData.position, tile);
	}
	public void removeTile(TilePosition tilePosition){
		GameTile tile = tiles[tilePosition];
		tiles.Remove (tilePosition);
		Destroy (tile.gameObject);
	}
	public void setSun(Color color, float brightness, Vector3 direction){
		sun.color = color;
		sun.intensity = brightness;
		sun.transform.eulerAngles = direction;
	}

	public static TilePosition getTilePosition(Vector3 worldPosition){
		return new TilePosition(getTilePosition(worldPosition.x),getTilePosition(worldPosition.y),getTilePosition(worldPosition.z));
	}
	public static int getTilePosition(float value){
		return (int)Mathf.Round(value);
	}
	public static float tileSize{
		get{
			return 1;
		}
	}
}

public class LevelOptions{

}
