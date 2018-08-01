using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletPrefab;

    public float fireDelay = 0.5f;
    float cooldownTimer = 0;
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;
            Instantiate(bulletPrefab,transform.position,transform.rotation);
        }   
	}
}
