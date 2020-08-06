using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfLeftBehind : MonoBehaviour
{
    void Update()
    {
        if (MovePlayer.player.transform.position.z - transform.position.z > 3)
        {
            gameObject.SetActive(false);
        }

    }
}
