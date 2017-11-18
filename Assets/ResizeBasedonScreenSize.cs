using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBasedonScreenSize : MonoBehaviour {

	private int screenW, screenH;
	// Use this for initialization
	void Start () {

		screenW = Screen.width;
		screenH = Screen.height;
		if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight || 
			Screen.orientation == ScreenOrientation.Landscape)
			GameObject.Find ("hustIcon").GetComponent<RectTransform> ().sizeDelta =  new Vector2(Screen.width / 5, Screen.height/3);
		else if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown)
			GameObject.Find ("hustIcon").GetComponent<RectTransform> ().sizeDelta =  new Vector2(Screen.width / 3, Screen.height/5);

		GameObject.Find ("mapIcon").GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 3, Screen.height / 5);
		GameObject.Find ("faqIcon").GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 4, Screen.height / 8);
		//GameObject.Find ("hustIcon").GetComponent<RectTransform> ().localScale = new Vector3 ((Screen.width * .1f / 100)+1, (Screen.height * .1f / 100)+1, 1);
	}
	
	// Update is called once per frame
	void Update () {

		if (screenW != Screen.width || screenH != Screen.height) {
			screenW = Screen.width;
			screenH = Screen.height;
			if (Screen.orientation == ScreenOrientation.LandscapeLeft || Screen.orientation == ScreenOrientation.LandscapeRight ||
			    Screen.orientation == ScreenOrientation.Landscape)
				GameObject.Find ("hustIcon").GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 5, Screen.height / 3);
			else if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
				GameObject.Find ("hustIcon").GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 3, Screen.height / 5);
				GameObject.Find ("mapIcon").GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 4, Screen.height / 8);
				GameObject.Find ("faqIcon").GetComponent<RectTransform> ().sizeDelta = new Vector2 (Screen.width / 4, Screen.height / 8);
			}
		}
	}
}
