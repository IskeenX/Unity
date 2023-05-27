using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public BirdScript bird;
    public int playerScore;
    public Text scoreText; //Used UnityEngine.UI
    public GameObject gameOverScreen;
    public GameObject pauseScreen;

    public void addScore(int scoreToAdd) //We are going to use this method from other scripts we need to make it PUBLIC
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    void Update()
    {
        Pause();
    }
    
    //UI
    public void GameOver()
    {
        bird.birdIsAlive = false;
        Time.timeScale = 0;
        bird.GameOverDeathSound();
        gameOverScreen.SetActive(true);
    }
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1) //On pause
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
            else //Running
            {
                gameOverScreen.SetActive(false);
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Used UnityEngine.SceneManagement
        Time.timeScale = 1;
    }
    void Menu()
    {
        
    }
}