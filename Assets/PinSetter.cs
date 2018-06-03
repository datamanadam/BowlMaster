using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public GameObject pinSet;


    private Ball ball;
    private float lastChangeTime;
    private bool ballEnteredBox = false;

    // Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}

    // Update is called once per frame
    void Update () {
        standingDisplay.text = CountStanding().ToString();
        //if ball has entered 
        if (ballEnteredBox)
        {
            checkStanding();
        }
	}


    public void RaisePins()
    {
        // raise standing pins only by distanceToRaise
        Debug.Log("Raising pins");
        foreach (Pins pins in GameObject.FindObjectsOfType<Pins>())
        {
            pins.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        foreach (Pins pins in GameObject.FindObjectsOfType<Pins>())
        {
            pins.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renewing pins");
        Instantiate(pinSet, new Vector3(0f, 20f, 1829f),Quaternion.identity);
    }








    void checkStanding()
    {
        //Update the LastStandingCount
        //Call PinsHaveSettleted() when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3.0f;
        if ((Time.time - lastChangeTime)> settleTime){

            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        ball.Reset();
        lastStandingCount = -1;
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }



    int CountStanding()
    {
        int standing = 0;

        foreach (Pins pins in GameObject.FindObjectsOfType<Pins>())
        {
            if (pins.isStanding())
            {
                standing++;
            }
        }


        return standing;

    }



    private void OnTriggerExit(Collider collider)
    {
       
        GameObject thingLeft = collider.gameObject;
        if (thingLeft.GetComponent<Pins>())
        {

           Destroy(thingLeft);
        }
    }


    void OnTriggerEnter(Collider collider)
    {
        GameObject thingHit = collider.gameObject;

        if (thingHit.GetComponent<Ball>())
        {
            standingDisplay.color = Color.red;
            ballEnteredBox = true;
            
        }

    }


}
