using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text pinText;

	private GameManager gameManager;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
    private float lastChangeTime;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		pinText.text = CountStanding ().ToString ();
		if (ballOutOfPlay){        // if ball has entered the box
			pinText.color = Color.yellow;
			UpdateSettledPinCount();
        }
	}

	public void Reset(){
		lastSettledCount = 10;

	}

	void OnTriggerExit (Collider collider){
		if (collider.gameObject.name == "Ball") {
			ballOutOfPlay = true;
		}
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

    	gameManager.Bowl(pinsFallen);

		lastStandingCount = -1; // reset lastStandingcount
		ballOutOfPlay = false; // reset ball enter box status.
      pinText.color = Color.green;

    }




}
