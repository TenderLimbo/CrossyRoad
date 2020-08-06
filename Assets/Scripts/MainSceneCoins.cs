using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneCoins : MonoBehaviour
{
    public Text coins;
    void Start()
    {
        coins.text = PlayerPrefs.GetInt("Coins", 0) + " coins";
    }

}
