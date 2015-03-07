using UnityEngine;
using System.Collections;

public class Toolbar_Button : MonoBehaviour {
	[HideInInspector]
	public Toolbar toolbar;
	public KeyCode hotKeyButton;
	public Tool tool;

	// Use this for initialization
	void Awake () {
		tool.toolButton = (Toolbar_Button)this;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(hotKeyButton)){
			select();
		}
	}

	public virtual void select(){
		toolbar.deselectAllTools();
		if(tool != null){
			tool.enableTool();
			Debug.Log("Selecting Tool: " + tool.name);
		}
	}
	public virtual void deselect(){
		if(tool != null){
			tool.disableTool();
		}
	}
}
