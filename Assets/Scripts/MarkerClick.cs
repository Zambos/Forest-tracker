using UnityEngine;
using System.Collections;

public class MarkerClick : MonoBehaviour {
	public GameObject Canvas;
	void Update(){
		if (Input.touchCount > 0){
			//Canvas.SetActive(false);
			//Debug.Log (Input.touchCount);
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).deltaPosition);
			//Transform marker = GameObject.FindWithTag("marker").transform;
			if(Physics.Raycast (ray, out hit, 100.0f))
				Debug.Log (hit.collider.tag);
					if(hit.collider.tag == "marker")
						Canvas.SetActive(false);
		}
	}
}
