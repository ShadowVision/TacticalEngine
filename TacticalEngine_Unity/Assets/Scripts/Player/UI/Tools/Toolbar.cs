using UnityEngine;
using System.Collections;

public class Toolbar : MonoBehaviour {
	[HideInInspector]
	public UI_HUD hud;
	public Tool[] tools;

	// Use this for initialization
	void Awake(){
		foreach(Tool tool in tools){
			tool.toolbar = (Toolbar)this;
		}
	}

	public void deselectAllTools(){
		foreach(Tool tool in tools){
			tool.deselect();
		}
	}
}
