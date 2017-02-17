using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text pinText;

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

	void OnTriggerEnter (Collider collider) {

	}
}
