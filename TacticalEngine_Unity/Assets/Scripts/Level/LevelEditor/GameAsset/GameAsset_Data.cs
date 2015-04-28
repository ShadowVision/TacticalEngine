using UnityEngine;
using System.Collections;
using SimpleJSON;
using GameData;

public class GameAsset_Data : MonoBehaviour {
	protected JSONNode data;

	[HideInInspector]
	public TilePosition position;

	public virtual JSONNode parseData(){
		data = JSONNode.Parse ("{}");
		
		return data;
	}
}

namespace GameData{
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
}