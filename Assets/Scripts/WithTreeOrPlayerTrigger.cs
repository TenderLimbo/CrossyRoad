using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WithTreeOrPlayerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree") || other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
