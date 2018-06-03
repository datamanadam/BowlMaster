using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody rigidBody;
    // Use this for initialization
    private bool ballRolled;
    public Vector3 launchVelocity;
    private AudioSource audioSource;
    public bool inPlay = false;
    private Vector3 ballStartPos;
    private Rigidbody myRigidBody;


    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        ballStartPos = transform.position;
        myRigidBody = GetComponent<Rigidbody>();
        
	}
	
    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Reset()
    {
        
        inPlay = false;
        transform.position = ballStartPos;
        myRigidBody.velocity = Vector3.zero;
        myRigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;

    }


}
