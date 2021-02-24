using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public Text currentScore;
    public GameObject gameoverText;
    public bool isGameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;

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
        if(isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            return;
        }
        else 
        {
            score++;
            currentScore.text = "Score: " + score.ToString();
        }
    }
}
