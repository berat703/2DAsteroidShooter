using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
    public GameObject[] tilePrefabs;
    public Transform playerTransform;
    private float limitXRight = 60f;
    private float limitXLeft = 0f;
    private float limitYUp = 60f;
    private float limitYDown = 0f;
    private float tileSize = 4f;
    private int tileCountX = 15;
    private int tileCountY = 15;
    //public Tilemap map;
	// Use this for initialization
	void Start () {
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
            if(limitXRight > playerTransform.position.x && playerTransform.position.x > limitXRight-16f)
            {
                tileCountX++;
                SpawnTileForX(limitXRight,tileCountY,limitYDown,1f);
                limitXRight = limitXRight + tileSize;
                limitXLeft = limitXLeft + tileSize;
            }
            else if(playerTransform.position.x < limitXLeft+16f && playerTransform.position.x>limitXLeft){
                tileCountX++;
                SpawnTileForX(limitXLeft, tileCountY,limitYDown,-1f);
                limitXLeft = limitXLeft - tileSize;
                limitXRight = limitXRight - tileSize;
            }
            if (playerTransform.position.y > limitYUp - 12f && limitYUp>playerTransform.position.y)
            {
                tileCountY++;
                SpawnTileForY(tileCountX,limitYUp,limitXLeft,1f);
                limitYUp = limitYUp + tileSize;
                limitYDown = limitYDown + tileSize;

            }
            else if (playerTransform.position.y < limitYDown + 12f && playerTransform.position.y>limitYDown)
            {
                tileCountY++;
                SpawnTileForY(tileCountX, limitYDown,limitXLeft,-1f);
                limitYDown = limitYDown - tileSize;
                limitYUp = limitYUp - tileSize;

            }
            playerTransform.hasChanged = false;
        }

	}

    private void SpawnTileForX(float x,int tileCountY,float startPosY,float rotation)
    {
        for(float i = startPosY; i <= startPosY+tileCountY * tileSize; i=tileSize+i)
        {
            Vector3 vector = new Vector3(x+tileSize*rotation, i, 0);
            if (!HasThePositionAnObject(vector, 0.1f))
            {
                for (int prefab = 0; prefab < tilePrefabs.Length; prefab++)
                {
                    GameObject go;
                    go = Instantiate(tilePrefabs[prefab]);
                    go.transform.parent = GameObject.Find("TileManager").transform;
                    go.transform.SetParent(transform);
                    go.transform.localPosition = vector;
                    //lastTilePosX += tileSize;
                }
        }
    }
        if (rotation > 0)
        {
            MustDeleteObjects(limitXLeft, startPosY, tileCountY, "x");

        }
        else
        {
            MustDeleteObjects(limitXRight, startPosY, tileCountY, "x");

        }

    }
    private void SpawnTileForY(int tileCountX, float y,float startPosX,float rotation)
    {
        for (float i = startPosX; i <= startPosX+tileCountX*tileSize; i=tileSize+i)
        {
            Vector3 vector = new Vector3( i , y+tileSize*rotation, 0);
            if (!HasThePositionAnObject(vector, 0.1f))
            {
                for (int prefab = 0; prefab < tilePrefabs.Length; prefab++)
                {
                    GameObject go;
                    go = Instantiate(tilePrefabs[prefab]);
                    go.transform.parent = GameObject.Find("TileManager").transform;
                    go.transform.SetParent(transform);
                    go.transform.localPosition = vector;

                }
            }

        }
        if (rotation > 0)
        {
            MustDeleteObjects(limitXLeft, limitYDown, tileCountX, "y");

        }
        else
        {
            MustDeleteObjects(limitXLeft, limitYUp, tileCountX, "y");

        }


    }

    void MustDeleteObjects(float startPosX,float startPosY,float tileCount,string axis)
    {
        if (axis.Equals("x"))
        {
            for(float i = 0; i <= tileCount; i++)
            {
                Vector3 obj = new Vector3(startPosX, startPosY+tileSize*i, 0);
                Die(obj, 1f);
            }
           tileCountX--;
        }
        else
        {
            for (float i = 0; i <= tileCount; i++)
            {
                Vector3 obj = new Vector3(startPosX + tileSize * i, startPosY, 0);
                Die(obj, 1f);
            }
            tileCountY--;
        }
    }

    void Die(Vector3 vector,float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(vector, radius);
        for(int i = 0; i < hitColliders.Length; i++)
        {
            Destroy(hitColliders[i].gameObject);
        }
        Collider[] hitCollidersForStone = Physics.OverlapSphere(vector, radius);


    }
}
