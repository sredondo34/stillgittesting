﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class Player_Movement : MonoBehaviour
{
    //float speed = 0.5f;
    //public Rigidbody body;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    public Interactable focus;

    // Use this for initialization
    void Start()
    {
       // body = GetComponent<Rigidbody>();
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //testing if i like this movement better and how to use it
        //Thinking about using this as the basis for the 3rd person isometric mode

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 1000, movementMask))
            {
                //move player to where we hit
                //Debug.Log("We Hit " + hit.collider.name + " " + hit.point);

                motor.MoveToPoint(hit.point);

                //stop focusing any objects
                RemoveFocus();
            }
        }

        // If we hit right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            //We create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //If the Ray hits
            if (Physics.Raycast(ray, out hit, 1000))
            {
                //Interact with objects
                //Debug.Log("We Interacted with " + hit.collider.name + " " + hit.point);
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                //If we did set it as our focus
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
            }
        }       
    }

    void SetFocus (Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
                
            focus = newFocus;
            motor.FollowTarget(newFocus);

        }

        newFocus.OnFocused(transform);       
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
            
        focus = null;
        motor.StopFollowingTarget();
    }
}
