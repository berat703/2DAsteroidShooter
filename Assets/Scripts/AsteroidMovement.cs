using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour {
    float maxSpeed = 0.5f;
    float shipBoundaryRadius = 0.5f;
    float timer = 3f;
    float changeRandomDuration = 3f;
    float horizontalRand;
    float verticalRand;

     void Start()
    {
        horizontalRand = Random.Range(-1f,1f);
        verticalRand = Random.Range(-1f,1f);
    }


    void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            horizontalRand = Random.Range(-1f, 1f);
            verticalRand = Random.Range(-1f, 1f);
            timer = changeRandomDuration;
        }



        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, verticalRand * maxSpeed * Time.deltaTime,0);
        pos +=  velocity;

        transform.position = pos;
    }
}
