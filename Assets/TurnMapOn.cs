using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMapOn : MonoBehaviour {
	private GameObject MapMain = null;
	public Texture t1;
	public void ToggleMap()
	{
		if (MapMain == null) {

			MapMain = GameObject.Find ("Map");
		}
		MapMain.SetActive (true);
		//GameObject.Find ("M1").SetActive (true);
		GameObject.Find ("Canvas_User").SetActive (false);
		//GameObject.Find ("EventSystem_User").SetActive (false);
			}

	public void ToggleMap_()
	{
		if (MapMain != null)
			MapMain.SetActive (false);
			}

	void OnGUI()
	{
		if(GUI.Button(new Rect(0,0, 250,250), "Turn map on"))
			MapMain.SetActive(true);

		if (GUI.Button (new Rect (250, 0, 350, 350), t1))
			;
			
	}
}
