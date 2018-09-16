using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Use this for initialization
    public GameObject bullet;
    public float speed;
    public float maxSpeed;
    float time;
    bool hitShield = false;
    GameObject playerOne;
    GameObject playerTwo;
    Rigidbody2D rb;

    int start;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        
        //Links the gameobject to the players
        playerOne = GameObject.FindGameObjectWithTag("playerOne");
        playerTwo = GameObject.FindGameObjectWithTag("playerTwo");


        //Randomly decides who to shoot at
        start = (int)Mathf.Round(Random.value);
        if (start == 1)
            rb.velocity = GetDirectionToPlayer(playerOne)*speed;
        else
            rb.velocity = GetDirectionToPlayer(playerTwo)*speed;
            
    }
	
	void Update () {

        
    }

    //returns the direction to the players
    public Vector3 GetDirectionToPlayer(GameObject player)
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 spawnerLocaiton = bullet.transform.position;
        Vector3 PositionVectorDiff = new Vector3(playerPosition.x - spawnerLocaiton.x, 
                playerPosition.y - spawnerLocaiton.y, playerPosition.z - spawnerLocaiton.z);
        print(playerPosition);
        Vector3 direction = GetUnitVector(PositionVectorDiff);
        return direction;
    }

    //finds the unit vector of the vector passed
    public Vector3 GetUnitVector(Vector3 vector)
    {
        float sum = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        Vector3 unitVector = new Vector3(vector.x / sum, vector.y / sum, vector.z / sum);
        return unitVector;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shield" && !hitShield)
        {
            time = Time.time + 0.2f;
            print("shield working");
            rb.velocity *= -5;
            hitShield = true;
            

        }

        if(collision.gameObject.tag == "wall")
        {
            rb.velocity *= 0.5f;
            hitShield = false;
            if (new Vector3(speed, speed, 0).magnitude > rb.velocity.magnitude)
            {
                rb.velocity = new Vector3(speed, speed, 0);
            }
        }
    }


}
