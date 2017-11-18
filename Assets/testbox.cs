using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testbox : MonoBehaviour {

	public int test = 0;
	// Use this for initialization
	IEnumerator Start () {
		for( int i = 0; i<3; i++) {
			GameObject.Find ("counter").GetComponent<Text> ().text = (test++).ToString ();
			yield return new WaitForSeconds (1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public string stringToEdit = "hello world";
	void OnGUI(){
		stringToEdit = GUI.TextField (new Rect (100, 100, 200, 200), stringToEdit, 250);
	}
}
