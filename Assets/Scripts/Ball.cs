using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector3 launchVelocity;
	public bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
    private Vector3 ballStartPos;


	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();
		rigidBody.useGravity = false;
        ballStartPos = transform.position;
	}

	public void Launch (Vector3 velocity)
	{
		inPlay = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;
		audioSource.Play ();
	}

    public void Reset(){
        inPlay = false;
        gameObject.transform.position = ballStartPos;
        rigidBody.useGravity = false;
        rigidBody.velocity = Vector3.zero; // I used "new Vector3 (0,0,0);" instead
        rigidBody.angularVelocity = Vector3.zero;
		gameObject.transform.rotation = Quaternion.identity;
}


	// Update is called once per frame
	void Update () {
		
	}
}
