using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject bullets;
    private float spawnTime = 0f;
    public float spawnRate;
    public Transform spawnerLocation;

    

	void Start () {

	}
	
	void Update () {

        if (Time.time > spawnTime)
        {
            Instantiate(bullets, spawnerLocation.position, spawnerLocation.rotation);
            spawnTime = Time.time + spawnRate;
        }

	}


    
}
