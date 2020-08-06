using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TrainMover : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        transform.DOMoveX(transform.position.x - 50, 2f);
    }
    
    
}
