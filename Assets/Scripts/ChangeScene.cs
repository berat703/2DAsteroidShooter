using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	public void LoadScene (string levelToLoad) {
        Application.LoadLevel(levelToLoad);
        ScoreScript.scoreValue = 0;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
