using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
    void OnEnable()
    {
        if (transform.position.z > 1)
        {
            for (int i = 0; i < Random.Range(3, 8); i++)
            {
                GameObject tree = ObjectPooler.SharedInstance.GetPooledObject(0);
                tree.transform.position =
                    new Vector3(Random.Range(-10, 10) + 0.2f, transform.position.y + 0.5f, transform.position.z);
                tree.SetActive(true);
            }
        }
    }
}
