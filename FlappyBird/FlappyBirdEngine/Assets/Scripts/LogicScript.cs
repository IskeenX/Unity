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
    public Text gameOverScoreText;
    public GameObject gameOverScreen;
    public GameObject pauseScreen;
    private float DifficultyMultiplier = 0.15f;
    int counter = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();            
        }
    }

    public void AddScore(int scoreToAdd) //Score counter and difficulty changer
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        //Difficulty
        counter++;
        if (counter == 10)
        {
            Time.timeScale += DifficultyMultiplier;
            counter = 0;
        }
    }

    //UI
    private void Pause()
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
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Used UnityEngine.SceneManagement
        Time.timeScale = 1;
    }
    public void Menu()
    {
        
    }
    public void GameOver()
    {
        bird.birdIsAlive = false;
        Time.timeScale = 0;
        bird.GameOverDeathSound();
        gameOverScreen.SetActive(true);
        gameOverScoreText.text = playerScore.ToString();
    }
}