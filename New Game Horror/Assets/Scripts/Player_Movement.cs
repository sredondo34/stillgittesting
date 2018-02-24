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
        //Im thinking ill use this kind of movement for the first person mode although ill 
        //Need to expand on it to make the player look where he wants to go, like basic turning

        /*  
         *  
         *
         if (Input.GetKey(KeyCode.W)) //Makes the player go forwards
         {

             body.AddForce(transform.forward * speed, ForceMode.Impulse);


         }

         if (Input.GetKey(KeyCode.D)) //Makes the player go right
         {

             body.AddForce(transform.right * speed, ForceMode.Impulse);

         }

         if (Input.GetKey(KeyCode.A)) //Makes the player go left
         {

             body.AddForce(-transform.right * speed, ForceMode.Impulse);

         }

         if (Input.GetKey(KeyCode.S)) //Makes the player go backwards
         {

             body.AddForce(-transform.forward * speed, ForceMode.Impulse);

         }

         */


         //testing if i like this movement better and how to use it
         //Thinking about using this as the basis for the 3rd person isometric mode

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                //move player to where we hit
                Debug.Log("We Hit " + hit.collider.name + " " + hit.point);
                motor.MoveToPoint(hit.point);


            }

        }



    }
}