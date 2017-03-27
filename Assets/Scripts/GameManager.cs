using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> bowls = new List<int>();

	private PinSetter pinSetter;
	private Ball ball;
	private ScoreDisplay scoreDisplay;
	// Use this for initialization
	void Start () {
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		ball = GameObject.FindObjectOfType<Ball>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}
	
	public void Bowl (int pinFalls){
		try{
			bowls.Add(pinFalls);
			ball.Reset();
			pinSetter.PerformAction(ActionMasterOldCopy.NextAction(bowls));
		} catch {
			Debug.LogWarning("Something went wrong in BOWL()");
		}

		try{
		scoreDisplay.FillRollCard(bowls);
		} catch{
			Debug.LogWarning("Something went wrong in ScoreDisplay.FillRollCard");
		}


	}
}
