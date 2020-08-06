using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainSpawner : MonoBehaviour
{
    private GameObject train;
    private Vector3 v;
    private Quaternion q;

    void OnEnable()
    {
        v = Vector3.right * 22;
        q = Quaternion.Euler(0, -90, 0);
        Invoke("Spawn", Random.Range(7, 10));
    }
    
    void Spawn()
    {
        if (gameObject.activeSelf)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            AudioManager.instance.Play("TrainWhistle");
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        train = ObjectPooler.SharedInstance.GetPooledObject(9);
        train.transform.position = transform.position + v + Vector3.up * 0.5f;
        train.transform.rotation = q;
        train.SetActive(true);
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        Invoke("Spawn", Random.Range(7, 10));
    }
}