﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour {
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    public bool Right;
    public bool Left;
    public bool Forward;
    public bool Back;



void Start()
    {
        dragDistance = Screen.height * 5 / 100; //dragDistance is 15% height of the screen
    }

    void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (lp.x - fp.x > 0 && lp.y - fp.y > 0)
                    {   //If the horizontal movement is greater than the vertical movement...
                        Forward = true;
                    }
                    if (lp.x - fp.x < 0 && lp.y - fp.y < 0)
                    {   //If the horizontal movement is greater than the vertical movement...
                        Back = true;
                    }
                    if (lp.x - fp.x < 0 && lp.y - fp.y > 0)
                    {   //If the horizontal movement is greater than the vertical movement...
                        Left = true;
                    }
                    if (lp.x - fp.x > 0 && lp.y - fp.y < 0)
                    {   //If the horizontal movement is greater than the vertical movement...
                        Right = true;
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Right = false;
                    Left = false;
                    Forward = false;
                    Back = false;
                }
            }
        }
    }
}