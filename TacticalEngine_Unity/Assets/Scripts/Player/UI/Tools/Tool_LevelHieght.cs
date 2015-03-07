﻿using UnityEngine;
using System.Collections;

public class Tool_LevelHieght : Tool {
	private bool dragging = false;
	private LevelTile tile;
	private Vector3 lastMousePosition;
	private Vector3 mouseDragDistance;

	public float thresholdYInPixels = 50;

	// Use this for initialization
	void Start () {
	
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
		}
	}
	private void drag(){
		if(LevelTile.focusedTile != null){
			int dragChangeAmount = 0;
			mouseDragDistance = Input.mousePosition - lastMousePosition;
			if(mouseDragDistance.y > thresholdYInPixels){
				dragChangeAmount = 1;
				lastMousePosition = Input.mousePosition;
			}else if(mouseDragDistance.y < -thresholdYInPixels){
				dragChangeAmount = -1;
				lastMousePosition = Input.mousePosition;
			}
			LevelTile.focusedTile.height = LevelTile.focusedTile.height + dragChangeAmount;
		}
	}
	private void stopDrag(){
		if(dragging){
			Debug.Log("Stopping Drag");
			dragging = false;
		}
	}
}
