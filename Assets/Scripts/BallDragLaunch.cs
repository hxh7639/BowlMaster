using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 launchVelocity; // course declared this in the method, only make it available to the methods that needs it, don't put everything at this level
	private Vector3 swipPositionStart;  // course decleared all the vectors together.
	private Vector3 swipPositionEnd;
	private float swipTimeStart;
	private float swipTimeEnd;

	// Use this for initialization
	void Start () {
	ball = GetComponent<Ball>();
		
	}

	public void MoveStart(float amount){  // moving ball left/right at start

		if (ball.inPlay == false){  // or normally !ball.inPlay
		ball.transform.Translate (new Vector3 (amount,0,0));
		}
	}



	public void DragStart(){
	swipPositionStart = Input.mousePosition;
	swipTimeStart = Time.time;

	}

	public void DragEnd(){
	//if (ball.inPlay == false){    to stop launching ball during play
	swipPositionEnd = Input.mousePosition;
	swipTimeEnd = Time.time;
	float swipDuration = swipTimeEnd - swipTimeStart;

	// launchVelocity.x = swipPositionEnd.x - swipPositionStart.x;   // game used speed formula for x as well.
	launchVelocity.x = ((swipPositionEnd.x - swipPositionStart.x) / swipDuration)/5; // look at course codes BM 195
	launchVelocity.z = ((swipPositionEnd.y - swipPositionStart.y) / swipDuration)/2; // course made (timeEnd - timeStart) into a separate variable just in this method


	ball.Launch(launchVelocity);
	}


		

}
