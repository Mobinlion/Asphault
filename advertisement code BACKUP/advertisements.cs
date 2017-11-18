using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class advertisements : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Advertisement.Initialize ("1379644");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void onGUI()
	{
		if (GUI.Button (new Rect (0, 0, 100, 100), "ADS!"))
			//Advertisement.Show ();
			ShowRewardedVideo();

	}


	void ShowRewardedVideo ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show("rewardedVideo", options);
	}

	void HandleShowResult (ShowResult result)
	{
		if(result == ShowResult.Finished) {
			Debug.Log("Video completed - Offer a reward to the player");

		}else if(result == ShowResult.Skipped) {
			Debug.LogWarning("Video was skipped - Do NOT reward the player");

		}else if(result == ShowResult.Failed) {
			Debug.LogError("Video failed to show");
		}
	}
}
