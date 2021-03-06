﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10.0f;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;
    public float rotationSpeed = 3;
    player player = new player();
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

        */
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime); 

        
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Comma)){
            transform.Rotate(0, 0, -rotationSpeed);
        };
        if (Input.GetKey(KeyCode.Period))
        {
            transform.Rotate(0, 0, rotationSpeed);
        };
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontalarrows");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Verticalarrows");
        
        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        //rb2d.AddForce(movement * speed);
        rb2d.velocity = movement * speed;
        rb2d.angularVelocity = 0;
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {

            player.GotHit();
            if (player.GetHealth() == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("p2win");
            }
        }
        
    }
}
