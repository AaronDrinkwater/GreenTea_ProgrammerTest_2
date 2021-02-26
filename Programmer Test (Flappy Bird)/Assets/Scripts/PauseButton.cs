using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public  Rigidbody playerRB;
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    public void GamePause()
    {
        isPaused = !isPaused;

        if (!isPaused)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1.0f;
            playerRB.isKinematic = false;
        }

        if (isPaused && !GameControl.instance.isGameOver)
        {
   
            isPaused = true;
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0.0f;
            playerRB.isKinematic = true;
            playerRB.velocity = Vector3.zero;
        }
    }
}
