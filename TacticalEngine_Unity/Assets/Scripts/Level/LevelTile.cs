using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTile : MonoBehaviour {
	public static LevelTile focusedTile;
	
	private List<LevelTile_Square> squares;
	private LevelTile_Square lastSquare;

	[HideInInspector]
	public TilePosition position;
	[HideInInspector]
	public int height{
		get{
			return squares.Count;
		}
		set{
			updateHeight(value);
		}
	}

	public LevelTile_Square tileSquareTemplate;



	// Use this for initialization
	void Awake () {
		squares = new List<LevelTile_Square> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void init(TileOptions options){
		position = options.position;
		height = options.height;
	}
	public void setFocus(){
		Debug.Log ("Focusing on tile: " + name);
		focusedTile = (LevelTile)this;
	}
	private void addSquare(){
		LevelTile_Square square = (LevelTile_Square)Instantiate(tileSquareTemplate, new Vector3(position.x,height,position.y), Quaternion.identity);
		square.transform.parent = transform;
		square.tile = (LevelTile)this;
		squares.Add(square);
		lastSquare = square;
	}
	private void removeSquare(){
		squares.Remove (lastSquare);
		Destroy (lastSquare.gameObject);
		foreach(LevelTile_Square square in squares){
			lastSquare = square;
		}
	}
	private void updateHeight(int newHeight){
		if (newHeight == height || newHeight < 1) {
			return;
		}else if(newHeight > height){
			for(int i=0; i<newHeight-height; i++){
				addSquare();
			}
		}else if(newHeight < height){
			for(int i=0; i<height-newHeight; i++){
				removeSquare();
			}
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