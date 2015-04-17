using UnityEngine;
using System.Collections;

public class MarkerClick : MonoBehaviour {
	bool flag = false;

	void Clicked(bool value){
		flag = value;
	}
	void Update(){
		if (flag == true) {
			Debug.Log ("Gosho");
			flag = false;
		}
	}
}
