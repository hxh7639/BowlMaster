using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold;
	public float distToRaise = 40f;

	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {

	}

	public void RaiseIfStanding(){
		if (IsStanding()) {
			rigidBody.useGravity = false;
			rigidBody.velocity = Vector3.zero; // I added to stop the pins from moving
			rigidBody.angularVelocity = Vector3.zero; // I added to stop the pins from moving
			transform.Translate (new Vector3(0,distToRaise,0), Space.World);  // transform.positon += supposed to work as well
		}
	}

	public void Lower (){
		if (IsStanding()) {
			transform.Translate (new Vector3(0,-distToRaise,0), Space.World);  // transform.positon += supposed to work as well
			rigidBody.useGravity = true;
		}
	}

	public bool IsStanding(){
		Vector3 greenVector = transform.forward;
		float standThreshold = standingThreshold / 10;
		float x = Mathf.Abs (greenVector.x);
		float z = Mathf.Abs (greenVector.z);
		if (x < standThreshold && z < standThreshold) {
			return true;
		} else {
			return false;
		}

}
	



}
