using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarhideExecute : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.fullScreen = false;

		// Makes the status bar and navigation bar visible over the content, but a bit transparent
		//StatusBarHide.statusBarState = StatusBarHide.navigationBarState = StatusBarHide.States.TranslucentOverContent;
		StatusBarHide.statusBarState = StatusBarHide.States.Visible;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



}

