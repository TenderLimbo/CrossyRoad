using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnTimbers : MonoBehaviour
{
    private GameObject go;
    private int turn;
    private Vector3 v;
    private Quaternion q;


    void Start()
    {
        turn = Random.Range(0, 2);
        if (turn == 0)
        {
            v = Vector3.left * 17;
            q = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            v = Vector3.right * 17;
            q = Quaternion.Euler(0, -90, 0);
        }

        Invoke("Spawn", Random.Range(0, 2));
    }

    void Spawn()
    {
        go = ObjectPooler.SharedInstance.GetPooledObject(4);
        go.transform.position = transform.position + v;
        go.transform.rotation = q;
        go.SetActive(true);
        Invoke("Spawn", Random.Range(2, 5));
    }
}