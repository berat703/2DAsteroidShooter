using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculateFPS : MonoBehaviour {

    public int Granularity = 5; // how many frames to wait until you re-calculate the FPS
    List<double> times;
    int counter = 5;
    float framerateThisFrame;
    private TextMeshProUGUI fpsText;
    private TextContainer m_TextContainer;
    public void Start()
    {
        framerateThisFrame = 1 / Time.deltaTime;
        Debug.Log(framerateThisFrame);
        times = new List<double>();
        fpsText = GetComponent<TextMeshProUGUI>();
        m_TextContainer = GetComponent<TextContainer>();
    }

    public void Update()
    {
        if (counter <= 0)
        {
            CalcFPS();
            counter = Granularity;
        }

        times.Add(Time.deltaTime);
        counter--;
    }

    public void CalcFPS()
    {
        double sum = 0;
        foreach (double F in times)
        {
            sum += F;
        }

        double average = sum / times.Count;
        double fps = 1 / average;
        fpsText.text = ((int)fps).ToString();
    }
}
