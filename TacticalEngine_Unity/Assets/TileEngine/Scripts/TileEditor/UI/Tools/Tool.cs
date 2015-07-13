using UnityEngine;
using System.Collections;

namespace TileEngine{
public class Tool : MonoBehaviour {
	[HideInInspector]
	public Toolbar toolbar;
	public virtual void enableTool (){}
	public virtual void disableTool (){}
	public virtual void updateTool (){}

	public KeyCode hotKeyButton;

	// Update is called once per frame
	protected void Update () {
		if(Input.GetKeyUp(hotKeyButton)){
			select();
		}
	}
	
	public virtual void select(){
		Debug.Log("Selecting Tool: " + name);
		toolbar.deselectAllTools();
		enableTool();
	}
	public virtual void deselect(){
		disableTool();
	}
	
	public void captureTile(){
		
	}
}
}