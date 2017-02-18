using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text pinText;
    private bool ballEnteredBox = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		pinText.text = CountStanding ().ToString ();

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
