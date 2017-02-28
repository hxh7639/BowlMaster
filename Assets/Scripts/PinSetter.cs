using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
	public Text pinText;
	public GameObject pinSet;

    private Ball ball;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private bool ballEnteredBox = false;
    private ActionMaster actionMaster = new ActionMaster();
	private Animator animator;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		pinText.text = CountStanding ().ToString ();
		if (ballEnteredBox){        // if ball has entered the box
           	UpdateSettledPinCount();
        }
	}

	public void RaisePins (){
		// raise standing pins only by distanceToRaise
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding();
		}
	}

	public void LowerPins (){
		// Lower standing pins only by distanceToRaise
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
				pin.Lower();
		}
	}

	public void RenewPins (){
		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3 (0, 15,0);
	}

	int CountStanding(){
		int standingPinCount = 0;
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if (pin.IsStanding()) {
				standingPinCount++;
			}
		}
		return standingPinCount;
	}

    void UpdateSettledPinCount (){
        // update the lastStandingCount
        // call PinsHaveSettled() when they have
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f; // How long to wait to consider Pins settled
        if (Time.time >= (lastChangeTime + settleTime))
        {
        	PinsHaveSettled();
        }
  
    }

    void PinsHaveSettled() {
    	int standing = CountStanding();
    	int pinsFallen = lastSettledCount - standing;
    	lastSettledCount = standing;

		ActionMaster.Action action = actionMaster.Bowl(pinsFallen); // calling action = (pass in pinsFallen)and whichever enum it gets
		Debug.Log ("pins fallend" + pinsFallen + " // "+ action);

		if(action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		} else if(action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			lastSettledCount = 10;
		} else if(action == ActionMaster.Action.Reset){
			animator.SetTrigger("resetTrigger");
			lastSettledCount = 10;
		}  else if(action == ActionMaster.Action.EndGame){
			throw new UnityException("Don't know how to handle end game");
		}



		lastStandingCount = -1; // reset lastStandingcount
        ballEnteredBox = false; // reset ball enter box status.
		ball.Reset();
        pinText.color = Color.green;

    }

	void OnTriggerEnter (Collider collider) {
        GameObject thingHit = collider.gameObject;
        // ball enters play box
        if (thingHit.GetComponent<Ball>())
        {
            ballEnteredBox = true;
            pinText.color = Color.red;
        }
    }


}
