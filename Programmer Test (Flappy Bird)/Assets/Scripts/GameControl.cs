using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public Text currentScore;
    public Text gameOverScore;
    public GameObject gameoverText;

    public bool isGameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;
    public float time = 0.0f;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            time += Time.deltaTime;

            if (time >= 1.0f && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                time = 0;
            }
        }
    }

    public void Died()
    {
        gameoverText.SetActive(true);
        isGameOver = true;
    }

    public void ScoreUp()
    {
        if(isGameOver)
        {
            currentScore.enabled = false;
        }
        else 
        {
            score++;
            currentScore.text = "Score: " + score.ToString();
        }
    }

    public void EndScore()
    {
        if(isGameOver)
        {
            gameOverScore.text = "Your Score: " + score.ToString();
        }
    }
}
