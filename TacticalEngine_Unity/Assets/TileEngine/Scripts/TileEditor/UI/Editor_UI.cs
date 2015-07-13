using UnityEngine;
using System.Collections;

namespace TileEngine{
public class Editor_UI : MonoBehaviour {
	public UI_HUD hud;
	public FocusGroup focusGroup;

	// Use this for initialization
	void Awake () {
		hud.ui = (Editor_UI)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
}