using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    float speed = 0.5f;
    public Rigidbody body;



    // Use this for initialization
    void Start()
    {

        body = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {

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





    }
}
