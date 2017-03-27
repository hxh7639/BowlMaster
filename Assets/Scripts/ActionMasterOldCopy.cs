using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMasterOldCopy{

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public static Action NextAction (List<int> pinFalls){
		ActionMasterOldCopy am = new ActionMasterOldCopy ();
		Action currentAction = new Action ();

		foreach (int pinFall in pinFalls) {
			currentAction = am.Bowl (pinFall);
		}
		return currentAction;
	}

	private Action Bowl (int pins){

		if (pins < 0 || pins > 10) {throw new UnityException ("Not sure what to return!1");}

        bowls[bowl - 1] = pins;

        if (bowl == 21){
            return Action.EndGame;
        }

        //@ frame 19
		if (bowl == 19){
			if (Bowl21Awarded()){
				bowl += 1;
            	return Action.Reset;
			} else if(!Bowl21Awarded()){
				bowl += 1;
            	return Action.Tidy;
			}
		}

        //@ frame 20

		if (bowl == 20){
			if (!Bowl21Awarded()){  //if no strike/spare
				return Action.EndGame;
			} else if(Bowl21AwardedOn19() && pins!=10){  // if no strike on frame 19
				bowl += 1;
            	return Action.Tidy;
			}else {   // else you got a spare on 20
				bowl += 1;
            	return Action.Reset;
			}
		}

        // strike and spare
        if (pins ==10){
			if (bowl % 2 != 0){ //Strike
				bowl += 2;
            	return Action.EndTurn;
			} else if (bowl % 2 == 0){ //Spare
				bowl += 1;
            	return Action.EndTurn;
			}

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

    private bool Bowl21AwardedOn19(){
        // Remember that arrays start counting at 0
        return (bowls [19-1] >=10);
    }

    private bool Bowl21Awarded(){
        return (bowls [19-1] + bowls [20-1] >=10);
    }

}
