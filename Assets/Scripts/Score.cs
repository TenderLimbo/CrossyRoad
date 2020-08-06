using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public MovePlayer player;
    public Text score;
    public Text coins;

    void Update()
    {
        if (player.transform.position.z > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", (int) player.transform.position.z);
        }

        PlayerPrefs.SetInt("YourScore", (int) player.transform.position.z);
        score.text = "Score " + PlayerPrefs.GetInt("YourScore");
        coins.text = PlayerPrefs.GetInt("Coins") + " coins";
    }
}