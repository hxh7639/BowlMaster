using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit (Collider collider){
        GameObject thingLeftBox = collider.gameObject;
        if (thingLeftBox.GetComponent<Pin>())
        {
            Destroy(thingLeftBox);
        } 
    }

}
