using UnityEngine;
using System.Collections;

[System.Serializable]
public class Data_GameTile: Data_GameAsset {
	private GameTile _parent;
	public GameTile parent{
		set{
			_parent = value;
			_parent.transform.position = new Vector3(position.x,position.y,position.z);
		}
	}

	public override SimpleJSON.JSONNode saveData ()
	{
		json = base.saveData ();

		return json;
	}
	public override void loadData (SimpleJSON.JSONNode savedNode)
	{
		base.loadData (savedNode);

	}
}