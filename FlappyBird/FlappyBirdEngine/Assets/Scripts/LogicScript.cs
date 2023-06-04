using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;

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
    private bool gameStarted = false;
    public GameObject player;
    public Text startText;

    public PipeSpawnerScript pipeSpawnerScript;

    void Start()
    {
        Time.timeScale = 0f; // Freeze the game time
        startText.text = "Press W to start"; // Display start message
        pipeSpawnerScript.SpawnPipe();
    }
    void Update()
    {
        if (!gameStarted && (Input.GetKeyDown(KeyCode.W)))
        {
            gameStarted = true;
            player.GetComponent<Rigidbody2D>().simulated = true; // Enable the player's Rigidbody2D to allow movement
            Time.timeScale = 1f; // Unfreeze the game time
            startText.gameObject.SetActive(false); // Hide the start message
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();            
        }
        pipeSpawnerScript.SpawnRate();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void GameOver()
    {
        bird.birdIsAlive = false;
        Time.timeScale = 0;
        bird.GameOverDeathSound();
        gameOverScreen.SetActive(true);
        //gameOverScoreText.text = playerScore.ToString();
    }
}