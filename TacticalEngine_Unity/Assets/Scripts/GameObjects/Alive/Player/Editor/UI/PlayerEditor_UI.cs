using UnityEngine;
using System.Collections;

public class PlayerEditor_UI : MonoBehaviour {
	[HideInInspector]
	public PlayerEditor_Controller player;
	public UI_HUD hud;
	public FocusGroup focusGroup;

	// Use this for initialization
	void Awake () {
		hud.ui = (PlayerEditor_UI)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
