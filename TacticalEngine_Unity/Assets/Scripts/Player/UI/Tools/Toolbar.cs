using UnityEngine;
using System.Collections;

public class Toolbar : MonoBehaviour {
	[HideInInspector]
	public UI_HUD hud;
	public Toolbar_Button[] buttons;

	// Use this for initialization
	void Awake(){
		foreach(Toolbar_Button button in buttons){
			button.toolbar = (Toolbar)this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void deselectAllTools(){
		foreach(Toolbar_Button button in buttons){
			button.deselect();
		}
	}
}
