using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    public Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 12.0f;
    private int amnTilesOnScreen = 7;
	// Use this for initialization
	void Start () {
        SpawnTile();

        for(int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update () {
        if (playerTransform.position.z > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTile();
        }
	}

    private void SpawnTile(Vector3 vector)
    {
        for(int prefab = 0; prefab < tilePrefabs.Length; prefab++)
        {
            GameObject go;
            go = Instantiate(tilePrefabs[prefab]);
            go.transform.parent = GameObject.Find("TileManager").transform;
            go.transform.SetParent(transform);
            go.transform.position = Vector3.forward * spawnZ;
            spawnZ += tileLength;
        }
    }
}
