using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
	public Text pinText;

    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		pinText.text = CountStanding ().ToString ();

        if (ballEnteredBox){        // if ball has entered the box
            CheckStanding();

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
		Debug.Log ("Renew Pins");
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

    void CheckStanding (){
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
            lastStandingCount = -1; // reset lastStandingcount
            ballEnteredBox = false; // reset ball enter box status.
            PinsHaveSettled();
            ball.Reset();
        }
  
    }

    void PinsHaveSettled() {
        pinText.color = Color.green;

    }

    void OnTriggerExit (Collider collider){
        GameObject thingLeftBox = collider.gameObject;
        if (thingLeftBox.GetComponent<Pin>())
        {
            Destroy(thingLeftBox);
        } 
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
