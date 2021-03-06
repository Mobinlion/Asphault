﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;
using System.Collections.Generic;






[RequireComponent(typeof(Button))]
public class AdsUnityExample : MonoBehaviour
{
	//---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//

	#if UNITY_IOS
	private string gameId = "1486551";
	#elif UNITY_ANDROID
	private string gameId = "1486550";
	#endif

	//-------------------------------------------------------------------//
	ColorBlock newColorBlock = new ColorBlock();
	public Color green = new Color(0.1F, 0.8F, 0.1F, 1.0F);
	Button m_Button;

	public string placementId = "rewardedVideo";

	void Start ()
	{    
		m_Button = GetComponent<Button>();
		if (m_Button) m_Button.onClick.AddListener(ShowAd);

		if (Advertisement.isSupported) {
			Advertisement.Initialize (gameId, true);
		}

		//---------- ONLY NECESSARY FOR ASSET PACKAGE INTEGRATION: ----------//

		if (Advertisement.isSupported) {
			Advertisement.Initialize (gameId, true);
		}

		//-------------------------------------------------------------------//

	}

	void Update ()
	{
		if (m_Button) m_Button.interactable = Advertisement.IsReady(placementId);
	}

	void ShowAd ()
	{
		ShowOptions options = new ShowOptions();
		options.resultCallback = HandleShowResult;

		Advertisement.Show(placementId, options);
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