using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player {

    // Use this for initialization

    int health;

    public player()
    {
        health =3;
    }
	

    public void GotHit()
    {
        health--;
        /*if (health == 0){
            Debug.Log("hope this works");
        }*/

    }
    public int GetHealth()
    {
        return health;
    }
}
