using UnityEngine;
using System.Collections;

public class Player_Controller : MonoBehaviour {
	public UI_Controller ui;
	// Use this for initialization
	void Awake () {
		ui.player = (Player_Controller)this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
