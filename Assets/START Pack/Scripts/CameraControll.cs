using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

	public Ball ball;

	private Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = ball.rigidbody  // offset is ball position - 20 in Y direction

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate
	}


}
