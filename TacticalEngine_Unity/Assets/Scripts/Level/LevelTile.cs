using UnityEngine;
using System.Collections;

public class LevelTile : MonoBehaviour {
	[HideInInspector]
	public TilePosition position;
	[HideInInspector]
	public float height = 1;

	public GameObject tileSquareTemplate;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(TileOptions options){
		position = options.position;
		height = options.height;

		for(int i=0; i<height; i++){
			GameObject square = (GameObject)Instantiate(tileSquareTemplate, new Vector3(position.x,i,position.y), Quaternion.identity);
			square.transform.parent = transform;
		}
	}
}
public class TileOptions{
	public TilePosition position;
	public int height;
}
public class TilePosition{
	public int x=0;
	public int y=0;
	public TilePosition(int X, int Y){
		x = X;
		y = Y;
	}
}