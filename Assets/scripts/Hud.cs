using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

    [SerializeField]
    Text Timer;
    public static float seconds = 0.0f;
    public bool IsGameTimerRun = true;

    public void Update()
    {
        if (IsGameTimerRun)
        {
            seconds += Time.deltaTime;
            Timer.text = "Time : " + Mathf.Round(seconds);
            
        }  
    }  

    public void StopGameTimer()
    {
        IsGameTimerRun = false;
    }
}
