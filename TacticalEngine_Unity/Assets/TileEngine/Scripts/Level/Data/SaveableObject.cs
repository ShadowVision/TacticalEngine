using UnityEngine;
using System.Collections;

public class SaveableObject : MonoBehaviour {
	protected DataNode data; 
	public DataNode saveData{ get { return data; } }
}
