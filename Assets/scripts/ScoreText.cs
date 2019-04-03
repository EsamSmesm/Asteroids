using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    public static int ScoreValue = 0;
    private Text Score;


    // Update is called once per frame
    void Update()
    {
        Score = GetComponent<Text>();
        Score.text = "Score : " + ScoreValue;
    }
}
