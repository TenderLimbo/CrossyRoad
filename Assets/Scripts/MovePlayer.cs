using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using DG.Tweening;
using Debug = UnityEngine.Debug;


enum OnTimber
{
    LEFT,
    RIGHT
}

public class MovePlayer : MonoBehaviour
{
    public GameManager gameManager;
    public static MovePlayer player;
    public bool isLanded = false;
    public bool isDead = false;
    public bool onTimber = false;
    public bool isTreeInFront = false;
    public bool isTreeInBack = false;
    public bool isTreeInLeft = false;
    public bool isTreeInRight = false;
    private GameObject currentTimber;
    private OnTimber OnTimberEnum;

    void Start()
    {
        player = this;
        AudioManager.instance.Play("Car");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("Train") )
        {
            AudioManager.instance.Play("Bump");
            isDead = true;
            transform.DOScaleY(0.05f, 0.1f);
            transform.DOMoveY(0.5f, 0.1f);
        }
        else if (other.gameObject.CompareTag("Timber"))
        {
            onTimber = true;
            currentTimber = other.gameObject;
            if (transform.position.x > currentTimber.transform.position.x)
            {
                transform.position = currentTimber.transform.position + Vector3.up + Vector3.right;
                OnTimberEnum = OnTimber.RIGHT;
            }
            else
            {
                transform.position = currentTimber.transform.position + Vector3.up + Vector3.left;
                OnTimberEnum = OnTimber.LEFT;
            }
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            AudioManager.instance.Play("CoinCollect");
            PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins",0) + 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Timber"))
        {
            onTimber = false;
        }
    }
    

    void Update()
    {
        if (transform.position.x % 1 != 0 && !onTimber)
        {
            double delta = Math.Round(transform.position.x);
            transform.position = new Vector3((float) delta, transform.position.y, transform.position.z);
        }


        if (transform.position.y == 1)
            isLanded = true;
        else
        {
            isLanded = false;
        }


        if (!isDead)
        {
            if (onTimber)
            {
                if (OnTimberEnum == OnTimber.LEFT)
                {
                    transform.position = currentTimber.transform.position + Vector3.up + Vector3.left;
                }
                else
                {
                    transform.position = currentTimber.transform.position + Vector3.up + Vector3.right;
                }
                    
            }

            CheckWaterDeath();
            CheckTree();
            Move();
        }
        else
        {
            gameObject.SetActive(false);
            gameManager.EndGame();
        }
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isLanded && !isTreeInFront)
        {
            transform.DOJump(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1),
                0.5f, 1, 0.15f);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && isLanded && !isTreeInBack)
        {
            transform.DOJump(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1),
                0.5f, 1, 0.15f);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && isLanded && !isTreeInLeft)
        {
            if (onTimber && OnTimberEnum == OnTimber.RIGHT)
            {
                transform.position = currentTimber.transform.position + Vector3.up + Vector3.left;
                OnTimberEnum = OnTimber.LEFT;
            }
            else 
                transform.DOJump(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z),
                0.5f, 1, 0.15f);
             
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && isLanded && !isTreeInRight)
        {
            if (onTimber && OnTimberEnum == OnTimber.LEFT)
            {
                transform.position = currentTimber.transform.position + Vector3.up + Vector3.right;
                OnTimberEnum = OnTimber.RIGHT;
            }
            else 
                transform.DOJump(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z),
                0.5f, 1, 0.15f);
          
        }
    }



    private void CheckWaterDeath()
    {
        if (isLanded)
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.transform.CompareTag("Water"))
                {
                    isDead = true;
                    print("DEAD FROM WATER");
                    AudioManager.instance.Play("Splash"); 
                }
            }
        }
    }

    private void CheckTree()
    {
        if (Physics.Raycast(transform.position, Vector3.forward, 1f))
        {
            isTreeInFront = true;
        }
        else
        {
            isTreeInFront = false;
        }

        if (Physics.Raycast(transform.position, Vector3.back, 1f))
        {
            isTreeInBack = true;
        }
        else
        {
            isTreeInBack = false;
        }

        if (Physics.Raycast(transform.position, Vector3.left, 1f))
        {
            isTreeInLeft = true;
        }
        else
        {
            isTreeInLeft = false;
        }

        if (Physics.Raycast(transform.position, Vector3.right, 1f))
        {
            isTreeInRight = true;
        }
        else
        {
            isTreeInRight = false;
        }
    }
}