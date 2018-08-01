using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform myTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (myTarget != null)
        {
            Vector3 targPos = myTarget.position;
            targPos.z = transform.position.z;

            transform.position = targPos;
        }
	}
}
