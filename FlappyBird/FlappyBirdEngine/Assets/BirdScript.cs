using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    private float minPositionY = -20;
    private float maxPositionY = 20;

    //Sound fields
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] public AudioClip deathSoundEffect;
    public float volume;
    new AudioSource audio;
    public bool alreadyPlayed = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Time.timeScale = 1;
    }

    void Update()
    {
        Jumping();
        BorderLimits();
    }

    void Jumping()
    {
        if (Input.GetKey(KeyCode.Space) && birdIsAlive)
        {
            jumpSoundEffect.Play();
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    //Game Over
    void BorderLimits()
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