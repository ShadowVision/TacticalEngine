using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelBuilder : MonoBehaviour {
	private Level level;
	
	public bool generateRandomMap = false;
	public CameraController cameraController;
	public Level levelTemplate;
	public int defaultMapSize=5;
	public int defaultMapHeight=1;


	// Use this for initialization
	void Start () {
		level = (Level)Instantiate (levelTemplate);
		level.name = "Level";

		if(generateRandomMap){
			loadRandomLevel();
		}else{
			loadLevel ();
		}

		//center camera
		cameraController.transform.position = new Vector3(defaultMapSize/2f,0,defaultMapSize/2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void loadRandomLevel(){
		LevelOptions options = new LevelOptions ();
		options.sunColor = new Color (Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f));
		options.sunBrightness = Random.Range(.2f,2f);
		options.sunDirection = new Vector3 (Random.Range(0,180), Random.Range(0,180), 0);

		List<TileOptions> tileOptions = new List<TileOptions> ();
		for(int x=0; x<defaultMapSize; x++){
			int height = Random.Range(1,6);
			for(int y=0; y<height; y++){
				for(int z=0; z<defaultMapSize; z++){
					TileOptions to = new TileOptions ();
					to.position = new TilePosition (x, y, z);
					tileOptions.Add(to);
				}
			}
		}
		options.tiles = tileOptions;
		level.init (options);
	}
	private void loadLevel(){
		LevelOptions options = new LevelOptions ();
		options.sunColor = new Color (0, 1, 1);
		options.sunBrightness = 1f;
		options.sunDirection = new Vector3 (45, 45, 0);

		List<TileOptions> tileOptions = new List<TileOptions> ();
		for(int x=0; x<defaultMapSize; x++){
			for(int y=0; y<defaultMapHeight; y++){
				for(int z=0; z<defaultMapSize; z++){
					TileOptions to = new TileOptions ();
					to.position = new TilePosition (x, y, z);
					tileOptions.Add(to);
				}
			}
		}
		options.tiles = tileOptions;
		level.init (options);
	}
}
