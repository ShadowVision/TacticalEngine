using UnityEngine;
using System.Collections;

namespace TileEngine{
	public class Tool_AddRemoveTile : Tool {
		private Vector3 tileWorldPosition;
		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		new void Update () {
			base.Update ();
			if (Input.GetMouseButtonDown (0)) {
				findTilePosition(true);
				addTile (Level.getTilePosition(tileWorldPosition));
			}
			if (Input.GetMouseButtonDown (1)) {
				findTilePosition(false);
				removeTile (Level.getTilePosition(tileWorldPosition));
			}
		}
		private void findTilePosition(bool add){
			Ray mouseRay = CameraController.cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo;
			if (Physics.Raycast (mouseRay,out hitInfo, 500)) {
				tileWorldPosition = hitInfo.collider.gameObject.transform.position;
				if(add){
					tileWorldPosition += hitInfo.normal;
				}
			}
		}
		private void addTile(TilePosition pos){
			Debug.Log("Adding block: " + pos);
			Level.instance.addTile (pos);
		}
		private void removeTile(TilePosition pos){
			Debug.Log("Removing block: " + pos);
			Level.instance.removeTile (pos);
		}
	}
}