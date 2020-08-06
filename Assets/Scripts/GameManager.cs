using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool hasEnded = false;
    public void EndGame()
    {
        if (!hasEnded)
        {
            hasEnded = true;
            DOTween.Clear(true);
            Invoke("Quit",2);
        }
       
    }

    private void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
