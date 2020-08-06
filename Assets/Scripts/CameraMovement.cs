using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public MovePlayer playerMovement;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && playerMovement.isLanded &&
            !playerMovement.isDead && !playerMovement.isTreeInFront && 
            playerMovement.transform.position.z - transform.position.z > 1)
            transform.DOMoveZ(transform.position.z + 1f, 0.2f);
  
            // transform.DOMoveZ(transform.position.z + 0.01f, 0.5f);
      
    }
}
