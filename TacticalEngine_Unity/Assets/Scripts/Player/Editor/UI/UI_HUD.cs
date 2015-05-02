using UnityEngine;
using System.Collections;

public class UI_HUD : MonoBehaviour {
	[HideInInspector]
	public PlayerEditor_UI ui;
	public Toolbar toolbar;

	// Use this for initialization
	void Awake () {
		toolbar.hud = (UI_HUD)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
