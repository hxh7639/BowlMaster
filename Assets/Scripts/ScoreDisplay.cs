﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {


    public Text[] rollTexts, frameTexts;




	// Use this for initialization
	void Start () {
		rollTexts[0].text = "X";
		frameTexts[1].text = "0";

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FillRollCard(List<int>rolls){
		// your code here
    }

    public void FillFrames (List<int> frames){
    	for (int i=0; i< frames.Count;i++){
    		frameTexts[i].text = frames[i].ToString();
    	}

    }

    static string formatrolls (List<int> rolls){
    	string output ="";
    	// your code here
    	return output;

    }
}
