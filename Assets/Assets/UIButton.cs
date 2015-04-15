using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;
using System.Collections.Specialized;
using System.Text;

[HideInInspector]
public class UIButton : MonoBehaviour {
	public GameObject Can1;
	public bool flag1 = false;
	public GameObject Can2;
	public GameObject Con;
	public GameObject plane;
	public GameObject camplane;
	public GameObject Can3;
	public GameObject Can4;
	public GameObject Up;
	public Text OP;
	public Text Other;
	public GameObject Back;
	public Camera mainCamera;
	
	public void OnClic()
	{
		Can1.SetActive (false);
		GameObject.FindGameObjectWithTag("map").SetActive(false);
		mainCamera.transform.position=new Vector3(10,5,-10);
		Can2.SetActive (true);
		Con.SetActive (true);
		plane.SetActive (true);
	}
	public void Ctou()
	{
		Back.SetActive (true);
		Can2.SetActive (false);
		//Con.SetActive (false);
		plane.SetActive (false);
		Up.SetActive (true);
		GameObject.FindGameObjectWithTag ("MainController").SendMessage ("SetTexture", GameObject.FindGameObjectWithTag ("MainController").GetComponent<PhoneCamera> ().Snap);
		GameObject.FindGameObjectWithTag ("MainController").SendMessage ("SetFalse", true);
		Debug.Log ("Gosho");
	}
	public void OfCOnU()
	{
		Can3.SetActive (true);
	}
	public void TakePicture(){
		GameObject.FindGameObjectWithTag ("MainController").SendMessage ("SetTrue", true);
		Debug.Log ("bgbnnn");
	}
	public void OP1()
	{
		Can3.SetActive (false);
		OP.text = "LOGGING";
	}
	public void OP2()
	{
		Can3.SetActive (false);
		OP.text = "WILDFIRE";
	}
	public void OP3()
	{
		Can3.SetActive (false);
		OP.text = "CONSTRUCTION";
	}
	public void OP4()
	{
		Can3.SetActive (false);
		OP.text = "AGRICULTURAL EXPANSION";
	}
	public void OP5()
	{
		Can3.SetActive (false);
		Can4.SetActive (true);
	}
	public void OP6()
	{
		Can4.SetActive (false);
		OP.text =" " + Other.text;
	}
	public void submit(){
		using (var client = new WebClient())
		{
			var values = new NameValueCollection();
			values["queryType"] = "1";
			values["desc"] = Other.text;
			values["xCoord"] = Input.location.lastData.latitude+"";
			values["yCoord"] = Input.location.lastData.longitude+"";
			values["reasons"]= Other.text;
			var response = client.UploadValues("http://localhost/NASA/Server.php", values);
			//Debug.Log(response);
			var responseString = Encoding.Default.GetString(response);
				
			var response2 = client.UploadFile("http://localhost/NASA/Server.php",  "POST", Application.persistentDataPath +
			                                  "/my_image.png");

			Debug.Log("assssssssss");
		}
	}
	IEnumerator Start()
	{
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;
		
		// Start service before querying location
		Input.location.Start();
		
		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}
		if (maxWait < 1)
		{
			print("Timed out");
			yield break;
		}
	}
	void Update(){
		//OP = GameObject.FindGameObjectWithTag("Con") as Text;
	}
}