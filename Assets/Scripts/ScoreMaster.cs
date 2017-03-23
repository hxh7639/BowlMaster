using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {

    // Returns a list of cumulative scores, like a normal score card.
    public static List<int> ScoreCumulative (List<int> rolls){
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls)){
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    // Return a list of individual frame scores, NOT cumulative.
	public static List<int> ScoreFrames (List<int> rolls){
        List<int> frame = new List<int>();
		List<int> fixedRolls = new List<int>();

//        for (int i = 1; i < rolls.Count; i += 2)  // Qui#2 working
//        {
//            if (frame.Count < 10) // test if last frame
//            {
//				if ((rolls[i - 1] + rolls[i]) < 10) //test if open frame (if no strike/spare)
//                { 
//                    frame.Add(rolls[i - 1] + rolls[i]);
//                }
//                else // strike or spare
//                {
//                    if (i + 1 < rolls.Count)  //tests if next roll exist 
//                    {
//                        frame.Add(rolls[i - 1] + rolls[i] + rolls[i + 1]);
//                        if (rolls[i - 1] == 10) // test if strike
//                        {
//                            i--; // strike should only advance i by 1 roll
//                        }
//                    }
//                }
//            }
//        }
//        return frame;
//    }

		for (int i = 0; i < (fixedRolls.Count); i++) // andy quick bakc up
	{
        {
        	for (int x=0; (x<rolls.Count);x++){  //tested and its working
        		if(rolls[x]==10){
				fixedRolls.Add(0);
        		}
				fixedRolls.Add(rolls[x]);
        	}
        }

			if(i > 0 && fixedRolls.Count % 2 ==0){
				if(i>0 && (fixedRolls[i-1] + fixedRolls [i]) <10) //if no spare
				{
					frame.Add (fixedRolls [i - 1] + fixedRolls [i]);
				}
			}else if (i > 1 && rolls [i - 2] == 10 ) {// handle pervious strike
				frame.Add (rolls [i - 2] + rolls [i - 1] + rolls [i]);
				frame.Add (rolls [i - 1] + rolls [i]);
			}else if(i > 1 && (rolls [i - 2] + rolls [i-1]) >= 10){ //handle pervious spare
				frame.Add (rolls [i - 2] + rolls [i - 1]+ rolls [i]);
			}
        }
        return frame;
 	}


//		for (int i = 0; i < (fiexedRolls.Count); i++) // andy quick bakc up
//
//        {
//			fiexedRolls.Add(rolls[i]);  //new list that add rolls as we go
//
//			int divider = fiexedRolls.Count; // count rolls in new list
//
//           	if(rolls[i]>=10){
//				fiexedRolls.Insert(i,0); // add extra 0 roll if we get a strike???
//			}
//
//			if(i > 0 && divider % 2 ==0){
//				if(i>0 && (rolls[i-1] + rolls [i]) <10) //if no spare
//				{
//				frame.Add (rolls [i - 1] + rolls [i]);
//				}
//			}else if (i > 1 && rolls [i - 2] == 10 ) {// handle pervious strike
//				frame.Add (rolls [i - 2] + rolls [i - 1] + rolls [i]);
//				frame.Add (rolls [i - 1] + rolls [i]);
//			}else if(i > 1 && (rolls [i - 2] + rolls [i-1]) >= 10){ //handle pervious spare
//				frame.Add (rolls [i - 2] + rolls [i - 1]+ rolls [i]);
//			}
//        }
//        return frame;
//  }
//

//        for (int i = 0; i < rolls.Count; i += 2)  // Class
//        {
//            if (rolls[i - 1] == 10 )
//            {
//                break;
//            }else if ((rolls[i-1] + rolls [i]) == 10){
//                break;
//            }else if ((rolls[i-1] + rolls [i]) == 10){
//                frame.Add (rolls[i-1] + rolls [i] + rolls [i+1]);
//            }else
//
//                frame.Add (rolls[i-1] + rolls [i]);
//        }
//        return frame;
//
//    }




  /*      for(int i = 0; i < rolls.Count; i++) { // Qui's for loop, currently at test 21
            if(i+1<rolls.Count) { //tests if the next roll exists in order to score the frame
                if(rolls[i]!=10&&(rolls[i]+rolls[i+1])!=10){ //tests if a frame is not a strike or a spare
                    frame.Add(rolls[i]+rolls[i+1]);
                    i++;
                } 
                else {
                    if(i+2<rolls.Count) { //tests if the first roll of the next frame exists in order to score the strike or spare
                        frame.Add(rolls[i]+rolls[i+1]+rolls[i+2]);
                        if ((rolls[i]+rolls[i+1])==10){
                            i++;
                        }

                    }
                }
             }
        }
        return frame;
    }
    */



}
