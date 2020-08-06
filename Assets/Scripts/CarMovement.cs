using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public int key;
    private float delta1 = 0.3f;
    private float delta2 = 0.2f;
    
    void Update()
    {
        if (key == 0)
        {
            if (transform.rotation == Quaternion.Euler(0, 90, 0))
            {
                transform.DOMoveX(transform.position.x + delta1, 0.2f);
            }
            else
            {
                transform.DOMoveX(transform.position.x - delta1, 0.2f);
            }
        }
        else if (key == 2)
        {
            if (transform.rotation == Quaternion.Euler(0, 90, 0))
            {
                transform.DOMoveX(transform.position.x + delta2, 0.2f);
            }
            else
            {
                transform.DOMoveX(transform.position.x - delta2, 0.2f);
            }
        }
    }
}