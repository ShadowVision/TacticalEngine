using UnityEngine;
using System.Collections;

public class Orientation : MonoBehaviour {

	private Vector3 upVector = new Vector3(0,1,0);
	public Vector3 up{
		get{
			return upVector;
		}
	}
	
	private Vector3 downVector = new Vector3(0,-1,0);
	public Vector3 down{
		get{
			return downVector;
		}
	}
	
	private Vector3 wallVector = new Vector3(0,0,0);
	public Vector3 wallDir{
		get{
			return downVector;
		}
	}

	public delegate void OnNewOrientationDelegate(Vector3 up);
	public OnNewOrientationDelegate OnNewOrientation;

	public void setGround(Vector3 groundNormal){
		if (groundNormal != upVector) {
			upVector = groundNormal;
			downVector = upVector * -1;
			if(OnNewOrientation != null){
				OnNewOrientation(upVector);
			}
		}
	}

}
