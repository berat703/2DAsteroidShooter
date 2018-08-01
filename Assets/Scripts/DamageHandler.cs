using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour {
    public int health = 1;
    public float invulnPeriod = 0;
    float invulnTimer = 0;
    int correctLayer;
    int deadAsteroid = 0;
    GameObject obj;
    void Start()
    {
        correctLayer = gameObject.layer;
        Transform[] trs =  GameObject.Find("Restart").GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == "RestartPanel")
            {
                 obj = t.gameObject;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        health--;
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
    }

    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (gameObject.name == "bullet(Clone)")
        {
            ScoreScript.scoreValue += 1;
        }
        if (gameObject.name == "player(Clone)")
        {
            obj.SetActive(true);
        }
        Destroy(gameObject);
    }



}
