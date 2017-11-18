using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hustAddMarkerGPS : MonoBehaviour {


//	public Texture2D hustGPSTexture = null;
//	private OnlineMapsMarker playerMarker;
//	private Vector2 oldPosition = Vector2.zero;
//	private Vector2 newPosition = Vector2.zero;
//	private bool coroutineStarted = false;
//	private int locationCounter = 0;
//
//	// Use this for initialization
//	void Start () {
//		// Create a new marker.
//		playerMarker = OnlineMaps.instance.AddMarker(new Vector2(0, 0), hustGPSTexture);
//
//
//		// Get instance of LocationService.
//		OnlineMapsLocationService locationService = OnlineMapsLocationService.instance;
//		playerMarker.enabled = false;
//
////		if (locationService == null)
////		{
////			
//////			Debug.LogError(
//////				"Location Service not found.\nAdd Location Service Component (Component / Infinity Code / Online Maps / Plugins / Location Service).");
//////			return;
////		}
//
//		// Subscribe to the change location event.
//		locationService.OnLocationChanged += OnLocationChanged;
//	}
//	
//	private void OnLocationChanged(Vector2 position)
//	{
//		if (playerMarker.position != Vector2.zero)
//			playerMarker.enabled = true;
//		
//		//playerMarker.position = position;
//
//		switch (locationCounter) {
//
//		case 0:
//			newPosition = position;
//			locationCounter++;
//			Debug.Log ("lolz1");
//			break;
//		case 1:
//			oldPosition = newPosition;
//			newPosition = position;
//			locationCounter++;
//			Debug.Log ("lolz2");
//			break;
//		default:
//			Debug.Log ("lolz3");
//			break;
//
//		}
//
//		OnlineMaps.instance.Redraw ();
//
//
//		if (!coroutineStarted && locationCounter == 2) {
//			StartCoroutine (moveGPS ());
//			coroutineStarted = true;
//		}
//
//
//	}
//
//
//	public float time = 2;
//	private float angle;
//
//	IEnumerator moveGPS()
//	{		
//
//		Debug.Log ("lolzmovegpsstarted");
//		while (angle < 1) {
//			angle += Time.deltaTime;
//
////			if (angle > 1)
////				angle = 1;
//			playerMarker.position = Vector2.Lerp (oldPosition, newPosition, angle);
//
//		}
//		Debug.Log ("lolzmovegpsended");
//		locationCounter = 0;
//		angle = 0;
//		coroutineStarted = false;
//		yield break;
//
//	}

}
