using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MapCanvasScript : MonoBehaviour {


	public static GameObject MapCanvas = null;
	private int screenW, screenH;
	public static GameObject mapScroll = null;  //change this later
	private GameObject hustRouteObject = null;
	private RectTransform mapImageRect = null;

	//public gameobjects
	public GameObject mainMap = null;
	public GameObject mainCanvas = null;




	private string[] hustCoords;
	private string[] hustLabel;


	//mapscroll xy coords
	private float mapScrollX;
	private float mapScrollY;
	private float mapScrollHeight;
	private float mapScrollWidth;


	//list of markers
	private List<OnlineMapsMarker> hustMarkers = new List<OnlineMapsMarker>();

	// Use this for initialization
	void Start () {


		if (MapCanvas == null) {
			MapCanvas = GameObject.Find ("MapCanvas");
			mapScroll = GameObject.Find ("mapScroll");
			hustRouteObject = GameObject.Find ("RouteCanvas");

		}

		screenW = Screen.width;
		screenH = Screen.height;
		mapImageRect = GameObject.Find ("mapImage").GetComponent<RectTransform> ();
		mapImageRect.sizeDelta = new Vector2 (screenW + 100, 64);
		mapScroll.SetActive (false);
		MapCanvas.SetActive (false);
		hustRouteObject.SetActive (false);



		//set dynamic map size for different screen sizes
//		int ow = screenW % 256;
//		int oh = screenH % 256;
//		if (ow != 0) screenW += 256 - ow;
//		if (oh != 0) screenH += 256 - oh;
//		OnlineMapsTileSetControl.instance.Resize(screenW, screenH, false);
		//set dynamic map size for different screen sizes

		mapScrollX = mapScroll.GetComponent<RectTransform> ().position.x;
		mapScrollY = mapScroll.GetComponent<RectTransform> ().position.y;
		mapScrollHeight = mapScroll.GetComponent<RectTransform> ().sizeDelta.y;
		mapScrollWidth = mapScroll.GetComponent<RectTransform> ().sizeDelta.x;


		//load coordinates resources and parse each line
		TextAsset textAsset = Resources.Load <TextAsset>("latlongHUST");
		hustCoords = textAsset.text.Split (',');

		TextAsset nameAsset = Resources.Load<TextAsset> ("locationHUST");
		hustLabel = nameAsset.text.Split ('\n');


	}

	// Update is called once per frame
	void Update () {

		if (screenW != Screen.width || screenH != Screen.height) {
			screenW = Screen.width;
			screenH = Screen.height;
			if(MapCanvas.activeSelf)
				mapImageRect.sizeDelta = new Vector2 (screenW + 100, 64);

		}




		//disable hamburger menu when user touches surrounding area
		//		if (Input.GetMouseButtonDown (0)) {
		//
		//			if (mapScroll.activeSelf) {
		//				Rect mapRect = new Rect (mapScrollX, mapScrollY, mapScrollWidth, mapScrollHeight);
		//				if (!mapRect.Contains (Input.mousePosition)) {
		//					mapScroll.SetActive (false);
		//				}
		//				else if(mapRect.Contains(Input.GetTouch(0).position))
		//					mapScroll.SetActive(false);
		//			}
		//
		//			//decimal class useful stuff
		//			//random class useful stuff
		//
		//		}

	}



	public void HamburgerEvent()
	{

		mapScroll.SetActive (true);
		GameObject.Find ("mapHamburgerButton").GetComponent<Button> ().interactable = false;

	}

	public void Building()
	{
		deleteMarkers();
		hustSearch ("Building","School","block");
		hustSearch ("Lab", "Department");
		mapScroll.SetActive (false);
		GameObject.Find ("mapHamburgerButton").GetComponent<Button> ().interactable = true;
		hustNavigation ();
		//get marker length(numbers)
		//Debug.Log (OnlineMaps.instance.markers.Length);

	}


	public void Canteen()
	{
		deleteMarkers();
		hustSearch ("Canteen", "Cafe", "Restaurant");
		mapScroll.SetActive (false);
		GameObject.Find ("mapHamburgerButton").GetComponent<Button> ().interactable = true;
		hustNavigation ();
	}

	public void Gate()
	{
		deleteMarkers();
		hustSearch ("Gate");
		mapScroll.SetActive (false);
		GameObject.Find ("mapHamburgerButton").GetComponent<Button> ().interactable = true;
		hustNavigation ();
	}

	public void Bank()
	{
		deleteMarkers();
		hustSearch ("Bank");
		mapScroll.SetActive (false);
		GameObject.Find ("mapHamburgerButton").GetComponent<Button> ().interactable = true;
		hustNavigation ();
	}


	public void Shop()
	{
		deleteMarkers();
		hustSearch ("Shop", "Print", "Hairdresser");
		hustSearch ("Supermarket", "Ji Mao", "Personal Care");
		hustSearch ("Post Office");
		mapScroll.SetActive (false);
		GameObject.Find ("mapHamburgerButton").GetComponent<Button> ().interactable = true;
		hustNavigation ();
	}

	public void Telecom()
	{
		deleteMarkers();
		hustSearch ("Unicom", "Mobile");
		mapScroll.SetActive (false);
		GameObject.Find ("mapHamburgerButton").GetComponent<Button> ().interactable = true;
		hustNavigation ();
	}



	private void hustSearch(string query, string query2="RANDOMSTRINGDETERMINED", string query3="RANDOMSTRINGDETERMINED")
	{
		for (int i = 0, j = 0; i < hustLabel.Length; i++) {

			if (hustLabel [i].Contains (query) || hustLabel[i].Contains(query2) || hustLabel[i].Contains(query3)) {
				if (i == 0) 
					hustMarkers.Add (OnlineMaps.instance.AddMarker (double.Parse (hustCoords [i + 1]), double.Parse (hustCoords [i]), hustLabel [i]));
				else
					hustMarkers.Add (OnlineMaps.instance.AddMarker (double.Parse (hustCoords [i * 2 + 1]), double.Parse (hustCoords [i * 2]), hustLabel [i]));



			}

		}

	}



	public void deleteMarkers()
	{
		for (int i = 0; i < hustMarkers.Count; i++) {
			OnlineMaps.instance.RemoveMarker (hustMarkers [i]);
		}
		hustMarkers.Clear ();
		if (hustDrawLine != null)
			OnlineMaps.instance.RemoveDrawingElement (hustDrawLine);
	}


	private OnlineMapsOpenRouteServiceDirectionResult hustTesla;
	private OnlineMapsOpenRouteServiceDirectionResult.Route [] hustTesla2; 
	private OnlineMapsDrawingLine hustDrawLine = null;
	private OnlineMapsMarkerBase hustMarker = null;
	public Toggle hustWalkObject = null;
	public Toggle hustDriveObject = null;

	public Text routeToTextTesla;
	/// <summary>
	/// Open Route Service API key
	/// </summary>
	public string key;
	private bool hustWalkingFoot = true;


	private void hustMarkerClick(OnlineMapsMarkerBase marker)
	{
		//display route window then on route we execute this code

		hustMarker = marker;
		hustRouteObject.SetActive (true);
		routeToTextTesla.text = marker.label;
		// Show in console marker label.
		Debug.Log(marker.label);
		//		Debug.Log (marker.position);
	}

	public void hustRoute()
	{

		if (OnlineMapsLocationService.instance.position != Vector2.zero) {


			OnlineMapsOpenRouteService.Directions(
				new OnlineMapsOpenRouteService.DirectionParams(key, 
					new []
					{
						// Coordinates
						//                        new OnlineMapsVector2d(8.6817521f, 49.4173462f), 
						//                        new OnlineMapsVector2d(8.6828883f, 49.4067577f)  //default
						new OnlineMapsVector2d(OnlineMapsLocationService.instance.position.x, OnlineMapsLocationService.instance.position.y), 
						new OnlineMapsVector2d(hustMarker.position.x, hustMarker.position.y)
					})
				{
					// Extra params
					language = "en",
					//profile = OnlineMapsOpenRouteService.DirectionParams.Profile.footWalking
					profile = (hustWalkingFoot)?(OnlineMapsOpenRouteService.DirectionParams.Profile.footWalking):(OnlineMapsOpenRouteService.DirectionParams.Profile.drivingCar)
				}).OnComplete += OnRequestComplete;

		}

	}

	public void hustRouteWalk(bool buttonValue)
	{

		hustDriveObject.isOn = (!buttonValue);
		hustWalkingFoot = buttonValue;
		Debug.Log ("walk: " + buttonValue);

	}


	public void hustRouteDrive(bool buttonValue)
	{

		hustWalkObject.isOn = (!buttonValue);
		hustWalkingFoot = (!buttonValue);
		Debug.Log ("car: " + buttonValue);

	}


	private void OnRequestComplete(string response)
	{
		Debug.Log(response);

		if (hustDrawLine != null)
			OnlineMaps.instance.RemoveDrawingElement (hustDrawLine);
		// Get the route steps.
		//List<OnlineMapsDirectionStep> steps = OnlineMapsDirectionStep.TryParseORS(response);

		hustTesla = OnlineMapsOpenRouteService.GetDirectionResults (response);


		// Get the route points.
		if (hustTesla == null)
		{
			//let the user know there has been an error with open route service***********************
			Debug.Log ("gods are not merciful");
			return; //make user know there is an error*******************
		}


		hustTesla2 = hustTesla.routes;
		Debug.Log (hustTesla.routes.Length);
		for (int i = 0; i < hustTesla.routes.Length; i++) {			

			List<OnlineMapsVector2d> points = hustTesla2 [i].points;

			hustDrawLine = new OnlineMapsDrawingLine (points, Color.red, 5);
			// Draw the route.
			//OnlineMaps.instance.AddDrawingElement(new OnlineMapsDrawingLine(points, Color.red));
			OnlineMaps.instance.AddDrawingElement (hustDrawLine);

			// Set the map position to the first point of route.
			OnlineMaps.instance.position = points [0];
		}
	}



	//delete hustDrawLine;

	private void hustNavigation ( )
	{
		for ( int i = 0; i < hustMarkers.Count; i++)
			hustMarkers [i].OnClick += hustMarkerClick;
	}


	public void hustArrow()
	{
		hustRouteObject.SetActive (false);		
	}

//	public void buttonClearAll()
//	{
	//		//reused deletemarkers()
//	}

	public void buttonShowAll()
	{
		for (int i = 0, j = 0; i < hustLabel.Length - 1; i++) {
			
			if (i == 0) 
				hustMarkers.Add (OnlineMaps.instance.AddMarker (double.Parse (hustCoords [i + 1]), double.Parse (hustCoords [i]), hustLabel [i]));
			else
				hustMarkers.Add (OnlineMaps.instance.AddMarker (double.Parse (hustCoords [i * 2 + 1]), double.Parse (hustCoords [i * 2]), hustLabel [i]));
			}
		hustNavigation ();
	}


	public void buttonMapCanvas()
	{
		mainMap.SetActive (false);
		MapCanvas.SetActive (false);
		mainCanvas.SetActive (true);
	}

}
