using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSTESTMINE : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		StartCoroutine (tester ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator tester()
	{
		
			GameObject.Find ("counter").GetComponent<Text> ().text = "inside";  
			// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser) {
			
			GameObject.Find ("lat").GetComponent<Text> ().text = "lat not enabled by user: ";

		}

			// Start service before querying location
			Input.location.Start (10.0f, 1f);

			// Wait until service initializes
			int maxWait = 20;
			while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
				
				maxWait--;
			GameObject.Find ("lat").GetComponent<Text> ().text = "Main Initializing: ";
			yield return new WaitForSeconds (1);
			}

			// Service didn't initialize in 20 seconds
			if (maxWait < 1) {
			GameObject.Find ("lat").GetComponent<Text> ().text = "lat timed out: ";
				yield return new WaitForSeconds (2);
			}

			// Connection has failed
		while (true) {
			if (Input.location.status == LocationServiceStatus.Failed) {
				GameObject.Find ("lat").GetComponent<Text> ().text = "lat Failed: ";     
				GameObject.Find ("long").GetComponent<Text> ().text = "long Failed: "; 

			} else if (Input.location.status == LocationServiceStatus.Initializing) {
				GameObject.Find ("lat").GetComponent<Text> ().text = "lat Initializing: ";     
				GameObject.Find ("long").GetComponent<Text> ().text = "long Initializing: "; 
			} else if (Input.location.status == LocationServiceStatus.Running) {
				// Access granted and location value could be retrieved
				//print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
				GameObject.Find ("lat").GetComponent<Text> ().text = "lat Running: " + Input.location.lastData.latitude.ToString ();     
				GameObject.Find ("long").GetComponent<Text> ().text = "long Running: " + Input.location.lastData.longitude.ToString ();  
			} else if (Input.location.status  == LocationServiceStatus.Stopped) {
				GameObject.Find ("lat").GetComponent<Text> ().text = "lat Stopped: ";     
				GameObject.Find ("long").GetComponent<Text> ().text = "long Stopped: "; 
			}
			yield return new WaitForSeconds (0.5f);
		}

			// Stop service if there is no need to query location updates continuously
			Input.location.Stop ();
			
		}
	}