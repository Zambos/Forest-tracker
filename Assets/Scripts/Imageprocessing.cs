using UnityEngine;
using System.Collections;
using System.Net;


public class Imageprocessing:MonoBehaviour{
	void Start(){
		string remoteUri = "http://www.contoso.com/library/homepage/images/";
		string fileName = "ms-banner.gif", myStringWebResource = null;
		// Create a new WebClient instance.
		WebClient myWebClient = new WebClient();
		// Concatenate the domain with the Web resource filename.
		myStringWebResource = remoteUri + fileName;
		//Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);
		// Download the Web resource and save it into the current filesystem folder.
		myWebClient.DownloadFile(myStringWebResource,fileName);
		Debug.Log(Application.absoluteURL);
	}
}
