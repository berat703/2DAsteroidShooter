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
            if(playerTransform.position.x > limitXRight-16f)
            {
                tileCountX++;

                SpawnTileForX(limitXRight,tileCountY,-1f*limitYDown,1f);
                limitXRight = limitXRight + tileSize;
                limitXLeft = limitXLeft - tileSize;

            }
            else if(playerTransform.position.x < -1f*limitXLeft+16f){
                tileCountX++;
                SpawnTileForX(-1f*limitXLeft, tileCountY,-1f*limitYDown,-1f);
                limitXLeft = limitXLeft + tileSize;
                limitXRight = limitXRight - tileSize;
            }
            if (playerTransform.position.y > limitYUp - 16f)
            {
                tileCountY++;
                SpawnTileForY(tileCountX,limitYUp,-1f*limitXLeft,1f);
                limitYUp = limitYUp + tileSize;
                limitYDown = limitYDown - tileSize;
            }
            else if (playerTransform.position.y < -1f*limitYDown + 16f)
            {
                tileCountY++;
                SpawnTileForY(tileCountX, -1f*limitYDown,-1f*limitXLeft,-1f);
                limitYDown = limitYDown + tileSize;
                limitYUp = limitYUp - tileSize;
            }
            playerTransform.hasChanged = false;
        }

	}

    private void SpawnTileForX(float x,int tileCountY,float startPosY,float rotation)
    {
        bool canDeleted = true;
        for(float i = startPosY; i <= tileCountY; i++)
        {
            Vector3 vector = new Vector3(x, i * tileSize, 0);
            if (!HasThePositionAnObject(vector, 0.1f))
            {
                for (int prefab = 0; prefab < tilePrefabs.Length; prefab++)
                {
                    GameObject go;
                    go = Instantiate(tilePrefabs[prefab]);
                    go.transform.parent = GameObject.Find("Tilemap").transform;
                    go.transform.SetParent(transform);
                    go.transform.localPosition = vector;
                    //lastTilePosX += tileSize;
                }
            }
        }
        if (canDeleted)
        {
            if (rotation > 0)
            {
                MustDeleteObjects(-1f*limitYDown, startPosY, tileCountY, "x");

            }
            else
            {
                MustDeleteObjects(limitYUp, startPosY, tileCountY, "x");

            }
            canDeleted = false;
        }
    }
    private void SpawnTileForY(int tileCountX, float y,float startPosX,float rotation)
    {
        bool canDeleted = true;
        for (float i = startPosX; i <= tileCountX; i++)
        {
            Vector3 vector = new Vector3( i * tileSize, y, 0);
            if (!HasThePositionAnObject(vector, 0.1f))
            {
                for (int prefab = 0; prefab < tilePrefabs.Length; prefab++)
                {
                    GameObject go;
                    go = Instantiate(tilePrefabs[prefab]);
                    go.transform.parent = GameObject.Find("Tilemap").transform;
                    go.transform.SetParent(transform);
                    go.transform.localPosition = vector;

                }
            }

        }
        if (canDeleted)
        {

                MustDeleteObjects(-1f*limitXLeft, limitYDown*-1f, tileCountX, "y");

            



            canDeleted = false;
        }

    }

    void MustDeleteObjects(float startPosX,float startPosY,float tileCount,string axis)
    {
        if (axis.Equals("x"))
        {
            for(float i = 0; i <= tileCount; i++)
            {
                Vector3 obj = new Vector3(startPosX, startPosY+tileSize*i, 0);
                Die(obj, 0.1f);
            }
           tileCountX--;
        }
        else
        {
            for (float i = 0; i <= tileCount; i++)
            {
                Vector3 obj = new Vector3(startPosX + tileSize * i, startPosY, 0);
                Die(obj, 0.1f);
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
            Debug.Log("Destroyed:"+hitColliders[i]);
        }

    }
}
