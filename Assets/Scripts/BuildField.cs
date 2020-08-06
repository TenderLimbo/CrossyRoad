using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BuildField : MonoBehaviour
{
    public MovePlayer player;
    private Vector3 pos = new Vector3(0, 0, -3);
    private int visibleChunks = 20;
    private GameObject chunk;
    
    void Start()
    {
        for (int i = 0; i < visibleChunks; i++)
        {
            if (i == 4)
            {
                chunk = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(5, 7));
            }
            else
            {
                chunk = ObjectPooler.SharedInstance.GetPooledObject(Random.Range(5, 8));
            }
            chunk.transform.position = pos;
            chunk.transform.rotation = Quaternion.Euler(0, 90, 0);
            pos.z++;
            chunk.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && player.isLanded && !player.isDead && !player.isTreeInFront)
        {
            int SpawnChance = Random.Range(0, 16);
            if (SpawnChance == 15)
            {
                chunk= ObjectPooler.SharedInstance.GetPooledObject(8);
            }
            else if (SpawnChance < 5)
            {
                chunk= ObjectPooler.SharedInstance.GetPooledObject(7);
            }
            else
            {
                chunk= ObjectPooler.SharedInstance.GetPooledObject(Random.Range(5, 7));
            }
           
            chunk.transform.position = pos;
            chunk.transform.rotation = Quaternion.Euler(0, 90, 0);
            pos.z++;
            chunk.SetActive(true);
        }
    }
}