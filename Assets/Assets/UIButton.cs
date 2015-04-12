using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;
using System.Collections.Specialized;
using System.Text;

[HideInInspector]
public class UIButton : MonoBehaviour {
	public GameObject Can1;
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
		Con.SetActive (false);
		plane.SetActive (false);
		Up.SetActive (true);

	}
	public void OfCOnU()
	{
		Can3.SetActive (true);
		
	}
	public void OP1()
	{
		Can3.SetActive (false);
		//OP.text = "Selected Reason:OP1";
	}
	public void OP2()
	{
		Can3.SetActive (false);
		//OP.text = "Selected Reason:OP2";
	}
	public void OP3()
	{
		Can3.SetActive (false);
		//OP.text = "Selected Reason:OP3";
	}
	public void OP4()
	{
		Can3.SetActive (false);
		//OP.text = "Selected Reason:OP4";
	}
	public void OP5()
	{
		Can3.SetActive (false);
		Can4.SetActive (true);
	}
	public void OP6()
	{
		Can4.SetActive (false);
		OP.text = "Selected Reason:" + Other.text;
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
			var response = client.UploadValues("http://forestwatch.comli.com/server.php", values);
			var responseString = Encoding.Default.GetString(response);
				
			var response2 = client.UploadFile("http://forestwatch.comli.com/server.php",  "POST", Application.persistentDataPath +
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