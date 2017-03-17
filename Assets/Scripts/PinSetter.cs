using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;

	public ActionMaster actionMaster = new ActionMaster(); // we need it on the top level because we only want one actionMaster. 

	private Animator animator;
	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	
	// Update is called once per frame
	void Update () {

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

	public void PerformAction (ActionMaster.Action action){
		if(action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");
		} else if(action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		} else if(action == ActionMaster.Action.Reset){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();		
			}  else if(action == ActionMaster.Action.EndGame){
			throw new UnityException("Don't know how to handle end game");
		}
	}

}
