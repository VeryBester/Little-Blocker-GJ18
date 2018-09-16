using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;
    private float rotationSpeed = 120;
    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        /*
        var pos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - pos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
<<<<<<< HEAD
        */
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); 
=======
        */  
>>>>>>> 21a5aa4dc5804510379ba3273635bff41614f554

        
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.X)){
            rotationSpeed  = rotationSpeed * -1;
        };
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rb2d.AddForce(movement * speed);
        rb2d.velocity = movement * speed;
<<<<<<< HEAD
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
=======
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
>>>>>>> 21a5aa4dc5804510379ba3273635bff41614f554
    }
}
