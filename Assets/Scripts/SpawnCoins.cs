using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCoins : MonoBehaviour
{
    private GameObject coin;
    
    void OnEnable()
    {
        if (transform.position.z > 1)
        {
            for (int i = 0; i < Random.Range(0, 2); i++)
            {
                coin = ObjectPooler.SharedInstance.GetPooledObject(1);
                coin.transform.position =
                    new Vector3(Random.Range(-10, 10), transform.position.y + 0.5f, transform.position.z);
                coin.SetActive(true);
            }
        }
    }

   
}
