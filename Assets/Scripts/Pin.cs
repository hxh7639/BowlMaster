using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold;

	// Use this for initialization
	void Start () {
		
	}

	public bool isStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(rotationInEuler.x);
		float tiltInY = Mathf.Abs(rotationInEuler.y);

		if (tiltInX <= standingThreshold) {
			return true;
		} else if (tiltInX <= standingThreshold) {
			return true;
		} else {
			return false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
