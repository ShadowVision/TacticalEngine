using UnityEngine;
using System.Collections;

public class SpawnMe : MonoBehaviour {
	public Transform spawnPoint;
	public GameObject spawnObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			spawn();
		}
	}
	private void spawn(){
		Instantiate (spawnObject, spawnPoint.position, spawnPoint.rotation);
	}
}
