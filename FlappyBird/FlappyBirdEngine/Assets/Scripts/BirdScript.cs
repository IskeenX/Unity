using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D birdRigidbody2D;
    private const float jumpAmount = 100f;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private float minPositionY = -47f;
    private float maxPositionY = 45f;
    public int countdownTime;
    public Text countdownDisplay;

    //Sound fields
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] public AudioClip deathSoundEffect;
    public float volume;
    new AudioSource audio;
    public bool alreadyPlayed = false;

    void Start()
    {
        birdRigidbody2D = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && birdIsAlive)
        {
            Jump();
        }
        BorderLimits();
    }
    private void Jump()
    {
        jumpSoundEffect.Play();
        birdRigidbody2D.velocity = Vector2.up * jumpAmount;
    }

    //Game Over
    private void BorderLimits()
    {
        if (transform.position.y < minPositionY || transform.position.y > maxPositionY)
        {
            logic.GameOver();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
    }
    public void GameOverDeathSound()
    {
        if(!alreadyPlayed)
        {
            audio.PlayOneShot(deathSoundEffect, volume);
            alreadyPlayed = true;
        }
    }
}