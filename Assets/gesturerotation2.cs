using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gesturerotation2 : MonoBehaviour {

    bool rotating;
    Vector2 startVector;
    float rotGestureWidth;
    float rotAngleMinimum;
    Quaternion deltav;
    private Quaternion m_OriginalRotation;
	// Use this for initialization
	void Start () {
        rotGestureWidth = 0.0f;
        rotAngleMinimum = 0.0f;
        m_OriginalRotation = transform.rotation;
	}
	

 
void Update () {
    //transform.rotation = m_OriginalRotation;
    if (Input.touchCount == 2) {
        if (!rotating) {
            startVector = Input.GetTouch(1).position - Input.GetTouch(0).position;
            rotating = startVector.sqrMagnitude > rotGestureWidth * rotGestureWidth;
        } else {
            var currVector = Input.GetTouch(1).position - Input.GetTouch(0).position;
            var angleOffset = Vector2.Angle(startVector, currVector);
            var LR = Vector3.Cross(startVector, currVector);
           
            if (angleOffset > rotAngleMinimum) {
                if (LR.z > 0) {
                    transform.rotation = transform.rotation * Quaternion.Euler(0.0f, 0.0f, -angleOffset);
                    // Anticlockwise turn equal to angleOffset.
                } else if (LR.z < 0) {
                         //if(deltav.z>360)
                        //deltav.z = 0;
                    //GameObject.Find("tlt").GetComponent<Text>().text = "angleoffset.z : " + Quaternion.Euler(0.0f, 0.0f, angleOffset).z.ToString();
                    transform.rotation = m_OriginalRotation * Quaternion.Euler(0.0f, 0.0f, angleOffset);
                    //GameObject.Find("tlt2").GetComponent<Text>().text = "camera.z : " + transform.rotation.z.ToString();
                    // Clockwise turn equal to angleOffset.
                }
            }
           
        }
       
    } else {
        rotating = false;
    }
}
}
