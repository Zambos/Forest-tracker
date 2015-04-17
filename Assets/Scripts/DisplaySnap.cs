using UnityEngine;
using System.Collections;

public class DisplaySnap : MonoBehaviour {
	public Texture2D texture;
	public Texture photo;
	public bool ff;
	void Start(){
//		texture = GetComponent<PhoneCamera> ();
		//ff = GetComponent<UIButton> ();
		//Debug.Log (ff);
	}
	void OnGUI(){
		Debug.Log (ff);
		bool flag2 = ff;
		/*if (flag2){
			GUI.DrawTexture (new Rect (Screen.width*0.05f,Screen.height*0.05f,Screen.width*0.8f,Screen.height*0.35f), texture);

		}*/
	}
	void SetTexture(Texture2D karpa){
		texture = karpa;
	}

	void SetFalse(bool value){
		ff = value;
		
	}
	//public byte[] Snap;
	/*public Texture2D snap;
	public Renderer rend;
	//public WWW www1 = new WWW ("file:///" + Application.persistentDataPath + "/my_imakge.png");
	public WWW www = new WWW ("file:///" + Application.persistentDataPath + "/my_image.png");
	// Use this for initialization
	void OnGUI(){
		Debug.Log ("bggb");
		GUI.DrawTexture (new Rect (Screen.width*0.05f,Screen.height*0.05f,Screen.width*0.8f,Screen.height*0.35f), www.texture);
		
	}
	IEnumerator Img () {
		//Snap.GetComponent<PhoneCamera> ();

 		//snap=System.IO.File.ReadAllBytes (Application.persistentDataPath + "/my_image.png");
//		snap = Resources.Load("C:/Users/Chelsea/AppData/LocalLow/fire/ForestTracker/my_image.png") as Texture2D;

		yield return www;
		rend.material.mainTexture = www.texture;
		Debug.Log ("hghgh");
		/*rend.material.mainTexture = new Texture2D (4, 5, TextureFormat.DXT1, false);
		while (true) {
			WWW www = new WWW (Application.persistentDataPath + "/my_image.png");
			yield www;
			www.LoadImageIntoTexture(rend.material.mainTexture);
		}
	}*/

	// Update is called once per frame
	/*void Update () {
	
	}*/
}
