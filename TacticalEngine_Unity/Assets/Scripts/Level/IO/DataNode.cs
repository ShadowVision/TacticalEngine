using UnityEngine;
using System.Collections;
using SimpleJSON;

public class DataNode {
	protected JSONNode json;

	public virtual JSONNode saveData(){
		json = JSONNode.Parse ("{}");
		return json;
	}
	public virtual void loadData(JSONNode savedNode){

	}

	public JSONNode getData(){
		return json;
	}
}
	