using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {

    public float standingThreshold = 3f;
    public float distanceToRaise = 40f;
    private Rigidbody rigidbody;



	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void RaiseIfStanding()
    {
        if (isStanding())
        {
            rigidbody.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
        }
    
    }

    public void Lower()
    {
        rigidbody.useGravity = true;
        transform.Translate(new Vector3(0, -4, 0), Space.World);
        
    }




    public bool isStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270-rotationInEuler.x);
        float tiltInz = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingThreshold && tiltInz < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }

        
    }

}
