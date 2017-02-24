using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster{

	public enum Action {Tidy, Rest, EndTurn, EndGame};


	public Action Bowl (int pins){
		if(pins == 10){
			return Action.EndTurn;
		} else return Action.Tidy;
	}
}
