using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTurner : MonoBehaviour
{
    public Text soundButtonText;

    private void Start()
    {
        Turn();
    }

    public void Turn()
    {
        if (AudioManager.instance.isOn)
        {
            soundButtonText.text = "Sound On";
            AudioManager.instance.isOn = false;
        }
        else
        {
            soundButtonText.text = "Sound Off";
            AudioManager.instance.isOn = true;
        }
    }
}
