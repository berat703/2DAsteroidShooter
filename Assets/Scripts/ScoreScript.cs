using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreScript : MonoBehaviour {

    public static int scoreValue=0;
    private TextMeshProUGUI score;
    private TextContainer m_TextContainer;

    // Use this for initialization
    void Start () {
        score = GetComponent<TextMeshProUGUI>();
        m_TextContainer = GetComponent<TextContainer>();

    }

    // Update is called once per frame
    void Update () {
        score.text = "Score:" + scoreValue;
	}
}
