using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour {

    public GameObject stonePrefab;
    public GameObject shipPrefab;
    public GameObject tilePrefab;
    
	// Use this for initialization
	void Start () {
        Quaternion rot = Quaternion.Euler(0, 0, 0);
		for(int i = 0; i < 16; i++)
        {
            for(int j = 0; j < 16; j++)
            {
                Vector3 vect = new Vector3(j*4,i*4,0);
                GameObject go = Instantiate(tilePrefab, vect, rot) as GameObject;
                go.name = string.Format("Tile_{0}_{1}", i,j);
                go.transform.parent = GameObject.Find("Tilemap").transform;
                go.transform.localPosition = vect;

                //Vector3 stoneVect = new Vector3(startX + j * 4, startY + i * 4, startZ);
                GameObject stoneGo = Instantiate(stonePrefab, vect, rot);
                stoneGo.name = string.Format("Stone_{0}_{1}", i, j);
                stoneGo.transform.parent = GameObject.Find("Tilemap").transform;
                stoneGo.transform.localPosition = vect;
            }
        }
        Vector3 shipVector = new Vector3(30, 30, 0);
        GameObject ship = Instantiate(shipPrefab, shipVector, transform.rotation);
        ship.transform.parent = GameObject.Find("Tilemap").transform;
        ship.transform.localRotation = rot;
        ship.transform.localPosition = shipVector;

        CameraFollow script = (CameraFollow)Camera.main.GetComponent("CameraFollow");
        script.myTarget = ship.transform;

        GameObject tilemap = GameObject.Find("TileManager");
        TileManager tileManager = tilemap.GetComponent<TileManager>();
        tileManager.playerTransform = ship.transform;
	}

    void Update () {
		
	}
}
