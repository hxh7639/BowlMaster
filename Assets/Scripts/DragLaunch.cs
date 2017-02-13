using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 launchVelocity;
	private Vector3 swipPositionStart;
	private Vector3 swipPositionEnd;
	private float swipTimeStart;
	private float swipTimeEnd;

	// Use this for initialization
	void Start () {
	ball = GetComponent<Ball>();
		
	}

	public void DragStart(){
	swipPositionStart = Input.mousePosition;
	swipTimeStart = Time.time;

	}

	public void DragEnd(){
	swipPositionEnd = Input.mousePosition;
	swipTimeEnd = Time.time;

	launchVelocity.x = swipPositionEnd.x - swipPositionStart.x;
	launchVelocity.z = (swipPositionEnd.y - swipPositionStart.y) / (swipTimeEnd - swipTimeStart);


	ball.Launch(launchVelocity);
	}


		

}
