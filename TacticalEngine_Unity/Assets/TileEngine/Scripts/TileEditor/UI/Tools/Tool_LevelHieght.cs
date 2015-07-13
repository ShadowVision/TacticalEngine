using UnityEngine;
using System.Collections;

namespace TileEngine{
public class Tool_LevelHieght : Tool {
	private bool dragging = false;
	private GameTile tile;
	private Vector3 lastMousePosition;
	private Vector3 mouseDragDistance;
	private Editor_UI ui;

	public float thresholdYInPixels = 50;

	// Use this for initialization
	void Start () {
		ui = toolbar.hud.ui;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(enabled){
			updateTool();
		}
	}

	public override void enableTool ()
	{
		enabled = true;
	}
	public override void disableTool ()
	{
		enabled = false;
	}
	public override void updateTool ()
	{
		if(enabled){
			if(dragging){
				drag();
			}else if(Input.GetMouseButtonDown(0)){
				startDrag();
			}
		}
		if(Input.GetMouseButtonUp(0)){
			stopDrag();
		}
	}

	private void startDrag(){
		if(!dragging){
			Debug.Log("Starting Drag");
			dragging = true;
			lastMousePosition = Input.mousePosition;
			captureTile();
		}
	}
	private void drag(){
		if(ui.focusGroup != null){
			int dragChangeAmount = 0;
			mouseDragDistance = Input.mousePosition - lastMousePosition;
			if(mouseDragDistance.y > thresholdYInPixels){
				dragChangeAmount = 1;
				lastMousePosition = Input.mousePosition;
			}else if(mouseDragDistance.y < -thresholdYInPixels){
				dragChangeAmount = -1;
				lastMousePosition = Input.mousePosition;
			}
			//ui.getAll() = LevelTile.focusedTile.height + dragChangeAmount;
		}
	}
	private void stopDrag(){
		if(dragging){
			Debug.Log("Stopping Drag");
			dragging = false;
		}
	}
}
}