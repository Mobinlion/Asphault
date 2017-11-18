using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initiateAPP : MonoBehaviour {

	private GameObject MainMap = null;
	private GameObject MainCanvas = null;
	private RectTransform backgroundImageRect = null;
	public Texture img;
	private int screenW, screenH;

	private List<Vector2> latLongVector = new List<Vector2> ();

	// Use this for initialization
	void Start () {

		if (MainMap == null) {
			MainMap = GameObject.Find ("Map");
			MainCanvas = GameObject.Find ("MainCanvas");
			screenW = Screen.width;
			screenH = Screen.height;
			backgroundImageRect = GameObject.Find ("backgroundImage").GetComponent<RectTransform> ();
			backgroundImageRect.sizeDelta = new Vector2 (screenW, screenH);

			LanguageCanvas.SetActive (false);
			FaqCanvas.SetActive (false);
			EmergencyCanvas.SetActive (false);
		}



		//GameObject.Find ("mapIcon").GetComponent<RectTransform> ().position = new Vector3 ((screenW*20)/100 * -1, (screenW*5)/100, 0);
		//GameObject.Find ("faqIcon").GetComponent<RectTransform> ().localPosition = new Vector3 (-50, 50, 0);




		//can disable map here
		if (MainMap != null)
			MainMap.SetActive (false);

	
//		foreach (OnlineMapsMarker marker in OnlineMaps.instance.markers) {
//
//			Debug.Log(marker.enabled);
//		}


		//better to delete all markers and add markers when user clicks on button and save their info...

		latLongVector.Add (new Vector2 (0, 0));
	}
	
	// Update is called once per frame
	void Update () {

		//it may not be required to set the screen size or backgroundimage size everytime cos we are not supporting the landscape mode
		if (screenW != Screen.width || screenH != Screen.height) {
			screenW = Screen.width;
			screenH = Screen.height;
			if(MainCanvas.activeSelf)
				backgroundImageRect.sizeDelta = new Vector2 (screenW, screenH);
			}

		}


	void OnGUI()
	{
		//how to change skin color of gui.button programmatically
//		if (GUI.Button (new Rect (0, 0, 150, 150), img))
//			Debug.Log ("clicked");

	}


	public void testing(string text)
	{
		Debug.Log (text);

	}




	public void mapIconEvent()
	{

		MainMap.SetActive (true);
		MainCanvas.SetActive (false);

		if(MapCanvasScript.MapCanvas)
		MapCanvasScript.MapCanvas.SetActive (true);

	}


	//faqicon event
	public GameObject FaqCanvas;
	public void faqIconEvent()
	{

		MainCanvas.SetActive (false);
		FaqCanvas.SetActive (true);
		
	}


	public void faqCanvasBackButton()
	{
		FaqCanvas.SetActive (false);
		MainCanvas.SetActive (true);
	}


	//language canvas event
	public GameObject LanguageCanvas;

	public void languagePartner()
	{
		MainCanvas.SetActive (false);
		LanguageCanvas.SetActive (true);

	}

	//languagepartner event backbutton
	public void languagePartnerBackButton()
	{
		LanguageCanvas.SetActive (false);
		MainCanvas.SetActive (true);
	}

	public GameObject EmergencyCanvas;
	public void Emergency()
	{
		
		MainCanvas.SetActive (false);
		EmergencyCanvas.SetActive (true);
	}

	public void EmergencyCanvasBackButton()
	{
		EmergencyCanvas.SetActive (false);
		MainCanvas.SetActive (true);
	}


}
