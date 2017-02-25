﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster{

	public enum Action {Tidy, Rest, EndTurn, EndGame};

	// private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl (int pins){

		if (pins < 0 || pins > 10) {
			throw new UnityException ("Not sure what to return!");
		}

		// Other behaviour, e.g. last frame

		if (pins == 10) {
            bowl += 2;
            return Action.EndTurn;
        }

		// If its the first bowl of a frame
		// return Action.Tidy
        if (bowl % 2 != 0)
        {   // Mid Frame (or last frame)
            bowl += 1;
            return Action.Tidy;
        }
        else if (bowl % 2 == 0){  // End of frame
            bowl +=1;
            return Action.EndTurn;
        }



		throw new UnityException ("Not sure what to return!");
	}

}
