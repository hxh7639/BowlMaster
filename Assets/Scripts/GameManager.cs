using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int>();

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
			rolls.Add(pinFalls);
			ball.Reset();
			pinSetter.PerformAction(ActionMasterOldCopy.NextAction(rolls));
		} catch {
			Debug.LogWarning("Something went wrong in BOWL()");
		}

		try{
		scoreDisplay.FillRollCard(rolls);
		scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
		} catch{
			Debug.LogWarning("Something went wrong in ScoreDisplay.FillRollCard");
		}


	}
}
