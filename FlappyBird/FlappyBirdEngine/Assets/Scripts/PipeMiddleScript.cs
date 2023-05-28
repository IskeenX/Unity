using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    [SerializeField] private AudioSource scoreSoundEffect;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); //It puts LogicScript automatically into reference slot
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3) //Checks if Bird object collided. 3 is the number of layer called Bird
        {
            scoreSoundEffect.Play();
            logic.AddScore(1); //Increases score by 1
        }
    }
}