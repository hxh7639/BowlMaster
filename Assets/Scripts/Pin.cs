using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold;

	// Use this for initialization
	void Start () {
		
	}

	public bool IsStanding(){
		Vector3 greenVector = transform.up;
		float standThreshold = standingThreshold / 10;
		float x = Mathf.Abs (greenVector.x);
		float z = Mathf.Abs (greenVector.z);
		if (x < standThreshold && z < standThreshold) {
			return true;
		} else {
			return false;
		}

}
	
	// Update is called once per frame
	void Update () {

	}
}
