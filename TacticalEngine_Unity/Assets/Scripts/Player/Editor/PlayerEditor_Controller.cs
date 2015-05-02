using UnityEngine;
using System.Collections;

public class PlayerEditor_Controller : MonoBehaviour {
	public PlayerEditor_UI ui;
	// Use this for initialization
	void Awake () {
		ui.player = (PlayerEditor_Controller)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
