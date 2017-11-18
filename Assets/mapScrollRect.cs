using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapScrollRect : MonoBehaviour {

	private int counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButtonDown (0) && MapCanvasScript.mapScroll) {
			
				if (MapCanvasScript.mapScroll.activeSelf) {
				Rect mapRect = new Rect (transform.position.x, transform.position.y, GetComponent<RectTransform> ().sizeDelta.x * ScreenScale.x,
					GetComponent<RectTransform> ().sizeDelta.y * ScreenScale.y + 80);

				//getting half of height
				float tesla = (GetComponent<RectTransform> ().sizeDelta.y * ScreenScale.y) / 2;

				//finding absolute center point
				mapRect.center = new Vector2 (transform.position.x, (tesla + transform.position.y) - 60);

				if (!mapRect.Contains (Input.mousePosition)) {
					MapCanvasScript.mapScroll.SetActive (false);
					Debug.Log ("outside");
					GameObject.Find ("mapHamburgerButton").GetComponent<Button> ().interactable = true;
				}
//							else if(mapRect.Contains(Input.GetTouch(0).position))
//								MapCanvasScript.mapScroll.SetActive(false);
				else
					Debug.Log ("inside" + counter++);
						}
		
		}
	}





	//CanvasScaler scales the canvas first by doing, canvas height/reference height then multiplying it by reference width, given match
	//of width to height is at 0 for width.
	//then step 1 is over...
	//step 2 consists of screen.height being divided by the new canvas height which is gotten from step 1, then we get a ratio, this ratio
	//can be used to multiply with height of any ui element or object or rect ( for mouse click even) to proportionatelly resize it
	//and for width same must be done...


	private CanvasScaler canvasScaler;
	private Vector2 ScreenScale
	{
		get
		{
			if (canvasScaler == null) {
				canvasScaler = GetComponentInParent<CanvasScaler> ();
			}

			if (canvasScaler) {
				return new Vector2 (Screen.width / MapCanvasScript.MapCanvas.GetComponent<RectTransform> ().sizeDelta.x,
					Screen.height / MapCanvasScript.MapCanvas.GetComponent<RectTransform> ().sizeDelta.y);
			}
			else
			{
				return Vector2.one;
			}

		}

	}

//	private CanvasScaler canvasScaler;
//	private Vector2 ScreenScale
//	{
//		get
//		{
//			if (canvasScaler == null)
//			{
//				canvasScaler = GetComponentInParent<CanvasScaler>();
//			}
//
//			if (canvasScaler)
//			{
//								return new Vector2(  (Screen.width/ canvasScaler.referenceResolution.x) * canvasScaler.referenceResolution.x,  (Screen.height / canvasScaler.referenceResolution.y) * canvasScaler.referenceResolution.x);
//			}
//			else
//			{
//				return Vector2.one;
//			}
//		}
//	}


}
