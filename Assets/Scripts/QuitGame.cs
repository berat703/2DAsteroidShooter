using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Application.Quit();
	}
	
    public void quit()
    {
        Debug.Log("quitted");
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
