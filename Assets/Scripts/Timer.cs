using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [ReadOnly] public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;
    private void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
            timeRemaining += Time.deltaTime;
            DisplayTime(timeRemaining);
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        timeRemaining = 0;
        timeText.text = string.Format("{0:00}:{1:00}", 0, 0);
    }
}