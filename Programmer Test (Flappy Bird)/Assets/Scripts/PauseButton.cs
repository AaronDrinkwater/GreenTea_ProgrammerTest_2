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
            Resume();
        }

        if (isPaused && !GameControl.instance.isGameOver)
        {
            PauseGame();
        }
    }

    public void Resume()
    {
        this.gameObject.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        playerRB.isKinematic = false;
    }

    private void PauseGame()

    {
        this.gameObject.SetActive(false);
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        playerRB.isKinematic = true;
        playerRB.velocity = Vector3.zero;
    }
}
