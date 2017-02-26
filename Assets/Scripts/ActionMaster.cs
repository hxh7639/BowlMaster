using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster{

	public enum Action {Tidy, Rest, EndTurn, EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl (int pins){

		if (pins < 0 || pins > 10) {throw new UnityException ("Not sure what to return!1");}

        bowls[bowl - 1] = pins;

        if (bowl == 21){
            return Action.EndGame;
        }

        //19
        if (bowl == 19 && Bowl21Awarded())
        {
            bowl += 1;
            return Action.Rest;
        }else if (bowl == 19 && !Bowl21Awarded())
        {
            bowl += 1;
            return Action.Tidy;
        }

        //20
        if (bowl == 20 && !Bowl21Awarded())
        {
            return Action.EndGame;
        }
        else if (bowl == 20 && Bowl21AwardedOn19())
        {
            bowl += 1;
            return Action.Tidy;
        }
        else if (bowl == 20){
            bowl += 1;
            return Action.Rest;
        }

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

    private bool Bowl21AwardedOn19(){
        // Remember that arrays start counting at 0
        return (bowls [19-1] >=10);
    }

    private bool Bowl21Awarded(){
        return (bowls [19-1] + bowls [20-1] >=10);
    }

}
