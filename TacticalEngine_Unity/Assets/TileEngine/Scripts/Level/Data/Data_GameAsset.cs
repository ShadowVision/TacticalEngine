using UnityEngine;
using System.Collections;

public class Data_GameAsset : DataNode {
	[HideInInspector]
	private TilePosition tilePosition;
	public TilePosition position{ get { return tilePosition; } set{tilePosition = value;} }

	public override SimpleJSON.JSONNode saveData ()
	{
		json = base.saveData ();
		json.Add ("PositionX", position.x.ToString());
		json.Add ("PositionY", position.y.ToString());
		json.Add ("PositionZ", position.z.ToString());
		return json;
	}
	public override void loadData (SimpleJSON.JSONNode savedNode)
	{
		base.loadData (savedNode);
		position = new TilePosition (savedNode ["PositionX"].AsInt, savedNode ["PositionY"].AsInt, savedNode ["PositionZ"].AsInt);
	}
}