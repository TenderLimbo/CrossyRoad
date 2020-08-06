using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    private int turn;
    private Vector3 v;
    private Quaternion q;
    private GameObject go;

    void Start()
    {
        turn = Random.Range(0, 2);
        if (turn == 0)
        {
            v = Vector3.left * 15;
            q = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            v = Vector3.right * 15;
            q = Quaternion.Euler(0, -90, 0);
        }
        Invoke("Spawn", Random.Range(0,2));
    }

    void Spawn()
    {
        go = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(2, 4));
        go.transform.position = transform.position + v + Vector3.up * 0.5f;
        go.transform.rotation = q;
        go.SetActive(true);
        Invoke("Spawn", Random.Range(2,5));
    }
}