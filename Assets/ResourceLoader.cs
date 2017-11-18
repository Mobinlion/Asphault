using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResourceLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {

		TextAsset textAsset = Resources.Load <TextAsset>("latlongHUST");
		string[] myData = textAsset.text.Split (',');
		Debug.Log (double.Parse (myData [0]));
		Debug.Log (double.Parse (myData [1]));
		Debug.Log (double.Parse (myData [2]));
		Debug.Log (double.Parse (myData [3]));
		TextAsset nameAsset = Resources.Load<TextAsset> ("locationHUST");
		string[] myName = nameAsset.text.Split ('\n');

		Debug.Log (myName [0]);
		Debug.Log (myName [1]);
		Debug.Log (myName [2]);

		double Lat = double.Parse (myData [0]);
		double Long = double.Parse (myData [1]);
		string nameLat = myName [0];

		OnlineMaps.instance.AddMarker (0.0, 0.0, "no");

	
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
