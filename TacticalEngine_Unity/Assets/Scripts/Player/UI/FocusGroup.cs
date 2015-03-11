using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FocusGroup {
	private List<GameAsset> _selectedAssets = new List<GameAsset>();
	public List<GameAsset> selectedAssets{
		get{
			return _selectedAssets;
		}
	}

	public void addFocus(GameAsset newAsset){
		_selectedAssets.Add (newAsset);
	}
	public void removeFocus(GameAsset oldAsset){
		_selectedAssets.Remove (oldAsset);
	}
	public void clearFocus(){
		_selectedAssets = new List<GameAsset> ();
	}
}
