using UnityEngine;
using System.Collections;

namespace TileEngine{
public class UI_HUD : MonoBehaviour {
	[HideInInspector]
	public Editor_UI ui;
	public Toolbar toolbar;

	// Use this for initialization
	void Awake () {
		toolbar.hud = (UI_HUD)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}