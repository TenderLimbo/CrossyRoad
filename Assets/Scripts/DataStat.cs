using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataStat : MonoBehaviour
{
    public Text highScore;
    public Text coins;
    public Text yourScore;
    private void Start()
    {
        highScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore", 0);
        coins.text = "Coins : " + PlayerPrefs.GetInt("Coins", 0);
        yourScore.text = "Your Score : " + PlayerPrefs.GetInt("YourScore", 0);
    }
    
}
