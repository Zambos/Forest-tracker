using UnityEngine;
using System.Collections;
using System.Runtime;
//using System.Drawing;
using System.ComponentModel;
public class PhoneCamera : MonoBehaviour
{
	public WebCamTexture mCamera = null;
	public GameObject plane;
	bool flag = false;
	//public Texture2D snap;
	public Texture2D texture;
	private int requestedHeight; 
	private int requestedWidth; 
	public int requestedFPS;
	public Quaternion baseRotation;
	public float rotAngle = 0;
	public Texture2D snap2;
	public Vector2 pivotPoint;
	public Texture2D snap;
	private Transform orientationMarker;
	// Use this for initialization
	void Start ()
	{
		Debug.Log (requestedWidth + "  " + Screen.width);
		//WebCamDevice[] devices = WebCamTexture.devices;
		Debug.Log ("Script has been started");
	//	Debug.Log (devices [0]);
		//plane = GameObject.FindWithTag ("Player");
		mCamera = new WebCamTexture (requestedWidth,requestedHeight,requestedFPS);
		plane.GetComponent<Renderer>().material.mainTexture = mCamera;
		baseRotation = transform.rotation;
		mCamera.Play ();
	}
	void Update(){
		if (flag == true) {
			TakePicture ();
		}
	}
	public void TakePicture(){
		Debug.Log ("bgbg");
		snap = new Texture2D(mCamera.width, mCamera.height);
		snap.SetPixels(mCamera.GetPixels());
		snap.Apply();
		//snap2=Sprite.Create (snap, new Rect (50, 50, 100, 100), new Vector2 (0.5f, 0.5f));
		System.IO.File.WriteAllBytes(Application.persistentDataPath +
			"/my_image.png",
			snap.EncodeToPNG());
		Debug.Log (Application.persistentDataPath +
						"/my_image.png");
		flag = false;
	}
	public Texture2D Snap
	{
		get { return snap; }
		set
		{
			snap=value;
		}
	}
	void SetTrue(bool value){
		flag = value;
		
	}
	// Update is called once per frame

		/*	public static Image RotateImage(Image img, float rotationAngle)
	{
		//create an empty Bitmap image
		Bitmap bmp = new Bitmap(img.Width, img.Height);
		
		//turn the Bitmap into a Graphics object
		Graphics gfx = Graphics.FromImage(bmp);
		
		//now we set the rotation point to the center of our image
		gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
		
		//now rotate the image
		gfx.RotateTransform(rotationAngle);
		
		gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
		
		//set the InterpolationMode to HighQualityBicubic so to ensure a high
		//quality image once it is transformed to the specified size
		gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
		
		//now draw our new image onto the graphics object
		gfx.DrawImage(img, new Point(0, 0));
		
		//dispose of our Graphics object
		gfx.Dispose();
		
		//return the image
		return bmp;
	}*/
}