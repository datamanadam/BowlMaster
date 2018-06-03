using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]

public class DragLaunch : MonoBehaviour {

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private Ball ball;
	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
    public void MoveStart (float amount)
    {
        if(!ball.inPlay)
        {
            ball.transform.Translate(new Vector3(amount, 0, 0));
        }
        
    }


    public void DragStart()
    {
        //Capture time and position of drag start
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {
        //Launch ball
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;

        float launchspeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchspeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchspeedX,0,launchspeedZ);

        ball.Launch(launchVelocity);
    }
}
