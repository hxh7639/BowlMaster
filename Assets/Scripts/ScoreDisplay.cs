using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {


    public Text[] rollTexts, frameTexts;




	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillRollCard(List<int>rolls){
		string scoresString = Formatrolls (rolls);
		for (int i=0; i< scoresString.Length;i++){
			rollTexts [i].text = scoresString [i].ToString();
		}
    }

    public void FillFrames (List<int> frames){
    	for (int i=0; i< frames.Count;i++){
    		frameTexts[i].text = frames[i].ToString();
    	}

    }

    public static string Formatrolls (List<int> rolls){
    	string output ="";

    	for (int i = 0; i < rolls.Count;i++){
    		int box = output.Length +1;							// score box (rolls) 1 to 21 

    		if(rolls[i]==0){									// always enter 0 as -
    			output += "-";
    		} else if ((box % 2==0 || box==21) && (rolls[i]+rolls[i-1])==10){ 	//spare check
    			output += "/";
    		} else if (rolls[i]==10) {							//strike check
    			if(box > 18){
    				output += "X";
    			}else {
					output += "X ";
				}    			
    		}else {
    		output += rolls[i].ToString();
    		}
    	}

    	return output;

    }
}
