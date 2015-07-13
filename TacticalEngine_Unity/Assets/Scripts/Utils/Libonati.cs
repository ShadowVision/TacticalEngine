using UnityEngine;
using System.Collections;
using System;

public class Libonati : MonoBehaviour {
	//Math
	static public bool pointInsideRect(Rect rect, Vector3 point){
		return point.x >= rect.xMin && point.x <= rect.xMax && point.y <= rect.yMin && point.y >= rect.yMax;
	}

	//Level managment
	static public void reloadLevel (){
		Application.LoadLevel (Application.loadedLevel);
	}
	static public void loadNextLevel(){
		int levelId = Application.loadedLevel;
		levelId ++;
		if(levelId >= Application.levelCount){
			levelId = 0;
		}
		Application.LoadLevel(levelId);
	}

	//Text Modification
	static public string padInt(int value, int numberOfDigits){
		return value.ToString ("D" + numberOfDigits.ToString ());
	}
	static public string clockString(int totalSeconds){		
		int minutes = (int)Mathf.Floor(totalSeconds/60);
		int seconds = (int)Mathf.Round(totalSeconds - minutes*60);
		string clock = minutes+":"+Libonati.padInt(seconds,2);
		return clock;
	}
	static public char[] generateTextCode(int codeLength){
		return generateCode(codeLength,"ABCDEFGHIJKLMNOPQRSTUVWXYZ");
	}
	static public char[] generateNumberCode(int codeLength){
		return generateCode(codeLength,"1234567890");
	}
	static public char[] generateCode(int codeLength, string possibleCharacters){
		char[] codeChar = new char[codeLength];
		for(int i=0; i<codeLength; i++){
			codeChar[i] = possibleCharacters[(int)UnityEngine.Random.Range(0,possibleCharacters.Length)];
		}
		return codeChar;
	}

	//Game Object Modification
	static public void destroyAllChildren(GameObject parent){
		foreach (Transform child in parent.transform) Destroy(child.gameObject);
	}
	public static Vector2 getPositionFromLinearArray(int i, int width){
		return new Vector2(i%width, Mathf.Floor(i/width));
	}
	
	static public void showAllSprites(GameObject obj){
		toggleAllSpriteVisibility (obj, true);
	}
	static public void hideAllSprites(GameObject obj){
		toggleAllSpriteVisibility (obj, false);
	}
	static public void toggleAllSpriteVisibility(GameObject obj, bool show){
		foreach(SpriteRenderer ren in obj.GetComponentsInChildren<SpriteRenderer>()){
			ren.enabled = show;
		}
	}
	
	static public void showAllMesh(GameObject obj){
		toggleAllMeshVisibility (obj, true);
	}
	static public void hideAllMesh(GameObject obj){
		toggleAllMeshVisibility (obj, false);
	}
	static public void toggleAllMeshVisibility(GameObject obj, bool show){
		foreach(MeshRenderer ren in obj.GetComponentsInChildren<MeshRenderer>()){
			ren.enabled = show;
		}
	}
	
	static public void hideAll(GameObject obj){
		hideAllMesh (obj);
		hideAllSprites (obj);
	}
	static public void showAll(GameObject obj){
		showAllMesh (obj);
		showAllSprites (obj);
	}

	static public object getRandomEnumValue(Type enumType){
		Array values = Enum.GetValues(enumType);
		return values.GetValue((int)UnityEngine.Random.Range(0,values.Length));
	}

	
	
	static public void disable2DColliders(GameObject obj){
		foreach(Collider2D col in obj.GetComponentsInChildren<Collider2D>()){
			col.enabled = false;
		}
	}
	static public void enable2DColliders(GameObject obj){
		foreach(Collider2D col in obj.GetComponentsInChildren<Collider2D>()){
			col.enabled = true;
		}
	}
	static public void disable3DColliders(GameObject obj){
		foreach(Collider col in obj.GetComponentsInChildren<Collider>()){
			col.enabled = false;
		}
	}
	static public void enable3DColliders(GameObject obj){
		foreach(Collider col in obj.GetComponentsInChildren<Collider>()){
			col.enabled = true;
		}
	}
	
	static public void disableColliders(GameObject obj){
		disable2DColliders (obj);
		disable3DColliders (obj);
	}
	static public void enableColliders(GameObject obj){
		enable2DColliders(obj);
		enable3DColliders(obj);
	}


	//Grid Based

	public static int tileToLinear(int x, int y, int stride){
		return y * stride + x;
	}
	public static Vector2 linearToTile(int i, int stride){
		return new Vector2 (i % stride, Mathf.Floor(i/stride));
	}

	public static float round(float value, int digits)
	{
		float mult = Mathf.Pow(10.0f, (float)digits);
		return Mathf.Round(value * mult) / mult;
	}

	//Color Manipulation
	public static string colorToString(Color color){
		return color.r + "," + color.g + "," + color.b + "," + color.a; 
	}
	public static Color stringToColor(string colorString){
		try{
			string[] colors = colorString.Split (',');
			return new Color (float.Parse(colors [0]), float.Parse(colors [1]), float.Parse(colors [2]), float.Parse(colors [3]));
		}catch{
			return Color.white;
		}
	}

	// Note that Color32 and Color implictly convert to each other. You may pass a Color object to this method without first casting it.
	public static string colorToHex(Color32 color)
	{
		string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
		return hex;
	}
	
	public static Color hexToColor(string hex)
	{
		hex = hex.Replace ("0x", "");//in case the string is formatted 0xFFFFFF
		hex = hex.Replace ("#", "");//in case the string is formatted #FFFFFF
		byte a = 255;//assume fully visible unless specified in hex
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		//Only use alpha if the string has enough characters
		if(hex.Length == 8){
			a = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		}
		return new Color32(r,g,b,a);
	}
}

public class TilePosition : IEquatable<TilePosition>{
	public int x;
	public int y;
	public int z;
	public TilePosition(int X, int Y, int Z){
		x=X;
		y=Y;
		z=Z;
	}
	public override string ToString ()
	{
		return x + ", " + y + ", " + z;
	}
	public override bool Equals(System.Object obj )
	{
		var other = obj as TilePosition;
		if( other == null ) return false;
		
		return Equals (other);             
	}
	public override int GetHashCode()
	{
		return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
	}
	public bool Equals( TilePosition other )
	{
		if (other.x == this.x && other.y == this.y && other.z == this.z) {
			return true;
		}
		return false;
		
	}
}
