using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {
	[HideInInspector]
	public Player_Controller player;
	public UI_HUD hud;

	// Use this for initialization
	void Awake () {
		hud.ui = (UI_Controller)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
