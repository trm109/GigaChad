using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    private bool isrunning;
    [SerializeField] Text timet;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 120f;
        isrunning = true;
    }
 
    void displayTime (float t)
    {
        timet.color = Color.white;
        float minutes = Mathf.FloorToInt(t / 60);
        float seconds = Mathf.FloorToInt(t % 60);
        timet.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (minutes < 1) { timet.color = Color.red; }
    }

    // Update is called once per frame
    void Update()
    {
        if (isrunning) {
            if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0f;
                isrunning = false; }

            displayTime(timeRemaining);
        }
    }
}
