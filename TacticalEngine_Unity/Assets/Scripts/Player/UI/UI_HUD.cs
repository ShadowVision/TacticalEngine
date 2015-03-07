using UnityEngine;
using System.Collections;

public class UI_HUD : MonoBehaviour {
	[HideInInspector]
	public UI_Controller ui;
	public Toolbar toolbar;

	// Use this for initialization
	void Awake () {
		toolbar.hud = (UI_HUD)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
