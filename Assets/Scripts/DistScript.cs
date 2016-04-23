using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistScript : MonoBehaviour {
	//Distance from former to current position
	float distanceTraveled = 0;

	//Last Position
	Vector3 lastPosition;

	//Text to be displayed
	public Text distext;

	// Use this for initialization
	void Start () {
		lastPosition = transform.position;
		distext.text = "Distance (ft) : " + distanceTraveled;
	}

	// Update is called once per frame
	void Update () {
		distext.text = "Distance (ft) : " + distanceTraveled;
		distanceTraveled = Vector3.Distance(transform.position, lastPosition)/10;
	}

	/*
   void OnGUI(){
       GUI.Label (new Rect (200, 100, 300, 300), distext);
   }
   */
}
