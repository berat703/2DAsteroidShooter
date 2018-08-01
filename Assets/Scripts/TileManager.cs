using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    public Transform playerTransform;
    private float limitXRight = 60.0f;
    private float limitXLeft = 0f;
    private float limitYUp = 64f;
    private float limitYDown = 0f;
    private float lastY = 30.0f;
    private float tileLength = 4.0f;
    private int amnTilesOnScreen = 7;
    private float tileSize = 4f;
    private int tileCountX = 15;
    private int tileCountY = 15;
    private float lastTilePosX;
    private float lastTilePosY;
	// Use this for initialization
	void Start () {
    lastTilePosX = tileSize* tileCountX;
    lastTilePosY = 64f;
}
    bool HasThePositionAnObject(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        if (hitColliders.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update () {
        if (playerTransform.hasChanged)
        {
            if(playerTransform.position.x > limitXRight-16f)
            {
                tileCountX++;
                SpawnTileForX(limitXRight,tileCountY,1f,limitYDown);
                limitXRight = limitXRight + tileSize;
            }
            else if(playerTransform.position.x<limitXLeft+16f){
                tileCountX++;
                SpawnTileForX(limitXLeft, tileCountY,-1f,limitYDown);
                limitXLeft = limitXLeft + tileSize;
            }
            if (playerTransform.position.y > limitYUp - 16f)
            {
                tileCountY++;
                SpawnTileForY(tileCountX,limitYUp,1f,limitXLeft);
                limitYUp = limitYUp + tileSize;
            }
            else if (playerTransform.position.y < limitYDown + 16f)
            {
                tileCountY++;
                SpawnTileForY(tileCountX, limitYDown, - 1f,limitXLeft);
                limitYDown = limitYDown + tileSize;
            }
            playerTransform.hasChanged = false;
        }

	}

    private void SpawnTileForX(float x,int tileCountY,float route,float startPosY)
    {
        for(float i = startPosY; i < tileCountY*tileSize; i++)
        {
            Vector3 vector = new Vector3(x*route, i * tileSize, 0);
            if (!HasThePositionAnObject(vector, 0.1f))
            {
                for (int prefab = 0; prefab < tilePrefabs.Length; prefab++)
                {
                    GameObject go;
                    go = Instantiate(tilePrefabs[prefab]);
                    go.transform.parent = GameObject.Find("TileManager").transform;
                    go.transform.SetParent(transform);
                    go.transform.localPosition = vector;
                    lastTilePosX += tileSize;

                    Vector3 deletedObject = new Vector3(vector.x * -1f ,vector.y,0);
                    DeleteObject(deletedObject, 0.1f);
                }
            }
        }
    }
    private void SpawnTileForY(int tileCountX, float y,  float route,float startPosX)
    {
        for (float i = startPosX; i < tileCountX*tileSize; i++)
        {
            Vector3 vector = new Vector3( i * tileSize, y * route, 0);
            if (!HasThePositionAnObject(vector, 0.1f))
            {
                for (int prefab = 0; prefab < tilePrefabs.Length; prefab++)
                {
                    GameObject go;
                    go = Instantiate(tilePrefabs[prefab]);
                    go.transform.parent = GameObject.Find("TileManager").transform;
                    go.transform.SetParent(transform);
                    go.transform.localPosition = vector;
                    lastTilePosX += tileSize;

                    Vector3 deletedObject = new Vector3(vector.x, vector.y * -1f, 0);
                    DeleteObject(deletedObject, 0.1f);
                }
            }
        }
    }

    void DeleteObject(Vector3 vector,float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(vector, radius);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            Destroy(hitColliders[i]);
            Debug.Log("Destroyed");
        }

    }
}
