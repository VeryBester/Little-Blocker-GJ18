using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    // Use this for initialization
    public GameObject bullet;
    public GameObject playerOne;
    public GameObject playerTwo;
    Rigidbody2D rb;
    public Object test;
    int start;


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        start = (int) Mathf.Round(Random.value);

        Vector3 player1 = playerOne.transform.position;
        if (start == 1)
            rb.velocity = GetDirectionToPlayer(playerOne);
        else
            rb.velocity = GetDirectionToPlayer(playerTwo);
            
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


}
