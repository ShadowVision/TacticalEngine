using UnityEngine;
using System.Collections;

public class Tool : MonoBehaviour {
	[HideInInspector]
	public Toolbar_Button toolButton;
	public virtual void enableTool (){}
	public virtual void disableTool (){}
	public virtual void updateTool (){}
}
