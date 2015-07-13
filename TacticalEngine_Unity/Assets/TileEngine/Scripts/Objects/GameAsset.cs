using UnityEngine;
using System.Collections;

public class GameAsset : SaveableObject {
	
	public virtual void OnCollisionEnter(Collision collision) {}
	public virtual void OnCollisionExit(Collision collision) {}
	public virtual void OnCollisionStay(Collision collision) {}

	public virtual Vector3 worldPosition{
		get{
			return transform.position;
		}
	}
	public virtual Vector3 levelPosition{
		get{
			Vector3 p = transform.position;
			p.x = Mathf.Round(p.x);
			p.x = Mathf.Round(p.y);
			p.x = Mathf.Round(p.z);
			return p;
		}
	}
}
